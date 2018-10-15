using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookCalendarExporter
{
    class RegistryHelper
    {
        public const string CONFIGKEY_EXPORT_ID = "ExportId";

        public static void AddApplicationToStartup()
        {
            var programName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(programName, "\"" + Application.ExecutablePath + "\" -minimized");
            }
        }

        public static void RemoveApplicationFromStartup()
        {
            var programName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue(programName, false);
            }
        }

        public static bool IsApplicationRegisteredForStartup()
        {
            var programName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (key.GetValue(programName) == null)
                    return false;
                else
                    return true;
            }
        }

        public static void SetApplicationConfigString(string key, string value)
        {
            Application.UserAppDataRegistry.SetValue(key, value);
        }

        public static string GetApplicationConfigString(string key)
        {
            var regkey = Application.UserAppDataRegistry.GetValue(key);
            if (regkey != null)
                return regkey.ToString();
            else
                return "";
        }
    }
}
