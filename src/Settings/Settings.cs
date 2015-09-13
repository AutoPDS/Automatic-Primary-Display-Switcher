using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace APDS
{
    public class Settings
    {
        private bool showBalloon = true;
        public bool ShowBalloon
        {
            get
            {
                return showBalloon;
            }
            set
            {
                showBalloon = value;
            }
        }

        private bool minimizeOnClose = false;
        public bool MinimizeOnClose 
        {
            get
            {
                return minimizeOnClose;
            } 
            set
            {
                minimizeOnClose = value;
            } 
        }
        private bool startOnStartup = false;
        public bool StartOnStartup
        {
            get
            {
                return startOnStartup;
            }
            set
            {
                startOnStartup = value;
            }
        }
        private bool startMinimizedToTray = false;
        public bool StartMinimizedToTray
        {
            get
            {
                return startMinimizedToTray;
            }
            set
            {
                startMinimizedToTray = value;
            }
        }
        private string settingsFilePath;



        private static Settings singleton;

        public static Settings GetInstance()
        {
            if(singleton == null)
            {
                singleton = new Settings();
            }
            return singleton;
        }

        private Settings()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\APDS");
            settingsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\APDS\\" + APDS.Properties.Resources.SettingsFile;
        }

        public void SaveSettingsToFile()
        {
            
            FileStream fs = new FileStream(settingsFilePath, FileMode.Create);
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            ser.Serialize(fs, singleton);

            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        public void LoadSettingsFromFile()
        {

            FileStream fs;
            try
            {
                fs = new FileStream(settingsFilePath, FileMode.Open);
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                return;
            }

            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            singleton = (Settings)ser.Deserialize(fs);

            fs.Flush();
            fs.Close();
            fs.Dispose();

        }
    }
}
