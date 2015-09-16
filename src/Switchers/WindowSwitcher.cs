using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace APDS
{
    class WindowSwitcher
    {
        private static WindowSwitcher instance;
        private IntPtr GetWindowHwnd(string winTitle)
        {
            return WinApi.User_32.FindWindow((string)null, winTitle);
        }

        public WinApi.DisplaySetting_Results SetWindowMonitor(string windowTitle, int monitor)
        {
            int displayNum = monitor;
            IntPtr winToSwitch = GetWindowHwnd(windowTitle);

            IntPtr flgs = WinApi.User_32.GetWindowLong(winToSwitch, (int)WinApi.WindowLongFlags.GWL_STYLE);
            long flgsint = flgs.ToInt64();
            flgsint = flgsint & ~(int)WinApi.WindowStyles.WS_BORDER;
            flgsint = flgsint & ~(int)WinApi.WindowStyles.WS_CAPTION;
            flgsint = flgsint & ~(int)WinApi.WindowStyles.WS_DLGFRAME;
            flgsint = flgsint & ~(int)WinApi.WindowStyles.WS_SIZEFRAME;

            IntPtr flgsnew = new IntPtr(flgsint);

            WinApi.User_32.SetWindowLong(winToSwitch, (int)WinApi.WindowLongFlags.GWL_STYLE, flgsnew);

            WinApi.POINTL moveto = DisplaySwitcher.GetInstance().GetMonitorCoords(monitor);

            int movetox = moveto.x;
            int movetoy = moveto.y;

            uint sizex = DisplaySwitcher.GetInstance().GetMonitorWidth(monitor);
            uint sizey = DisplaySwitcher.GetInstance().GetMonitorHeight(monitor);

            bool res = WinApi.User_32.SetWindowPos(winToSwitch, IntPtr.Zero, movetox, movetoy, sizex, sizey, WinApi.SetWindowPosFlags.SWP_NOZORDER | WinApi.SetWindowPosFlags.SWP_SHOWWINDOW);

            if (!res)
            {
                return WinApi.DisplaySetting_Results.DISP_CHANGE_FAILED;
            }

            return WinApi.DisplaySetting_Results.DISP_CHANGE_SUCCESSFUL;
        }

        private WindowSwitcher()
        {

        }

        public static WindowSwitcher GetInstance()
        {
            if (instance == null)
            {
                instance = new WindowSwitcher();
            }
            return instance;
        }
    }
}
