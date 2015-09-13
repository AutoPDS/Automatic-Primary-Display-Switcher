using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APDS
{
    public partial class frmIdentifyWindow : Form
    {
        int monDisplay = -1;
        int timeLeft = 3;
        public frmIdentifyWindow(int monitorToDisplay)
        {
            monDisplay = monitorToDisplay;
            InitializeComponent();
        }

        private frmIdentifyWindow()
        {
            InitializeComponent();
        }

        private void frmIdentifyWindow_Load(object sender, EventArgs e)
        {
            //Set up the monitor label
            lblMon.Text = "This is monitor " + (monDisplay + 1) + " - " + DisplaySwitcher.GetInstance().GetDeviceName(monDisplay);

            //Set up the timer label
            lblClose.Text = "This window will close in " + timeLeft + " seconds";

            //Hide frame
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //Resize to fit the name of the monitor.
            if (lblMon.Size.Width > lblClose.Size.Width)
            {
                this.Size = new Size(lblMon.Width + 20, this.Size.Height);
            }
            else
            {
                this.Size = new Size(lblClose.Width + 20, this.Size.Height);
            }
            
            //Position the window in the centre of the monitor
            int x = DisplaySwitcher.GetInstance().GetMonitorCoords(monDisplay).x;
            int y = DisplaySwitcher.GetInstance().GetMonitorCoords(monDisplay).y;
            x += (int)DisplaySwitcher.GetInstance().GetMonitorWidth(monDisplay) / 2;
            y += (int)DisplaySwitcher.GetInstance().GetMonitorHeight(monDisplay) / 2;
            x -= this.Size.Width / 2;
            y -= this.Size.Height / 2;
            this.Location = new Point(x,y);
            
            //Align the labels to the centre of the window
            int lblx = (this.Size.Width / 2) - 1;
            int lbly = this.Size.Height / 2 + 2;
            lblx -= (int)lblClose.Size.Width / 2;
            lbly -= (int)lblClose.Size.Height / 2;
            lblClose.Location = new Point(lblx, lbly + 20);

            lblx = (this.Size.Width / 2) + 5;
            lbly = this.Size.Height / 2 - 10;
            lblx -= (int)lblMon.Size.Width / 2;
            lbly -= (int)lblMon.Size.Height / 2;

            lblMon.Location = new Point(lblx, lbly);
    
            //Start the countdown timer to close
            tmrCountdown.Start();
        }

        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblClose.Text = "This window will close in " + timeLeft + " seconds";
            if (timeLeft == 0)
            {
                tmrCountdown.Stop();
                this.Close();
            }
        }
    }
}
