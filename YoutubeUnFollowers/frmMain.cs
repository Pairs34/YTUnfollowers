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

namespace YoutubeUnFollowers
{
    public partial class frmMain : Form
    {
        IWebDriver driver;
        const string FOLLOWERS = "https://www.youtube.com/feed/channels";
        public frmMain()
        {
            InitializeComponent();
            Process.GetProcesses()
                     .Where(pr => pr.ProcessName.Contains("gecko") || pr.ProcessName.Contains("firefox"))
                     .ForEach(p => p.Kill());
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

            driver = new FirefoxDriver(driverService,new FirefoxOptions() { Profile = ffProfile });
            driver.Url = FOLLOWERS;
        }

        public double GetScrollPosition(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var value = js.ExecuteScript("return window.scrollHeight;");
            return Convert.ToDouble(value);
        }

        public double OldPosition = 0;
        public int attempt = 0;
        public void GotoFullButtom()
        {
            if (attempt == 30)
            {
                return;
            }

            var scPosition = GetScrollPosition(driver);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo([0], 1000)", scPosition);

            Thread.Sleep(2000);
            attempt++;
            GotoFullButtom();
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

        List<string> GetLinks()
        { 
            List<string> links = new List<string>();
            var elements = driver.FindElements(By.Id("main-link"));
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
                //string url = "https://www.youtube.com/user/ExtremitySoft/channels";
                driver.Navigate().GoToUrl(item + "/channels");

                WaitForPageLoad();

                GotoFullButtom();

                try
                {
                    var channels = driver.FindElements(By.XPath("//span[@id='title']"));

                    if (channels.Count == 0)
                    {
                        unFollowers.Add(item);
                    }
                    else
                    {
                        var unFollowerChannels = channels.Where(x => x.Text == txtChannelName.Text).ToList();
                        if (unFollowerChannels.Count == 0)
                        {
                            unFollowers.Add(item);
                        }
                    }
                }
                catch (Exception)
                {
                    unFollowers.Add(item);
                }

                break;
            }
            return unFollowers;
        }

        private void btnUnfollow_Click(object sender, EventArgs e)
        {
            //main-link

            var links = GetLinks();

            var unFollowers = CheckIsFollow(links);

            lstUnfollowers.Items.AddRange(unFollowers.ToArray());
        }
    }
}
