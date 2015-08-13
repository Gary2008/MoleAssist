using Config;
using Fight;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MoleAssist
{ 
    public partial class form_Main : Form
    {
        private static string lua;
        private FightManager GlobalFight;
        public form_Main()
        {
            lua = ConfigManager.Get(Config.Item.Lua);
            GlobalFight = new FightManager(lua);
            InitializeComponent();
        }
        
        private void radio_modeSelect1Changed(object sender, EventArgs e)
        {

        }

        private void radio_modeSelect2_CheckedChanged(object sender, EventArgs e)
        {
            combo_NPCSelect.Visible = radio_modeSelect2.Checked;
        }

        private void radio_modeSelect3_CheckedChanged(object sender, EventArgs e)
        {
            btn_getxy.Visible = textBox_customX.Visible = textBox_customY.Visible = radio_modeSelect3.Checked;
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

        private void form_Main_Load(object sender, EventArgs e)
        {
            combo_skillMode.SelectedIndex = 0;
            combo_autoIdentifyFailed.SelectedIndex = 0;
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

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!GlobalFight.IsFighting)
            {
                if (textBox_interval.Text == "")
                {
                    MessageBox.Show("打野周期不能为空");
                    return;
                }

                if (radio_modeSelect1.Checked)
                {
                    //TODO: 1.刷野怪 的处理

                }
                else if (radio_modeSelect2.Checked)
                {
                    if (combo_NPCSelect.Text == "")
                    {
                        MessageBox.Show("请选择指定NPC或忍者");
                        return;
                    }
                    //TODO: 2. NPC/忍者 的处理

                }
                else if(radio_modeSelect3.Checked)
                {
                    if (textBox_customX.Text == "" || textBox_customY.Text == "")
                    {
                        MessageBox.Show("还未获取坐标");
                        return ;
                    }
                    //TODO: 3. NPC/忍者 的处理

                }
                MessageBox.Show("请期待正式版辅助放出~");
                //开启刷怪线程，传入参数    ps：1为刷野怪，2为npc忍者   3为自定义
                GlobalFight.Start();
                btn_start.Text = "结束";
            }
            else {
                GlobalFight.Stop();
                btn_start.Text = "开始";
            }
        }

        bool isGetting = false;
        private void btn_getxy_Click(object sender, EventArgs e)
        {
            if (isGetting)
                return ;
            isGetting = true;
            MessageBox.Show("请在3秒内把鼠标移到要获取的坐标");
            Thread t = new Thread(o => Thread.Sleep(3000));
            t.Start(this);
            while (t.IsAlive)
            {
                Application.DoEvents();
            }
            Point point = webBrowser_game.PointToClient(MousePosition);
            textBox_customX.Text = point.X.ToString();
            textBox_customY.Text = point.Y.ToString();
            MessageBox.Show("获取成功！" + point.ToString() );
            Properties.Settings.Default.customPoint = point;
            isGetting = false;
        }


        void RunCmd(string cmd)
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

        private void form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
