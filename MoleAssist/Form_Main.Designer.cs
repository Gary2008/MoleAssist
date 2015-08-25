﻿namespace MoleAssist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_SkillOrder = new System.Windows.Forms.TextBox();
            this.combo_skillMode = new System.Windows.Forms.ComboBox();
            this.combo_identifyFailed = new System.Windows.Forms.ComboBox();
            this.checkBox_alert = new System.Windows.Forms.CheckBox();
            this.checkBox_qucikTraining = new System.Windows.Forms.CheckBox();
            this.checkBox_isAutoIdentify = new System.Windows.Forms.CheckBox();
            this.checkBox_useAnger = new System.Windows.Forms.CheckBox();
            this.checkBox_ReHP = new System.Windows.Forms.CheckBox();
            this.radio_modeSelect1 = new System.Windows.Forms.RadioButton();
            this.radio_modeSelect2 = new System.Windows.Forms.RadioButton();
            this.radio_modeSelect3 = new System.Windows.Forms.RadioButton();
            this.combo_NPCSelect = new System.Windows.Forms.ComboBox();
            this.btn_getxy = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.textBox_customY = new System.Windows.Forms.TextBox();
            this.textBox_customX = new System.Windows.Forms.TextBox();
            this.btn_clearCache = new System.Windows.Forms.Button();
            this.btn_refreshGame = new System.Windows.Forms.Button();
            this.checkBox_onTop = new System.Windows.Forms.CheckBox();
            this.webBrowser_game = new System.Windows.Forms.WebBrowser();
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
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            label_skillOrder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label_skillOrder
            // 
            label_skillOrder.AutoSize = true;
            label_skillOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            label_skillOrder.ForeColor = System.Drawing.Color.White;
            label_skillOrder.Location = new System.Drawing.Point(31, 196);
            label_skillOrder.Name = "label_skillOrder";
            label_skillOrder.Size = new System.Drawing.Size(89, 12);
            label_skillOrder.TabIndex = 7;
            label_skillOrder.Text = "技能释放顺序：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "技能模式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "不能识别验证图时";
            // 
            // textbox_SkillOrder
            // 
            this.textbox_SkillOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.textbox_SkillOrder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MoleAssist.Properties.Settings.Default, "SkillOrder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textbox_SkillOrder.ForeColor = System.Drawing.Color.White;
            this.textbox_SkillOrder.Location = new System.Drawing.Point(126, 193);
            this.textbox_SkillOrder.Name = "textbox_SkillOrder";
            this.textbox_SkillOrder.Size = new System.Drawing.Size(71, 21);
            this.textbox_SkillOrder.TabIndex = 8;
            this.textbox_SkillOrder.Text = global::MoleAssist.Properties.Settings.Default.SkillOrder;
            this.textbox_SkillOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_SkillOrder_KeyPress);
            // 
            // combo_skillMode
            // 
            this.combo_skillMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.combo_skillMode.DisplayMember = "0";
            this.combo_skillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_skillMode.ForeColor = System.Drawing.Color.White;
            this.combo_skillMode.FormattingEnabled = true;
            this.combo_skillMode.Items.AddRange(new object[] {
            "单技能",
            "多技能"});
            this.combo_skillMode.Location = new System.Drawing.Point(126, 167);
            this.combo_skillMode.Name = "combo_skillMode";
            this.combo_skillMode.Size = new System.Drawing.Size(67, 20);
            this.combo_skillMode.TabIndex = 6;
            this.combo_skillMode.SelectedIndexChanged += new System.EventHandler(this.combo_skillMode_SelectedIndexChanged);
            // 
            // combo_identifyFailed
            // 
            this.combo_identifyFailed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.combo_identifyFailed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_identifyFailed.Enabled = false;
            this.combo_identifyFailed.ForeColor = System.Drawing.Color.White;
            this.combo_identifyFailed.FormattingEnabled = true;
            this.combo_identifyFailed.Items.AddRange(new object[] {
            "弹出窗口",
            "自动刷新",
            "随机点击"});
            this.combo_identifyFailed.Location = new System.Drawing.Point(126, 295);
            this.combo_identifyFailed.Name = "combo_identifyFailed";
            this.combo_identifyFailed.Size = new System.Drawing.Size(72, 20);
            this.combo_identifyFailed.TabIndex = 5;
            // 
            // checkBox_alert
            // 
            this.checkBox_alert.AutoSize = true;
            this.checkBox_alert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.checkBox_alert.Checked = global::MoleAssist.Properties.Settings.Default.alert;
            this.checkBox_alert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_alert.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "alert", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_alert.Enabled = false;
            this.checkBox_alert.ForeColor = System.Drawing.Color.White;
            this.checkBox_alert.Location = new System.Drawing.Point(126, 246);
            this.checkBox_alert.Name = "checkBox_alert";
            this.checkBox_alert.Size = new System.Drawing.Size(72, 16);
            this.checkBox_alert.TabIndex = 4;
            this.checkBox_alert.Text = "异常鸣笛";
            this.checkBox_alert.UseVisualStyleBackColor = false;
            // 
            // checkBox_qucikTraining
            // 
            this.checkBox_qucikTraining.AutoSize = true;
            this.checkBox_qucikTraining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.checkBox_qucikTraining.Checked = global::MoleAssist.Properties.Settings.Default.qucikTraining;
            this.checkBox_qucikTraining.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "qucikTraining", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_qucikTraining.Enabled = false;
            this.checkBox_qucikTraining.ForeColor = System.Drawing.Color.White;
            this.checkBox_qucikTraining.Location = new System.Drawing.Point(37, 224);
            this.checkBox_qucikTraining.Name = "checkBox_qucikTraining";
            this.checkBox_qucikTraining.Size = new System.Drawing.Size(72, 16);
            this.checkBox_qucikTraining.TabIndex = 3;
            this.checkBox_qucikTraining.Text = "精灵带练";
            this.checkBox_qucikTraining.UseVisualStyleBackColor = false;
            this.checkBox_qucikTraining.CheckedChanged += new System.EventHandler(this.checkBox_qucikTraining_CheckedChanged);
            // 
            // checkBox_isAutoIdentify
            // 
            this.checkBox_isAutoIdentify.AutoSize = true;
            this.checkBox_isAutoIdentify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.checkBox_isAutoIdentify.Checked = global::MoleAssist.Properties.Settings.Default.isAutoIdentify;
            this.checkBox_isAutoIdentify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_isAutoIdentify.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "isAutoIdentify", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_isAutoIdentify.Enabled = false;
            this.checkBox_isAutoIdentify.ForeColor = System.Drawing.Color.White;
            this.checkBox_isAutoIdentify.Location = new System.Drawing.Point(37, 268);
            this.checkBox_isAutoIdentify.Name = "checkBox_isAutoIdentify";
            this.checkBox_isAutoIdentify.Size = new System.Drawing.Size(84, 16);
            this.checkBox_isAutoIdentify.TabIndex = 2;
            this.checkBox_isAutoIdentify.Text = "自动过验证";
            this.checkBox_isAutoIdentify.UseVisualStyleBackColor = false;
            // 
            // checkBox_useAnger
            // 
            this.checkBox_useAnger.AutoSize = true;
            this.checkBox_useAnger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.checkBox_useAnger.Checked = global::MoleAssist.Properties.Settings.Default.useAnger;
            this.checkBox_useAnger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_useAnger.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "useAnger", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_useAnger.Enabled = false;
            this.checkBox_useAnger.ForeColor = System.Drawing.Color.White;
            this.checkBox_useAnger.Location = new System.Drawing.Point(126, 224);
            this.checkBox_useAnger.Name = "checkBox_useAnger";
            this.checkBox_useAnger.Size = new System.Drawing.Size(72, 16);
            this.checkBox_useAnger.TabIndex = 1;
            this.checkBox_useAnger.Text = "自动放怒";
            this.checkBox_useAnger.UseVisualStyleBackColor = false;
            // 
            // checkBox_ReHP
            // 
            this.checkBox_ReHP.AutoSize = true;
            this.checkBox_ReHP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.checkBox_ReHP.Checked = global::MoleAssist.Properties.Settings.Default.ReHP;
            this.checkBox_ReHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ReHP.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "ReHP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ReHP.ForeColor = System.Drawing.Color.White;
            this.checkBox_ReHP.Location = new System.Drawing.Point(37, 246);
            this.checkBox_ReHP.Name = "checkBox_ReHP";
            this.checkBox_ReHP.Size = new System.Drawing.Size(72, 16);
            this.checkBox_ReHP.TabIndex = 0;
            this.checkBox_ReHP.Text = "自动回血";
            this.checkBox_ReHP.UseVisualStyleBackColor = false;
            // 
            // radio_modeSelect1
            // 
            this.radio_modeSelect1.AutoSize = true;
            this.radio_modeSelect1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.radio_modeSelect1.Checked = true;
            this.radio_modeSelect1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radio_modeSelect1.Location = new System.Drawing.Point(24, 49);
            this.radio_modeSelect1.Name = "radio_modeSelect1";
            this.radio_modeSelect1.Size = new System.Drawing.Size(83, 16);
            this.radio_modeSelect1.TabIndex = 1;
            this.radio_modeSelect1.TabStop = true;
            this.radio_modeSelect1.Text = "野      怪";
            this.radio_modeSelect1.UseVisualStyleBackColor = false;
            // 
            // radio_modeSelect2
            // 
            this.radio_modeSelect2.AutoSize = true;
            this.radio_modeSelect2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.radio_modeSelect2.Enabled = false;
            this.radio_modeSelect2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radio_modeSelect2.Location = new System.Drawing.Point(24, 75);
            this.radio_modeSelect2.Name = "radio_modeSelect2";
            this.radio_modeSelect2.Size = new System.Drawing.Size(83, 16);
            this.radio_modeSelect2.TabIndex = 2;
            this.radio_modeSelect2.Text = "NPC / 忍者";
            this.radio_modeSelect2.UseVisualStyleBackColor = false;
            this.radio_modeSelect2.CheckedChanged += new System.EventHandler(this.radio_modeSelect2_CheckedChanged);
            // 
            // radio_modeSelect3
            // 
            this.radio_modeSelect3.AutoSize = true;
            this.radio_modeSelect3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.radio_modeSelect3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radio_modeSelect3.Location = new System.Drawing.Point(24, 103);
            this.radio_modeSelect3.Name = "radio_modeSelect3";
            this.radio_modeSelect3.Size = new System.Drawing.Size(83, 16);
            this.radio_modeSelect3.TabIndex = 3;
            this.radio_modeSelect3.Text = "自定义坐标";
            this.radio_modeSelect3.UseVisualStyleBackColor = false;
            this.radio_modeSelect3.CheckedChanged += new System.EventHandler(this.radio_modeSelect3_CheckedChanged);
            // 
            // combo_NPCSelect
            // 
            this.combo_NPCSelect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.combo_NPCSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_NPCSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.combo_NPCSelect.Location = new System.Drawing.Point(123, 74);
            this.combo_NPCSelect.Name = "combo_NPCSelect";
            this.combo_NPCSelect.Size = new System.Drawing.Size(73, 20);
            this.combo_NPCSelect.TabIndex = 4;
            this.combo_NPCSelect.Visible = false;
            // 
            // btn_getxy
            // 
            this.btn_getxy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_getxy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_getxy.Location = new System.Drawing.Point(121, 101);
            this.btn_getxy.Name = "btn_getxy";
            this.btn_getxy.Size = new System.Drawing.Size(75, 20);
            this.btn_getxy.TabIndex = 9;
            this.btn_getxy.Text = "获取坐标";
            this.btn_getxy.UseVisualStyleBackColor = false;
            this.btn_getxy.Visible = false;
            this.btn_getxy.Click += new System.EventHandler(this.btn_getxy_Click);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_start.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_start.Location = new System.Drawing.Point(24, 128);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(89, 23);
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // textBox_customY
            // 
            this.textBox_customY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.textBox_customY.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_customY.Location = new System.Drawing.Point(167, 128);
            this.textBox_customY.MaxLength = 6;
            this.textBox_customY.Name = "textBox_customY";
            this.textBox_customY.ReadOnly = true;
            this.textBox_customY.Size = new System.Drawing.Size(29, 21);
            this.textBox_customY.TabIndex = 15;
            this.textBox_customY.Visible = false;
            this.textBox_customY.WordWrap = false;
            // 
            // textBox_customX
            // 
            this.textBox_customX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.textBox_customX.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_customX.Location = new System.Drawing.Point(123, 128);
            this.textBox_customX.MaxLength = 6;
            this.textBox_customX.Name = "textBox_customX";
            this.textBox_customX.ReadOnly = true;
            this.textBox_customX.Size = new System.Drawing.Size(29, 21);
            this.textBox_customX.TabIndex = 14;
            this.textBox_customX.Visible = false;
            this.textBox_customX.WordWrap = false;
            // 
            // btn_clearCache
            // 
            this.btn_clearCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.btn_clearCache.ForeColor = System.Drawing.Color.White;
            this.btn_clearCache.Location = new System.Drawing.Point(128, 356);
            this.btn_clearCache.Name = "btn_clearCache";
            this.btn_clearCache.Size = new System.Drawing.Size(75, 23);
            this.btn_clearCache.TabIndex = 2;
            this.btn_clearCache.Text = "清除缓存";
            this.btn_clearCache.UseVisualStyleBackColor = false;
            this.btn_clearCache.Click += new System.EventHandler(this.btn_clearCache_Click);
            // 
            // btn_refreshGame
            // 
            this.btn_refreshGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.btn_refreshGame.ForeColor = System.Drawing.Color.White;
            this.btn_refreshGame.Location = new System.Drawing.Point(26, 356);
            this.btn_refreshGame.Name = "btn_refreshGame";
            this.btn_refreshGame.Size = new System.Drawing.Size(75, 23);
            this.btn_refreshGame.TabIndex = 1;
            this.btn_refreshGame.Text = "刷新游戏";
            this.btn_refreshGame.UseVisualStyleBackColor = false;
            this.btn_refreshGame.Click += new System.EventHandler(this.btn_refreshGame_Click);
            // 
            // checkBox_onTop
            // 
            this.checkBox_onTop.AutoSize = true;
            this.checkBox_onTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(89)))), ((int)(((byte)(174)))));
            this.checkBox_onTop.Checked = global::MoleAssist.Properties.Settings.Default.OnTop;
            this.checkBox_onTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MoleAssist.Properties.Settings.Default, "OnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_onTop.ForeColor = System.Drawing.Color.White;
            this.checkBox_onTop.Location = new System.Drawing.Point(26, 334);
            this.checkBox_onTop.Name = "checkBox_onTop";
            this.checkBox_onTop.Size = new System.Drawing.Size(72, 16);
            this.checkBox_onTop.TabIndex = 0;
            this.checkBox_onTop.Text = "置顶显示";
            this.checkBox_onTop.UseVisualStyleBackColor = false;
            this.checkBox_onTop.CheckedChanged += new System.EventHandler(this.checkBox_onTop_CheckedChanged);
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
            this.webBrowser_game.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_game_DocumentCompleted);            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1170, 304);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 52);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1170, 304);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 52);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.btn_clearCache);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_refreshGame);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBox_onTop);
            this.groupBox2.Controls.Add(this.radio_modeSelect1);
            this.groupBox2.Controls.Add(this.textbox_SkillOrder);
            this.groupBox2.Controls.Add(this.textBox_customY);
            this.groupBox2.Controls.Add(label_skillOrder);
            this.groupBox2.Controls.Add(this.combo_skillMode);
            this.groupBox2.Controls.Add(this.btn_getxy);
            this.groupBox2.Controls.Add(this.combo_identifyFailed);
            this.groupBox2.Controls.Add(this.radio_modeSelect2);
            this.groupBox2.Controls.Add(this.checkBox_alert);
            this.groupBox2.Controls.Add(this.radio_modeSelect3);
            this.groupBox2.Controls.Add(this.checkBox_qucikTraining);
            this.groupBox2.Controls.Add(this.combo_NPCSelect);
            this.groupBox2.Controls.Add(this.checkBox_isAutoIdentify);
            this.groupBox2.Controls.Add(this.btn_start);
            this.groupBox2.Controls.Add(this.checkBox_useAnger);
            this.groupBox2.Controls.Add(this.textBox_customX);
            this.groupBox2.Controls.Add(this.checkBox_ReHP);
            this.groupBox2.Location = new System.Drawing.Point(949, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 415);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1200, 660);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1200, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.webBrowser_game);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.Text = "约瑟传说鼹鼠辅助";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.WebBrowser webBrowser_game;
        private System.Windows.Forms.Button btn_refreshGame;
        private System.Windows.Forms.CheckBox checkBox_onTop;
        private System.Windows.Forms.Button btn_clearCache;
        private System.Windows.Forms.TextBox textBox_customY;
        private System.Windows.Forms.TextBox textBox_customX;
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
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox3;

    }
}

