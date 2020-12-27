namespace MSSMS
{
    partial class AddMachines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMachines));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelFixedForm = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxMachineName = new System.Windows.Forms.TextBox();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelWorkingState = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.labelMachineName = new System.Windows.Forms.Label();
            this.comboBoxWorkingState = new System.Windows.Forms.ComboBox();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panelSeperator = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnDemo = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelInAppNotifications = new System.Windows.Forms.Panel();
            this.btnCloseInAppNotification = new System.Windows.Forms.Button();
            this.lableInAppNotification = new System.Windows.Forms.Label();
            this.pbInAppNotification = new System.Windows.Forms.PictureBox();
            this.panelContainer.SuspendLayout();
            this.panelBody.SuspendLayout();
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
            this.panelContainer.Size = new System.Drawing.Size(934, 631);
            this.panelContainer.TabIndex = 35;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBody.Controls.Add(this.panelFixedForm);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 113);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(934, 473);
            this.panelBody.TabIndex = 17;
            // 
            // panelFixedForm
            // 
            this.panelFixedForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelFixedForm.BackColor = System.Drawing.SystemColors.Control;
            this.panelFixedForm.Controls.Add(this.label6);
            this.panelFixedForm.Controls.Add(this.label3);
            this.panelFixedForm.Controls.Add(this.label2);
            this.panelFixedForm.Controls.Add(this.label1);
            this.panelFixedForm.Controls.Add(this.label5);
            this.panelFixedForm.Controls.Add(this.label10);
            this.panelFixedForm.Controls.Add(this.panel2);
            this.panelFixedForm.Controls.Add(this.textBoxMachineName);
            this.panelFixedForm.Controls.Add(this.textBoxSerialNumber);
            this.panelFixedForm.Controls.Add(this.textBoxDescription);
            this.panelFixedForm.Controls.Add(this.labelWorkingState);
            this.panelFixedForm.Controls.Add(this.labelLocation);
            this.panelFixedForm.Controls.Add(this.labelSerialNumber);
            this.panelFixedForm.Controls.Add(this.labelMachineName);
            this.panelFixedForm.Controls.Add(this.comboBoxWorkingState);
            this.panelFixedForm.Controls.Add(this.comboBoxLocation);
            this.panelFixedForm.Controls.Add(this.labelDescription);
            this.panelFixedForm.Controls.Add(this.btnSave);
            this.panelFixedForm.Controls.Add(this.btnReset);
            this.panelFixedForm.Location = new System.Drawing.Point(70, 0);
            this.panelFixedForm.Name = "panelFixedForm";
            this.panelFixedForm.Size = new System.Drawing.Size(798, 461);
            this.panelFixedForm.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(636, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 49;
            this.label6.Text = "* Required Fields";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(517, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(478, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(154, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(115, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(53, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 18);
            this.label10.TabIndex = 47;
            this.label10.Text = "Machine Details:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(113, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 1);
            this.panel2.TabIndex = 48;
            // 
            // textBoxMachineName
            // 
            this.textBoxMachineName.Location = new System.Drawing.Point(176, 114);
            this.textBoxMachineName.Name = "textBoxMachineName";
            this.textBoxMachineName.Size = new System.Drawing.Size(210, 22);
            this.textBoxMachineName.TabIndex = 2;
            this.textBoxMachineName.Text = " ";
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Location = new System.Drawing.Point(176, 75);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(210, 22);
            this.textBoxSerialNumber.TabIndex = 1;
            this.textBoxSerialNumber.Text = " ";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(56, 196);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(693, 176);
            this.textBoxDescription.TabIndex = 5;
            // 
            // labelWorkingState
            // 
            this.labelWorkingState.AutoSize = true;
            this.labelWorkingState.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkingState.Location = new System.Drawing.Point(416, 117);
            this.labelWorkingState.Name = "labelWorkingState";
            this.labelWorkingState.Size = new System.Drawing.Size(98, 18);
            this.labelWorkingState.TabIndex = 43;
            this.labelWorkingState.Text = "Working  State:";
            this.labelWorkingState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocation.Location = new System.Drawing.Point(416, 75);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(63, 18);
            this.labelLocation.TabIndex = 43;
            this.labelLocation.Text = "Location:";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.AutoSize = true;
            this.labelSerialNumber.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialNumber.Location = new System.Drawing.Point(53, 75);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(65, 18);
            this.labelSerialNumber.TabIndex = 44;
            this.labelSerialNumber.Text = "Serial No:";
            this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMachineName
            // 
            this.labelMachineName.AutoSize = true;
            this.labelMachineName.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMachineName.Location = new System.Drawing.Point(53, 112);
            this.labelMachineName.Name = "labelMachineName";
            this.labelMachineName.Size = new System.Drawing.Size(99, 18);
            this.labelMachineName.TabIndex = 46;
            this.labelMachineName.Text = "Machine Name:";
            this.labelMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxWorkingState
            // 
            this.comboBoxWorkingState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkingState.FormattingEnabled = true;
            this.comboBoxWorkingState.Location = new System.Drawing.Point(539, 114);
            this.comboBoxWorkingState.Name = "comboBoxWorkingState";
            this.comboBoxWorkingState.Size = new System.Drawing.Size(210, 25);
            this.comboBoxWorkingState.TabIndex = 4;
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Location = new System.Drawing.Point(539, 72);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(210, 25);
            this.comboBoxLocation.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(53, 166);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(79, 18);
            this.labelDescription.TabIndex = 45;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnSave.Location = new System.Drawing.Point(625, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 37);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Add Machine";
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
            this.btnReset.Location = new System.Drawing.Point(529, 400);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 37);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panelSeperator
            // 
            this.panelSeperator.AutoScroll = true;
            this.panelSeperator.BackColor = System.Drawing.SystemColors.Control;
            this.panelSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeperator.Location = new System.Drawing.Point(0, 99);
            this.panelSeperator.Name = "panelSeperator";
            this.panelSeperator.Size = new System.Drawing.Size(934, 14);
            this.panelSeperator.TabIndex = 5;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCopyright.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCopyright.Location = new System.Drawing.Point(228, 601);
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
            this.panelHeader.Size = new System.Drawing.Size(934, 99);
            this.panelHeader.TabIndex = 4;
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
            this.btnDemo.Location = new System.Drawing.Point(778, 30);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(90, 37);
            this.btnDemo.TabIndex = 6;
            this.btnDemo.Text = "DEMO";
            this.btnDemo.UseVisualStyleBackColor = false;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(145, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "ADD MACHINES";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(74, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(833, 52);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Enter the required details in order to add machine details to the system.";
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
            this.panelInAppNotifications.Size = new System.Drawing.Size(934, 57);
            this.panelInAppNotifications.TabIndex = 34;
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
            this.btnCloseInAppNotification.Location = new System.Drawing.Point(839, 11);
            this.btnCloseInAppNotification.Name = "btnCloseInAppNotification";
            this.btnCloseInAppNotification.Size = new System.Drawing.Size(84, 37);
            this.btnCloseInAppNotification.TabIndex = 0;
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
            this.lableInAppNotification.TabIndex = 1;
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
            // AddMachines
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(951, 591);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelInAppNotifications);
            this.Font = new System.Drawing.Font("Ubuntu", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 530);
            this.Name = "AddMachines";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Machine";
            this.Load += new System.EventHandler(this.AddMachines_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelFixedForm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxMachineName;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelSerialNumber;
        private System.Windows.Forms.Label labelMachineName;
        private System.Windows.Forms.ComboBox comboBoxLocation;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelWorkingState;
        private System.Windows.Forms.ComboBox comboBoxWorkingState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDemo;
    }
}
