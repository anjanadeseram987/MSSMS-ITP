namespace MSSMS
{
    partial class ReportMachineViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMachineViewer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitile = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.dataGridViewReportMachines = new System.Windows.Forms.DataGridView();
            this.machineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machinename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workingState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addeddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelInAppNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportMachines)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInAppNotifications
            // 
            this.panelInAppNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.panelInAppNotifications.Controls.Add(this.lableInAppNotification);
            this.panelInAppNotifications.Controls.Add(this.btnCloseInAppNotification);
            this.panelInAppNotifications.Controls.Add(this.pbInAppNotification);
            this.panelInAppNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInAppNotifications.Location = new System.Drawing.Point(0, 0);
            this.panelInAppNotifications.Name = "panelInAppNotifications";
            this.panelInAppNotifications.Size = new System.Drawing.Size(867, 57);
            this.panelInAppNotifications.TabIndex = 43;
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(772, 10);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 20;
            this.btnCloseInAppNotification.Text = "Close";
            this.btnCloseInAppNotification.UseVisualStyleBackColor = false;
            this.btnCloseInAppNotification.Click += new System.EventHandler(this.btnCloseInAppNotification_Click);
            // 
            // pbInAppNotification
            // 
            this.pbInAppNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInAppNotification.ErrorImage = null;
            this.pbInAppNotification.Location = new System.Drawing.Point(8, 10);
            this.pbInAppNotification.Name = "pbInAppNotification";
            this.pbInAppNotification.Size = new System.Drawing.Size(44, 38);
            this.pbInAppNotification.TabIndex = 0;
            this.pbInAppNotification.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(635, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 37);
            this.btnExport.TabIndex = 45;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel10.Controls.Add(this.pictureBox2);
            this.panel10.Controls.Add(this.lblTitile);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 57);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(867, 138);
            this.panel10.TabIndex = 46;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(3, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(354, 71);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // lblTitile
            // 
            this.lblTitile.AutoSize = true;
            this.lblTitile.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.Location = new System.Drawing.Point(30, 80);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(305, 25);
            this.lblTitile.TabIndex = 3;
            this.lblTitile.Text = "MACHINERY ON DEMAND REPORT";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.Control;
            this.panelSearch.Controls.Add(this.btnExport);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 195);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(867, 50);
            this.panelSearch.TabIndex = 47;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.lblCopyright);
            this.panelBody.Controls.Add(this.dataGridViewReportMachines);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 245);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(867, 454);
            this.panelBody.TabIndex = 48;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(209, 418);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 21);
            this.lblCopyright.TabIndex = 23;
            this.lblCopyright.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewReportMachines
            // 
            this.dataGridViewReportMachines.AllowUserToAddRows = false;
            this.dataGridViewReportMachines.AllowUserToDeleteRows = false;
            this.dataGridViewReportMachines.AllowUserToResizeRows = false;
            this.dataGridViewReportMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReportMachines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReportMachines.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewReportMachines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReportMachines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReportMachines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewReportMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReportMachines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.machineId,
            this.serialno,
            this.machinename,
            this.location,
            this.workingState,
            this.addedby,
            this.addeddate,
            this.description});
            this.dataGridViewReportMachines.EnableHeadersVisualStyles = false;
            this.dataGridViewReportMachines.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewReportMachines.Location = new System.Drawing.Point(11, 6);
            this.dataGridViewReportMachines.Name = "dataGridViewReportMachines";
            this.dataGridViewReportMachines.ReadOnly = true;
            this.dataGridViewReportMachines.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewReportMachines.RowHeadersVisible = false;
            this.dataGridViewReportMachines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReportMachines.Size = new System.Drawing.Size(843, 396);
            this.dataGridViewReportMachines.TabIndex = 22;
            // 
            // machineId
            // 
            this.machineId.HeaderText = "Machine ID";
            this.machineId.Name = "machineId";
            this.machineId.ReadOnly = true;
            // 
            // serialno
            // 
            this.serialno.HeaderText = "Machine Serial No.";
            this.serialno.Name = "serialno";
            this.serialno.ReadOnly = true;
            // 
            // machinename
            // 
            this.machinename.HeaderText = "Name";
            this.machinename.Name = "machinename";
            this.machinename.ReadOnly = true;
            // 
            // location
            // 
            this.location.HeaderText = "Location/Production Floor";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // workingState
            // 
            this.workingState.HeaderText = "Working State";
            this.workingState.Name = "workingState";
            this.workingState.ReadOnly = true;
            // 
            // addedby
            // 
            this.addedby.HeaderText = "Added By";
            this.addedby.Name = "addedby";
            this.addedby.ReadOnly = true;
            // 
            // addeddate
            // 
            this.addeddate.HeaderText = "Added Date";
            this.addeddate.Name = "addeddate";
            this.addeddate.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // ReportMachineViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportMachineViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machinery Status Report";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            this.panelInAppNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportMachines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblTitile;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.DataGridView dataGridViewReportMachines;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialno;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinename;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn workingState;
        private System.Windows.Forms.DataGridViewTextBoxColumn addedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn addeddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblCopyright;
    }
}
