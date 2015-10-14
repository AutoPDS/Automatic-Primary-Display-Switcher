using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace APDS
{
    class DisplaySwitcher
    {
        private List<WinApi.DISPLAY_DEVICE> ddevices = new List<WinApi.DISPLAY_DEVICE>();
        private List<WinApi.DEVMODE> dmodes = new List<WinApi.DEVMODE>();
        private List<WinApi.DISPLAY_DEVICE> dnames = new List<WinApi.DISPLAY_DEVICE>();
        private int primaryMonitor;
        private static DisplaySwitcher instance;
        public int PrimaryMonitor
        {
            get { return primaryMonitor; }
            set { primaryMonitor = value; }
        }
        public static WinApi.DEVMODE NewDevMode()
        {
            WinApi.DEVMODE dm = new WinApi.DEVMODE();
            dm.dmDeviceName = new String(new char[31]);
            dm.dmFormName = new String(new char[31]);
            dm.dmSize = (ushort)Marshal.SizeOf(dm);
            return dm;
        }

        public void RefreshDisplays()
        {
            for (int i = 0; i < this.ddevices.Count; i++)
            {
                WinApi.DEVMODE mode = dmodes[i];
                WinApi.User_32.EnumDisplaySettings(this.ddevices[i].DeviceName, (int)WinApi.DEVMODE_SETTINGS.ENUM_REGISTRY_SETTINGS, ref mode);
                this.dmodes[i] = mode;

                WinApi.DISPLAY_DEVICE device = ddevices[i];
                WinApi.User_32.EnumDisplayDevices(null, i, ref device, 0);
                ddevices[i] = device;
                
            }

        }

        public void RefreshPrimaryDisplay()
        {
            for (int i = 0; i < ddevices.Count; i++ )
            {
                bool primary = ((ddevices[i].StateFlags & WinApi.Display_Device_Stateflags.DISPLAY_DEVICE_PRIMARY_DEVICE) == WinApi.Display_Device_Stateflags.DISPLAY_DEVICE_PRIMARY_DEVICE);
                //test if the display is active
                if (primary)
                {
                    primaryMonitor = i;
                    break;
                }
            }
        }

        public bool EnumDisplays()
        {
            bool success = true;
            int count = 0;

            while (success == true)
            {
                ddevices.Add(new WinApi.DISPLAY_DEVICE());
                WinApi.DISPLAY_DEVICE device = ddevices[count];
                device.cb = Marshal.SizeOf(device);

                success = WinApi.User_32.EnumDisplayDevices(null, count, ref device, 0);

                ddevices[count] = device;

                if (success)
                {
                    dmodes.Add(NewDevMode());
                    WinApi.DEVMODE mode = dmodes[count];
                    WinApi.User_32.EnumDisplaySettings(device.DeviceName, (int)WinApi.DEVMODE_SETTINGS.ENUM_REGISTRY_SETTINGS, ref mode);
                    dmodes[count] = mode;

                    
                    WinApi.DISPLAY_DEVICE dd = ddevices[count];
                    WinApi.User_32.EnumDisplayDevices(dd.DeviceName, 0, ref dd, 0);
                    dnames.Add(dd);

                    frmMain.WriteDebugMessage("Device found: " + count + ", deviceID: " + dd.DeviceID + ", deviceName: " + dd.DeviceName + ", deviceString: " + dd.DeviceString + ", position:" + mode.dmPosition.x + ", " + mode.dmPosition.y + ", size: " + mode.dmPelsWidth + ", " + mode.dmPelsHeight);

                }
                else
                {
                    ddevices.RemoveAt(count);
                }

                count++;
            }

            //clean up displays, remove inactive
            int numdevices = ddevices.Count;
            for (int i = numdevices - 1; i >= 0; i--)
            {
                bool active = ((ddevices[i].StateFlags & WinApi.Display_Device_Stateflags.DISPLAY_DEVICE_ATTACHED_TO_DESKTOP) == WinApi.Display_Device_Stateflags.DISPLAY_DEVICE_ATTACHED_TO_DESKTOP);
                //test if the display is active
                if (!active)
                {
                    //if not active, remove the display and mode from the list.
                    ddevices.RemoveAt(i);
                    dmodes.RemoveAt(i);
                }
            }

            if (ddevices.Count == 0)
            {
                return false;
            }

            return true;
        }

        public WinApi.DisplaySetting_Results SetPrimaryDisplay(int displayNum)
        {
            WinApi.DEVMODE dev;
            WinApi.POINTL zero;
            zero = new WinApi.POINTL();
            zero.x = 0;
            zero.y = 0;
            int flags;
            WinApi.DisplaySetting_Results result;

            WinApi.POINTL currentpos = dmodes[displayNum].dmPosition;

            bool primary = ((ddevices[displayNum].StateFlags & WinApi.Display_Device_Stateflags.DISPLAY_DEVICE_PRIMARY_DEVICE) == WinApi.Display_Device_Stateflags.DISPLAY_DEVICE_PRIMARY_DEVICE);
            if (primary)
            {
                return WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL;
            }

            for (int i = 0; i < ddevices.Count; i++)
            {

                dev = dmodes[i];

                dev.dmPosition = dmodes[i].dmPosition + (zero - currentpos);
                dev.dmFields = WinApi.DEVMODE_Flags.DM_POSITION;

                flags = (int)WinApi.DeviceFlags.CDS_UPDATEREGISTRY | (int)WinApi.DeviceFlags.CDS_NORESET;

                result = (WinApi.DisplaySetting_Results)WinApi.User_32.ChangeDisplaySettingsEx(ddevices[i].DeviceName, ref dev, (IntPtr)null, flags, IntPtr.Zero);

                if (result != WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL)
                {
                    return result;
                }

            }

            WinApi.DEVMODE d = NewDevMode();

            /*result = (WinApi.DisplaySetting_Results)WinApi.User_32.ChangeDisplaySettingsEx((String)null, (IntPtr)null, (IntPtr)null, 0, IntPtr.Zero);
            if (result != WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL)
            {
                return result;
            }*/

            RefreshDisplays();

            dev = dmodes[displayNum];
            flags = (int)WinApi.DeviceFlags.CDS_SET_PRIMARY | (int)WinApi.DeviceFlags.CDS_UPDATEREGISTRY | (int)WinApi.DeviceFlags.CDS_NORESET;

            result = (WinApi.DisplaySetting_Results)WinApi.User_32.ChangeDisplaySettingsEx(ddevices[displayNum].DeviceName, ref dev, (IntPtr)null, flags, IntPtr.Zero);
            if (result != WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL)
            {
                return result;
            }

            result = (WinApi.DisplaySetting_Results)WinApi.User_32.ChangeDisplaySettingsEx((String)null, (IntPtr)null, (IntPtr)null, 0, IntPtr.Zero);
            if (result != WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL)
            {
                return result;
            }

            RefreshDisplays();

            return WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL;
        }

        public int GetNumDisplays()
        {
            return ddevices.Count;
        }

        public String GetDeviceName(int displayIndex)
        {
            return dnames[displayIndex].DeviceString;
        }

        public WinApi.POINTL GetMonitorCoords(int displayIndex)
        {
            WinApi.POINTL ret = dmodes[displayIndex].dmPosition;
            return ret;
        }

        public uint GetMonitorWidth(int displayIndex)
        {
            return dmodes[displayIndex].dmPelsWidth;
        }

        public uint GetMonitorHeight(int displayIndex)
        {
            return dmodes[displayIndex].dmPelsHeight;
        }

        private DisplaySwitcher()
        {
            if (!EnumDisplays())
            {
                Console.WriteLine("Failed to enumerate display devices!");
                return;
            }
            RefreshPrimaryDisplay();
        }

        public static DisplaySwitcher GetInstance()
        {
            if (instance == null)
            {
                instance = new DisplaySwitcher();
            }

            return instance;
        }
    }
}
