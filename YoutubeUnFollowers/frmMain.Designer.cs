namespace YoutubeUnFollowers
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstUnfollowers = new System.Windows.Forms.ListBox();
            this.lblUnfollowers = new System.Windows.Forms.Label();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.backWorker = new System.ComponentModel.BackgroundWorker();
            this.btnUnFollow = new DevExpress.XtraEditors.SimpleButton();
            this.btnSettings = new DevExpress.XtraEditors.SimpleButton();
            this.cbProfiles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblProfile = new System.Windows.Forms.Label();
            this.btnInitProfil = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lstUnfollowers
            // 
            this.lstUnfollowers.FormattingEnabled = true;
            this.lstUnfollowers.Location = new System.Drawing.Point(12, 60);
            this.lstUnfollowers.Name = "lstUnfollowers";
            this.lstUnfollowers.Size = new System.Drawing.Size(435, 251);
            this.lstUnfollowers.TabIndex = 2;
            // 
            // lblUnfollowers
            // 
            this.lblUnfollowers.AutoSize = true;
            this.lblUnfollowers.Location = new System.Drawing.Point(12, 37);
            this.lblUnfollowers.Name = "lblUnfollowers";
            this.lblUnfollowers.Size = new System.Drawing.Size(122, 13);
            this.lblUnfollowers.TabIndex = 3;
            this.lblUnfollowers.Text = "Takipten Çıkılan Kanallar";
            // 
            // txtChannelName
            // 
            this.txtChannelName.Location = new System.Drawing.Point(71, 6);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(148, 21);
            this.txtChannelName.TabIndex = 4;
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.Location = new System.Drawing.Point(13, 9);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(51, 13);
            this.lblChannelName.TabIndex = 5;
            this.lblChannelName.Text = "Kanal Adı";
            // 
            // backWorker
            // 
            this.backWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorker_DoWork);
            // 
            // btnUnFollow
            // 
            this.btnUnFollow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUnFollow.ImageOptions.Image")));
            this.btnUnFollow.Location = new System.Drawing.Point(267, 31);
            this.btnUnFollow.Name = "btnUnFollow";
            this.btnUnFollow.Size = new System.Drawing.Size(99, 23);
            this.btnUnFollow.TabIndex = 6;
            this.btnUnFollow.Text = "Takipten Çık";
            this.btnUnFollow.Click += new System.EventHandler(this.btnUnfollow_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnSettings.Location = new System.Drawing.Point(372, 31);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cbProfiles
            // 
            this.cbProfiles.Location = new System.Drawing.Point(267, 6);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbProfiles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbProfiles.Size = new System.Drawing.Size(99, 20);
            this.cbProfiles.TabIndex = 8;
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(230, 9);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(31, 13);
            this.lblProfile.TabIndex = 9;
            this.lblProfile.Text = "Profil";
            // 
            // btnInitProfil
            // 
            this.btnInitProfil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnInitProfil.Location = new System.Drawing.Point(372, 4);
            this.btnInitProfil.Name = "btnInitProfil";
            this.btnInitProfil.Size = new System.Drawing.Size(75, 23);
            this.btnInitProfil.TabIndex = 10;
            this.btnInitProfil.Text = "Hazırla";
            this.btnInitProfil.Click += new System.EventHandler(this.btnInitProfil_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 323);
            this.Controls.Add(this.btnInitProfil);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.cbProfiles);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnUnFollow);
            this.Controls.Add(this.lblChannelName);
            this.Controls.Add(this.txtChannelName);
            this.Controls.Add(this.lblUnfollowers);
            this.Controls.Add(this.lstUnfollowers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YT Unfollowers";
            ((System.ComponentModel.ISupportInitialize)(this.cbProfiles.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstUnfollowers;
        private System.Windows.Forms.Label lblUnfollowers;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Label lblChannelName;
        private System.ComponentModel.BackgroundWorker backWorker;
        private DevExpress.XtraEditors.SimpleButton btnUnFollow;
        private DevExpress.XtraEditors.SimpleButton btnSettings;
        private DevExpress.XtraEditors.ComboBoxEdit cbProfiles;
        private System.Windows.Forms.Label lblProfile;
        private DevExpress.XtraEditors.SimpleButton btnInitProfil;
    }
}

