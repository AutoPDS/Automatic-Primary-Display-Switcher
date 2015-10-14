using System;
using System.Runtime.InteropServices;
using System.Text;

public class WinApi
{
    public const Int32 CCHDEVICENAME = 32;
    public const Int32 CCHFORMNAME = 32;

    public delegate bool EnumWindowsDelegate(IntPtr hwnd, IntPtr lParam);

    public enum SetWindowPosFlags : uint
    {
        /// <summary>If the calling thread and the thread that owns the window are attached to different input queues, 
        /// the system posts the request to the thread that owns the window. This prevents the calling thread from 
        /// blocking its execution while other threads process the request.</summary>
        /// <remarks>SWP_ASYNCWINDOWPOS</remarks>
        SWP_ASYNCWINDOWPOS = 0x4000,
        /// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
        /// <remarks>SWP_DEFERERASE</remarks>
        SWP_DEFERERASE = 0x2000,
        /// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
        /// <remarks>SWP_DRAWFRAME</remarks>
        SWP_DRAWFRAME = 0x0020,
        /// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to 
        /// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE 
        /// is sent only when the window's size is being changed.</summary>
        /// <remarks>SWP_FRAMECHANGED</remarks>
        SWP_FRAMCHANGED = 0x0020,
        /// <summary>Hides the window.</summary>
        /// <remarks>SWP_HIDEWINDOW</remarks>
        SWP_HIDEWINDOW = 0x0080,
        /// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the 
        /// top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter 
        /// parameter).</summary>
        /// <remarks>SWP_NOACTIVATE</remarks>
        SWP_NOACTIVATE = 0x0010,
        /// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid 
        /// contents of the client area are saved and copied back into the client area after the window is sized or 
        /// repositioned.</summary>
        /// <remarks>SWP_NOCOPYBITS</remarks>
        SWP_NOCOPYBITS = 0x0100,
        /// <summary>Retains the current position (ignores X and Y parameters).</summary>
        /// <remarks>SWP_NOMOVE</remarks>
        SWP_NOMOVE = 0x0002,
        /// <summary>Does not change the owner window's position in the Z order.</summary>
        /// <remarks>SWP_NOOWNERZORDER</remarks>
        SWP_NOOWNERZORDER = 0x0200,
        /// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to 
        /// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent 
        /// window uncovered as a result of the window being moved. When this flag is set, the application must 
        /// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
        /// <remarks>SWP_NOREDRAW</remarks>
        SWP_NOREDRAW = 0x0008,
        /// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
        /// <remarks>SWP_NOREPOSITION</remarks>
        SWP_NOREPOSITION = 0x0200,
        /// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
        /// <remarks>SWP_NOSENDCHANGING</remarks>
        SWP_NOSENDCHANGING = 0x0400,
        /// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
        /// <remarks>SWP_NOSIZE</remarks>
        SWP_NOSIZE = 0x0001,
        /// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
        /// <remarks>SWP_NOZORDER</remarks>
        SWP_NOZORDER = 0x0004,
        /// <summary>Displays the window.</summary>
        /// <remarks>SWP_SHOWWINDOW</remarks>
        SWP_SHOWWINDOW = 0x0040
    }

    public enum WindowStyles : uint
    {
        /// <summary>The window has a thin-line border.</summary>
        WS_BORDER = 0x800000,

        /// <summary>The window has a title bar (includes the WS_BORDER style).</summary>
        WS_CAPTION = 0xc00000,

        /// <summary>The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.</summary>
        WS_CHILD = 0x40000000,

        /// <summary>Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.</summary>
        WS_CLIPCHILDREN = 0x2000000,

        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated.
        /// If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        WS_CLIPSIBLINGS = 0x4000000,

        /// <summary>The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.</summary>
        WS_DISABLED = 0x8000000,

        /// <summary>The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.</summary>
        WS_DLGFRAME = 0x400000,

        /// <summary>
        /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style.
        /// The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
        /// </summary>
        WS_GROUP = 0x20000,

        /// <summary>The window has a horizontal scroll bar.</summary>
        WS_HSCROLL = 0x100000,

        /// <summary>The window is initially maximized.</summary> 
        WS_MAXIMIZE = 0x1000000,

        /// <summary>The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.</summary> 
        WS_MAXIMIZEBOX = 0x10000,

        /// <summary>The window is initially minimized.</summary>
        WS_MINIMIZE = 0x20000000,

        /// <summary>The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.</summary>
        WS_MINIMIZEBOX = 0x20000,

        /// <summary>The window is an overlapped window. An overlapped window has a title bar and a border.</summary>
        WS_OVERLAPPED = 0x0,

        /// <summary>The window is an overlapped window.</summary>
        WS_OVERLAPPEDWINDOW = (uint)WS_OVERLAPPED | (uint)WS_CAPTION | (uint)WS_SYSMENU | (uint)WS_SIZEFRAME | (uint)WS_MINIMIZEBOX | (uint)WS_MAXIMIZEBOX,

        /// <summary>The window is a pop-up window. This style cannot be used with the WS_CHILD style.</summary>
        WS_POPUP = 0x80000000u,

