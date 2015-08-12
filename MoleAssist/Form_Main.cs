using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoleAssist
{
    public partial class form_Main : Form
    {
        public form_Main()
        {
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
                textbox_SkillOrder.ReadOnly =true;
            }
            else
            {
                textbox_SkillOrder.ReadOnly = false;
            }
        }

        private void form_Main_Load(object sender, EventArgs e)
        {
            combo_skillMode.Text = "单技能";
            combo_autoIdentifyFailed.Text = "弹出窗口";
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
            if (!FightControl.isFighting)
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
                //开启刷怪线程，传入参数3    ps：1为刷野怪，2为npc忍者   3为自定义
                // new Thread..
                btn_start.Text = "结束";
            }
            else {
                //暂停线程
                btn_start.Text = "开始";
            }
        }

        private void btn_getxy_Click(object sender, EventArgs e)
        {

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

    }
}
