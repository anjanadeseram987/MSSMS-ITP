namespace MSSMS
{
    partial class AdminLobbyChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLobbyChild));
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panelCardContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUUA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblEMP = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblUA = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).BeginInit();
            this.panelInAppNotifications.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelCardContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(675, 10);
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(769, 57);
            this.panelInAppNotifications.TabIndex = 29;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.panel7);
            this.panelBody.Controls.Add(this.panel3);
            this.panelBody.Controls.Add(this.label13);
            this.panelBody.Controls.Add(this.panelCardContainer);
            this.panelBody.Controls.Add(this.panelTitle);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 57);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(769, 532);
            this.panelBody.TabIndex = 31;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 321);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(769, 165);
            this.panel7.TabIndex = 16;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(213, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(354, 71);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 307);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 14);
            this.panel3.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(153, 502);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(450, 21);
            this.label13.TabIndex = 14;
            this.label13.Text = "©2020 MSSMS. Jafferjee Brothers Tea Division.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelCardContainer
            // 
            this.panelCardContainer.AutoScroll = true;
            this.panelCardContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panelCardContainer.Controls.Add(this.panel1);
            this.panelCardContainer.Controls.Add(this.panel2);
            this.panelCardContainer.Controls.Add(this.panel6);
            this.panelCardContainer.Controls.Add(this.panelCard1);
            this.panelCardContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCardContainer.Location = new System.Drawing.Point(0, 99);
            this.panelCardContainer.Name = "panelCardContainer";
            this.panelCardContainer.Size = new System.Drawing.Size(769, 208);
            this.panelCardContainer.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(911, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 15);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lblUUA);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(635, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 144);
            this.panel2.TabIndex = 8;
            // 
            // lblUUA
            // 
            this.lblUUA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUUA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblUUA.Font = new System.Drawing.Font("Ubuntu Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUUA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUUA.Location = new System.Drawing.Point(176, 13);
            this.lblUUA.Name = "lblUUA";
            this.lblUUA.Size = new System.Drawing.Size(94, 54);
            this.lblUUA.TabIndex = 4;
            this.lblUUA.Text = "9999";
            this.lblUUA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ubuntu Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 87);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of\r\nUnauthorized \r\nAccounts";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lblEMP);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label18);
            this.panel6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Location = new System.Drawing.Point(328, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(283, 144);
            this.panel6.TabIndex = 8;
            // 
            // lblEMP
            // 
            this.lblEMP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblEMP.Font = new System.Drawing.Font("Ubuntu Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEMP.Location = new System.Drawing.Point(175, 13);
            this.lblEMP.Name = "lblEMP";
            this.lblEMP.Size = new System.Drawing.Size(94, 54);
            this.lblEMP.TabIndex = 4;
            this.lblEMP.Text = "9999";
            this.lblEMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Ubuntu Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(10, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 58);
            this.label17.TabIndex = 3;
            this.label17.Text = "Number of\r\nEmployees";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(12, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(204, 55);
            this.label18.TabIndex = 3;
            this.label18.Text = "Total Number of Employee details handled by the system";
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.Transparent;
            this.panelCard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelCard1.BackgroundImage")));
            this.panelCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCard1.Controls.Add(this.lblUA);
            this.panelCard1.Controls.Add(this.label11);
            this.panelCard1.Controls.Add(this.label12);
            this.panelCard1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panelCard1.Location = new System.Drawing.Point(22, 24);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(283, 144);
            this.panelCard1.TabIndex = 8;
            // 
            // lblUA
            // 
            this.lblUA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblUA.Font = new System.Drawing.Font("Ubuntu Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUA.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUA.Location = new System.Drawing.Point(175, 13);
            this.lblUA.Name = "lblUA";
            this.lblUA.Size = new System.Drawing.Size(94, 54);
            this.lblUA.TabIndex = 4;
            this.lblUA.Text = "9999";
            this.lblUA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Ubuntu Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 58);
            this.label11.TabIndex = 3;
            this.label11.Text = "Number of\r\nUsers Accounts";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(12, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(204, 55);
            this.label12.TabIndex = 3;
            this.label12.Text = "Total Number of User Accounts Associated with this system";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.panelTitle.Controls.Add(this.pictureBox1);
            this.panelTitle.Controls.Add(this.label2);
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(769, 99);
            this.panelTitle.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "LOBBY";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(74, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(685, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "You are currently in the lobby. You can find an updated summery of the system for" +
    " the ongoing month, below. Please use the sidebar to navigate to the relevant se" +
    "ctions.";
            // 
            // AdminLobbyChild
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(786, 491);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLobbyChild";
            this.Text = "AdminLobbyChild";
            this.Load += new System.EventHandler(this.AdminLobbyChild_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbInAppNotification)).EndInit();
            this.panelInAppNotifications.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelCardContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInAppNotification;
        private System.Windows.Forms.Label lableInAppNotification;
        private System.Windows.Forms.Button btnCloseInAppNotification;
        private System.Windows.Forms.Panel panelInAppNotifications;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelCardContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUUA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblEMP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label lblUA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}