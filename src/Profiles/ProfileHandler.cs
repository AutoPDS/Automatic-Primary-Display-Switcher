using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using APDS;

namespace APDS
{
    public class ProfileHandler
    {
        private static ProfileHandler instance;
        private List<SwitchProfile> profiles = new List<SwitchProfile>();
        public List<SwitchProfile> Profiles
        {
            get { return profiles; }
            set { profiles = value; }
        }

        private string profilesFilePath;

        public static ProfileHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new ProfileHandler();
            }

            return instance;
        }

        private ProfileHandler()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\APDS");
            profilesFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\APDS\\" + APDS.Properties.Resources.ProfilesFile;
        }

        public SwitchProfile FindMatch(string windowTitle)
        {
            for (int i = 0; i < profiles.Count; i++ )
            {
                if (profiles[i].WindowTitle.Equals(windowTitle))
                {
                    return profiles[i];
                }
            }
            return null;
        }

        public void SaveProfilesToFile()
        {

            FileStream fs = new FileStream(profilesFilePath, FileMode.Create);
            XmlSerializer ser = new XmlSerializer(typeof(ProfileHandler));
            ser.Serialize(fs, instance);

            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        public void LoadProfilesFromFile()
        {
            FileStream fs;
            try
            {
                fs = new FileStream(profilesFilePath, FileMode.Open);
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }

            XmlSerializer ser = new XmlSerializer(typeof(ProfileHandler));
            instance = (ProfileHandler)ser.Deserialize(fs);

            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        public void AddNewSwitchProfile(SwitchProfile.SwitchType switchType, string windowTitle, int monitorToSwitchTo, int delay)
        {
            profiles.Add(new SwitchProfile(switchType, windowTitle, monitorToSwitchTo, delay));
        }

        public void RemoveSwitchProfile(int index)
        {
            profiles.RemoveAt(index);
        }

        public void UpdateSwitchProfile(int index, SwitchProfile.SwitchType switchType, string windowTitle, int monitorToSwitchTo, int delay)
        {
            profiles[index] = new SwitchProfile(switchType, windowTitle, monitorToSwitchTo, delay);
        }

        public int GetNumProfiles()
        {
            return profiles.Count;
        }

        public string GetProfileName(int index)
        {
            return profiles[index].WindowTitle;
        }

        public SwitchProfile GetProfile(int index)
        {
            return profiles[index];
        }

        public void ClearAllProfiles()
        {
            profiles.Clear();
        }
    }
}
