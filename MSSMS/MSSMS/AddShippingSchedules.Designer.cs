namespace MSSMS
{
    partial class AddShippingSchedules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddShippingSchedules));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.dataGridOrderItems = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductionEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyerBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoredAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddToSchedule = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelFixedForm = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerLoadingDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.textBoxInstructions = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelSeperator = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.btnDemo = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).BeginInit();
            this.panelFixedForm.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelBody);
            this.panelContainer.Controls.Add(this.panelSeperator);
            this.panelContainer.Controls.Add(this.lblCopyright);
            this.panelContainer.Controls.Add(this.panelHeader);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 57);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(917, 1102);
            this.panelContainer.TabIndex = 32;
            // 
            // panelBody
            // 
            this.panelBody.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.panel1);
            this.panelBody.Controls.Add(this.panelFixedForm);
            this.panelBody.Location = new System.Drawing.Point(0, 113);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(917, 946);
            this.panelBody.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxKeyword);
            this.panel1.Controls.Add(this.dataGridOrderItems);
            this.panel1.Location = new System.Drawing.Point(109, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 441);
            this.panel1.TabIndex = 34;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSearch.BackgroundImage")));
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(580, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(97, 37);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "      Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyword.Location = new System.Drawing.Point(419, 20);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(152, 22);
            this.textBoxKeyword.TabIndex = 9;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.OrderItemNo,
            this.ProductionEndDate,
            this.BuyerBrand,
            this.product,
            this.ShippingAddress,
            this.location,
            this.mcquantity,
            this.ManufacturedAmount,
            this.StoredAmount,
            this.ShippedAmount,
            this.AddToSchedule});
            this.dataGridOrderItems.EnableHeadersVisualStyles = false;
            this.dataGridOrderItems.Location = new System.Drawing.Point(12, 59);
            this.dataGridOrderItems.Name = "dataGridOrderItems";
            this.dataGridOrderItems.ReadOnly = true;
            this.dataGridOrderItems.RowHeadersVisible = false;
            this.dataGridOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOrderItems.Size = new System.Drawing.Size(667, 369);
            this.dataGridOrderItems.TabIndex = 11;
            this.dataGridOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridStoredOrderItems_CellContentClick);
            // 
            // order
            // 
            this.order.HeaderText = "Order No.";
            this.order.Name = "order";
            this.order.ReadOnly = true;
            this.order.Width = 83;
            // 
            // OrderItemNo
            // 
            this.OrderItemNo.HeaderText = "Order Item No.";
            this.OrderItemNo.Name = "OrderItemNo";
            this.OrderItemNo.ReadOnly = true;
            this.OrderItemNo.Width = 93;
            // 
            // ProductionEndDate
            // 
            this.ProductionEndDate.HeaderText = "Production End Date";
            this.ProductionEndDate.Name = "ProductionEndDate";
            this.ProductionEndDate.ReadOnly = true;
            this.ProductionEndDate.Width = 115;
            // 
            // BuyerBrand
            // 
            this.BuyerBrand.HeaderText = "Buyer/Brand";
            this.BuyerBrand.Name = "BuyerBrand";
            this.BuyerBrand.ReadOnly = true;
            this.BuyerBrand.Width = 105;
            // 
            // product
            // 
            this.product.HeaderText = "Product Description";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            this.product.Width = 139;
            // 
            // ShippingAddress
            // 
            this.ShippingAddress.HeaderText = "Shipping Address";
            this.ShippingAddress.Name = "ShippingAddress";
            this.ShippingAddress.ReadOnly = true;
            this.ShippingAddress.Width = 124;
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            this.location.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.location.Width = 65;
            // 
            // mcquantity
            // 
            this.mcquantity.HeaderText = "Total MC Quantity";
            this.mcquantity.Name = "mcquantity";
            this.mcquantity.ReadOnly = true;
            this.mcquantity.Width = 129;
            // 
            // ManufacturedAmount
            // 
            this.ManufacturedAmount.HeaderText = "Manufactured  MC Quantity";
            this.ManufacturedAmount.Name = "ManufacturedAmount";
            this.ManufacturedAmount.ReadOnly = true;
            this.ManufacturedAmount.Width = 132;
            // 
            // StoredAmount
            // 
            this.StoredAmount.HeaderText = "Stored MC Quantity";
            this.StoredAmount.Name = "StoredAmount";
            this.StoredAmount.ReadOnly = true;
            this.StoredAmount.Width = 139;
            // 
            // ShippedAmount
            // 
            this.ShippedAmount.HeaderText = "Shipped MC Quantity";
            this.ShippedAmount.Name = "ShippedAmount";
            this.ShippedAmount.ReadOnly = true;
            this.ShippedAmount.Width = 146;
            // 
            // AddToSchedule
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.AddToSchedule.DefaultCellStyle = dataGridViewCellStyle4;
            this.AddToSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToSchedule.HeaderText = "";
            this.AddToSchedule.Name = "AddToSchedule";
            this.AddToSchedule.ReadOnly = true;
            this.AddToSchedule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AddToSchedule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AddToSchedule.Width = 17;
            // 
            // panelFixedForm
            // 
            this.panelFixedForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelFixedForm.BackColor = System.Drawing.SystemColors.Control;
            this.panelFixedForm.Controls.Add(this.label3);
            this.panelFixedForm.Controls.Add(this.label12);
            this.panelFixedForm.Controls.Add(this.label2);
            this.panelFixedForm.Controls.Add(this.label11);
            this.panelFixedForm.Controls.Add(this.textBoxAddress);
            this.panelFixedForm.Controls.Add(this.textBoxDestination);
            this.panelFixedForm.Controls.Add(this.label1);
            this.panelFixedForm.Controls.Add(this.panel3);
            this.panelFixedForm.Controls.Add(this.label4);
            this.panelFixedForm.Controls.Add(this.panel2);
            this.panelFixedForm.Controls.Add(this.dateTimePickerLoadingDate);
            this.panelFixedForm.Controls.Add(this.btnSave);
            this.panelFixedForm.Controls.Add(this.btnReset);
            this.panelFixedForm.Controls.Add(this.textBoxInstructions);
            this.panelFixedForm.Controls.Add(this.label6);
            this.panelFixedForm.Controls.Add(this.label8);
            this.panelFixedForm.Controls.Add(this.label13);
            this.panelFixedForm.Controls.Add(this.label5);
            this.panelFixedForm.Location = new System.Drawing.Point(67, 0);
            this.panelFixedForm.Name = "panelFixedForm";
            this.panelFixedForm.Size = new System.Drawing.Size(786, 931);
            this.panelFixedForm.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(627, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "* Required Fields";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(104, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 20);
            this.label12.TabIndex = 44;
            this.label12.Text = "*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(130, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(134, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.Location = new System.Drawing.Point(203, 179);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(296, 22);
            this.textBoxAddress.TabIndex = 5;
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(203, 140);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(296, 22);
            this.textBoxDestination.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "Schedule Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(104, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 1);
            this.panel3.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(44, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Add Order Items";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(104, 461);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 1);
            this.panel2.TabIndex = 42;
            // 
            // dateTimePickerLoadingDate
            // 
            this.dateTimePickerLoadingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerLoadingDate.Location = new System.Drawing.Point(203, 102);
            this.dateTimePickerLoadingDate.Name = "dateTimePickerLoadingDate";
            this.dateTimePickerLoadingDate.Size = new System.Drawing.Size(218, 22);
            this.dateTimePickerLoadingDate.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(559, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 37);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Add Schedule\r\n";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(458, 347);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 37);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // textBoxInstructions
            // 
            this.textBoxInstructions.Location = new System.Drawing.Point(203, 219);
            this.textBoxInstructions.Multiline = true;
            this.textBoxInstructions.Name = "textBoxInstructions";
            this.textBoxInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInstructions.Size = new System.Drawing.Size(535, 110);
            this.textBoxInstructions.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Loading Date:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "Address";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(41, 219);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 18);
            this.label13.TabIndex = 26;
            this.label13.Text = "Remarks/ Instructions:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 36);
            this.label5.TabIndex = 26;
            this.label5.Text = "Destination:\r\n(City/Country)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSeperator
            // 
            this.panelSeperator.AutoScroll = true;
            this.panelSeperator.BackColor = System.Drawing.SystemColors.Control;
            this.panelSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeperator.Location = new System.Drawing.Point(0, 99);
            this.panelSeperator.Name = "panelSeperator";
            this.panelSeperator.Size = new System.Drawing.Size(917, 14);
            this.panelSeperator.TabIndex = 15;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(219, 1072);
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
            this.panelHeader.Controls.Add(this.btnDemo);
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblDescription);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(917, 99);
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(70, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "ADD SHIPPING SCHEDULE";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(816, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Fill All the required feilds add a new shipping schedule.";
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(917, 57);
            this.panelInAppNotifications.TabIndex = 31;
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(822, 11);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 1;
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
            // btnDemo
            // 
            this.btnDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.btnDemo.FlatAppearance.BorderSize = 0;
            this.btnDemo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnDemo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDemo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDemo.Location = new System.Drawing.Point(763, 30);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(90, 37);
            this.btnDemo.TabIndex = 47;
            this.btnDemo.Text = "DEMO";
            this.btnDemo.UseVisualStyleBackColor = false;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // AddShippingSchedules
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(934, 591);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 530);
            this.Name = "AddShippingSchedules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Shipping Schedule";
            this.Load += new System.EventHandler(this.AddShippingSchedules_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).EndInit();
            this.panelFixedForm.ResumeLayout(false);
            this.panelFixedForm.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridOrderItems;
        private System.Windows.Forms.Panel panelFixedForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerLoadingDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox textBoxInstructions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelSeperator;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductionEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyerBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn mcquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoredAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippedAmount;
        private System.Windows.Forms.DataGridViewButtonColumn AddToSchedule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDemo;
    }
}