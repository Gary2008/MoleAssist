using Config;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MoleAssist
{ 
    public partial class Form_Main : Form
    {
        private static string lua;
        private FightManager GlobalFight;
        public Form_Main()
        {
            lua = ConfigManager.LuaScript;
            GlobalFight = new FightManager(lua);
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
                    GlobalFight.FightOptions.interval = int.Parse(textBox_interval.Text);
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
                            //GlobalFight.FightOptions.
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
            }
            catch (System.FormatException)
            {
                MessageBox.Show("格式解析错误", "请检查参数设定");
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

        private void button1_Click(object sender, EventArgs e)
        {
            Common.Click(Common.hGame, new Point { X=int.Parse(textBox_customX.Text),Y=int.Parse(textBox_customY.Text) });
            
        }
    }
}
