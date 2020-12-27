namespace MSSMS
{
    partial class ManageOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageOrders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelOIPBody = new System.Windows.Forms.Panel();
            this.dataGridOrderItems = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.comboBoxColumn = new System.Windows.Forms.ComboBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.contractno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelContainer.SuspendLayout();
            this.panelOIPBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(679, 10);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 1;
            this.btnCloseInAppNotification.Text = "Close";
            this.btnCloseInAppNotification.UseVisualStyleBackColor = false;
            this.btnCloseInAppNotification.Click += new System.EventHandler(this.btnCloseInAppNotification_Click);
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
            this.panelContainer.Size = new System.Drawing.Size(773, 671);
            this.panelContainer.TabIndex = 24;
            // 
            // panelOIPBody
            // 
            this.panelOIPBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelOIPBody.Controls.Add(this.dataGridOrderItems);
            this.panelOIPBody.Controls.Add(this.btnPrint);
            this.panelOIPBody.Controls.Add(this.btnRefresh);
            this.panelOIPBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOIPBody.Location = new System.Drawing.Point(0, 168);
            this.panelOIPBody.Name = "panelOIPBody";
            this.panelOIPBody.Size = new System.Drawing.Size(773, 454);
            this.panelOIPBody.TabIndex = 29;
            // 
            // dataGridOrderItems
            // 
            this.dataGridOrderItems.AllowUserToAddRows = false;
            this.dataGridOrderItems.AllowUserToDeleteRows = false;
            this.dataGridOrderItems.AllowUserToResizeRows = false;
            this.dataGridOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOrderItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridOrderItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contractno,
            this.orderno,
            this.OrderItemNo,
            this.Buyer,
            this.Brand,
            this.productDetails,
            this.mcquantity,
            this.Location,
            this.ShippingAddress,
            this.orderstatus,
            this.Delete});
            this.dataGridOrderItems.EnableHeadersVisualStyles = false;
            this.dataGridOrderItems.Location = new System.Drawing.Point(12, 41);
            this.dataGridOrderItems.Name = "dataGridOrderItems";
            this.dataGridOrderItems.ReadOnly = true;
            this.dataGridOrderItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridOrderItems.RowHeadersVisible = false;
            this.dataGridOrderItems.RowHeadersWidth = 51;
            this.dataGridOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOrderItems.Size = new System.Drawing.Size(749, 396);
            this.dataGridOrderItems.TabIndex = 7;
            this.dataGridOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrderItems_CellContentClick);
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
            this.btnPrint.Location = new System.Drawing.Point(731, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 6;
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
            this.btnRefresh.Location = new System.Drawing.Point(695, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.AutoScroll = true;
            this.panelSearch.BackColor = System.Drawing.SystemColors.Control;
            this.panelSearch.Controls.Add(this.comboBoxColumn);
            this.panelSearch.Controls.Add(this.textBoxKeyword);
            this.panelSearch.Controls.Add(this.label5);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.label7);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 99);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(773, 69);
            this.panelSearch.TabIndex = 27;
            // 
            // comboBoxColumn
            // 
            this.comboBoxColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumn.FormattingEnabled = true;
            this.comboBoxColumn.ItemHeight = 17;
            this.comboBoxColumn.Location = new System.Drawing.Point(373, 27);
            this.comboBoxColumn.Name = "comboBoxColumn";
            this.comboBoxColumn.Size = new System.Drawing.Size(114, 25);
            this.comboBoxColumn.TabIndex = 2;
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyword.Location = new System.Drawing.Point(501, 30);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(152, 22);
            this.textBoxKeyword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Filter by:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(663, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 37);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "      Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(498, 7);
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
            this.lblCopyright.Location = new System.Drawing.Point(155, 641);
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
            this.panelHeader.Size = new System.Drawing.Size(773, 99);
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
            this.lblHeader.Size = new System.Drawing.Size(197, 25);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "ORDERS/ CONTRACTS";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(689, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "All orders have been listed down in two seperate grids as \"in progress\" and \"fini" +
    "shed\" orders. Please use the filters to optimize the search results.";
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(773, 57);
            this.panelInAppNotifications.TabIndex = 23;
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
            // contractno
            // 
            this.contractno.HeaderText = "Contract No.";
            this.contractno.MinimumWidth = 6;
            this.contractno.Name = "contractno";
            this.contractno.ReadOnly = true;
            this.contractno.Width = 109;
            // 
            // orderno
            // 
            this.orderno.HeaderText = "Order No.";
            this.orderno.MinimumWidth = 6;
            this.orderno.Name = "orderno";
            this.orderno.ReadOnly = true;
            this.orderno.Width = 90;
            // 
            // OrderItemNo
            // 
            this.OrderItemNo.HeaderText = "Order Item No.";
            this.OrderItemNo.MinimumWidth = 6;
            this.OrderItemNo.Name = "OrderItemNo";
            this.OrderItemNo.ReadOnly = true;
            this.OrderItemNo.Width = 121;
            // 
            // Buyer
            // 
            this.Buyer.HeaderText = "Buyer Name";
            this.Buyer.MinimumWidth = 6;
            this.Buyer.Name = "Buyer";
            this.Buyer.ReadOnly = true;
            this.Buyer.Width = 104;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand Name";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 104;
            // 
            // productDetails
            // 
            this.productDetails.HeaderText = "Tea Product Details";
            this.productDetails.MinimumWidth = 6;
            this.productDetails.Name = "productDetails";
            this.productDetails.ReadOnly = true;
            this.productDetails.Width = 137;
            // 
            // mcquantity
            // 
            this.mcquantity.HeaderText = "Number of Master Cartons";
            this.mcquantity.MinimumWidth = 6;
            this.mcquantity.Name = "mcquantity";
            this.mcquantity.ReadOnly = true;
            this.mcquantity.Width = 131;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 84;
            // 
            // ShippingAddress
            // 
            this.ShippingAddress.HeaderText = "Shipping Address";
            this.ShippingAddress.MinimumWidth = 6;
            this.ShippingAddress.Name = "ShippingAddress";
            this.ShippingAddress.ReadOnly = true;
            this.ShippingAddress.Width = 124;
            // 
            // orderstatus
            // 
            this.orderstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orderstatus.HeaderText = "Order Status";
            this.orderstatus.MinimumWidth = 200;
            this.orderstatus.Name = "orderstatus";
            this.orderstatus.ReadOnly = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 17;
            // 
            // ManageOrders
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(790, 491);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageOrders";
            this.Text = "Manage orders";
            this.Load += new System.EventHandler(this.ManageOrders_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelOIPBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).EndInit();
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

        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.ComboBox comboBoxColumn;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelOIPBody;
        private System.Windows.Forms.DataGridView dataGridOrderItems;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractno;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderno;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn mcquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderstatus;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}