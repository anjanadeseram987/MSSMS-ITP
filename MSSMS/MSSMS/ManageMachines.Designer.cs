namespace MSSMS
{
    partial class ManageMachines
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageMachines));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.dataGridMachines = new System.Windows.Forms.DataGridView();
            this.machineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machinename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workingState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addeddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateMachine = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteMachine = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.comboBoxColumn = new System.Windows.Forms.ComboBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAddMachine = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitile = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelContainer.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMachines)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelBody);
            this.panelContainer.Controls.Add(this.panelSearch);
            this.panelContainer.Controls.Add(this.panel10);
            this.panelContainer.Controls.Add(this.lblCopyright);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 57);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(769, 664);
            this.panelContainer.TabIndex = 25;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.dataGridMachines);
            this.panelBody.Controls.Add(this.btnPrint);
            this.panelBody.Controls.Add(this.btnRefresh);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 167);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(769, 454);
            this.panelBody.TabIndex = 18;
            // 
            // dataGridMachines
            // 
            this.dataGridMachines.AllowUserToAddRows = false;
            this.dataGridMachines.AllowUserToDeleteRows = false;
            this.dataGridMachines.AllowUserToResizeRows = false;
            this.dataGridMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMachines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridMachines.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridMachines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridMachines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridMachines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMachines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.machineId,
            this.serialno,
            this.machinename,
            this.location,
            this.workingState,
            this.addedby,
            this.addeddate,
            this.description,
            this.UpdateMachine,
            this.DeleteMachine});
            this.dataGridMachines.EnableHeadersVisualStyles = false;
            this.dataGridMachines.Location = new System.Drawing.Point(12, 41);
            this.dataGridMachines.Name = "dataGridMachines";
            this.dataGridMachines.ReadOnly = true;
            this.dataGridMachines.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridMachines.RowHeadersVisible = false;
            this.dataGridMachines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMachines.Size = new System.Drawing.Size(745, 399);
            this.dataGridMachines.TabIndex = 22;
            this.dataGridMachines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMachines_CellContentClick);
            // 
            // machineId
            // 
            this.machineId.HeaderText = "Machine ID";
            this.machineId.Name = "machineId";
            this.machineId.ReadOnly = true;
            this.machineId.Width = 89;
            // 
            // serialno
            // 
            this.serialno.HeaderText = "Machine Serial No.";
            this.serialno.Name = "serialno";
            this.serialno.ReadOnly = true;
            this.serialno.Width = 112;
            // 
            // machinename
            // 
            this.machinename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.machinename.HeaderText = "Name";
            this.machinename.MinimumWidth = 150;
            this.machinename.Name = "machinename";
            this.machinename.ReadOnly = true;
            // 
            // location
            // 
            this.location.HeaderText = "Location/Production Floor";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            this.location.Width = 174;
            // 
            // workingState
            // 
            this.workingState.HeaderText = "Working State";
            this.workingState.Name = "workingState";
            this.workingState.ReadOnly = true;
            this.workingState.Width = 107;
            // 
            // addedby
            // 
            this.addedby.HeaderText = "Added By";
            this.addedby.Name = "addedby";
            this.addedby.ReadOnly = true;
            this.addedby.Width = 83;
            // 
            // addeddate
            // 
            this.addeddate.HeaderText = "Added Date";
            this.addeddate.Name = "addeddate";
            this.addeddate.ReadOnly = true;
            this.addeddate.Width = 96;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 101;
            // 
            // UpdateMachine
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.UpdateMachine.DefaultCellStyle = dataGridViewCellStyle2;
            this.UpdateMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateMachine.HeaderText = "";
            this.UpdateMachine.Name = "UpdateMachine";
            this.UpdateMachine.ReadOnly = true;
            this.UpdateMachine.Width = 5;
            // 
            // DeleteMachine
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.DeleteMachine.DefaultCellStyle = dataGridViewCellStyle3;
            this.DeleteMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMachine.HeaderText = "";
            this.DeleteMachine.Name = "DeleteMachine";
            this.DeleteMachine.ReadOnly = true;
            this.DeleteMachine.Width = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatAppearance.BorderSize = 4;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Location = new System.Drawing.Point(727, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.BorderSize = 4;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(691, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.AutoScroll = true;
            this.panelSearch.BackColor = System.Drawing.SystemColors.Control;
            this.panelSearch.Controls.Add(this.comboBoxColumn);
            this.panelSearch.Controls.Add(this.textBoxKeyword);
            this.panelSearch.Controls.Add(this.label16);
            this.panelSearch.Controls.Add(this.btnAddMachine);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 99);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(769, 68);
            this.panelSearch.TabIndex = 17;
            // 
            // comboBoxColumn
            // 
            this.comboBoxColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumn.FormattingEnabled = true;
            this.comboBoxColumn.Items.AddRange(new object[] {
            "All",
            "Machine ID",
            "Serial No",
            "Name",
            "Location",
            "Working State",
            "Added By",
            "Added Date",
            "Description"});
            this.comboBoxColumn.Location = new System.Drawing.Point(371, 27);
            this.comboBoxColumn.Name = "comboBoxColumn";
            this.comboBoxColumn.Size = new System.Drawing.Size(114, 25);
            this.comboBoxColumn.TabIndex = 30;
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyword.Location = new System.Drawing.Point(499, 30);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(152, 22);
            this.textBoxKeyword.TabIndex = 29;
            this.textBoxKeyword.MouseHover += new System.EventHandler(this.textBoxKeyword_MouseHover);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(368, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 17);
            this.label16.TabIndex = 24;
            this.label16.Text = "Filter by:";
            // 
            // btnAddMachine
            // 
            this.btnAddMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnAddMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddMachine.FlatAppearance.BorderSize = 0;
            this.btnAddMachine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnAddMachine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnAddMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMachine.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddMachine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMachine.Location = new System.Drawing.Point(12, 16);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(122, 37);
            this.btnAddMachine.TabIndex = 27;
            this.btnAddMachine.Text = "Add Machine";
            this.btnAddMachine.UseVisualStyleBackColor = false;
            this.btnAddMachine.Click += new System.EventHandler(this.btnAddMachine_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(661, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 37);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "      Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Keyword:";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel10.Controls.Add(this.pictureBox2);
            this.panel10.Controls.Add(this.lblTitile);
            this.panel10.Controls.Add(this.lblDescription);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(769, 99);
            this.panel10.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(11, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lblTitile
            // 
            this.lblTitile.AutoSize = true;
            this.lblTitile.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.Location = new System.Drawing.Point(70, 15);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(115, 25);
            this.lblTitile.TabIndex = 3;
            this.lblTitile.Text = "MACHINERY";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(685, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "A list of all the machines, with their locations and other important details, is " +
    "displayed below. Search results can be optimized using the search filters.";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(153, 634);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 21);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.panelInAppNotifications.TabIndex = 24;
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(675, 10);
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
            // ManageMachines
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(786, 491);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageMachines";
            this.Text = "ManageMachines";
            this.Load += new System.EventHandler(this.ManageMachines_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMachines)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.DataGridView dataGridMachines;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.ComboBox comboBoxColumn;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAddMachine;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitile;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCopyright;
        public System.Windows.Forms.Panel panelInAppNotifications;
        public System.Windows.Forms.Button btnCloseInAppNotification;
        public System.Windows.Forms.Label lableInAppNotification;
        public System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialno;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinename;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn workingState;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn addeddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewButtonColumn UpdateMachine;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteMachine;
    }
}
