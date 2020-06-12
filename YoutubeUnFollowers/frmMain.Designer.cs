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
            this.btnUnfollow = new System.Windows.Forms.Button();
            this.lstUnfollowers = new System.Windows.Forms.ListBox();
            this.lblUnfollowers = new System.Windows.Forms.Label();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUnfollow
            // 
            this.btnUnfollow.Location = new System.Drawing.Point(217, 4);
            this.btnUnfollow.Name = "btnUnfollow";
            this.btnUnfollow.Size = new System.Drawing.Size(108, 23);
            this.btnUnfollow.TabIndex = 1;
            this.btnUnfollow.Text = "Get Unfollowers";
            this.btnUnfollow.UseVisualStyleBackColor = true;
            this.btnUnfollow.Click += new System.EventHandler(this.btnUnfollow_Click);
            // 
            // lstUnfollowers
            // 
            this.lstUnfollowers.FormattingEnabled = true;
            this.lstUnfollowers.Location = new System.Drawing.Point(13, 66);
            this.lstUnfollowers.Name = "lstUnfollowers";
            this.lstUnfollowers.Size = new System.Drawing.Size(312, 251);
            this.lstUnfollowers.TabIndex = 2;
            // 
            // lblUnfollowers
            // 
            this.lblUnfollowers.AutoSize = true;
            this.lblUnfollowers.Location = new System.Drawing.Point(13, 43);
            this.lblUnfollowers.Name = "lblUnfollowers";
            this.lblUnfollowers.Size = new System.Drawing.Size(119, 13);
            this.lblUnfollowers.TabIndex = 3;
            this.lblUnfollowers.Text = "Takip Etmeyen Kanallar";
            // 
            // txtChannelName
            // 
            this.txtChannelName.Location = new System.Drawing.Point(71, 6);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(140, 20);
            this.txtChannelName.TabIndex = 4;
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.Location = new System.Drawing.Point(13, 9);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(52, 13);
            this.lblChannelName.TabIndex = 5;
            this.lblChannelName.Text = "Kanal Adı";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 327);
            this.Controls.Add(this.lblChannelName);
            this.Controls.Add(this.txtChannelName);
            this.Controls.Add(this.lblUnfollowers);
            this.Controls.Add(this.lstUnfollowers);
            this.Controls.Add(this.btnUnfollow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "YT Unfollowers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUnfollow;
        private System.Windows.Forms.ListBox lstUnfollowers;
        private System.Windows.Forms.Label lblUnfollowers;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Label lblChannelName;
    }
}

