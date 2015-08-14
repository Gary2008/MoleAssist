namespace MoleAssist
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (GlobalFight != null)
                {
                    GlobalFight.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_fightOptions = new System.Windows.Forms.GroupBox();
            this.textbox_SkillOrder = new System.Windows.Forms.TextBox();
            this.label_skillOrder = new System.Windows.Forms.Label();
            this.combo_skillMode = new System.Windows.Forms.ComboBox();
            this.combo_autoIdentifyFailed = new System.Windows.Forms.ComboBox();
            this.checkBox_alert = new System.Windows.Forms.CheckBox();
            this.checkBox_qucikTraining = new System.Windows.Forms.CheckBox();
            this.checkBox_isAutoIdentify = new System.Windows.Forms.CheckBox();
            this.checkBox_useAnger = new System.Windows.Forms.CheckBox();
            this.checkBox_couldHiddenMode = new System.Windows.Forms.CheckBox();
            this.checkBox_ReHP = new System.Windows.Forms.CheckBox();
            this.radio_modeSelect1 = new System.Windows.Forms.RadioButton();
            this.radio_modeSelect2 = new System.Windows.Forms.RadioButton();
            this.radio_modeSelect3 = new System.Windows.Forms.RadioButton();
            this.combo_NPCSelect = new System.Windows.Forms.ComboBox();
            this.btn_getxy = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_interval = new System.Windows.Forms.TextBox();
            this.textBox_customY = new System.Windows.Forms.TextBox();
            this.textBox_customX = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_disclaimer = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_about = new System.Windows.Forms.Label();
            this.webBrowser_game = new System.Windows.Forms.WebBrowser();
            this.groupBox_control = new System.Windows.Forms.GroupBox();
            this.btn_clearCache = new System.Windows.Forms.Button();
            this.btn_refreshGame = new System.Windows.Forms.Button();
            this.checkBox_onTop = new System.Windows.Forms.CheckBox();
            this.groupBox_fightOptions.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_fightOptions
            // 
            this.groupBox_fightOptions.Controls.Add(this.textbox_SkillOrder);
            this.groupBox_fightOptions.Controls.Add(this.label_skillOrder);
            this.groupBox_fightOptions.Controls.Add(this.combo_skillMode);
            this.groupBox_fightOptions.Controls.Add(this.combo_autoIdentifyFailed);
            this.groupBox_fightOptions.Controls.Add(this.checkBox_alert);
            this.groupBox_fightOptions.Controls.Add(this.checkBox_qucikTraining);
            this.groupBox_fightOptions.Controls.Add(this.checkBox_isAutoIdentify);
            this.groupBox_fightOptions.Controls.Add(this.checkBox_useAnger);
            this.groupBox_fightOptions.Controls.Add(this.checkBox_couldHiddenMode);
            this.groupBox_fightOptions.Controls.Add(this.checkBox_ReHP);
            this.groupBox_fightOptions.Location = new System.Drawing.Point(174, 2);
            this.groupBox_fightOptions.Name = "groupBox_fightOptions";
            this.groupBox_fightOptions.Size = new System.Drawing.Size(236, 90);
            this.groupBox_fightOptions.TabIndex = 0;
            this.groupBox_fightOptions.TabStop = false;
            this.groupBox_fightOptions.Text = "刷怪设置";
            // 
            // textbox_SkillOrder
            // 
            this.textbox_SkillOrder.Location = new System.Drawing.Point(157, 11);
            this.textbox_SkillOrder.Name = "textbox_SkillOrder";
            this.textbox_SkillOrder.ReadOnly = true;
            this.textbox_SkillOrder.Size = new System.Drawing.Size(71, 21);
            this.textbox_SkillOrder.TabIndex = 8;
            // 
            // label_skillOrder
            // 
            this.label_skillOrder.AutoSize = true;
            this.label_skillOrder.Location = new System.Drawing.Point(76, 16);
            this.label_skillOrder.Name = "label_skillOrder";
            this.label_skillOrder.Size = new System.Drawing.Size(89, 12);
            this.label_skillOrder.TabIndex = 7;
            this.label_skillOrder.Text = "技能释放顺序：";
            // 
            // combo_skillMode
            // 
            this.combo_skillMode.DisplayMember = "0";
            this.combo_skillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_skillMode.FormattingEnabled = true;
            this.combo_skillMode.Items.AddRange(new object[] {
            "单技能",
            "多技能"});
            this.combo_skillMode.Location = new System.Drawing.Point(6, 13);
            this.combo_skillMode.Name = "combo_skillMode";
            this.combo_skillMode.Size = new System.Drawing.Size(67, 20);
            this.combo_skillMode.TabIndex = 6;
            this.combo_skillMode.SelectedIndexChanged += new System.EventHandler(this.combo_skillMode_SelectedIndexChanged);
            // 
            // combo_autoIdentifyFailed
            // 
            this.combo_autoIdentifyFailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_autoIdentifyFailed.FormattingEnabled = true;
            this.combo_autoIdentifyFailed.Items.AddRange(new object[] {
            "弹出窗口",
            "自动刷新",
            "随机点击"});
            this.combo_autoIdentifyFailed.Location = new System.Drawing.Point(156, 33);
            this.combo_autoIdentifyFailed.Name = "combo_autoIdentifyFailed";
            this.combo_autoIdentifyFailed.Size = new System.Drawing.Size(72, 20);
            this.combo_autoIdentifyFailed.TabIndex = 5;
            // 
            // checkBox_alert
            // 
            this.checkBox_alert.AutoSize = true;
            this.checkBox_alert.Checked = global::MoleAssist.Properties.Settings.Default.alert;
            this.checkBox_alert.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "alert", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_alert.Location = new System.Drawing.Point(156, 58);
            this.checkBox_alert.Name = "checkBox_alert";
            this.checkBox_alert.Size = new System.Drawing.Size(72, 16);
            this.checkBox_alert.TabIndex = 4;
            this.checkBox_alert.Text = "异常鸣笛";
            this.checkBox_alert.UseVisualStyleBackColor = true;
            // 
            // checkBox_qucikTraining
            // 
            this.checkBox_qucikTraining.AutoSize = true;
            this.checkBox_qucikTraining.Checked = global::MoleAssist.Properties.Settings.Default.qucikTraining;
            this.checkBox_qucikTraining.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "qucikTraining", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_qucikTraining.Location = new System.Drawing.Point(6, 73);
            this.checkBox_qucikTraining.Name = "checkBox_qucikTraining";
            this.checkBox_qucikTraining.Size = new System.Drawing.Size(72, 16);
            this.checkBox_qucikTraining.TabIndex = 3;
            this.checkBox_qucikTraining.Text = "精灵带练";
            this.checkBox_qucikTraining.UseVisualStyleBackColor = true;
            this.checkBox_qucikTraining.CheckedChanged += new System.EventHandler(this.checkBox_qucikTraining_CheckedChanged);
            // 
            // checkBox_isAutoIdentify
            // 
            this.checkBox_isAutoIdentify.AutoSize = true;
            this.checkBox_isAutoIdentify.Checked = global::MoleAssist.Properties.Settings.Default.isAutoIdentify;
            this.checkBox_isAutoIdentify.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "isAutoIdentify", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_isAutoIdentify.Location = new System.Drawing.Point(6, 36);
            this.checkBox_isAutoIdentify.Name = "checkBox_isAutoIdentify";
            this.checkBox_isAutoIdentify.Size = new System.Drawing.Size(156, 16);
            this.checkBox_isAutoIdentify.TabIndex = 2;
            this.checkBox_isAutoIdentify.Text = "自动过验证，不能识别时";
            this.checkBox_isAutoIdentify.UseVisualStyleBackColor = true;
            // 
            // checkBox_useAnger
            // 
            this.checkBox_useAnger.AutoSize = true;
            this.checkBox_useAnger.Checked = global::MoleAssist.Properties.Settings.Default.useAnger;
            this.checkBox_useAnger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_useAnger.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "useAnger", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_useAnger.Location = new System.Drawing.Point(84, 58);
            this.checkBox_useAnger.Name = "checkBox_useAnger";
            this.checkBox_useAnger.Size = new System.Drawing.Size(72, 16);
            this.checkBox_useAnger.TabIndex = 1;
            this.checkBox_useAnger.Text = "自动放怒";
            this.checkBox_useAnger.UseVisualStyleBackColor = true;
            // 
            // checkBox_couldHiddenMode
            // 
            this.checkBox_couldHiddenMode.AutoSize = true;
            this.checkBox_couldHiddenMode.Checked = global::MoleAssist.Properties.Settings.Default.couldHiddenMode;
            this.checkBox_couldHiddenMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_couldHiddenMode.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "couldHiddenMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_couldHiddenMode.Location = new System.Drawing.Point(84, 73);
            this.checkBox_couldHiddenMode.Name = "checkBox_couldHiddenMode";
            this.checkBox_couldHiddenMode.Size = new System.Drawing.Size(84, 16);
            this.checkBox_couldHiddenMode.TabIndex = 9;
            this.checkBox_couldHiddenMode.Text = "可后台模式";
            this.checkBox_couldHiddenMode.UseVisualStyleBackColor = true;
            // 
            // checkBox_ReHP
            // 
            this.checkBox_ReHP.AutoSize = true;
            this.checkBox_ReHP.Checked = global::MoleAssist.Properties.Settings.Default.ReHP;
            this.checkBox_ReHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ReHP.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "ReHP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ReHP.Location = new System.Drawing.Point(6, 58);
            this.checkBox_ReHP.Name = "checkBox_ReHP";
            this.checkBox_ReHP.Size = new System.Drawing.Size(72, 16);
            this.checkBox_ReHP.TabIndex = 0;
            this.checkBox_ReHP.Text = "自动回血";
            this.checkBox_ReHP.UseVisualStyleBackColor = true;
            // 
            // radio_modeSelect1
            // 
            this.radio_modeSelect1.AutoSize = true;
            this.radio_modeSelect1.Checked = true;
            this.radio_modeSelect1.Location = new System.Drawing.Point(6, 6);
            this.radio_modeSelect1.Name = "radio_modeSelect1";
            this.radio_modeSelect1.Size = new System.Drawing.Size(83, 16);
            this.radio_modeSelect1.TabIndex = 1;
            this.radio_modeSelect1.TabStop = true;
            this.radio_modeSelect1.Text = "野      怪";
            this.radio_modeSelect1.UseVisualStyleBackColor = true;
            // 
            // radio_modeSelect2
            // 
            this.radio_modeSelect2.AutoSize = true;
            this.radio_modeSelect2.Location = new System.Drawing.Point(6, 28);
            this.radio_modeSelect2.Name = "radio_modeSelect2";
            this.radio_modeSelect2.Size = new System.Drawing.Size(83, 16);
            this.radio_modeSelect2.TabIndex = 2;
            this.radio_modeSelect2.Text = "NPC / 忍者";
            this.radio_modeSelect2.UseVisualStyleBackColor = true;
            this.radio_modeSelect2.CheckedChanged += new System.EventHandler(this.radio_modeSelect2_CheckedChanged);
            // 
            // radio_modeSelect3
            // 
            this.radio_modeSelect3.AutoSize = true;
            this.radio_modeSelect3.Location = new System.Drawing.Point(6, 50);
            this.radio_modeSelect3.Name = "radio_modeSelect3";
            this.radio_modeSelect3.Size = new System.Drawing.Size(83, 16);
            this.radio_modeSelect3.TabIndex = 3;
            this.radio_modeSelect3.Text = "自定义坐标";
            this.radio_modeSelect3.UseVisualStyleBackColor = true;
            this.radio_modeSelect3.CheckedChanged += new System.EventHandler(this.radio_modeSelect3_CheckedChanged);
            // 
            // combo_NPCSelect
            // 
            this.combo_NPCSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_NPCSelect.FormattingEnabled = true;
            this.combo_NPCSelect.Items.AddRange(new object[] {
            "——NPC",
            "葛雷芬",
            "萨伯尔",
            "斯莫克",
            "娜娜",
            "——忍者",
            "涟漪",
            "斩灵",
            "百魁"});
            this.combo_NPCSelect.Location = new System.Drawing.Point(95, 28);
            this.combo_NPCSelect.Name = "combo_NPCSelect";
            this.combo_NPCSelect.Size = new System.Drawing.Size(73, 20);
            this.combo_NPCSelect.TabIndex = 4;
            this.combo_NPCSelect.Visible = false;
            // 
            // btn_getxy
            // 
            this.btn_getxy.Location = new System.Drawing.Point(93, 50);
            this.btn_getxy.Name = "btn_getxy";
            this.btn_getxy.Size = new System.Drawing.Size(75, 20);
            this.btn_getxy.TabIndex = 9;
            this.btn_getxy.Text = "获取坐标";
            this.btn_getxy.UseVisualStyleBackColor = true;
            this.btn_getxy.Visible = false;
            this.btn_getxy.Click += new System.EventHandler(this.btn_getxy_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(9, 71);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(89, 23);
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage1);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Controls.Add(this.tabPage3);
            this.tabControl_Main.Location = new System.Drawing.Point(2, 662);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(427, 122);
            this.tabControl_Main.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox_interval);
            this.tabPage1.Controls.Add(this.textBox_customY);
            this.tabPage1.Controls.Add(this.radio_modeSelect1);
            this.tabPage1.Controls.Add(this.textBox_customX);
            this.tabPage1.Controls.Add(this.groupBox_fightOptions);
            this.tabPage1.Controls.Add(this.radio_modeSelect2);
            this.tabPage1.Controls.Add(this.radio_modeSelect3);
            this.tabPage1.Controls.Add(this.btn_start);
            this.tabPage1.Controls.Add(this.combo_NPCSelect);
            this.tabPage1.Controls.Add(this.btn_getxy);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(419, 96);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "自动刷怪";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox_interval
            // 
            this.textBox_interval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MoleAssist.Properties.Settings.Default, "FightInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_interval.Location = new System.Drawing.Point(115, 5);
            this.textBox_interval.Name = "textBox_interval";
            this.textBox_interval.Size = new System.Drawing.Size(30, 21);
            this.textBox_interval.TabIndex = 16;
            this.textBox_interval.Text = global::MoleAssist.Properties.Settings.Default.FightInterval;
            this.textBox_interval.Visible = false;
            // 
            // textBox_customY
            // 
            this.textBox_customY.Location = new System.Drawing.Point(137, 71);
            this.textBox_customY.Name = "textBox_customY";
            this.textBox_customY.Size = new System.Drawing.Size(29, 21);
            this.textBox_customY.TabIndex = 15;
            this.textBox_customY.Visible = false;
            this.textBox_customY.WordWrap = false;
            // 
            // textBox_customX
            // 
            this.textBox_customX.Location = new System.Drawing.Point(104, 71);
            this.textBox_customX.Name = "textBox_customX";
            this.textBox_customX.Size = new System.Drawing.Size(29, 21);
            this.textBox_customX.TabIndex = 14;
            this.textBox_customX.Visible = false;
            this.textBox_customX.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_disclaimer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(419, 96);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "责任说明";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_disclaimer
            // 
            this.label_disclaimer.AutoSize = true;
            this.label_disclaimer.Location = new System.Drawing.Point(3, 15);
            this.label_disclaimer.Name = "label_disclaimer";
            this.label_disclaimer.Size = new System.Drawing.Size(389, 72);
            this.label_disclaimer.TabIndex = 0;
            this.label_disclaimer.Text = " 约瑟传说鼹鼠辅助    \r\n 开发：瞬杀  帅气的番茄酱 负责：同样帅气的迷恋\r\n（原“乄Mole灬家族辅助”）\r\n本软件仅供学习研究及娱乐使用，严禁用作非法用" +
    "途！\r\n由于将本软件用作非法用途而产生的一系列法律责任由使用者自行承担。\r\n本辅助软件开发人员及鼹鼠家族将不承担任何法律责任！";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label_about);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(419, 96);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.Location = new System.Drawing.Point(1, 0);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(413, 96);
            this.label_about.TabIndex = 0;
            this.label_about.Text = "\r\n约瑟传说鼹鼠辅助（原mole家族辅助）\r\n    “约瑟传说鼹鼠辅助”创立于2013年5月，软件自研发之始即以“让玩家\r\n解放双手，自由游戏”为宗旨，我们一直" +
    "致力于提供更优质的服务，不断开创\r\n新的功能。\r\n    在未来，我们将仍然坚持以倾听用户声音为主，创造更优质的用户体验，\r\n更好的让玩家解放双手，自由游戏，这" +
    "是我们的目标也是一直在坚持的信念。\r\n\r\n";
            // 
            // webBrowser_game
            // 
            this.webBrowser_game.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_game.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_game.Name = "webBrowser_game";
            this.webBrowser_game.Size = new System.Drawing.Size(1200, 660);
            this.webBrowser_game.TabIndex = 12;
            this.webBrowser_game.Url = new System.Uri("http://seer2.61.com/play.shtml", System.UriKind.Absolute);
            // 
            // groupBox_control
            // 
            this.groupBox_control.Controls.Add(this.btn_clearCache);
            this.groupBox_control.Controls.Add(this.btn_refreshGame);
            this.groupBox_control.Controls.Add(this.checkBox_onTop);
            this.groupBox_control.Location = new System.Drawing.Point(435, 676);
            this.groupBox_control.Name = "groupBox_control";
            this.groupBox_control.Size = new System.Drawing.Size(103, 108);
            this.groupBox_control.TabIndex = 13;
            this.groupBox_control.TabStop = false;
            this.groupBox_control.Text = "控制台";
            // 
            // btn_clearCache
            // 
            this.btn_clearCache.Location = new System.Drawing.Point(15, 71);
            this.btn_clearCache.Name = "btn_clearCache";
            this.btn_clearCache.Size = new System.Drawing.Size(75, 23);
            this.btn_clearCache.TabIndex = 2;
            this.btn_clearCache.Text = "清除缓存";
            this.btn_clearCache.UseVisualStyleBackColor = true;
            this.btn_clearCache.Click += new System.EventHandler(this.btn_clearCache_Click);
            // 
            // btn_refreshGame
            // 
            this.btn_refreshGame.Location = new System.Drawing.Point(15, 42);
            this.btn_refreshGame.Name = "btn_refreshGame";
            this.btn_refreshGame.Size = new System.Drawing.Size(75, 23);
            this.btn_refreshGame.TabIndex = 1;
            this.btn_refreshGame.Text = "刷新游戏";
            this.btn_refreshGame.UseVisualStyleBackColor = true;
            this.btn_refreshGame.Click += new System.EventHandler(this.btn_refreshGame_Click);
            // 
            // checkBox_onTop
            // 
            this.checkBox_onTop.AutoSize = true;
            this.checkBox_onTop.Checked = global::MoleAssist.Properties.Settings.Default.OnTop;
            this.checkBox_onTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "OnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_onTop.Location = new System.Drawing.Point(18, 20);
            this.checkBox_onTop.Name = "checkBox_onTop";
            this.checkBox_onTop.Size = new System.Drawing.Size(72, 16);
            this.checkBox_onTop.TabIndex = 0;
            this.checkBox_onTop.Text = "置顶显示";
            this.checkBox_onTop.UseVisualStyleBackColor = true;
            this.checkBox_onTop.CheckedChanged += new System.EventHandler(this.checkBox_onTop_CheckedChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1201, 785);
            this.Controls.Add(this.groupBox_control);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.webBrowser_game);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.Text = "约瑟传说鼹鼠辅助";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.groupBox_fightOptions.ResumeLayout(false);
            this.groupBox_fightOptions.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox_control.ResumeLayout(false);
            this.groupBox_control.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_fightOptions;
        private System.Windows.Forms.TextBox textbox_SkillOrder;
        private System.Windows.Forms.Label label_skillOrder;
        private System.Windows.Forms.ComboBox combo_skillMode;
        private System.Windows.Forms.ComboBox combo_autoIdentifyFailed;
        private System.Windows.Forms.CheckBox checkBox_alert;
        private System.Windows.Forms.CheckBox checkBox_qucikTraining;
        private System.Windows.Forms.CheckBox checkBox_isAutoIdentify;
        private System.Windows.Forms.CheckBox checkBox_useAnger;
        private System.Windows.Forms.CheckBox checkBox_ReHP;
        private System.Windows.Forms.RadioButton radio_modeSelect1;
        private System.Windows.Forms.RadioButton radio_modeSelect2;
        private System.Windows.Forms.RadioButton radio_modeSelect3;
        private System.Windows.Forms.ComboBox combo_NPCSelect;
        private System.Windows.Forms.Button btn_getxy;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox checkBox_couldHiddenMode;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label_disclaimer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label_about;
        private System.Windows.Forms.WebBrowser webBrowser_game;
        private System.Windows.Forms.GroupBox groupBox_control;
        private System.Windows.Forms.Button btn_refreshGame;
        private System.Windows.Forms.CheckBox checkBox_onTop;
        private System.Windows.Forms.Button btn_clearCache;
        private System.Windows.Forms.TextBox textBox_customY;
        private System.Windows.Forms.TextBox textBox_customX;
        private System.Windows.Forms.TextBox textBox_interval;
    }
}

