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
            System.Windows.Forms.Label label_skillOrder;
            System.Windows.Forms.Label label_disclaimer;
            System.Windows.Forms.Label label_about;
            this.groupBox_fightOptions = new System.Windows.Forms.GroupBox();
            this.textbox_SkillOrder = new System.Windows.Forms.TextBox();
            this.combo_skillMode = new System.Windows.Forms.ComboBox();
            this.combo_identifyFailed = new System.Windows.Forms.ComboBox();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser_game = new System.Windows.Forms.WebBrowser();
            this.groupBox_control = new System.Windows.Forms.GroupBox();
            this.btn_clearCache = new System.Windows.Forms.Button();
            this.btn_refreshGame = new System.Windows.Forms.Button();
            this.checkBox_onTop = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            label_skillOrder = new System.Windows.Forms.Label();
            label_disclaimer = new System.Windows.Forms.Label();
            label_about = new System.Windows.Forms.Label();
            this.groupBox_fightOptions.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_skillOrder
            // 
            label_skillOrder.AutoSize = true;
            label_skillOrder.Location = new System.Drawing.Point(76, 16);
            label_skillOrder.Name = "label_skillOrder";
            label_skillOrder.Size = new System.Drawing.Size(89, 12);
            label_skillOrder.TabIndex = 7;
            label_skillOrder.Text = "技能释放顺序：";
            // 
            // label_disclaimer
            // 
            label_disclaimer.AutoSize = true;
            label_disclaimer.Location = new System.Drawing.Point(3, 15);
            label_disclaimer.Name = "label_disclaimer";
            label_disclaimer.Size = new System.Drawing.Size(389, 72);
            label_disclaimer.TabIndex = 0;
            label_disclaimer.Text = " 约瑟传说鼹鼠辅助    \r\n 开发：瞬杀  帅气的番茄酱 负责：同样帅气的迷恋\r\n（原“乄Mole灬家族辅助”）\r\n本软件仅供学习研究及娱乐使用，严禁用作非法用" +
    "途！\r\n由于将本软件用作非法用途而产生的一系列法律责任由使用者自行承担。\r\n本辅助软件开发人员及鼹鼠家族将不承担任何法律责任！";
            // 
            // label_about
            // 
            label_about.AutoSize = true;
            label_about.Location = new System.Drawing.Point(1, 0);
            label_about.Name = "label_about";
            label_about.Size = new System.Drawing.Size(413, 96);
            label_about.TabIndex = 0;
            label_about.Text = "\r\n约瑟传说鼹鼠辅助（原mole家族辅助）\r\n    “约瑟传说鼹鼠辅助”创立于2013年5月，软件自研发之始即以“让玩家\r\n解放双手，自由游戏”为宗旨，我们一直" +
    "致力于提供更优质的服务，不断开创\r\n新的功能。\r\n    在未来，我们将仍然坚持以倾听用户声音为主，创造更优质的用户体验，\r\n更好的让玩家解放双手，自由游戏，这" +
    "是我们的目标也是一直在坚持的信念。\r\n\r\n";
            // 
            // groupBox_fightOptions
            // 
            this.groupBox_fightOptions.Controls.Add(this.textbox_SkillOrder);
            this.groupBox_fightOptions.Controls.Add(label_skillOrder);
            this.groupBox_fightOptions.Controls.Add(this.combo_skillMode);
            this.groupBox_fightOptions.Controls.Add(this.combo_identifyFailed);
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
            this.textbox_SkillOrder.Size = new System.Drawing.Size(71, 21);
            this.textbox_SkillOrder.TabIndex = 8;
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
            // combo_identifyFailed
            // 
            this.combo_identifyFailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_identifyFailed.Enabled = false;
            this.combo_identifyFailed.FormattingEnabled = true;
            this.combo_identifyFailed.Items.AddRange(new object[] {
            "弹出窗口",
            "自动刷新",
            "随机点击"});
            this.combo_identifyFailed.Location = new System.Drawing.Point(156, 33);
            this.combo_identifyFailed.Name = "combo_identifyFailed";
            this.combo_identifyFailed.Size = new System.Drawing.Size(72, 20);
            this.combo_identifyFailed.TabIndex = 5;
            // 
            // checkBox_alert
            // 
            this.checkBox_alert.AutoSize = true;
            this.checkBox_alert.Checked = global::MoleAssist.Properties.Settings.Default.alert;
            this.checkBox_alert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_alert.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "alert", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_alert.Enabled = false;
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
            this.checkBox_qucikTraining.Enabled = false;
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
            this.checkBox_isAutoIdentify.Enabled = false;
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
            this.checkBox_useAnger.Enabled = false;
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
            this.checkBox_couldHiddenMode.Enabled = false;
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
            this.checkBox_ReHP.Enabled = false;
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
            this.radio_modeSelect2.Enabled = false;
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
            this.textBox_customY.MaxLength = 6;
            this.textBox_customY.Name = "textBox_customY";
            this.textBox_customY.ReadOnly = true;
            this.textBox_customY.Size = new System.Drawing.Size(29, 21);
            this.textBox_customY.TabIndex = 15;
            this.textBox_customY.WordWrap = false;
            // 
            // textBox_customX
            // 
            this.textBox_customX.Location = new System.Drawing.Point(104, 71);
            this.textBox_customX.MaxLength = 6;
            this.textBox_customX.Name = "textBox_customX";
            this.textBox_customX.ReadOnly = true;
            this.textBox_customX.Size = new System.Drawing.Size(29, 21);
            this.textBox_customX.TabIndex = 14;
            this.textBox_customX.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(label_disclaimer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(419, 96);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "责任说明";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(label_about);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(419, 96);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser_game
            // 
            this.webBrowser_game.AllowWebBrowserDrop = false;
            this.webBrowser_game.CausesValidation = false;
            this.webBrowser_game.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser_game.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_game.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_game.Name = "webBrowser_game";
            this.webBrowser_game.ScrollBarsEnabled = false;
            this.webBrowser_game.Size = new System.Drawing.Size(1200, 660);
            this.webBrowser_game.TabIndex = 12;
            this.webBrowser_game.Url = new System.Uri("http://seer2.61.com/play.shtml", System.UriKind.Absolute);
            this.webBrowser_game.WebBrowserShortcutsEnabled = false;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 687);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "获得物品";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 687);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 27);
            this.button2.TabIndex = 15;
            this.button2.Text = "关闭资料";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(706, 687);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 27);
            this.button3.TabIndex = 16;
            this.button3.Text = "战斗结束";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(775, 687);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 27);
            this.button4.TabIndex = 17;
            this.button4.Text = "技能或等级提升";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(878, 687);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 27);
            this.button5.TabIndex = 18;
            this.button5.Text = "在线时间";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(946, 687);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 27);
            this.button6.TabIndex = 19;
            this.button6.Text = "首发死亡";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1018, 687);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(61, 27);
            this.button7.TabIndex = 20;
            this.button7.Text = "寻找野怪";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1085, 687);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(61, 27);
            this.button8.TabIndex = 21;
            this.button8.Text = "战斗加载";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(572, 729);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(109, 27);
            this.button9.TabIndex = 22;
            this.button9.Text = "是否可以使用技能";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(687, 729);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(61, 27);
            this.button10.TabIndex = 23;
            this.button10.Text = "验证框";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(754, 729);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(61, 27);
            this.button11.TabIndex = 24;
            this.button11.Text = "替换精灵";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(843, 738);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1201, 785);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_fightOptions;
        private System.Windows.Forms.TextBox textbox_SkillOrder;
        private System.Windows.Forms.ComboBox combo_skillMode;
        private System.Windows.Forms.CheckBox checkBox_alert;
        private System.Windows.Forms.CheckBox checkBox_qucikTraining;
        private System.Windows.Forms.CheckBox checkBox_useAnger;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowser_game;
        private System.Windows.Forms.GroupBox groupBox_control;
        private System.Windows.Forms.Button btn_refreshGame;
        private System.Windows.Forms.CheckBox checkBox_onTop;
        private System.Windows.Forms.Button btn_clearCache;
        private System.Windows.Forms.TextBox textBox_customY;
        private System.Windows.Forms.TextBox textBox_customX;
        private System.Windows.Forms.TextBox textBox_interval;
        private System.Windows.Forms.ComboBox combo_identifyFailed;
        private System.Windows.Forms.CheckBox checkBox_isAutoIdentify;
        private System.Windows.Forms.CheckBox checkBox_ReHP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label1;
    }
}