        /// <summary>The window is a pop-up window. The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.</summary>
        WS_POPUPWINDOW = (uint)WS_POPUP | (uint)WS_BORDER | (uint)WS_SYSMENU,

        /// <summary>The window has a sizing border.</summary>
        WS_SIZEFRAME = 0x40000,

        /// <summary>The window has a window menu on its title bar. The WS_CAPTION style must also be specified.</summary>
        WS_SYSMENU = 0x80000,

        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key.
        /// Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.  
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
        /// For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
        /// </summary>
        WS_TABSTOP = 0x10000,

        /// <summary>The window is initially visible. This style can be turned on and off by using the ShowWindow or SetWindowPos function.</summary>
        WS_VISIBLE = 0x10000000,

        /// <summary>The window has a vertical scroll bar.</summary>
        WS_VSCROLL = 0x200000
    }
    public enum WindowLongFlags : int
    {
        GWL_EXSTYLE = -20,
        GWLP_HINSTANCE = -6,
        GWLP_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_USERDATA = -21,
        GWL_WNDPROC = -4,
        DWLP_USER = 0x8,
        DWLP_MSGRESULT = 0x0,
        DWLP_DLGPROC = 0x4
    }

    public enum DEVMODE_SETTINGS
    {
        ENUM_CURRENT_SETTINGS = (-1),
        ENUM_REGISTRY_SETTINGS = (-2)
    }

    public enum Display_Device_Stateflags
    {
        DISPLAY_DEVICE_ATTACHED_TO_DESKTOP = 0x1,
        DISPLAY_DEVICE_MIRRORING_DRIVER = 0x8,
        DISPLAY_DEVICE_MODESPRUNED = 0x8000000,
        DISPLAY_DEVICE_MULTI_DRIVER = 0x2,
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x4,
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x10
    }

    public enum DeviceFlags
    {
        CDS_FULLSCREEN = 0x4,
        CDS_GLOBAL = 0x8,
        CDS_NORESET = 0x10000000,
        CDS_RESET = 0x40000000,
        CDS_SET_PRIMARY = 0x10,
        CDS_TEST = 0x2,
        CDS_UPDATEREGISTRY = 0x1,
        CDS_VIDEOPARAMETERS = 0x20,
    }

    public enum DEVMODE_Flags
    {
        DM_BITSPERPEL = 0x40000,
        DM_DISPLAYFLAGS = 0x200000,
        DM_DISPLAYFREQUENCY = 0x400000,
        DM_PELSHEIGHT = 0x100000,
        DM_PELSWIDTH = 0x80000,
        DM_POSITION = 0x20
    }

    public enum DisplaySetting_Results
    {
        DISP_CHANGE_BADFLAGS = -4,
        DISP_CHANGE_BADMODE = -2,
        DISP_CHANGE_BADPARAM = -5,
        DISP_CHANGE_FAILED = -1,
        DISP_CHANGE_NOTUPDATED = -3,
        DISP_CHANGE_RESTART = 1,
        DISP_CHANGE_SUCCESSFUL = 0
    }

    [StructLayout(LayoutKind.Sequential)] 
    public struct POINTL 
    { 
        [MarshalAs(UnmanagedType.I4)] 
        public int x; 
        [MarshalAs(UnmanagedType.I4)] 
        public int y; 

        public static POINTL operator -(POINTL p1, POINTL p2)
        {
            POINTL ret = new POINTL();
            ret.x = p1.x - p2.x;
            ret.y = p1.y - p2.y;

            return ret;
        }
        public static POINTL operator +(POINTL p1, POINTL p2)
        {
            POINTL ret = new POINTL();
            ret.x = p1.x + p2.x;
            ret.y = p1.y + p2.y;

            return ret;
        }


    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmSpecVersion;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmDriverVersion;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmSize;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmDriverExtra;

        [MarshalAs(UnmanagedType.U4)]
        public DEVMODE_Flags dmFields;

        public POINTL dmPosition;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayOrientation;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFixedOutput;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmColor;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmDuplex;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmYResolution;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmTTOption;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmCollate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmLogPixels;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmBitsPerPel;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPelsWidth;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPelsHeight;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFlags;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFrequency;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmICMMethod;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmICMIntent;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmMediaType;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDitherType;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmReserved1;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmReserved2;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPanningWidth;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPanningHeight;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DISPLAY_DEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public Display_Device_Stateflags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }


    public class User_32
    {
        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettingsEx(string lpszDeviceName, [In] ref DEVMODE lpDevMode, IntPtr hwnd, int dwFlags, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettingsEx(string lpszDeviceName, IntPtr lpDevMode, IntPtr hwnd, int dwFlags, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string lpDevice, int iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);

        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsDelegate enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWindInsertAfter, int X, int Y, uint cx, uint cy, SetWindowPosFlags uFlags);

        public static IntPtr GetWindowLong(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
            {
                return GetWindowLong32(hWnd, nIndex);
            }
            return GetWindowLongPtr64(hWnd, nIndex);
        }


        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLong32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }


        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLong32(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();

    }

}
