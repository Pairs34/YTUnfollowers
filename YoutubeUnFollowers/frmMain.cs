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
        const string FOLLOWERS = "https://m.youtube.com/feed/channels";
        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
            ffProfile.SetPreference("general.useragent.override", "iPhone");

            driver = new FirefoxDriver(driverService, new FirefoxOptions() { Profile = ffProfile });
            driver.Url = FOLLOWERS;
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

                GotoFullButtom();

                try
                {
                    var channels = driver.FindElements(By.XPath("//h4[@class='compact-media-item-headline']"));

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
            }
            return unFollowers;
        }

        private void btnUnfollow_Click(object sender, EventArgs e)
        {
            //main-link
            backWorker.RunWorkerAsync();
        }

        private void backWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
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

        private void btnSaveUnFollowers_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\unfollowers.txt"))
            {
                File.Create(Application.StartupPath + "\\unfollowers.txt").Close();
            }

            File.WriteAllLines(Application.StartupPath + "\\unfollowers.txt", lstUnfollowers.Items.Cast<string>().ToList());

            MessageBox.Show("All Saved");
        }

        private void btnUnfollow_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\unfollowers.txt"))
            {
                List<string> unFollowed = new List<string>();
                Task.Factory.StartNew(() =>
                {

                    var unFollowers = File.ReadAllLines(Application.StartupPath + "\\unfollowers.txt");
                    foreach (var item in unFollowers)
                    {
                        try
                        {
                            driver.Navigate().GoToUrl(item);

                            WaitForPageLoad();

                            Thread.Sleep(2000);

                            RunJSCommand(driver, "document.querySelector(\"div > ytm-subscribe-button-renderer > div > c3-material-button > button > div > div\").click()");

                            Thread.Sleep(2000);

                            RunJSCommand(driver, "document.querySelector(\"div.dialog-buttons > c3-material-button:nth-child(2) > button > div > div\").click()");

                            Thread.Sleep(2000);

                            unFollowed.Add(item);

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
                            continue;
                        }
                    }


                    if (!File.Exists(Application.StartupPath + "\\unFollowed.txt"))
                    {
                        File.Create(Application.StartupPath + "\\unFollowed.txt").Close();
                    }

                    File.WriteAllLines(Application.StartupPath + "\\unFollowed.txt", unFollowed.ToList());

                    MessageBox.Show("All Saved");

                });
            }
        }
    }
}
