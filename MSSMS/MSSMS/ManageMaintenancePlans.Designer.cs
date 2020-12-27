namespace MSSMS
{
    partial class ManageMaintenancePlans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageMaintenancePlans));
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.AddMaintenancePlan = new System.Windows.Forms.Button();
            this.comboBoxColumnOIP = new System.Windows.Forms.ComboBox();
            this.textBoxKeywordOIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchOIP = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panelOIPBody = new System.Windows.Forms.Panel();
            this.dataGridMaintenancePlans = new System.Windows.Forms.DataGridView();
            this.planname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submittedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitteddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approveddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrintOIP = new System.Windows.Forms.Button();
            this.btnRefreshOIP = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelOIPBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMaintenancePlans)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
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
            // btnCloseInAppNotification
            // 
            this.btnCloseInAppNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseInAppNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCloseInAppNotification.FlatAppearance.BorderSize = 0;
            this.btnCloseInAppNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(43)))), ((int)(((byte)(33)))));
            this.btnCloseInAppNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCloseInAppNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseInAppNotification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(657, 10);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 20;
            this.btnCloseInAppNotification.Text = "Close";
            this.btnCloseInAppNotification.UseVisualStyleBackColor = false;
            this.btnCloseInAppNotification.Click += new System.EventHandler(this.btnCloseInAppNotification_Click);
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(752, 57);
            this.panelInAppNotifications.TabIndex = 28;
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
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Controls.Add(this.lblDescription);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(752, 99);
            this.panelHeader.TabIndex = 7;
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
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(70, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(201, 25);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "MAINTENANCE PLANS";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(668, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "All Maintenance plans are listed down in the below table. Please use the filters " +
    "to optimize the search results.";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(145, 631);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 21);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelSearch
            // 
            this.panelSearch.AutoScroll = true;
            this.panelSearch.BackColor = System.Drawing.SystemColors.Control;
            this.panelSearch.Controls.Add(this.AddMaintenancePlan);
            this.panelSearch.Controls.Add(this.comboBoxColumnOIP);
            this.panelSearch.Controls.Add(this.textBoxKeywordOIP);
            this.panelSearch.Controls.Add(this.label5);
            this.panelSearch.Controls.Add(this.btnSearchOIP);
            this.panelSearch.Controls.Add(this.label7);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 99);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(752, 69);
            this.panelSearch.TabIndex = 27;
            // 
            // AddMaintenancePlan
            // 
            this.AddMaintenancePlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.AddMaintenancePlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddMaintenancePlan.FlatAppearance.BorderSize = 0;
            this.AddMaintenancePlan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.AddMaintenancePlan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.AddMaintenancePlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMaintenancePlan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddMaintenancePlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddMaintenancePlan.Location = new System.Drawing.Point(12, 16);
            this.AddMaintenancePlan.Name = "AddMaintenancePlan";
            this.AddMaintenancePlan.Size = new System.Drawing.Size(182, 37);
            this.AddMaintenancePlan.TabIndex = 31;
            this.AddMaintenancePlan.Text = "Add Maintenance Plan\r\n";
            this.AddMaintenancePlan.UseVisualStyleBackColor = false;
            this.AddMaintenancePlan.Click += new System.EventHandler(this.AddProductionPlan_Click);
            // 
            // comboBoxColumnOIP
            // 
            this.comboBoxColumnOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColumnOIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumnOIP.FormattingEnabled = true;
            this.comboBoxColumnOIP.Items.AddRange(new object[] {
            "All"});
            this.comboBoxColumnOIP.Location = new System.Drawing.Point(352, 27);
            this.comboBoxColumnOIP.Name = "comboBoxColumnOIP";
            this.comboBoxColumnOIP.Size = new System.Drawing.Size(114, 25);
            this.comboBoxColumnOIP.TabIndex = 30;
            // 
            // textBoxKeywordOIP
            // 
            this.textBoxKeywordOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeywordOIP.Location = new System.Drawing.Point(480, 30);
            this.textBoxKeywordOIP.Name = "textBoxKeywordOIP";
            this.textBoxKeywordOIP.Size = new System.Drawing.Size(152, 22);
            this.textBoxKeywordOIP.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Filter by:";
            // 
            // btnSearchOIP
            // 
            this.btnSearchOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearchOIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchOIP.BackgroundImage")));
            this.btnSearchOIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchOIP.FlatAppearance.BorderSize = 0;
            this.btnSearchOIP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSearchOIP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnSearchOIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchOIP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchOIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchOIP.Location = new System.Drawing.Point(642, 16);
            this.btnSearchOIP.Name = "btnSearchOIP";
            this.btnSearchOIP.Size = new System.Drawing.Size(96, 37);
            this.btnSearchOIP.TabIndex = 27;
            this.btnSearchOIP.Text = "      Search";
            this.btnSearchOIP.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Keyword:";
            // 
            // panelOIPBody
            // 
            this.panelOIPBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelOIPBody.Controls.Add(this.dataGridMaintenancePlans);
            this.panelOIPBody.Controls.Add(this.btnPrintOIP);
            this.panelOIPBody.Controls.Add(this.btnRefreshOIP);
            this.panelOIPBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOIPBody.Location = new System.Drawing.Point(0, 168);
            this.panelOIPBody.Name = "panelOIPBody";
            this.panelOIPBody.Size = new System.Drawing.Size(752, 447);
            this.panelOIPBody.TabIndex = 29;
            // 
            // dataGridMaintenancePlans
            // 
            this.dataGridMaintenancePlans.AllowUserToAddRows = false;
            this.dataGridMaintenancePlans.AllowUserToDeleteRows = false;
            this.dataGridMaintenancePlans.AllowUserToResizeRows = false;
            this.dataGridMaintenancePlans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMaintenancePlans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridMaintenancePlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMaintenancePlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.planname,
            this.start,
            this.enddate,
            this.submittedby,
            this.submitteddate,
            this.approval,
            this.approvedby,
            this.approveddate,
            this.completion,
            this.note,
            this.Update,
            this.Delete});
            this.dataGridMaintenancePlans.Location = new System.Drawing.Point(12, 41);
            this.dataGridMaintenancePlans.Name = "dataGridMaintenancePlans";
            this.dataGridMaintenancePlans.ReadOnly = true;
            this.dataGridMaintenancePlans.Size = new System.Drawing.Size(728, 392);
            this.dataGridMaintenancePlans.TabIndex = 22;
            // 
            // planname
            // 
            this.planname.HeaderText = "Maintenance Plan Name";
            this.planname.Name = "planname";
            this.planname.ReadOnly = true;
            this.planname.Width = 131;
            // 
            // start
            // 
            this.start.HeaderText = "Start Date";
            this.start.Name = "start";
            this.start.ReadOnly = true;
            this.start.Width = 89;
            // 
            // enddate
            // 
            this.enddate.HeaderText = "End Date";
            this.enddate.Name = "enddate";
            this.enddate.ReadOnly = true;
            this.enddate.Width = 81;
            // 
            // submittedby
            // 
            this.submittedby.HeaderText = "Submitted By";
            this.submittedby.Name = "submittedby";
            this.submittedby.ReadOnly = true;
            this.submittedby.Width = 105;
            // 
            // submitteddate
            // 
            this.submitteddate.HeaderText = "Submitted Date";
            this.submitteddate.Name = "submitteddate";
            this.submitteddate.ReadOnly = true;
            this.submitteddate.Width = 119;
            // 
            // approval
            // 
            this.approval.HeaderText = "Approval Status";
            this.approval.Name = "approval";
            this.approval.ReadOnly = true;
            this.approval.Width = 120;
            // 
            // approvedby
            // 
            this.approvedby.HeaderText = "Approved By";
            this.approvedby.Name = "approvedby";
            this.approvedby.ReadOnly = true;
            this.approvedby.Width = 103;
            // 
            // approveddate
            // 
            this.approveddate.HeaderText = "Approved Date";
            this.approveddate.Name = "approveddate";
            this.approveddate.ReadOnly = true;
            this.approveddate.Width = 116;
            // 
            // completion
            // 
            this.completion.HeaderText = "Completion Status";
            this.completion.Name = "completion";
            this.completion.ReadOnly = true;
            this.completion.Width = 134;
            // 
            // note
            // 
            this.note.HeaderText = "Special Notes";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 107;
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            this.Update.ReadOnly = true;
            this.Update.Width = 60;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 57;
            // 
            // btnPrintOIP
            // 
            this.btnPrintOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintOIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnPrintOIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrintOIP.BackgroundImage")));
            this.btnPrintOIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintOIP.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrintOIP.FlatAppearance.BorderSize = 4;
            this.btnPrintOIP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnPrintOIP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnPrintOIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintOIP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrintOIP.Location = new System.Drawing.Point(710, 6);
            this.btnPrintOIP.Name = "btnPrintOIP";
            this.btnPrintOIP.Size = new System.Drawing.Size(30, 30);
            this.btnPrintOIP.TabIndex = 26;
            this.btnPrintOIP.UseVisualStyleBackColor = false;
            this.btnPrintOIP.Click += new System.EventHandler(this.btnPrintOIP_Click);
            // 
            // btnRefreshOIP
            // 
            this.btnRefreshOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshOIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnRefreshOIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshOIP.BackgroundImage")));
            this.btnRefreshOIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshOIP.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRefreshOIP.FlatAppearance.BorderSize = 4;
            this.btnRefreshOIP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnRefreshOIP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnRefreshOIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshOIP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshOIP.Location = new System.Drawing.Point(674, 6);
            this.btnRefreshOIP.Name = "btnRefreshOIP";
            this.btnRefreshOIP.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshOIP.TabIndex = 26;
            this.btnRefreshOIP.UseVisualStyleBackColor = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelOIPBody);
            this.panelContainer.Controls.Add(this.panelSearch);
            this.panelContainer.Controls.Add(this.lblCopyright);
            this.panelContainer.Controls.Add(this.panelHeader);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 57);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(752, 661);
            this.panelContainer.TabIndex = 29;
            // 
            // ManageMaintenancePlans
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(769, 491);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageMaintenancePlans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageMaintenancePlans";
            this.Load += new System.EventHandler(this.ManageMaintenancePlans_Load);
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelOIPBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMaintenancePlans)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button AddMaintenancePlan;
        private System.Windows.Forms.ComboBox comboBoxColumnOIP;
        private System.Windows.Forms.TextBox textBoxKeywordOIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchOIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelOIPBody;
        private System.Windows.Forms.DataGridView dataGridMaintenancePlans;
        private System.Windows.Forms.Button btnPrintOIP;
        private System.Windows.Forms.Button btnRefreshOIP;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn planname;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn enddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn submittedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn submitteddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn approval;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn approveddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn completion;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}