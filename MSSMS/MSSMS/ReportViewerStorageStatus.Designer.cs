namespace MSSMS
{
    partial class ReportViewerStorageStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewerStorageStatus));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.dataGridReport = new System.Windows.Forms.DataGridView();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bybr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stqh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBody = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).BeginInit();
            this.panelBody.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(202, 1003);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 21);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridReport
            // 
            this.dataGridReport.AllowUserToAddRows = false;
            this.dataGridReport.AllowUserToDeleteRows = false;
            this.dataGridReport.AllowUserToResizeRows = false;
            this.dataGridReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNo,
            this.orderin,
            this.bybr,
            this.ProductDetails,
            this.tq,
            this.stq,
            this.stqh,
            this.ld});
            this.dataGridReport.EnableHeadersVisualStyles = false;
            this.dataGridReport.Location = new System.Drawing.Point(12, 41);
            this.dataGridReport.Name = "dataGridReport";
            this.dataGridReport.ReadOnly = true;
            this.dataGridReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridReport.RowHeadersVisible = false;
            this.dataGridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReport.Size = new System.Drawing.Size(843, 933);
            this.dataGridReport.TabIndex = 7;
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "Order No.";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.Width = 83;
            // 
            // orderin
            // 
            this.orderin.HeaderText = "Order Item No.";
            this.orderin.Name = "orderin";
            this.orderin.ReadOnly = true;
            this.orderin.Width = 93;
            // 
            // bybr
            // 
            this.bybr.HeaderText = "Buyer/Brand";
            this.bybr.Name = "bybr";
            this.bybr.ReadOnly = true;
            this.bybr.Width = 105;
            // 
            // ProductDetails
            // 
            this.ProductDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductDetails.HeaderText = "Product Details";
            this.ProductDetails.MinimumWidth = 150;
            this.ProductDetails.Name = "ProductDetails";
            this.ProductDetails.ReadOnly = true;
            // 
            // tq
            // 
            this.tq.HeaderText = "Total Tea Quantity";
            this.tq.Name = "tq";
            this.tq.ReadOnly = true;
            this.tq.Width = 130;
            // 
            // stq
            // 
            this.stq.HeaderText = "Stored Tea Quantity";
            this.stq.Name = "stq";
            this.stq.ReadOnly = true;
            this.stq.Width = 139;
            // 
            // stqh
            // 
            this.stqh.HeaderText = "Stored Goods Health";
            this.stqh.Name = "stqh";
            this.stqh.ReadOnly = true;
            this.stqh.Width = 146;
            // 
            // ld
            // 
            this.ld.HeaderText = "Loading Date";
            this.ld.Name = "ld";
            this.ld.ReadOnly = true;
            this.ld.Width = 103;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.dataGridReport);
            this.panelBody.Controls.Add(this.btnPrint);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(867, 991);
            this.panelBody.TabIndex = 19;
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
            this.btnPrint.Location = new System.Drawing.Point(825, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelBody);
            this.panelContainer.Controls.Add(this.lblCopyright);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 222);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(867, 1033);
            this.panelContainer.TabIndex = 49;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Location = new System.Drawing.Point(420, 35);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(351, 89);
            this.labelInfo.TabIndex = 46;
            this.labelInfo.Text = "REPORT ISSUED ON: \r\nREPORT GENERATED BY: \r\n\r\nREPORT TYPE:\r\nDATE/MONTH/YEAR/DURATI" +
    "ON: \r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "STORAGE STATUS REPORT";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel7.Controls.Add(this.labelInfo);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 57);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(867, 165);
            this.panel7.TabIndex = 48;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(354, 71);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(772, 10);
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
            this.lableInAppNotification.Click += new System.EventHandler(this.lableInAppNotification_Click);
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(867, 57);
            this.panelInAppNotifications.TabIndex = 47;
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
            // ReportViewerStorageStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportViewerStorageStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Storage Status Report";
            this.Load += new System.EventHandler(this.ReportViewerStorageStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.DataGridView dataGridReport;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderin;
        private System.Windows.Forms.DataGridViewTextBoxColumn bybr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn tq;
        private System.Windows.Forms.DataGridViewTextBoxColumn stq;
        private System.Windows.Forms.DataGridViewTextBoxColumn stqh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ld;
    }
}