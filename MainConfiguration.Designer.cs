namespace ScreenGrab
{
    partial class MainConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConfiguration));
            this.groupFTP = new System.Windows.Forms.GroupBox();
            this.chkLinkEnabled = new System.Windows.Forms.CheckBox();
            this.lblLinkString = new System.Windows.Forms.Label();
            this.txtLinkString = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.groupSaveToFile = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSaveToFileLocation = new System.Windows.Forms.TextBox();
            this.chkEnableSaveToFile = new System.Windows.Forms.CheckBox();
            this.chkEnableFTP = new System.Windows.Forms.CheckBox();
            this.dlgSaveToFile = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupFTP.SuspendLayout();
            this.groupSaveToFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFTP
            // 
            this.groupFTP.Controls.Add(this.chkLinkEnabled);
            this.groupFTP.Controls.Add(this.lblLinkString);
            this.groupFTP.Controls.Add(this.txtLinkString);
            this.groupFTP.Controls.Add(this.btnTest);
            this.groupFTP.Controls.Add(this.lblPass);
            this.groupFTP.Controls.Add(this.lblUsername);
            this.groupFTP.Controls.Add(this.lblServer);
            this.groupFTP.Controls.Add(this.txtPass);
            this.groupFTP.Controls.Add(this.txtUser);
            this.groupFTP.Controls.Add(this.txtServer);
            this.groupFTP.Enabled = false;
            this.groupFTP.Location = new System.Drawing.Point(13, 116);
            this.groupFTP.Name = "groupFTP";
            this.groupFTP.Size = new System.Drawing.Size(205, 155);
            this.groupFTP.TabIndex = 0;
            this.groupFTP.TabStop = false;
            this.groupFTP.Text = "FTP Settings";
            // 
            // chkLinkEnabled
            // 
            this.chkLinkEnabled.AutoSize = true;
            this.chkLinkEnabled.Location = new System.Drawing.Point(18, 103);
            this.chkLinkEnabled.Name = "chkLinkEnabled";
            this.chkLinkEnabled.Size = new System.Drawing.Size(164, 17);
            this.chkLinkEnabled.TabIndex = 10;
            this.chkLinkEnabled.Text = "Copy Image Link to Clipboard";
            this.chkLinkEnabled.UseVisualStyleBackColor = true;
            this.chkLinkEnabled.CheckedChanged += new System.EventHandler(this.chkLinkEnabled_CheckedChanged);
            // 
            // lblLinkString
            // 
            this.lblLinkString.AutoSize = true;
            this.lblLinkString.Location = new System.Drawing.Point(15, 129);
            this.lblLinkString.Name = "lblLinkString";
            this.lblLinkString.Size = new System.Drawing.Size(59, 13);
            this.lblLinkString.TabIndex = 8;
            this.lblLinkString.Text = "Link Prefix:";
            // 
            // txtLinkString
            // 
            this.txtLinkString.Location = new System.Drawing.Point(80, 126);
            this.txtLinkString.Name = "txtLinkString";
            this.txtLinkString.Size = new System.Drawing.Size(118, 20);
            this.txtLinkString.TabIndex = 7;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(139, 57);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(59, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(15, 76);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(33, 13);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Pass:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 49);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(32, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "User:";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(6, 22);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 3;
            this.lblServer.Text = "Server:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(54, 73);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(79, 20);
            this.txtPass.TabIndex = 2;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(53, 46);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(80, 20);
            this.txtUser.TabIndex = 1;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(53, 19);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(146, 20);
            this.txtServer.TabIndex = 0;
            // 
            // groupSaveToFile
            // 
            this.groupSaveToFile.Controls.Add(this.btnBrowse);
            this.groupSaveToFile.Controls.Add(this.txtSaveToFileLocation);
            this.groupSaveToFile.Enabled = false;
            this.groupSaveToFile.Location = new System.Drawing.Point(12, 35);
            this.groupSaveToFile.Name = "groupSaveToFile";
            this.groupSaveToFile.Size = new System.Drawing.Size(205, 75);
            this.groupSaveToFile.TabIndex = 1;
            this.groupSaveToFile.TabStop = false;
            this.groupSaveToFile.Text = "Save to File Settings";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(6, 45);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSaveToFileLocation
            // 
            this.txtSaveToFileLocation.Location = new System.Drawing.Point(6, 19);
            this.txtSaveToFileLocation.Name = "txtSaveToFileLocation";
            this.txtSaveToFileLocation.Size = new System.Drawing.Size(193, 20);
            this.txtSaveToFileLocation.TabIndex = 0;
            // 
            // chkEnableSaveToFile
            // 
            this.chkEnableSaveToFile.AutoSize = true;
            this.chkEnableSaveToFile.Location = new System.Drawing.Point(12, 12);
            this.chkEnableSaveToFile.Name = "chkEnableSaveToFile";
            this.chkEnableSaveToFile.Size = new System.Drawing.Size(118, 17);
            this.chkEnableSaveToFile.TabIndex = 2;
            this.chkEnableSaveToFile.Text = "Enable Save to File";
            this.chkEnableSaveToFile.UseVisualStyleBackColor = true;
            this.chkEnableSaveToFile.CheckedChanged += new System.EventHandler(this.chkEnableSaveToFile_CheckedChanged);
            // 
            // chkEnableFTP
            // 
            this.chkEnableFTP.AutoSize = true;
            this.chkEnableFTP.Location = new System.Drawing.Point(136, 12);
            this.chkEnableFTP.Name = "chkEnableFTP";
            this.chkEnableFTP.Size = new System.Drawing.Size(82, 17);
            this.chkEnableFTP.TabIndex = 3;
            this.chkEnableFTP.Text = "Enable FTP";
            this.chkEnableFTP.UseVisualStyleBackColor = true;
            this.chkEnableFTP.CheckedChanged += new System.EventHandler(this.chkEnableFTP_CheckedChanged);
            // 
            // dlgSaveToFile
            // 
            this.dlgSaveToFile.DefaultExt = "png";
            this.dlgSaveToFile.Filter = "PNG Image|*.png";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(39, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 304);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkEnableFTP);
            this.Controls.Add(this.chkEnableSaveToFile);
            this.Controls.Add(this.groupSaveToFile);
            this.Controls.Add(this.groupFTP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainConfiguration";
            this.Text = "ScreenGrab Configuration";
            this.Load += new System.EventHandler(this.MainConfiguration_Load);
            this.groupFTP.ResumeLayout(false);
            this.groupFTP.PerformLayout();
            this.groupSaveToFile.ResumeLayout(false);
            this.groupSaveToFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFTP;
        private System.Windows.Forms.GroupBox groupSaveToFile;
        private System.Windows.Forms.CheckBox chkEnableSaveToFile;
        private System.Windows.Forms.CheckBox chkEnableFTP;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSaveToFileLocation;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.SaveFileDialog dlgSaveToFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLinkString;
        private System.Windows.Forms.Label lblLinkString;
        private System.Windows.Forms.CheckBox chkLinkEnabled;
        private System.Windows.Forms.Button btnCancel;
    }
}

