namespace MSSMS
{
    partial class RequestReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestReports));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.monthlyReports = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePickerMonthOnly = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateMonthlyReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetMonthlyReport = new System.Windows.Forms.Button();
            this.comboBoxMonthlyReport = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dailyReports = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePickerDailyReport = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateDailyReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResetDailyReport = new System.Windows.Forms.Button();
            this.comboBoxDailyReport = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.durationReports = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerDurationEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDurationStart = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateDurationReport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetDurationReport = new System.Windows.Forms.Button();
            this.comboBoxDurationReport = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yearlyReports = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerYearOnly = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateYearlyReport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnResetYearlyReport = new System.Windows.Forms.Button();
            this.comboBoxYearlyReport = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelSeperator = new System.Windows.Forms.Panel();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.monthlyReports.SuspendLayout();
            this.panel4.SuspendLayout();
            this.dailyReports.SuspendLayout();
            this.panel3.SuspendLayout();
            this.durationReports.SuspendLayout();
            this.panel2.SuspendLayout();
            this.yearlyReports.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(161, 565);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 21);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(70, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(155, 25);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Request Reports";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(716, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Please select the type of report needs to be generated with a specific date, dura" +
    "tion or a month.";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Controls.Add(this.lblDescription);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 99);
            this.panelHeader.TabIndex = 30;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.BackgroundImage")));
            this.pictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxIcon.Location = new System.Drawing.Point(11, 10);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(57, 57);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 4;
            this.pictureBoxIcon.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelBody);
            this.panelContainer.Controls.Add(this.panelSeperator);
            this.panelContainer.Controls.Add(this.panelHeader);
            this.panelContainer.Controls.Add(this.lblCopyright);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 57);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 595);
            this.panelContainer.TabIndex = 41;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.tabControl1);
            this.panelBody.Controls.Add(this.panel5);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 113);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(800, 440);
            this.panelBody.TabIndex = 33;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.monthlyReports);
            this.tabControl1.Controls.Add(this.dailyReports);
            this.tabControl1.Controls.Add(this.durationReports);
            this.tabControl1.Controls.Add(this.yearlyReports);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 116);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 310);
            this.tabControl1.TabIndex = 34;
            // 
            // monthlyReports
            // 
            this.monthlyReports.AutoScroll = true;
            this.monthlyReports.Controls.Add(this.panel4);
            this.monthlyReports.Location = new System.Drawing.Point(4, 26);
            this.monthlyReports.Name = "monthlyReports";
            this.monthlyReports.Padding = new System.Windows.Forms.Padding(3);
            this.monthlyReports.Size = new System.Drawing.Size(792, 280);
            this.monthlyReports.TabIndex = 0;
            this.monthlyReports.Text = "Monthly Reports";
            this.monthlyReports.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.dateTimePickerMonthOnly);
            this.panel4.Controls.Add(this.btnGenerateMonthlyReport);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnResetMonthlyReport);
            this.panel4.Controls.Add(this.comboBoxMonthlyReport);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(90, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(608, 208);
            this.panel4.TabIndex = 63;
            // 
            // dateTimePickerMonthOnly
            // 
            this.dateTimePickerMonthOnly.CustomFormat = "MM/yyyy";
            this.dateTimePickerMonthOnly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMonthOnly.Location = new System.Drawing.Point(140, 74);
            this.dateTimePickerMonthOnly.MinDate = new System.DateTime(1975, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerMonthOnly.Name = "dateTimePickerMonthOnly";
            this.dateTimePickerMonthOnly.Size = new System.Drawing.Size(227, 22);
            this.dateTimePickerMonthOnly.TabIndex = 62;
            // 
            // btnGenerateMonthlyReport
            // 
            this.btnGenerateMonthlyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateMonthlyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnGenerateMonthlyReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateMonthlyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGenerateMonthlyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnGenerateMonthlyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateMonthlyReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateMonthlyReport.Location = new System.Drawing.Point(458, 159);
            this.btnGenerateMonthlyReport.Name = "btnGenerateMonthlyReport";
            this.btnGenerateMonthlyReport.Size = new System.Drawing.Size(124, 37);
            this.btnGenerateMonthlyReport.TabIndex = 61;
            this.btnGenerateMonthlyReport.Text = "&Generate Report";
            this.btnGenerateMonthlyReport.UseVisualStyleBackColor = false;
            this.btnGenerateMonthlyReport.Click += new System.EventHandler(this.btnGenerateMonthlyReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 36);
            this.label1.TabIndex = 59;
            this.label1.Text = "Report Type:\r\n(Name)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetMonthlyReport
            // 
            this.btnResetMonthlyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetMonthlyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnResetMonthlyReport.FlatAppearance.BorderSize = 0;
            this.btnResetMonthlyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnResetMonthlyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnResetMonthlyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetMonthlyReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetMonthlyReport.Location = new System.Drawing.Point(358, 159);
            this.btnResetMonthlyReport.Name = "btnResetMonthlyReport";
            this.btnResetMonthlyReport.Size = new System.Drawing.Size(90, 37);
            this.btnResetMonthlyReport.TabIndex = 60;
            this.btnResetMonthlyReport.Text = "&Reset";
            this.btnResetMonthlyReport.UseVisualStyleBackColor = false;
            this.btnResetMonthlyReport.Click += new System.EventHandler(this.btnResetMonthlyReport_Click);
            // 
            // comboBoxMonthlyReport
            // 
            this.comboBoxMonthlyReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonthlyReport.FormattingEnabled = true;
            this.comboBoxMonthlyReport.Location = new System.Drawing.Point(140, 21);
            this.comboBoxMonthlyReport.Name = "comboBoxMonthlyReport";
            this.comboBoxMonthlyReport.Size = new System.Drawing.Size(442, 25);
            this.comboBoxMonthlyReport.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 58;
            this.label3.Text = "Select Month/Year:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dailyReports
            // 
            this.dailyReports.Controls.Add(this.panel3);
            this.dailyReports.Location = new System.Drawing.Point(4, 22);
            this.dailyReports.Name = "dailyReports";
            this.dailyReports.Padding = new System.Windows.Forms.Padding(3);
            this.dailyReports.Size = new System.Drawing.Size(792, 284);
            this.dailyReports.TabIndex = 1;
            this.dailyReports.Text = "On-demand reports (Daily)";
            this.dailyReports.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.dateTimePickerDailyReport);
            this.panel3.Controls.Add(this.btnGenerateDailyReport);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnResetDailyReport);
            this.panel3.Controls.Add(this.comboBoxDailyReport);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(85, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 205);
            this.panel3.TabIndex = 57;
            // 
            // dateTimePickerDailyReport
            // 
            this.dateTimePickerDailyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDailyReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDailyReport.Location = new System.Drawing.Point(136, 74);
            this.dateTimePickerDailyReport.Name = "dateTimePickerDailyReport";
            this.dateTimePickerDailyReport.Size = new System.Drawing.Size(227, 22);
            this.dateTimePickerDailyReport.TabIndex = 56;
            // 
            // btnGenerateDailyReport
            // 
            this.btnGenerateDailyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateDailyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnGenerateDailyReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateDailyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGenerateDailyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnGenerateDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateDailyReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateDailyReport.Location = new System.Drawing.Point(454, 159);
            this.btnGenerateDailyReport.Name = "btnGenerateDailyReport";
            this.btnGenerateDailyReport.Size = new System.Drawing.Size(124, 37);
            this.btnGenerateDailyReport.TabIndex = 55;
            this.btnGenerateDailyReport.Text = "&Generate Report";
            this.btnGenerateDailyReport.UseVisualStyleBackColor = false;
            this.btnGenerateDailyReport.Click += new System.EventHandler(this.btnGenerateDailyReport_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 36);
            this.label2.TabIndex = 47;
            this.label2.Text = "Report Type:\r\n(Name)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetDailyReport
            // 
            this.btnResetDailyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetDailyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnResetDailyReport.FlatAppearance.BorderSize = 0;
            this.btnResetDailyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnResetDailyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnResetDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetDailyReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetDailyReport.Location = new System.Drawing.Point(354, 159);
            this.btnResetDailyReport.Name = "btnResetDailyReport";
            this.btnResetDailyReport.Size = new System.Drawing.Size(90, 37);
            this.btnResetDailyReport.TabIndex = 54;
            this.btnResetDailyReport.Text = "&Reset";
            this.btnResetDailyReport.UseVisualStyleBackColor = false;
            this.btnResetDailyReport.Click += new System.EventHandler(this.btnResetDailyReport_Click);
            // 
            // comboBoxDailyReport
            // 
            this.comboBoxDailyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDailyReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDailyReport.FormattingEnabled = true;
            this.comboBoxDailyReport.Location = new System.Drawing.Point(136, 21);
            this.comboBoxDailyReport.Name = "comboBoxDailyReport";
            this.comboBoxDailyReport.Size = new System.Drawing.Size(442, 25);
            this.comboBoxDailyReport.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 18);
            this.label10.TabIndex = 34;
            this.label10.Text = "Select Date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // durationReports
            // 
            this.durationReports.Controls.Add(this.panel2);
            this.durationReports.Location = new System.Drawing.Point(4, 22);
            this.durationReports.Name = "durationReports";
            this.durationReports.Size = new System.Drawing.Size(792, 284);
            this.durationReports.TabIndex = 2;
            this.durationReports.Text = "On-demand reports (Duration)";
            this.durationReports.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.dateTimePickerDurationEnd);
            this.panel2.Controls.Add(this.dateTimePickerDurationStart);
            this.panel2.Controls.Add(this.btnGenerateDurationReport);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnResetDurationReport);
            this.panel2.Controls.Add(this.comboBoxDurationReport);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(75, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 217);
            this.panel2.TabIndex = 63;
            // 
            // dateTimePickerDurationEnd
            // 
            this.dateTimePickerDurationEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDurationEnd.Location = new System.Drawing.Point(146, 125);
            this.dateTimePickerDurationEnd.Name = "dateTimePickerDurationEnd";
            this.dateTimePickerDurationEnd.Size = new System.Drawing.Size(131, 22);
            this.dateTimePickerDurationEnd.TabIndex = 62;
            // 
            // dateTimePickerDurationStart
            // 
            this.dateTimePickerDurationStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDurationStart.Location = new System.Drawing.Point(146, 78);
            this.dateTimePickerDurationStart.Name = "dateTimePickerDurationStart";
            this.dateTimePickerDurationStart.Size = new System.Drawing.Size(131, 22);
            this.dateTimePickerDurationStart.TabIndex = 62;
            // 
            // btnGenerateDurationReport
            // 
            this.btnGenerateDurationReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateDurationReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnGenerateDurationReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateDurationReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGenerateDurationReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnGenerateDurationReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateDurationReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateDurationReport.Location = new System.Drawing.Point(464, 163);
            this.btnGenerateDurationReport.Name = "btnGenerateDurationReport";
            this.btnGenerateDurationReport.Size = new System.Drawing.Size(124, 37);
            this.btnGenerateDurationReport.TabIndex = 61;
            this.btnGenerateDurationReport.Text = "&Generate Report";
            this.btnGenerateDurationReport.UseVisualStyleBackColor = false;
            this.btnGenerateDurationReport.Click += new System.EventHandler(this.btnGenerateDurationReport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 36);
            this.label4.TabIndex = 59;
            this.label4.Text = "Report Type:\r\n(Name)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetDurationReport
            // 
            this.btnResetDurationReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetDurationReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnResetDurationReport.FlatAppearance.BorderSize = 0;
            this.btnResetDurationReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnResetDurationReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnResetDurationReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetDurationReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetDurationReport.Location = new System.Drawing.Point(364, 163);
            this.btnResetDurationReport.Name = "btnResetDurationReport";
            this.btnResetDurationReport.Size = new System.Drawing.Size(90, 37);
            this.btnResetDurationReport.TabIndex = 60;
            this.btnResetDurationReport.Text = "&Reset";
            this.btnResetDurationReport.UseVisualStyleBackColor = false;
            this.btnResetDurationReport.Click += new System.EventHandler(this.btnResetDurationReport_Click);
            // 
            // comboBoxDurationReport
            // 
            this.comboBoxDurationReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDurationReport.FormattingEnabled = true;
            this.comboBoxDurationReport.Location = new System.Drawing.Point(146, 25);
            this.comboBoxDurationReport.Name = "comboBoxDurationReport";
            this.comboBoxDurationReport.Size = new System.Drawing.Size(442, 25);
            this.comboBoxDurationReport.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 58;
            this.label8.Text = "To (Date):";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 58;
            this.label5.Text = "From (Date):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yearlyReports
            // 
            this.yearlyReports.Controls.Add(this.panel1);
            this.yearlyReports.Location = new System.Drawing.Point(4, 22);
            this.yearlyReports.Name = "yearlyReports";
            this.yearlyReports.Size = new System.Drawing.Size(792, 284);
            this.yearlyReports.TabIndex = 3;
            this.yearlyReports.Text = "Year-End Reports";
            this.yearlyReports.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.dateTimePickerYearOnly);
            this.panel1.Controls.Add(this.btnGenerateYearlyReport);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnResetYearlyReport);
            this.panel1.Controls.Add(this.comboBoxYearlyReport);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(80, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 212);
            this.panel1.TabIndex = 63;
            // 
            // dateTimePickerYearOnly
            // 
            this.dateTimePickerYearOnly.CustomFormat = "yyyy";
            this.dateTimePickerYearOnly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerYearOnly.Location = new System.Drawing.Point(141, 76);
            this.dateTimePickerYearOnly.Name = "dateTimePickerYearOnly";
            this.dateTimePickerYearOnly.Size = new System.Drawing.Size(227, 22);
            this.dateTimePickerYearOnly.TabIndex = 62;
            // 
            // btnGenerateYearlyReport
            // 
            this.btnGenerateYearlyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateYearlyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnGenerateYearlyReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateYearlyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnGenerateYearlyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnGenerateYearlyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateYearlyReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateYearlyReport.Location = new System.Drawing.Point(459, 161);
            this.btnGenerateYearlyReport.Name = "btnGenerateYearlyReport";
            this.btnGenerateYearlyReport.Size = new System.Drawing.Size(124, 37);
            this.btnGenerateYearlyReport.TabIndex = 61;
            this.btnGenerateYearlyReport.Text = "&Generate Report";
            this.btnGenerateYearlyReport.UseVisualStyleBackColor = false;
            this.btnGenerateYearlyReport.Click += new System.EventHandler(this.btnGenerateYearlyReport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 36);
            this.label6.TabIndex = 59;
            this.label6.Text = "Report Type:\r\n(Name)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetYearlyReport
            // 
            this.btnResetYearlyReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetYearlyReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnResetYearlyReport.FlatAppearance.BorderSize = 0;
            this.btnResetYearlyReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnResetYearlyReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnResetYearlyReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetYearlyReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetYearlyReport.Location = new System.Drawing.Point(359, 161);
            this.btnResetYearlyReport.Name = "btnResetYearlyReport";
            this.btnResetYearlyReport.Size = new System.Drawing.Size(90, 37);
            this.btnResetYearlyReport.TabIndex = 60;
            this.btnResetYearlyReport.Text = "&Reset";
            this.btnResetYearlyReport.UseVisualStyleBackColor = false;
            this.btnResetYearlyReport.Click += new System.EventHandler(this.btnResetYearlyReport_Click);
            // 
            // comboBoxYearlyReport
            // 
            this.comboBoxYearlyReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearlyReport.FormattingEnabled = true;
            this.comboBoxYearlyReport.Location = new System.Drawing.Point(141, 23);
            this.comboBoxYearlyReport.Name = "comboBoxYearlyReport";
            this.comboBoxYearlyReport.Size = new System.Drawing.Size(442, 25);
            this.comboBoxYearlyReport.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 58;
            this.label7.Text = "Select Year:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 116);
            this.panel5.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.label9.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(87, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 18);
            this.label9.TabIndex = 42;
            this.label9.Text = "Note";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.label12.Location = new System.Drawing.Point(87, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(597, 54);
            this.label12.TabIndex = 41;
            this.label12.Text = resources.GetString("label12.Text");
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSeperator
            // 
            this.panelSeperator.AutoScroll = true;
            this.panelSeperator.BackColor = System.Drawing.SystemColors.Control;
            this.panelSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeperator.Location = new System.Drawing.Point(0, 99);
            this.panelSeperator.Name = "panelSeperator";
            this.panelSeperator.Size = new System.Drawing.Size(800, 14);
            this.panelSeperator.TabIndex = 32;
            // 
            // btnCloseInAppNotification
            // 
            this.btnCloseInAppNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseInAppNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCloseInAppNotification.FlatAppearance.BorderSize = 0;
            this.btnCloseInAppNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(43)))), ((int)(((byte)(33)))));
            this.btnCloseInAppNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCloseInAppNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseInAppNotification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(705, 10);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 20;
            this.btnCloseInAppNotification.Text = "Close";
            this.btnCloseInAppNotification.UseVisualStyleBackColor = false;
            this.btnCloseInAppNotification.Click += new System.EventHandler(this.btnCloseInAppNotification_Click);
            // 
            // lableInAppNotification
            // 
            this.lableInAppNotification.BackColor = System.Drawing.Color.Transparent;
            this.lableInAppNotification.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableInAppNotification.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lableInAppNotification.Location = new System.Drawing.Point(59, 6);
            this.lableInAppNotification.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lableInAppNotification.Name = "lableInAppNotification";
            this.lableInAppNotification.Size = new System.Drawing.Size(598, 47);
            this.lableInAppNotification.TabIndex = 19;
            this.lableInAppNotification.Text = "WARNING! Data Not Saved due to a Server Error. \r\nError Code: 552";
            this.lableInAppNotification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelInAppNotifications
            // 
            this.panelInAppNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.panelInAppNotifications.Controls.Add(this.btnCloseInAppNotification);
            this.panelInAppNotifications.Controls.Add(this.lableInAppNotification);
            this.panelInAppNotifications.Controls.Add(this.pbInAppNotification);
            this.panelInAppNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInAppNotifications.Location = new System.Drawing.Point(0, 0);
            this.panelInAppNotifications.Name = "panelInAppNotifications";
            this.panelInAppNotifications.Size = new System.Drawing.Size(800, 57);
            this.panelInAppNotifications.TabIndex = 40;
            // 
            // pbInAppNotification
            // 
            this.pbInAppNotification.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbInAppNotification.BackgroundImage")));
            this.pbInAppNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInAppNotification.ErrorImage = null;
            this.pbInAppNotification.Location = new System.Drawing.Point(8, 10);
            this.pbInAppNotification.Name = "pbInAppNotification";
            this.pbInAppNotification.Size = new System.Drawing.Size(44, 38);
            this.pbInAppNotification.TabIndex = 0;
            this.pbInAppNotification.TabStop = false;
            // 
            // RequestReports
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RequestReports";
            this.Text = "RequestReports";
            this.Load += new System.EventHandler(this.RequestReports_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.monthlyReports.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.dailyReports.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.durationReports.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.yearlyReports.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelSeperator;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage monthlyReports;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePickerMonthOnly;
        private System.Windows.Forms.Button btnGenerateMonthlyReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetMonthlyReport;
        private System.Windows.Forms.ComboBox comboBoxMonthlyReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage dailyReports;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePickerDailyReport;
        private System.Windows.Forms.Button btnGenerateDailyReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResetDailyReport;
        private System.Windows.Forms.ComboBox comboBoxDailyReport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage durationReports;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDurationEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDurationStart;
        private System.Windows.Forms.Button btnGenerateDurationReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnResetDurationReport;
        private System.Windows.Forms.ComboBox comboBoxDurationReport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage yearlyReports;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerYearOnly;
        private System.Windows.Forms.Button btnGenerateYearlyReport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnResetYearlyReport;
        private System.Windows.Forms.ComboBox comboBoxYearlyReport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
    }
}