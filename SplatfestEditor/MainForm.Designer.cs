namespace SplatfestEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_Langs = new System.Windows.Forms.ToolStripComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox_neutralColor = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox_betaColor = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_betaShortName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_betaName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox_alphaColor = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_alphaShortName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_alphaName = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_waitButton = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox_cameraType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_emotion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_speaker = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_actionText = new System.Windows.Forms.TextBox();
            this.comboBox_newsType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_actions = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.value_festVer = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.value_festId = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_resultTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_endTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_startTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_announceTime = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_neutralColor)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_betaColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_alphaColor)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_festVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_festId)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripComboBox_Langs});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(438, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripComboBox_Langs
            // 
            this.toolStripComboBox_Langs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_Langs.Name = "toolStripComboBox_Langs";
            this.toolStripComboBox_Langs.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox_Langs.Visible = false;
            this.toolStripComboBox_Langs.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Langs_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(416, 324);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(408, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Teams";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.pictureBox_neutralColor);
            this.groupBox3.Location = new System.Drawing.Point(6, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 52);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Team Neutral";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Color :";
            // 
            // pictureBox_neutralColor
            // 
            this.pictureBox_neutralColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_neutralColor.Location = new System.Drawing.Point(45, 21);
            this.pictureBox_neutralColor.Name = "pictureBox_neutralColor";
            this.pictureBox_neutralColor.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_neutralColor.TabIndex = 4;
            this.pictureBox_neutralColor.TabStop = false;
            this.pictureBox_neutralColor.Click += new System.EventHandler(this.pictureBox_neutralColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.pictureBox_betaColor);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox_betaShortName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_betaName);
            this.groupBox2.Location = new System.Drawing.Point(6, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Team Beta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Color :";
            // 
            // pictureBox_betaColor
            // 
            this.pictureBox_betaColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_betaColor.Location = new System.Drawing.Point(45, 44);
            this.pictureBox_betaColor.Name = "pictureBox_betaColor";
            this.pictureBox_betaColor.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_betaColor.TabIndex = 4;
            this.pictureBox_betaColor.TabStop = false;
            this.pictureBox_betaColor.Click += new System.EventHandler(this.pictureBox_betaColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Short Name :";
            // 
            // textBox_betaShortName
            // 
            this.textBox_betaShortName.Location = new System.Drawing.Point(160, 74);
            this.textBox_betaShortName.Name = "textBox_betaShortName";
            this.textBox_betaShortName.Size = new System.Drawing.Size(208, 20);
            this.textBox_betaShortName.TabIndex = 2;
            this.textBox_betaShortName.Validated += new System.EventHandler(this.SaveTeams);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(117, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Name :";
            // 
            // textBox_betaName
            // 
            this.textBox_betaName.Location = new System.Drawing.Point(160, 19);
            this.textBox_betaName.Multiline = true;
            this.textBox_betaName.Name = "textBox_betaName";
            this.textBox_betaName.Size = new System.Drawing.Size(208, 49);
            this.textBox_betaName.TabIndex = 0;
            this.textBox_betaName.Validated += new System.EventHandler(this.SaveTeams);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox_alphaColor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_alphaShortName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_alphaName);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Team Alpha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Color :";
            // 
            // pictureBox_alphaColor
            // 
            this.pictureBox_alphaColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_alphaColor.Location = new System.Drawing.Point(45, 44);
            this.pictureBox_alphaColor.Name = "pictureBox_alphaColor";
            this.pictureBox_alphaColor.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_alphaColor.TabIndex = 4;
            this.pictureBox_alphaColor.TabStop = false;
            this.pictureBox_alphaColor.Click += new System.EventHandler(this.pictureBox_alphaColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Short Name :";
            // 
            // textBox_alphaShortName
            // 
            this.textBox_alphaShortName.Location = new System.Drawing.Point(160, 74);
            this.textBox_alphaShortName.Name = "textBox_alphaShortName";
            this.textBox_alphaShortName.Size = new System.Drawing.Size(208, 20);
            this.textBox_alphaShortName.TabIndex = 2;
            this.textBox_alphaShortName.Validated += new System.EventHandler(this.SaveTeams);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name :";
            // 
            // textBox_alphaName
            // 
            this.textBox_alphaName.Location = new System.Drawing.Point(160, 19);
            this.textBox_alphaName.Multiline = true;
            this.textBox_alphaName.Name = "textBox_alphaName";
            this.textBox_alphaName.Size = new System.Drawing.Size(208, 49);
            this.textBox_alphaName.TabIndex = 0;
            this.textBox_alphaName.Validated += new System.EventHandler(this.SaveTeams);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox_waitButton);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.comboBox_cameraType);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.comboBox_emotion);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox_speaker);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_actionText);
            this.tabPage1.Controls.Add(this.comboBox_newsType);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listBox_actions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(408, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "News";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox_waitButton
            // 
            this.checkBox_waitButton.AutoSize = true;
            this.checkBox_waitButton.Location = new System.Drawing.Point(238, 133);
            this.checkBox_waitButton.Name = "checkBox_waitButton";
            this.checkBox_waitButton.Size = new System.Drawing.Size(82, 17);
            this.checkBox_waitButton.TabIndex = 16;
            this.checkBox_waitButton.Text = "Wait Button";
            this.checkBox_waitButton.UseVisualStyleBackColor = true;
            this.checkBox_waitButton.CheckedChanged += new System.EventHandler(this.SaveScriptAction);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(139, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Camera Type :";
            // 
            // comboBox_cameraType
            // 
            this.comboBox_cameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cameraType.FormattingEnabled = true;
            this.comboBox_cameraType.Location = new System.Drawing.Point(217, 106);
            this.comboBox_cameraType.Name = "comboBox_cameraType";
            this.comboBox_cameraType.Size = new System.Drawing.Size(159, 21);
            this.comboBox_cameraType.TabIndex = 14;
            this.comboBox_cameraType.SelectedIndexChanged += new System.EventHandler(this.SaveScriptAction);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(164, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Emotion :";
            // 
            // comboBox_emotion
            // 
            this.comboBox_emotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_emotion.FormattingEnabled = true;
            this.comboBox_emotion.Location = new System.Drawing.Point(217, 79);
            this.comboBox_emotion.Name = "comboBox_emotion";
            this.comboBox_emotion.Size = new System.Drawing.Size(159, 21);
            this.comboBox_emotion.TabIndex = 12;
            this.comboBox_emotion.SelectedIndexChanged += new System.EventHandler(this.SaveScriptAction);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Speaker :";
            // 
            // comboBox_speaker
            // 
            this.comboBox_speaker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_speaker.FormattingEnabled = true;
            this.comboBox_speaker.Location = new System.Drawing.Point(217, 52);
            this.comboBox_speaker.Name = "comboBox_speaker";
            this.comboBox_speaker.Size = new System.Drawing.Size(159, 21);
            this.comboBox_speaker.TabIndex = 10;
            this.comboBox_speaker.SelectedIndexChanged += new System.EventHandler(this.SaveScriptAction);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text :";
            // 
            // textBox_actionText
            // 
            this.textBox_actionText.Location = new System.Drawing.Point(137, 161);
            this.textBox_actionText.Multiline = true;
            this.textBox_actionText.Name = "textBox_actionText";
            this.textBox_actionText.Size = new System.Drawing.Size(255, 121);
            this.textBox_actionText.TabIndex = 8;
            this.textBox_actionText.Validated += new System.EventHandler(this.SaveScriptAction);
            // 
            // comboBox_newsType
            // 
            this.comboBox_newsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_newsType.FormattingEnabled = true;
            this.comboBox_newsType.Location = new System.Drawing.Point(144, 6);
            this.comboBox_newsType.Name = "comboBox_newsType";
            this.comboBox_newsType.Size = new System.Drawing.Size(121, 21);
            this.comboBox_newsType.TabIndex = 5;
            this.comboBox_newsType.SelectedIndexChanged += new System.EventHandler(this.comboBox_newsType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "News Types :";
            // 
            // listBox_actions
            // 
            this.listBox_actions.FormattingEnabled = true;
            this.listBox_actions.Location = new System.Drawing.Point(17, 44);
            this.listBox_actions.Name = "listBox_actions";
            this.listBox_actions.Size = new System.Drawing.Size(112, 238);
            this.listBox_actions.TabIndex = 3;
            this.listBox_actions.SelectedIndexChanged += new System.EventHandler(this.listBox_actions_SelectedIndexChanged);
            this.listBox_actions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_actions_MouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.value_festVer);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.value_festId);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(408, 298);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Other";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(94, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Version :";
            // 
            // value_festVer
            // 
            this.value_festVer.Location = new System.Drawing.Point(144, 181);
            this.value_festVer.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.value_festVer.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.value_festVer.Name = "value_festVer";
            this.value_festVer.Size = new System.Drawing.Size(120, 20);
            this.value_festVer.TabIndex = 4;
            this.value_festVer.ValueChanged += new System.EventHandler(this.SaveOther);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(79, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Festival ID :";
            // 
            // value_festId
            // 
            this.value_festId.Location = new System.Drawing.Point(144, 157);
            this.value_festId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.value_festId.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.value_festId.Name = "value_festId";
            this.value_festId.Size = new System.Drawing.Size(120, 20);
            this.value_festId.TabIndex = 2;
            this.value_festId.ValueChanged += new System.EventHandler(this.SaveOther);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox_resultTime);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.textBox_endTime);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.textBox_startTime);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textBox_announceTime);
            this.groupBox4.Location = new System.Drawing.Point(80, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 117);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Result :";
            // 
            // textBox_resultTime
            // 
            this.textBox_resultTime.Location = new System.Drawing.Point(75, 82);
            this.textBox_resultTime.Name = "textBox_resultTime";
            this.textBox_resultTime.Size = new System.Drawing.Size(168, 20);
            this.textBox_resultTime.TabIndex = 6;
            this.textBox_resultTime.Validated += new System.EventHandler(this.SaveOther);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "End :";
            // 
            // textBox_endTime
            // 
            this.textBox_endTime.Location = new System.Drawing.Point(75, 61);
            this.textBox_endTime.Name = "textBox_endTime";
            this.textBox_endTime.Size = new System.Drawing.Size(168, 20);
            this.textBox_endTime.TabIndex = 4;
            this.textBox_endTime.Validated += new System.EventHandler(this.SaveOther);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Start :";
            // 
            // textBox_startTime
            // 
            this.textBox_startTime.Location = new System.Drawing.Point(75, 40);
            this.textBox_startTime.Name = "textBox_startTime";
            this.textBox_startTime.Size = new System.Drawing.Size(168, 20);
            this.textBox_startTime.TabIndex = 2;
            this.textBox_startTime.Validated += new System.EventHandler(this.SaveOther);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Announce :";
            // 
            // textBox_announceTime
            // 
            this.textBox_announceTime.Location = new System.Drawing.Point(75, 19);
            this.textBox_announceTime.Name = "textBox_announceTime";
            this.textBox_announceTime.Size = new System.Drawing.Size(168, 20);
            this.textBox_announceTime.TabIndex = 0;
            this.textBox_announceTime.Validated += new System.EventHandler(this.SaveOther);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 365);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_neutralColor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_betaColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_alphaColor)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_festVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_festId)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Langs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox_actions;
        private System.Windows.Forms.ComboBox comboBox_newsType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_actionText;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_alphaShortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_alphaName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox_alphaColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox_neutralColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox_betaColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_betaShortName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_betaName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_resultTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_endTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_startTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_announceTime;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox_cameraType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_emotion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_speaker;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown value_festVer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown value_festId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_waitButton;
    }
}

