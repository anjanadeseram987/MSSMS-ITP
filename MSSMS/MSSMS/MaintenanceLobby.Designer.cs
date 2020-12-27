namespace MSSMS
{
    partial class MaintenanceLobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceLobby));
            this.panelSidebarContainer = new System.Windows.Forms.Panel();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooterLogo = new System.Windows.Forms.Label();
            this.sm_profile = new System.Windows.Forms.Panel();
            this.btnProfileSecurity = new System.Windows.Forms.Button();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.sm_reports = new System.Windows.Forms.Panel();
            this.btnReqReports = new System.Windows.Forms.Button();
            this.sm_maintenance = new System.Windows.Forms.Panel();
            this.btnManageMaintenance = new System.Windows.Forms.Button();
            this.btnManageIssues = new System.Windows.Forms.Button();
            this.sm_machines = new System.Windows.Forms.Panel();
            this.btnManageMachines = new System.Windows.Forms.Button();
            this.panelDPContainer = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnMachines = new System.Windows.Forms.Button();
            this.btnLobby = new System.Windows.Forms.Button();
            this.pbDP = new MSSMS.CustomizedControls.CircularPanel();
            this.panelSidebarContainer.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.sm_profile.SuspendLayout();
            this.sm_reports.SuspendLayout();
            this.sm_maintenance.SuspendLayout();
            this.sm_machines.SuspendLayout();
            this.panelDPContainer.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panelSidebar.Controls.Add(this.sm_maintenance);
            this.panelSidebar.Controls.Add(this.btnMaintenance);
            this.panelSidebar.Controls.Add(this.sm_machines);
            this.panelSidebar.Controls.Add(this.btnMachines);
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
            this.panelFooter.Location = new System.Drawing.Point(0, 537);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(208, 109);
            this.panelFooter.TabIndex = 43;
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
            this.sm_profile.Location = new System.Drawing.Point(0, 438);
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
            // sm_reports
            // 
            this.sm_reports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sm_reports.Controls.Add(this.btnReqReports);
            this.sm_reports.Dock = System.Windows.Forms.DockStyle.Top;
            this.sm_reports.Location = new System.Drawing.Point(0, 339);
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
            // sm_maintenance
            // 
            this.sm_maintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sm_maintenance.Controls.Add(this.btnManageMaintenance);
            this.sm_maintenance.Controls.Add(this.btnManageIssues);
            this.sm_maintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.sm_maintenance.Location = new System.Drawing.Point(0, 193);
            this.sm_maintenance.Name = "sm_maintenance";
            this.sm_maintenance.Size = new System.Drawing.Size(208, 99);
            this.sm_maintenance.TabIndex = 38;
            // 
            // btnManageMaintenance
            // 
            this.btnManageMaintenance.BackColor = System.Drawing.Color.Transparent;
            this.btnManageMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageMaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageMaintenance.FlatAppearance.BorderSize = 0;
            this.btnManageMaintenance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnManageMaintenance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnManageMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMaintenance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageMaintenance.Location = new System.Drawing.Point(0, 47);
            this.btnManageMaintenance.Name = "btnManageMaintenance";
            this.btnManageMaintenance.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManageMaintenance.Size = new System.Drawing.Size(208, 47);
            this.btnManageMaintenance.TabIndex = 21;
            this.btnManageMaintenance.Text = "            Manage Maintenance\r\n            Plans";
            this.btnManageMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageMaintenance.UseVisualStyleBackColor = false;
            this.btnManageMaintenance.Click += new System.EventHandler(this.btnManageMaintenance_Click);
            // 
            // btnManageIssues
            // 
            this.btnManageIssues.BackColor = System.Drawing.Color.Transparent;
            this.btnManageIssues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageIssues.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageIssues.FlatAppearance.BorderSize = 0;
            this.btnManageIssues.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnManageIssues.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnManageIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageIssues.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageIssues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageIssues.Location = new System.Drawing.Point(0, 0);
            this.btnManageIssues.Name = "btnManageIssues";
            this.btnManageIssues.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManageIssues.Size = new System.Drawing.Size(208, 47);
            this.btnManageIssues.TabIndex = 20;
            this.btnManageIssues.Text = "            Reported Issues";
            this.btnManageIssues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageIssues.UseVisualStyleBackColor = false;
            this.btnManageIssues.Click += new System.EventHandler(this.btnManageIssues_Click);
            // 
            // sm_machines
            // 
            this.sm_machines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sm_machines.Controls.Add(this.btnManageMachines);
            this.sm_machines.Dock = System.Windows.Forms.DockStyle.Top;
            this.sm_machines.Location = new System.Drawing.Point(0, 94);
            this.sm_machines.Name = "sm_machines";
            this.sm_machines.Size = new System.Drawing.Size(208, 52);
            this.sm_machines.TabIndex = 32;
            // 
            // btnManageMachines
            // 
            this.btnManageMachines.BackColor = System.Drawing.Color.Transparent;
            this.btnManageMachines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageMachines.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageMachines.FlatAppearance.BorderSize = 0;
            this.btnManageMachines.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnManageMachines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnManageMachines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMachines.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageMachines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageMachines.Location = new System.Drawing.Point(0, 0);
            this.btnManageMachines.Name = "btnManageMachines";
            this.btnManageMachines.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManageMachines.Size = new System.Drawing.Size(208, 47);
            this.btnManageMachines.TabIndex = 21;
            this.btnManageMachines.Text = "            Manage Machinery";
            this.btnManageMachines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageMachines.UseVisualStyleBackColor = false;
            this.btnManageMachines.Click += new System.EventHandler(this.btnManageMachines_Click);
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
            this.lblDesignation.Text = "Engineer";
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
            this.btnProfile.Location = new System.Drawing.Point(0, 391);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(208, 47);
            this.btnProfile.TabIndex = 41;
            this.btnProfile.Text = "               Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
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
            this.btnReports.Location = new System.Drawing.Point(0, 292);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(208, 47);
            this.btnReports.TabIndex = 39;
            this.btnReports.Text = "               Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaintenance.FlatAppearance.BorderSize = 0;
            this.btnMaintenance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnMaintenance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("btnMaintenance.Image")));
            this.btnMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaintenance.Location = new System.Drawing.Point(0, 146);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(208, 47);
            this.btnMaintenance.TabIndex = 37;
            this.btnMaintenance.Text = "               Maintenance";
            this.btnMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaintenance.UseVisualStyleBackColor = false;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnMachines
            // 
            this.btnMachines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnMachines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMachines.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMachines.FlatAppearance.BorderSize = 0;
            this.btnMachines.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnMachines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnMachines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMachines.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMachines.Image = ((System.Drawing.Image)(resources.GetObject("btnMachines.Image")));
            this.btnMachines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMachines.Location = new System.Drawing.Point(0, 47);
            this.btnMachines.Name = "btnMachines";
            this.btnMachines.Size = new System.Drawing.Size(208, 47);
            this.btnMachines.TabIndex = 31;
            this.btnMachines.Text = "               Machines";
            this.btnMachines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMachines.UseVisualStyleBackColor = false;
            this.btnMachines.Click += new System.EventHandler(this.btnMachines_Click);
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
            // pbDP
            // 
            this.pbDP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDP.BackgroundImage")));
            this.pbDP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbDP.Location = new System.Drawing.Point(71, 12);
            this.pbDP.Name = "pbDP";
            this.pbDP.Size = new System.Drawing.Size(83, 83);
            this.pbDP.TabIndex = 14;
            // 
            // MaintenanceLobby
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
            this.Name = "MaintenanceLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceLobby_FormClosed);
            this.Load += new System.EventHandler(this.MaintenanceLobby_Load);
            this.panelSidebarContainer.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.sm_profile.ResumeLayout(false);
            this.sm_reports.ResumeLayout(false);
            this.sm_maintenance.ResumeLayout(false);
            this.sm_machines.ResumeLayout(false);
            this.panelDPContainer.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Panel sm_maintenance;
        private System.Windows.Forms.Button btnManageIssues;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Panel sm_machines;
        private System.Windows.Forms.Button btnManageMachines;
        private System.Windows.Forms.Button btnMachines;
        private System.Windows.Forms.Button btnLobby;
        private System.Windows.Forms.Panel panelDPContainer;
        private CustomizedControls.CircularPanel pbDP;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnManageMaintenance;
    }
}