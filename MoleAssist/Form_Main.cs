using Config;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace MoleAssist
{
    public partial class Form_Main : Form
    {
        private static FightManager GlobalFight = new FightManager(ConfigManager.LuaScript);
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            combo_skillMode.SelectedIndex = 0;
            combo_identifyFailed.SelectedIndex = 0;
            List<Config.Functions> enabledFunctions = (List<Config.Functions>) ConfigManager.Get(Config.Item.Functions);
            foreach (Config.Functions func in enabledFunctions)
            {
                switch (func)
                {
                    case Functions.AutoFight:
                        //TODO: 显示刷怪区
                        break;
                    case Functions.Notice:
                        //TODO: 显示公告区
                        break;
                    default:
                        break;
                }
            }
        }

        private void radio_modeSelect2_CheckedChanged(object sender, EventArgs e)
        {
            combo_NPCSelect.Visible = radio_modeSelect2.Checked;
        }

        private void radio_modeSelect3_CheckedChanged(object sender, EventArgs e)
        {
            btn_getxy.Visible = radio_modeSelect3.Checked; 
            textBox_customX.Visible = radio_modeSelect3.Checked;
            textBox_customY.Visible = radio_modeSelect3.Checked;
        }

        private void combo_skillMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //单技能模式也要用户输入：使用第几个技能
            textbox_SkillOrder.Enabled = true;
        }

        private void checkBox_qucikTraining_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("请将带练精灵放到第二位");
        }

        private void btn_refreshGame_Click(object sender, EventArgs e)
        {
            if (GlobalFight.IsFighting)
            {
                MessageBox.Show("请先停止刷怪！");
                return;
            }
            webBrowser_game.Refresh();
        }

        private void btn_clearCache_Click(object sender, EventArgs e)
        {
            RunCmd("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8");
        }


        private void checkBox_onTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = this.checkBox_onTop.Checked;
        }

        private bool changing = false; 
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (changing)
            {
                return ;
            }
            changing = true;
            try
            {
                if (!GlobalFight.IsFighting)
                    {
                    //此时GlobalFight.IsFighting为假，需要开始
                    //设定参数
                    var type = (radio_modeSelect1.Checked ? FightType.Wild :
                        (radio_modeSelect2.Checked ? FightType.NPC :
                            FightType.CustomPoint)
                            );
                    Common.UpdateFlashHandle(webBrowser_game.Handle);
                    GlobalFight.FightOptions.handle = Common.hGame;
                    GlobalFight.FightOptions.interval = Common.settings.FightInterval;
                    GlobalFight.FightOptions.type = Enum.GetName(typeof(FightType), type);
                    GlobalFight.FightOptions.skillMode = combo_skillMode.SelectedIndex;
                    GlobalFight.FightOptions.skillOrder = textbox_SkillOrder.Text;
                    GlobalFight.FightOptions.identifyFailed = combo_identifyFailed.SelectedIndex;
                    GlobalFight.FightOptions.ReHP = checkBox_ReHP.Checked;
                    GlobalFight.FightOptions.useAnger = checkBox_useAnger.Checked;
                    GlobalFight.FightOptions.qucikTraining = checkBox_qucikTraining.Checked;
                    GlobalFight.FightOptions.couldHiddenMode = checkBox_couldHiddenMode.Checked;
                    switch (type)
                    {
                        case FightType.Wild:
                            break;
                        case FightType.NPC:
                            if (combo_NPCSelect.SelectedIndex == 0)
                            {
                                throw new InputInvailedException("没有选择NPC或忍者！");
                            }
                            GlobalFight.FightOptions.NPC = combo_NPCSelect.SelectedIndex;
                            break;
                        case FightType.CustomPoint:
                            if (string.IsNullOrEmpty(textBox_customX.Text) || string.IsNullOrEmpty(textBox_customY.Text))
                            {
                                throw new InputInvailedException("没有获取坐标！");
                            }
                            GlobalFight.FightOptions.customPoint = new Point
                            {
                                X = int.Parse(textBox_customX.Text),
                                Y = int.Parse(textBox_customY.Text)
                            };
                            break;
                        default:
                            throw new InputInvailedException("无效的刷怪模式！");
                    }
                    //开启刷怪线程
                    GlobalFight.Start();
                    btn_start.Text = "结束";
                }
                else
                {
                    //此时GlobalFight.IsFighting为真，需要结束
                    GlobalFight.Stop();
                    btn_start.Text = "开始";
                }
            }
            catch (InputInvailedException exception)
            {
                MessageBox.Show(exception.Message, "请检查参数设定");
                return;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("格式解析错误", "请检查参数设定");
                return;
            }
            finally
            {
                changing = false;
            }
        }

        bool isGetting = false;
        private void btn_getxy_Click(object sender, EventArgs e)
        {
            if (isGetting || GlobalFight.IsFighting)
            {
                return;
            }
            isGetting = true;
            MessageBox.Show("把鼠标移到要获取的坐标上，然后按下回车","不要点确定");
            Point point = webBrowser_game.PointToClient(MousePosition);
            textBox_customX.Text = point.X.ToString();
            textBox_customY.Text = point.Y.ToString();
            MessageBox.Show("获取成功！" + point.ToString());
            //保存到setting，以便下次运行时读取
            Common.settings.customPoint = point;
            isGetting = false;
        }


        private static void RunCmd(string cmd)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            // 关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            // 重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            // 重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.WriteLine("exit");
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.settings.Save();
        }

        private void button1_Click(object sender, EventArgs e)//-------------------------获得物品
        {
            if (ifcolor.GetGoods())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text = (ColorTranslator.ToWin32(a.GetPixel(700, 288)).ToString()) +","+ (ColorTranslator.ToWin32(a.GetPixel(594, 411)).ToString());
                a.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)//-----------------关闭资料
        {
            if (ifcolor.Profile())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(959, 95)).ToString()) +","+ (ColorTranslator.ToWin32(a.GetPixel(552, 114)).ToString());
                a.Dispose();
            }
        }
        private void button3_Click(object sender, EventArgs e)//------------------战斗结束
        {
            if (ifcolor.FightEnd())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(542, 196)).ToString()) +","+ (ColorTranslator.ToWin32(a.GetPixel(603, 197)).ToString());
                a.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)//------------------技能或等级提升
        {
            if (ifcolor.SkillLvUp())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(189, 222)).ToString()) +","+ (ColorTranslator.ToWin32(a.GetPixel(587, 461)).ToString());
                a.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)//------------------在线时间
        {
            if (ifcolor.OnlineTime())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(409, 320)).ToString()) +","+ (ColorTranslator.ToWin32(a.GetPixel(474, 283)).ToString());
                a.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)//-----------------首发死亡
        {
            if (ifcolor.PetDie())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(153, 103)).ToString());
                a.Dispose();
            }
        }

        private void button7_Click(object sender, EventArgs e)//------------------寻找野怪
        {
            if (ifcolor.FindAndClickMonster())
            {
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  "找不到";
                a.Dispose();
            }
        }

        private void button8_Click(object sender, EventArgs e)//--------------------------战斗加载
        {
            if (ifcolor.IfcheckGhost())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(121, 3)).ToString());
                a.Dispose();
            }
        }

        private void button9_Click(object sender, EventArgs e)//========================是否可以使用技能
        {
            if (ifcolor.IfFight())
            {
                 
            }
            else
            {
                Bitmap a = Piccolor.GetWindow(Handle);
                label1.Text =  (ColorTranslator.ToWin32(a.GetPixel(327, 576)).ToString());
                a.Dispose();
            }
        }

        private void button10_Click(object sender, EventArgs e)//-----------------验证框
        {
           if( ifcolor.IfVerify() == 5)
            {
                MessageBox.Show("没有匹配到");
            }
        }

        private void button11_Click(object sender, EventArgs e)//----------------------替换精灵
        {
            ifcolor.ReplaceGhost();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GlobalFight.callLua(ConfigManager.LuaScript);
        }

        private void webBrowser_game_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ifcolor.fuck(webBrowser_game.Handle);
            Common.UpdateFlashHandle(webBrowser_game.Handle);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetTempPath() + "\\";
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void textbox_SkillOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
