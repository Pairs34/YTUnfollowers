namespace YoutubeUnFollowers
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.lblProfilAdi = new System.Windows.Forms.Label();
            this.txtProfilAdi = new System.Windows.Forms.TextBox();
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.btnAddProfil = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteProfil = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblProfilAdi
            // 
            this.lblProfilAdi.AutoSize = true;
            this.lblProfilAdi.Location = new System.Drawing.Point(12, 9);
            this.lblProfilAdi.Name = "lblProfilAdi";
            this.lblProfilAdi.Size = new System.Drawing.Size(49, 13);
            this.lblProfilAdi.TabIndex = 0;
            this.lblProfilAdi.Text = "Profil Adı";
            // 
            // txtProfilAdi
            // 
            this.txtProfilAdi.Location = new System.Drawing.Point(67, 6);
            this.txtProfilAdi.Name = "txtProfilAdi";
            this.txtProfilAdi.Size = new System.Drawing.Size(151, 21);
            this.txtProfilAdi.TabIndex = 1;
            // 
            // lstProfiles
            // 
            this.lstProfiles.FormattingEnabled = true;
            this.lstProfiles.Location = new System.Drawing.Point(12, 33);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(324, 160);
            this.lstProfiles.TabIndex = 2;
            // 
            // btnAddProfil
            // 
            this.btnAddProfil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnAddProfil.Location = new System.Drawing.Point(224, 4);
            this.btnAddProfil.Name = "btnAddProfil";
            this.btnAddProfil.Size = new System.Drawing.Size(53, 23);
            this.btnAddProfil.TabIndex = 3;
            this.btnAddProfil.Text = "Ekle";
            this.btnAddProfil.Click += new System.EventHandler(this.btnAddProfil_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(283, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(53, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteProfil
            // 
            this.btnDeleteProfil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image1")));
            this.btnDeleteProfil.Location = new System.Drawing.Point(224, 200);
            this.btnDeleteProfil.Name = "btnDeleteProfil";
            this.btnDeleteProfil.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteProfil.TabIndex = 5;
            this.btnDeleteProfil.Text = "Profil Sil";
            this.btnDeleteProfil.Click += new System.EventHandler(this.btnDeleteProfil_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 233);
            this.Controls.Add(this.btnDeleteProfil);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddProfil);
            this.Controls.Add(this.lstProfiles);
            this.Controls.Add(this.txtProfilAdi);
            this.Controls.Add(this.lblProfilAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProfilAdi;
        private System.Windows.Forms.TextBox txtProfilAdi;
        private System.Windows.Forms.ListBox lstProfiles;
        private DevExpress.XtraEditors.SimpleButton btnAddProfil;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDeleteProfil;
    }
}