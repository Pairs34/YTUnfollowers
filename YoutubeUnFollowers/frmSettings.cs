using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeUnFollowers.Helper;

namespace YoutubeUnFollowers
{
    public partial class frmSettings : DevExpress.XtraEditors.XtraForm
    {
        public frmSettings()
        {
            InitializeComponent();
            GetUserList();
        }

        public void GetUserList()
        {
            string localFFProfiles = Globals.FF_PROFILE_FILE;

            if (File.Exists(localFFProfiles))
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(localFFProfiles);
                lstProfiles.Items.Clear();
                foreach (var item in data.Sections.Where(x => x.SectionName.StartsWith("Profile")))
                {
                    if (!data[item.SectionName]["Name"].Contains("default"))
                        lstProfiles.Items.Add(data[item.SectionName]["Name"]);
                }
            }
        }
        private async Task<bool> CreateProfile()
        {
            try
            {
                if (Globals.FF_EXECUTE_PATH == null)
                {
                    MessageBox.Show("Firefox dizini bulunamadı. Lütfen firefox'un kurulu olduğundan emin olun.");
                    return false;
                }

                string param = $"-CreateProfile \"{txtProfilAdi.Text}\"";
                Process.Start(Globals.FF_EXECUTE_PATH, param);

                await Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1500);
                    GetUserList();
                    txtProfilAdi.ResetText();
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetUserList();
        }

        private async void btnAddProfil_Click(object sender, EventArgs e)
        {
            bool isProfileCreated = await CreateProfile();
            if (isProfileCreated)
            {
                GetUserList();
            }
            else
            {
                MessageBox.Show("Profil oluşturulamadı.");
            }
        }

        private void btnDeleteProfil_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.FF_EXECUTE_PATH, "-p");
        }
    }
}
