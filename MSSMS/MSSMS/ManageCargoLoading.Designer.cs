namespace MSSMS
{
    partial class ManageCargoLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCargoLoading));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelOIPBody = new System.Windows.Forms.Panel();
            this.dataGridCargoLoadingCharts = new System.Windows.Forms.DataGridView();
            this.ssid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorderquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revieweddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrintOIP = new System.Windows.Forms.Button();
            this.btnRefreshOIP = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.AddCargoLoadingChart = new System.Windows.Forms.Button();
            this.comboBoxColumnOIP = new System.Windows.Forms.ComboBox();
            this.textBoxKeywordOIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchOIP = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.panelContainer.SuspendLayout();
            this.panelOIPBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCargoLoadingCharts)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
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
            this.panelContainer.Size = new System.Drawing.Size(769, 661);
            this.panelContainer.TabIndex = 33;
            // 
            // panelOIPBody
            // 
            this.panelOIPBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelOIPBody.Controls.Add(this.dataGridCargoLoadingCharts);
            this.panelOIPBody.Controls.Add(this.btnPrintOIP);
            this.panelOIPBody.Controls.Add(this.btnRefreshOIP);
            this.panelOIPBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOIPBody.Location = new System.Drawing.Point(0, 168);
            this.panelOIPBody.Name = "panelOIPBody";
            this.panelOIPBody.Size = new System.Drawing.Size(769, 447);
            this.panelOIPBody.TabIndex = 29;
            // 
            // dataGridCargoLoadingCharts
            // 
            this.dataGridCargoLoadingCharts.AllowUserToAddRows = false;
            this.dataGridCargoLoadingCharts.AllowUserToDeleteRows = false;
            this.dataGridCargoLoadingCharts.AllowUserToResizeRows = false;
            this.dataGridCargoLoadingCharts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCargoLoadingCharts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridCargoLoadingCharts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCargoLoadingCharts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ssid,
            this.cid,
            this.tagent,
            this.stime,
            this.etime,
            this.totalmc,
            this.totalweight,
            this.sorderquantity,
            this.supervisor,
            this.reviewer,
            this.revieweddate,
            this.Remarks,
            this.Update,
            this.Delete});
            this.dataGridCargoLoadingCharts.Location = new System.Drawing.Point(12, 41);
            this.dataGridCargoLoadingCharts.Name = "dataGridCargoLoadingCharts";
            this.dataGridCargoLoadingCharts.ReadOnly = true;
            this.dataGridCargoLoadingCharts.Size = new System.Drawing.Size(745, 392);
            this.dataGridCargoLoadingCharts.TabIndex = 22;
            // 
            // ssid
            // 
            this.ssid.HeaderText = "Shipping Schedule ID";
            this.ssid.Name = "ssid";
            this.ssid.ReadOnly = true;
            this.ssid.Width = 96;
            // 
            // cid
            // 
            this.cid.HeaderText = "Contract ID";
            this.cid.Name = "cid";
            this.cid.ReadOnly = true;
            this.cid.Width = 95;
            // 
            // tagent
            // 
            this.tagent.HeaderText = "Transport Agent";
            this.tagent.Name = "tagent";
            this.tagent.ReadOnly = true;
            this.tagent.Width = 121;
            // 
            // stime
            // 
            this.stime.HeaderText = "Start Time";
            this.stime.Name = "stime";
            this.stime.ReadOnly = true;
            this.stime.Width = 88;
            // 
            // etime
            // 
            this.etime.HeaderText = "End Time";
            this.etime.Name = "etime";
            this.etime.ReadOnly = true;
            this.etime.Width = 80;
            // 
            // totalmc
            // 
            this.totalmc.HeaderText = "Total M/C Quantity";
            this.totalmc.Name = "totalmc";
            this.totalmc.ReadOnly = true;
            this.totalmc.Width = 87;
            // 
            // totalweight
            // 
            this.totalweight.HeaderText = "Total Weight (KG)";
            this.totalweight.Name = "totalweight";
            this.totalweight.ReadOnly = true;
            this.totalweight.Width = 96;
            // 
            // sorderquantity
            // 
            this.sorderquantity.HeaderText = "Total Number of Sub-Orders";
            this.sorderquantity.Name = "sorderquantity";
            this.sorderquantity.ReadOnly = true;
            this.sorderquantity.Width = 108;
            // 
            // supervisor
            // 
            this.supervisor.HeaderText = "Supervised By";
            this.supervisor.Name = "supervisor";
            this.supervisor.ReadOnly = true;
            this.supervisor.Width = 108;
            // 
            // reviewer
            // 
            this.reviewer.HeaderText = "Reviewed By";
            this.reviewer.Name = "reviewer";
            this.reviewer.ReadOnly = true;
            this.reviewer.Width = 101;
            // 
            // revieweddate
            // 
            this.revieweddate.HeaderText = "Reviewed Date";
            this.revieweddate.Name = "revieweddate";
            this.revieweddate.ReadOnly = true;
            this.revieweddate.Width = 114;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 85;
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
            this.btnPrintOIP.Location = new System.Drawing.Point(727, 6);
            this.btnPrintOIP.Name = "btnPrintOIP";
            this.btnPrintOIP.Size = new System.Drawing.Size(30, 30);
            this.btnPrintOIP.TabIndex = 26;
            this.btnPrintOIP.UseVisualStyleBackColor = false;
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
            this.btnRefreshOIP.Location = new System.Drawing.Point(691, 6);
            this.btnRefreshOIP.Name = "btnRefreshOIP";
            this.btnRefreshOIP.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshOIP.TabIndex = 26;
            this.btnRefreshOIP.UseVisualStyleBackColor = false;
            // 
            // panelSearch
            // 
            this.panelSearch.AutoScroll = true;
            this.panelSearch.BackColor = System.Drawing.SystemColors.Control;
            this.panelSearch.Controls.Add(this.AddCargoLoadingChart);
            this.panelSearch.Controls.Add(this.comboBoxColumnOIP);
            this.panelSearch.Controls.Add(this.textBoxKeywordOIP);
            this.panelSearch.Controls.Add(this.label5);
            this.panelSearch.Controls.Add(this.btnSearchOIP);
            this.panelSearch.Controls.Add(this.label7);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 99);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(769, 69);
            this.panelSearch.TabIndex = 27;
            // 
            // AddCargoLoadingChart
            // 
            this.AddCargoLoadingChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.AddCargoLoadingChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddCargoLoadingChart.FlatAppearance.BorderSize = 0;
            this.AddCargoLoadingChart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.AddCargoLoadingChart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.AddCargoLoadingChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCargoLoadingChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddCargoLoadingChart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddCargoLoadingChart.Location = new System.Drawing.Point(12, 16);
            this.AddCargoLoadingChart.Name = "AddCargoLoadingChart";
            this.AddCargoLoadingChart.Size = new System.Drawing.Size(109, 37);
            this.AddCargoLoadingChart.TabIndex = 31;
            this.AddCargoLoadingChart.Text = "Start Loading\r\n";
            this.AddCargoLoadingChart.UseVisualStyleBackColor = false;
            this.AddCargoLoadingChart.Click += new System.EventHandler(this.AddProductionPlan_Click);
            // 
            // comboBoxColumnOIP
            // 
            this.comboBoxColumnOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColumnOIP.FormattingEnabled = true;
            this.comboBoxColumnOIP.Location = new System.Drawing.Point(369, 27);
            this.comboBoxColumnOIP.Name = "comboBoxColumnOIP";
            this.comboBoxColumnOIP.Size = new System.Drawing.Size(114, 25);
            this.comboBoxColumnOIP.TabIndex = 30;
            // 
            // textBoxKeywordOIP
            // 
            this.textBoxKeywordOIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeywordOIP.Location = new System.Drawing.Point(497, 30);
            this.textBoxKeywordOIP.Name = "textBoxKeywordOIP";
            this.textBoxKeywordOIP.Size = new System.Drawing.Size(152, 22);
            this.textBoxKeywordOIP.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 7);
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
            this.btnSearchOIP.Location = new System.Drawing.Point(659, 16);
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
            this.label7.Location = new System.Drawing.Point(494, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Keyword:";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(153, 631);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 21);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.panelHeader.Size = new System.Drawing.Size(769, 99);
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
            this.lblHeader.Size = new System.Drawing.Size(229, 25);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "CARGO LOADING CHARTS";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(685, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "All the cargo loading charts are displayed below. Please use the filters to optim" +
    "ize the search results.";
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(769, 57);
            this.panelInAppNotifications.TabIndex = 32;
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(674, 10);
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
            // ManageCargoLoading
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(786, 491);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageCargoLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageCargoLoading";
            this.Load += new System.EventHandler(this.ManageCargoLoading_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelOIPBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCargoLoadingCharts)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelOIPBody;
        private System.Windows.Forms.DataGridView dataGridCargoLoadingCharts;
        private System.Windows.Forms.Button btnPrintOIP;
        private System.Windows.Forms.Button btnRefreshOIP;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button AddCargoLoadingChart;
        private System.Windows.Forms.ComboBox comboBoxColumnOIP;
        private System.Windows.Forms.TextBox textBoxKeywordOIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchOIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagent;
        private System.Windows.Forms.DataGridViewTextBoxColumn stime;
        private System.Windows.Forms.DataGridViewTextBoxColumn etime;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorderquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn supervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn revieweddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}