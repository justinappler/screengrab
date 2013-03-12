using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ScreenGrab
{
    public class RegistrySettings
    {
        public class Settings
        {
            public bool saveToFileEnabled;
            public bool ftpEnabled;
            public bool copyLinkToClipboard;
            public String fileLocation;
            public String ftpHost;
            public String ftpUser;
            public String ftpPass;
            public String linkString;
        }

        public static bool settingsExist()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ScreenGrab\\Settings");
            String saveRes = (String)regKey.GetValue("Save to File", "null");
            String ftpRes = (String)regKey.GetValue("FTP Upload", "null");

            return !(saveRes.CompareTo("null") == 0 || ftpRes.CompareTo("null") == 0);
        }

        public static void saveSettings(Settings s)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ScreenGrab\\Settings");

            regKey.SetValue("Save to File", s.saveToFileEnabled.ToString().ToLower());
            regKey.SetValue("FTP Upload", s.ftpEnabled.ToString().ToLower());
            regKey.SetValue("Link to Clipboard", s.copyLinkToClipboard.ToString().ToLower());

            regKey.SetValue("FTP Host", s.ftpHost);
            regKey.SetValue("FTP User", s.ftpUser);
            regKey.SetValue("FTP Pass", s.ftpPass);
            regKey.SetValue("File Location", s.fileLocation);
            regKey.SetValue("Link String", s.linkString);
        }

        private static void writeDefaults()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\ScreenGrab\\Settings");

            regKey.SetValue("Save to File", "false");
            regKey.SetValue("FTP Upload", "false");
            regKey.SetValue("Link to Clipboard", "false");

            regKey.SetValue("FTP Host", "");
            regKey.SetValue("FTP User", "");
            regKey.SetValue("FTP Pass", "");
            regKey.SetValue("File Location", "");
            regKey.SetValue("Link String", "");
        }

        public static Settings getSettings()
        {
            if (!settingsExist())
                writeDefaults();

            Settings s = new Settings();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\ScreenGrab\\Settings");

            s.saveToFileEnabled = (((String)regKey.GetValue("Save to File", "null")).CompareTo("true") == 0);
            s.ftpEnabled = (((String)regKey.GetValue("FTP Upload", "null")).CompareTo("true") == 0);
            s.copyLinkToClipboard = (((String)regKey.GetValue("Link to Clipboard", "null")).CompareTo("true") == 0);

            s.fileLocation = (String)regKey.GetValue("File Location", "null");
            s.ftpHost = (String)regKey.GetValue("FTP Host", "null");
            s.ftpPass = (String)regKey.GetValue("FTP Pass", "null");
            s.ftpUser = (String)regKey.GetValue("FTP User", "null");
            s.linkString = (String)regKey.GetValue("Link String", "null");

            return s;
        }
    }
}
