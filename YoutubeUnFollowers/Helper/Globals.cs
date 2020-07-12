using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeUnFollowers.Helper
{
    public static class Globals
    {
        public static string FF_EXECUTE_PATH = String.Empty;
        public static string FF_PROFILE_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + "\\Mozilla\\Firefox\\profiles.ini";
        public static void GetFFExecutePath()
        {
            RegistryKey browserKeys;
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            string[] browserNames = browserKeys.GetSubKeyNames();

            foreach (var item in browserNames)
            {
                var commandKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet\" + item + @"\shell\open\command");
                if (commandKey != null)
                {
                    var brwPath = commandKey.GetValue("");
                    if (brwPath.ToString().Contains("firefox.exe"))
                    {
                        FF_EXECUTE_PATH = brwPath.ToString();
                    }
                }
            }
        }
    }
}
