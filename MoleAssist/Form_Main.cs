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
            combo_autoIdentifyFailed.SelectedIndex = 0;
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
            if (combo_skillMode.SelectedIndex == 0) {
                textbox_SkillOrder.Enabled = false;
            }
            else
            {
                textbox_SkillOrder.Enabled = true;
            }
        }

        private void checkBox_qucikTraining_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("请将带练精灵放到第二位");
        }

        private void btn_refreshGame_Click(object sender, EventArgs e)
        {
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
                FightType type = new FightType();
                if (!GlobalFight.IsFighting)
                {
                    //此时GlobalFight.IsFighting为假，需要开始
                    if (radio_modeSelect1.Checked)
                    {
                        //TODO: 1.刷野怪 的处理
                        type = FightType.Wild;
                    }
                    else if (radio_modeSelect2.Checked)
                    {
                        if (string.IsNullOrEmpty(combo_NPCSelect.Text))
                        {
                            MessageBox.Show("请选择指定NPC或忍者");
                            return;
                        }
                        //TODO: 2. NPC/忍者 的处理
                        type = FightType.NPC;
                    }
                    else if (radio_modeSelect3.Checked)
                    {
                        if (string.IsNullOrEmpty(textBox_customX.Text) || string.IsNullOrEmpty(textBox_customY.Text))
                        {
                            MessageBox.Show("还未指定坐标");
                            return;
                        }
                        //TODO: 3. 自定义 的处理
                        type = FightType.CustomPoint;
                        GlobalFight.CustomPoint = new Point
                        {
                            X = int.Parse(textBox_customX.Text),
                            Y = int.Parse(textBox_customY.Text)
                        };
                    }

                    //开启刷怪线程，传入参数
                    GlobalFight.Start(type);
                    btn_start.Text = "结束";
                }
                else
                {
                    //此时GlobalFight.IsFighting为真，需要结束
                    GlobalFight.Stop();
                    btn_start.Text = "开始";
                }
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
            Properties.Settings.Default.customPoint = point;
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
            Properties.Settings.Default.Save();
        }
    }
}
