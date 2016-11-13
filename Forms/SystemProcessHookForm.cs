using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace APDS
{

    public class WinHookEventArgs
    {
        public Interop.ShellEvents type;
        public string wName;

        public WinHookEventArgs(Interop.ShellEvents t, string w)
        {
            type = t;
            wName = w;
        }

        public override string ToString()
        {
            return "WinHookEventArgs: " + Enum.GetName(typeof(Interop.ShellEvents), type) + ", " + wName;
        }
    }
    public class SystemProcessHookForm : Form
    {
        private readonly int msgNotify;
        public delegate void EventHandler(object sender, WinHookEventArgs e);
        public event EventHandler WindowEvent;
        protected virtual void OnWindowEvent(WinHookEventArgs e)
        {
            var handler = WindowEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public SystemProcessHookForm()
        {
            // Hook on to the shell
            msgNotify = Interop.RegisterWindowMessage("SHELLHOOK");
            Interop.RegisterShellHookWindow(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == msgNotify)
            {
                // Receive shell messages
                switch ((Interop.ShellEvents)m.WParam.ToInt32())
                {
                    case Interop.ShellEvents.HSHELL_WINDOWDESTROYED:
                    case Interop.ShellEvents.HSHELL_WINDOWCREATED:
                        string wName = GetWindowName(m.LParam);
                        var action = (Interop.ShellEvents)m.WParam.ToInt32();
                        OnWindowEvent(new WinHookEventArgs(action, wName));
                        break;
                    case Interop.ShellEvents.HSHELL_WINDOWACTIVATED:
                        wName = GetClassName(m.LParam);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private string GetWindowName(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder();
            int longi = Interop.GetWindowTextLength(hwnd) + 1;
            sb.Capacity = longi;
            Interop.GetWindowText(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }

        private string GetClassName(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder();
            sb.EnsureCapacity(1024);
            Interop.GetClassName(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            try { Interop.DeregisterShellHookWindow(this.Handle); }
            catch { }
            base.Dispose(disposing);
        }
    }
}
