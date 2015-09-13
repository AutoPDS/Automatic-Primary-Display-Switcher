using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APDS
{
    public partial class frmGrabTitle : Form
    {
        public delegate void GrabWinTitle(string WindowTitle);
        GrabWinTitle returnWinTitle;

        public frmGrabTitle(GrabWinTitle callback)
        {
            InitializeComponent();
            returnWinTitle = callback;
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            int size = WinApi.User_32.GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                WinApi.User_32.GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }

            return String.Empty;
        }

        public static IEnumerable<string> FindWindows()
        {
            IntPtr found = IntPtr.Zero;
            List<string> windowsList = new List<string>();


            WinApi.User_32.EnumWindows(delegate(IntPtr wnd, IntPtr param)
            {
                if (WinApi.User_32.IsWindowVisible(wnd))
                {
                    string winTitle = GetWindowText(wnd);
                    if(winTitle.Length == 0)
                    {
                        return true;
                    }
                    windowsList.Add(winTitle);
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windowsList;
        }

        private void GetWinTitles()
        {
            listWinTitles.Items.Clear();

            IEnumerable<string> winList = FindWindows();

            foreach(string i in winList)
            {
                listWinTitles.Items.Add(i);
                listWinTitles.Columns[0].Width = -1;
            }
            
        }


        private void btnWinListOK_Click(object sender, EventArgs e)
        {
            if(listWinTitles.SelectedItems.Count > 0)
            {
                returnWinTitle(listWinTitles.SelectedItems[0].Text);
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWinListRefresh_Click(object sender, EventArgs e)
        {
            GetWinTitles();
        }

        private void frmGrabTitle_Load(object sender, EventArgs e)
        {
            GetWinTitles();
        }


    }
}
