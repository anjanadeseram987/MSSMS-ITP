namespace MSSMS
{
    partial class ShipLobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipLobby));
            this.panelSidebarContainer = new System.Windows.Forms.Panel();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFooterLogo = new System.Windows.Forms.Label();
            this.sm_profile = new System.Windows.Forms.Panel();
            this.btnProfileSecurity = new System.Windows.Forms.Button();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.sm_reports = new System.Windows.Forms.Panel();
            this.btnReqReports = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.sm_shipping = new System.Windows.Forms.Panel();
            this.btnViewShippedGoods = new System.Windows.Forms.Button();
            this.btnCargoLoadingMgmt = new System.Windows.Forms.Button();
            this.btnViewShipShedules = new System.Windows.Forms.Button();
            this.btnShipping = new System.Windows.Forms.Button();
            this.btnLobby = new System.Windows.Forms.Button();
            this.panelDPContainer = new System.Windows.Forms.Panel();
            this.pbDP = new MSSMS.CustomizedControls.CircularPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.panelSidebarContainer.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.sm_profile.SuspendLayout();
            this.sm_reports.SuspendLayout();
            this.sm_shipping.SuspendLayout();
            this.panelDPContainer.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebarContainer
            // 
            this.panelSidebarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panelSidebarContainer.Controls.Add(this.panelSidebar);
            this.panelSidebarContainer.Controls.Add(this.panelDPContainer);
            this.panelSidebarContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebarContainer.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarContainer.Name = "panelSidebarContainer";
            this.panelSidebarContainer.Size = new System.Drawing.Size(225, 601);
            this.panelSidebarContainer.TabIndex = 2;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSidebar.AutoScroll = true;
            this.panelSidebar.Controls.Add(this.panelFooter);
            this.panelSidebar.Controls.Add(this.sm_profile);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.sm_reports);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.sm_shipping);
            this.panelSidebar.Controls.Add(this.btnShipping);
            this.panelSidebar.Controls.Add(this.btnLobby);
            this.panelSidebar.Location = new System.Drawing.Point(0, 110);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(225, 508);
            this.panelSidebar.TabIndex = 2;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.pictureBox1);
            this.panelFooter.Controls.Add(this.lblFooterLogo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFooter.Location = new System.Drawing.Point(0, 485);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(208, 109);
            this.panelFooter.TabIndex = 43;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // lblFooterLogo
            // 
            this.lblFooterLogo.AutoSize = true;
            this.lblFooterLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterLogo.Font = new System.Drawing.Font("AXIS Extra Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterLogo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFooterLogo.Location = new System.Drawing.Point(84, 42);
            this.lblFooterLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFooterLogo.Name = "lblFooterLogo";
            this.lblFooterLogo.Size = new System.Drawing.Size(61, 16);
            this.lblFooterLogo.TabIndex = 21;
            this.lblFooterLogo.Text = "MSSMS\r\n";
            // 
            // sm_profile
            // 
            this.sm_profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sm_profile.Controls.Add(this.btnProfileSecurity);
            this.sm_profile.Controls.Add(this.btnViewProfile);
            this.sm_profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.sm_profile.Location = new System.Drawing.Point(0, 386);
            this.sm_profile.Name = "sm_profile";
            this.sm_profile.Size = new System.Drawing.Size(208, 99);
            this.sm_profile.TabIndex = 42;
            // 
            // btnProfileSecurity
            // 
            this.btnProfileSecurity.BackColor = System.Drawing.Color.Transparent;
            this.btnProfileSecurity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProfileSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfileSecurity.FlatAppearance.BorderSize = 0;
            this.btnProfileSecurity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnProfileSecurity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnProfileSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfileSecurity.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProfileSecurity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfileSecurity.Location = new System.Drawing.Point(0, 47);
            this.btnProfileSecurity.Name = "btnProfileSecurity";
            this.btnProfileSecurity.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProfileSecurity.Size = new System.Drawing.Size(208, 47);
            this.btnProfileSecurity.TabIndex = 22;
            this.btnProfileSecurity.Text = "            Security";
            this.btnProfileSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfileSecurity.UseVisualStyleBackColor = false;
            this.btnProfileSecurity.Click += new System.EventHandler(this.btnProfileSecurity_Click);
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnViewProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewProfile.FlatAppearance.BorderSize = 0;
            this.btnViewProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnViewProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnViewProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewProfile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewProfile.Location = new System.Drawing.Point(0, 0);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnViewProfile.Size = new System.Drawing.Size(208, 47);
            this.btnViewProfile.TabIndex = 20;
            this.btnViewProfile.Text = "            My Profile";
            this.btnViewProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewProfile.UseVisualStyleBackColor = false;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnProfile.Image")));
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 339);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(208, 47);
            this.btnProfile.TabIndex = 41;
            this.btnProfile.Text = "               Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // sm_reports
            // 
            this.sm_reports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sm_reports.Controls.Add(this.btnReqReports);
            this.sm_reports.Dock = System.Windows.Forms.DockStyle.Top;
            this.sm_reports.Location = new System.Drawing.Point(0, 287);
            this.sm_reports.Name = "sm_reports";
            this.sm_reports.Size = new System.Drawing.Size(208, 52);
            this.sm_reports.TabIndex = 40;
            // 
            // btnReqReports
            // 
            this.btnReqReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReqReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReqReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReqReports.FlatAppearance.BorderSize = 0;
            this.btnReqReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnReqReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnReqReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReqReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReqReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReqReports.Location = new System.Drawing.Point(0, 0);
            this.btnReqReports.Name = "btnReqReports";
            this.btnReqReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReqReports.Size = new System.Drawing.Size(208, 47);
            this.btnReqReports.TabIndex = 20;
            this.btnReqReports.Text = "            Request Reports";
            this.btnReqReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReqReports.UseVisualStyleBackColor = false;
            this.btnReqReports.Click += new System.EventHandler(this.btnReqReports_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 240);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(208, 47);
            this.btnReports.TabIndex = 39;
            this.btnReports.Text = "               Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // sm_shipping
            // 
            this.sm_shipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sm_shipping.Controls.Add(this.btnViewShippedGoods);
            this.sm_shipping.Controls.Add(this.btnCargoLoadingMgmt);
            this.sm_shipping.Controls.Add(this.btnViewShipShedules);
            this.sm_shipping.Dock = System.Windows.Forms.DockStyle.Top;
            this.sm_shipping.Location = new System.Drawing.Point(0, 94);
            this.sm_shipping.Name = "sm_shipping";
            this.sm_shipping.Size = new System.Drawing.Size(208, 146);
            this.sm_shipping.TabIndex = 36;
            // 
            // btnViewShippedGoods
            // 
            this.btnViewShippedGoods.BackColor = System.Drawing.Color.Transparent;
            this.btnViewShippedGoods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewShippedGoods.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewShippedGoods.FlatAppearance.BorderSize = 0;
            this.btnViewShippedGoods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnViewShippedGoods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnViewShippedGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewShippedGoods.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewShippedGoods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewShippedGoods.Location = new System.Drawing.Point(0, 94);
            this.btnViewShippedGoods.Name = "btnViewShippedGoods";
            this.btnViewShippedGoods.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnViewShippedGoods.Size = new System.Drawing.Size(208, 47);
            this.btnViewShippedGoods.TabIndex = 22;
            this.btnViewShippedGoods.Text = "            Shipped Orders";
            this.btnViewShippedGoods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewShippedGoods.UseVisualStyleBackColor = false;
            this.btnViewShippedGoods.Click += new System.EventHandler(this.btnViewShippedGoods_Click);
            // 
            // btnCargoLoadingMgmt
            // 
            this.btnCargoLoadingMgmt.BackColor = System.Drawing.Color.Transparent;
            this.btnCargoLoadingMgmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCargoLoadingMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargoLoadingMgmt.FlatAppearance.BorderSize = 0;
            this.btnCargoLoadingMgmt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnCargoLoadingMgmt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnCargoLoadingMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargoLoadingMgmt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCargoLoadingMgmt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargoLoadingMgmt.Location = new System.Drawing.Point(0, 47);
            this.btnCargoLoadingMgmt.Name = "btnCargoLoadingMgmt";
            this.btnCargoLoadingMgmt.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCargoLoadingMgmt.Size = new System.Drawing.Size(208, 47);
            this.btnCargoLoadingMgmt.TabIndex = 21;
            this.btnCargoLoadingMgmt.Text = "            Cargo Loading";
            this.btnCargoLoadingMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargoLoadingMgmt.UseVisualStyleBackColor = false;
            this.btnCargoLoadingMgmt.Click += new System.EventHandler(this.btnCargoLoadingMgmt_Click);
            // 
            // btnViewShipShedules
            // 
            this.btnViewShipShedules.BackColor = System.Drawing.Color.Transparent;
            this.btnViewShipShedules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewShipShedules.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewShipShedules.FlatAppearance.BorderSize = 0;
            this.btnViewShipShedules.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnViewShipShedules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnViewShipShedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewShipShedules.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewShipShedules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewShipShedules.Location = new System.Drawing.Point(0, 0);
            this.btnViewShipShedules.Name = "btnViewShipShedules";
            this.btnViewShipShedules.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnViewShipShedules.Size = new System.Drawing.Size(208, 47);
            this.btnViewShipShedules.TabIndex = 20;
            this.btnViewShipShedules.Text = "            Manage Shipping \r\n            schedules";
            this.btnViewShipShedules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewShipShedules.UseVisualStyleBackColor = false;
            this.btnViewShipShedules.Click += new System.EventHandler(this.btnViewShipShedules_Click);
            // 
            // btnShipping
            // 
            this.btnShipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnShipping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShipping.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShipping.FlatAppearance.BorderSize = 0;
            this.btnShipping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnShipping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnShipping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShipping.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnShipping.Image = ((System.Drawing.Image)(resources.GetObject("btnShipping.Image")));
            this.btnShipping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipping.Location = new System.Drawing.Point(0, 47);
            this.btnShipping.Name = "btnShipping";
            this.btnShipping.Size = new System.Drawing.Size(208, 47);
            this.btnShipping.TabIndex = 35;
            this.btnShipping.Text = "               Shipping";
            this.btnShipping.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipping.UseVisualStyleBackColor = false;
            this.btnShipping.Click += new System.EventHandler(this.btnShipping_Click);
            // 
            // btnLobby
            // 
            this.btnLobby.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnLobby.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLobby.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLobby.FlatAppearance.BorderSize = 0;
            this.btnLobby.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnLobby.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnLobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLobby.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLobby.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLobby.Image = ((System.Drawing.Image)(resources.GetObject("btnLobby.Image")));
            this.btnLobby.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLobby.Location = new System.Drawing.Point(0, 0);
            this.btnLobby.Name = "btnLobby";
            this.btnLobby.Size = new System.Drawing.Size(208, 47);
            this.btnLobby.TabIndex = 1;
            this.btnLobby.Text = "               Lobby";
            this.btnLobby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLobby.UseVisualStyleBackColor = false;
            this.btnLobby.Click += new System.EventHandler(this.btnLobby_Click);
            // 
            // panelDPContainer
            // 
            this.panelDPContainer.Controls.Add(this.pbDP);
            this.panelDPContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDPContainer.Location = new System.Drawing.Point(0, 0);
            this.panelDPContainer.Name = "panelDPContainer";
            this.panelDPContainer.Size = new System.Drawing.Size(225, 110);
            this.panelDPContainer.TabIndex = 0;
            // 
            // pbDP
            // 
            this.pbDP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDP.BackgroundImage")));
            this.pbDP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbDP.Location = new System.Drawing.Point(71, 12);
            this.pbDP.Name = "pbDP";
            this.pbDP.Size = new System.Drawing.Size(83, 83);
            this.pbDP.TabIndex = 14;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.panelHeader.Controls.Add(this.lblDesignation);
            this.panelHeader.Controls.Add(this.lblUsername);
            this.panelHeader.Controls.Add(this.btnSignOut);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(225, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(769, 110);
            this.panelHeader.TabIndex = 3;
            // 
            // lblDesignation
            // 
            this.lblDesignation.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignation.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblDesignation.Location = new System.Drawing.Point(12, 34);
            this.lblDesignation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(313, 25);
            this.lblDesignation.TabIndex = 21;
            this.lblDesignation.Text = "Shipping Manager";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblUsername.Location = new System.Drawing.Point(12, 12);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(313, 25);
            this.lblUsername.TabIndex = 22;
            this.lblUsername.Text = "@username";
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.btnSignOut.FlatAppearance.BorderSize = 0;
            this.btnSignOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSignOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSignOut.Location = new System.Drawing.Point(16, 62);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(84, 33);
            this.btnSignOut.TabIndex = 20;
            this.btnSignOut.Text = "Sign out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.AutoScroll = true;
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(225, 110);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(769, 491);
            this.panelMainContainer.TabIndex = 4;
            this.panelMainContainer.TabStop = true;
            // 
            // ShipLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 601);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebarContainer);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1010, 640);
            this.Name = "ShipLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShipLobby_FormClosed);
            this.Load += new System.EventHandler(this.ShipLobby_Load);
            this.panelSidebarContainer.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.sm_profile.ResumeLayout(false);
            this.sm_reports.ResumeLayout(false);
            this.sm_shipping.ResumeLayout(false);
            this.panelDPContainer.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebarContainer;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFooterLogo;
        private System.Windows.Forms.Panel sm_profile;
        private System.Windows.Forms.Button btnProfileSecurity;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Panel sm_reports;
        private System.Windows.Forms.Button btnReqReports;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel sm_shipping;
        private System.Windows.Forms.Button btnViewShipShedules;
        private System.Windows.Forms.Button btnShipping;
        private System.Windows.Forms.Button btnLobby;
        private System.Windows.Forms.Panel panelDPContainer;
        private CustomizedControls.CircularPanel pbDP;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnViewShippedGoods;
        private System.Windows.Forms.Button btnCargoLoadingMgmt;
    }
}