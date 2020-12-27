namespace MSSMS
{
    partial class ManageShipping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageShipping));
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridShippedGoods = new System.Windows.Forms.DataGridView();
            this.contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suborder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippeddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loacation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.comboBoxColumn = new System.Windows.Forms.ComboBox();
            this.panelBody = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShippedGoods)).BeginInit();
            this.panelBody.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(668, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "A complete list of shipped master cartons is displayed below. Please use the sear" +
    "ch filters to optimize the search results.";
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
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(70, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(139, 25);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Shipped Goods";
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyword.Location = new System.Drawing.Point(480, 29);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(152, 22);
            this.textBoxKeyword.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(349, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 17);
            this.label16.TabIndex = 24;
            this.label16.Text = "Filter by:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Keyword:";
            // 
            // dataGridShippedGoods
            // 
            this.dataGridShippedGoods.AllowUserToAddRows = false;
            this.dataGridShippedGoods.AllowUserToDeleteRows = false;
            this.dataGridShippedGoods.AllowUserToResizeRows = false;
            this.dataGridShippedGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridShippedGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridShippedGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridShippedGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contract,
            this.order,
            this.suborder,
            this.mc,
            this.Product,
            this.shippeddate,
            this.Loacation,
            this.Update,
            this.Delete});
            this.dataGridShippedGoods.Location = new System.Drawing.Point(12, 41);
            this.dataGridShippedGoods.Name = "dataGridShippedGoods";
            this.dataGridShippedGoods.ReadOnly = true;
            this.dataGridShippedGoods.Size = new System.Drawing.Size(728, 396);
            this.dataGridShippedGoods.TabIndex = 22;
            // 
            // contract
            // 
            this.contract.HeaderText = "Contract No.";
            this.contract.Name = "contract";
            this.contract.ReadOnly = true;
            this.contract.Width = 102;
            // 
            // order
            // 
            this.order.HeaderText = "Order Number";
            this.order.Name = "order";
            this.order.ReadOnly = true;
            this.order.Width = 110;
            // 
            // suborder
            // 
            this.suborder.HeaderText = "Sub-Order No.";
            this.suborder.Name = "suborder";
            this.suborder.ReadOnly = true;
            this.suborder.Width = 109;
            // 
            // mc
            // 
            this.mc.HeaderText = "M/C No.";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            this.mc.Width = 75;
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product.HeaderText = "Product Details";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // shippeddate
            // 
            this.shippeddate.HeaderText = "Shipped Date";
            this.shippeddate.Name = "shippeddate";
            this.shippeddate.ReadOnly = true;
            this.shippeddate.Width = 106;
            // 
            // Loacation
            // 
            this.Loacation.HeaderText = "Location";
            this.Loacation.Name = "Loacation";
            this.Loacation.ReadOnly = true;
            this.Loacation.Width = 86;
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            this.Update.ReadOnly = true;
            this.Update.Text = "Update";
            this.Update.Width = 60;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.Width = 57;
            // 
            // comboBoxColumn
            // 
            this.comboBoxColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColumn.FormattingEnabled = true;
            this.comboBoxColumn.Location = new System.Drawing.Point(352, 26);
            this.comboBoxColumn.Name = "comboBoxColumn";
            this.comboBoxColumn.Size = new System.Drawing.Size(114, 25);
            this.comboBoxColumn.TabIndex = 30;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.dataGridShippedGoods);
            this.panelBody.Controls.Add(this.btnPrint);
            this.panelBody.Controls.Add(this.btnRefresh);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 167);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(752, 454);
            this.panelBody.TabIndex = 32;
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
            this.btnPrint.Location = new System.Drawing.Point(710, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.UseVisualStyleBackColor = false;
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
            this.btnRefresh.Location = new System.Drawing.Point(674, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelBody);
            this.panelContainer.Controls.Add(this.panelSearch);
            this.panelContainer.Controls.Add(this.panelHeader);
            this.panelContainer.Controls.Add(this.lblCopyright);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 57);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(752, 661);
            this.panelContainer.TabIndex = 31;
            // 
            // panelSearch
            // 
            this.panelSearch.AutoScroll = true;
            this.panelSearch.BackColor = System.Drawing.SystemColors.Control;
            this.panelSearch.Controls.Add(this.comboBoxColumn);
            this.panelSearch.Controls.Add(this.textBoxKeyword);
            this.panelSearch.Controls.Add(this.label16);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 99);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(752, 68);
            this.panelSearch.TabIndex = 31;
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
            this.btnSearch.Location = new System.Drawing.Point(642, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 37);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "      Search";
            this.btnSearch.UseVisualStyleBackColor = false;
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
            // btnCloseInAppNotification
            // 
            this.btnCloseInAppNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseInAppNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCloseInAppNotification.FlatAppearance.BorderSize = 0;
            this.btnCloseInAppNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(43)))), ((int)(((byte)(33)))));
            this.btnCloseInAppNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCloseInAppNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseInAppNotification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(658, 10);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 20;
            this.btnCloseInAppNotification.Text = "Close";
            this.btnCloseInAppNotification.UseVisualStyleBackColor = false;
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(752, 57);
            this.panelInAppNotifications.TabIndex = 30;
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
            // ManageShipping
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(769, 491);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(769, 491);
            this.Name = "ManageShipping";
            this.Text = "ManageShipping";
            this.Load += new System.EventHandler(this.ManageShipping_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShippedGoods)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridShippedGoods;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox comboBoxColumn;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn suborder;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippeddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loacation;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}