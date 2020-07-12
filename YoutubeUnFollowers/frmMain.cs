using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using YoutubeUnFollowers.Helper;

namespace YoutubeUnFollowers
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        IWebDriver driver;
        const string FOLLOWERS = "https://m.youtube.com/feed/channels";
        
        public frmMain()
        {
            InitializeComponent();
            Globals.GetFFExecutePath();
            CheckForIllegalCrossThreadCalls = false;
            GetUserList();
        }

        protected void WaitForPageLoad()
        {
            try
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                WebDriverWait webDriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
                webDriverWait.Until<bool>((IWebDriver wd) => javaScriptExecutor.ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception) { }
        }

        public void GetUserList()
        {
            string localFFProfiles = Globals.FF_PROFILE_FILE;

            if (File.Exists(localFFProfiles))
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(localFFProfiles);
                cbProfiles.Properties.Items.Clear();
                foreach (var item in data.Sections.Where(x => x.SectionName.StartsWith("Profile")))
                {
                    if (!data[item.SectionName]["Name"].Contains("default"))
                        cbProfiles.Properties.Items.Add(data[item.SectionName]["Name"]);
                }
            }
        }
        List<string> GetLinks()
        {
            var Scroller = Task.Factory.StartNew(() =>
            {
                GotoFullButtom();
            });

            Task.WaitAll(new Task[] { Scroller });

            List<string> links = new List<string>();
            var elements = driver.FindElements(By.CssSelector("ytm-channel-list-item-renderer.item a.cbox.channel-list-item-link"));
            foreach (var item in elements)
            {
                links.Add(item.GetAttribute("href"));
            }

            return links;
        }

        List<string> CheckIsFollow(List<string> links)
        {
            List<string> unFollowers = new List<string>();
            foreach (var item in links)
            {
                driver.Navigate().GoToUrl(item + "/channels");

                WaitForPageLoad();

                try
                {
                    var channels = driver.FindElements(By.XPath("//h4[@class='compact-media-item-headline']"));

                    if (channels.Count == 0)
                    {
                        ClickUnFollow();
                        unFollowers.Add(item);
                    }
                    else
                    {
                        GotoFullButtom();

                        var unFollowerChannels = channels.Where(x => x.Text == txtChannelName.Text).ToList();
                        if (unFollowerChannels.Count == 0)
                        {
                            ClickUnFollow();
                            unFollowers.Add(item);
                        }
                    }
                }
                catch (Exception)
                {
                    unFollowers.Add(item);
                }
            }
            return unFollowers;
        }

        private void btnUnfollow_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtChannelName.Text))
            {
                MessageBox.Show("Kanal Adı Boş");
                return;
            }
            backWorker.RunWorkerAsync();
        }

        private void backWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            string pathToCurrentUserProfiles = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Mozilla\Firefox\Profiles";
            string[] pathsToProfiles = Directory.GetDirectories(pathToCurrentUserProfiles, $"*.default", SearchOption.TopDirectoryOnly);
            string profilePath = string.Empty;
            if (pathsToProfiles.Length != 0)
            {
                profilePath = pathsToProfiles[0];
            }

            FirefoxProfile ffProfile = new FirefoxProfile(profilePath);
            ffProfile.SetPreference("general.useragent.override", "iPhone");

            FirefoxOptions ffOptions = new FirefoxOptions();
            ffOptions.Profile = ffProfile;
            ffOptions.AddArguments(new[] { "--headless","--disable-web-security", "--user-data-dir", "--allow-running-insecure-content" });

            driver = new FirefoxDriver(driverService, ffOptions);
            driver.Url = FOLLOWERS;

            var links = GetLinks();

            var unFollowers = CheckIsFollow(links);

            lstUnfollowers.Items.AddRange(unFollowers.ToArray());
        }

        protected void RunJSCommand(IWebDriver driver, string jsCommand, object[] options = null)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            if (options != null)
            {
                javaScriptExecutor.ExecuteScript(jsCommand, options);
            }
            else
            {
                javaScriptExecutor.ExecuteScript(jsCommand);
            }

        }
        public double GetScrollPosition(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var value = js.ExecuteScript("return window.pageYOffset");
            return Convert.ToDouble(value);
        }

        double Oldpos = 0;
        public void GotoFullButtom()
        {
            double scPos = 0;
            bool isStopped = true;
            while (isStopped)
            {
                RunJSCommand(driver, $"window.scrollTo({scPos},{scPos + 10000});");
                Thread.Sleep(1000);

                try
                {
                    IWebElement LoadMore = driver.FindElement(By.XPath("//div/c3-next-continuation/c3-material-button/button"));
                    if (LoadMore != null)
                    {
                        RunJSCommand(driver, "document.querySelector(\"div > c3-next-continuation > c3-material-button > button\").click()");
                    }
                }
                catch (NoSuchElementException)
                {
                    isStopped = false;
                    break;
                }

                Thread.Sleep(1500);

                scPos = GetScrollPosition(driver);

                if (Oldpos == scPos)
                {
                    isStopped = false;
                    Console.WriteLine("Break While");
                }
                else
                {
                    Console.WriteLine(Oldpos + " - " + scPos);
                    Oldpos = scPos;
                }
            }

            Console.WriteLine("Bitti");
        }
        private void ClickUnFollow()
        {
            try
            {
                Thread.Sleep(2000);

                RunJSCommand(driver, "document.querySelector(\"div > ytm-subscribe-button-renderer > div > c3-material-button > button > div > div\").click()");

                Thread.Sleep(2000);

                RunJSCommand(driver, "document.querySelector(\"div.dialog-buttons > c3-material-button:nth-child(2) > button > div > div\").click()");

                Thread.Sleep(2000);
            }
            catch (Exception err)
            {
                try
                {
                    Thread.Sleep(2000);

                    RunJSCommand(driver, "document.querySelector(\"div > ytm-subscribe-button-renderer > div > c3-material-button > button > div > div\").click()");

                    Thread.Sleep(2000);

                    RunJSCommand(driver, "document.querySelector(\"div.dialog-buttons > c3-material-button:nth-child(2) > button > div > div\").click()");

                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
            GetUserList();
        }

        private void btnInitProfil_Click(object sender, EventArgs e)
        {
            string param = $"-P \"{cbProfiles.EditValue.ToString()}\" -new-window \"accounts.google.com\"";
            Process.Start(Globals.FF_EXECUTE_PATH, param);
        }
    }
}
