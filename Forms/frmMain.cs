//define console if you need the console window to appear.
//#define CONSOLE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using APDS;
using System.Diagnostics;



namespace APDS
{
    public partial class frmMain : Form
    {
        
        SystemProcessHookForm sphfForm;
        System.Windows.Forms.NotifyIcon ntfIcon;
        ContextMenuStrip cmsNtfIcon;
        static string logFilePath;

        //this gets set to true whenever we try to restore from tray.
        bool allowshow = false;

        public frmMain()
        {

            SetupDebugFile();

            InitializeComponent();

            //Set up our display switching class
            DisplaySwitcher.GetInstance();
            WindowSwitcher.GetInstance();

            SetupSettings();

            SetupTrayContext();

            SetupTrayIcon();

            SetupMenuStates();

            SetupIcons();

            SetupWindowHooks();

            SetupData();

            SetupEvents();

        }

        #region Setups
        /// <summary>
        /// Setup all the required controls, data etc.
        /// 
        /// </summary>
        private void SetupSettings()
        {
            Settings.GetInstance().LoadSettingsFromFile();
            ProfileHandler.GetInstance().LoadProfilesFromFile();
        }
        private void SetupTrayContext()
        {
            //Set up Notification Context Menu
            cmsNtfIcon = new ContextMenuStrip();
            cmsNtfIcon.Items.Add("Open " + APDS.Properties.Resources.APDSTitle);
            cmsNtfIcon.Items.Add("Exit");
            cmsNtfIcon.Items[0].Click += cmsNtfIcon0_Click;
            cmsNtfIcon.Items[1].Click += cmsNtfIcon1_Click;
        }

        private void SetupTrayIcon()
        {
            //Set up our new notification tray Icon
            ntfIcon = new NotifyIcon();
            ntfIcon.MouseDoubleClick += ntfIcon_MouseDoubleClick;
            ntfIcon.Visible = true;
            ntfIcon.Text = APDS.Properties.Resources.APDSTitle;
            ntfIcon.ContextMenuStrip = cmsNtfIcon;
            ntfIcon.BalloonTipTitle = "Automatic Primary Display Switcher";
            ntfIcon.BalloonTipText = "Double click to open";
        }

        private void SetupMenuStates()
        {
            //Set up menu strip option states
            minimizeToTrayWhenClosedToolStripMenuItem.Checked = Settings.GetInstance().MinimizeOnClose;
            showBalloonTipWhenMinimizingToTrayToolStripMenuItem.Checked = Settings.GetInstance().ShowBalloon;
            startMinimizedToTrayToolStripMenuItem.Checked = Settings.GetInstance().StartMinimizedToTray;
            startWithWindowsToolStripMenuItem.Checked = Settings.GetInstance().StartOnStartup;
        }

        private void SetupIcons()
        {
            //Set up icons
            this.Icon = APDS.Properties.Resources.AutomaticPrimaryDisplaySwitcher32ppi;
            ntfIcon.Icon = APDS.Properties.Resources.AutomaticPrimaryDisplaySwitcher32ppi;
        }

        private void SetupWindowHooks()
        {
            //Set up our window hooks
            sphfForm = new SystemProcessHookForm();
            sphfForm.WindowEvent += new SystemProcessHookForm.EventHandler(ProcessWinOpen);
            Thread newThread = new System.Threading.Thread(RunEvents);
            newThread.Start();
        }

        private void SetupData()
        {
            //Populate the drop down list
            int numDisplays = DisplaySwitcher.GetInstance().GetNumDisplays();

            for (int i = 0; i < numDisplays; i++)
            {
                cmbDisplays.Items.Insert(i, "Monitor " + (i + 1) + " : " + DisplaySwitcher.GetInstance().GetDeviceName(i));
            }
            cmbDisplays.SelectedIndex = 0;

            for (int i = 0; i < numDisplays; i++)
            {
                cmbDisplays2.Items.Insert(i, "Monitor " + (i + 1) + " : " + DisplaySwitcher.GetInstance().GetDeviceName(i));
            }
            cmbDisplays2.SelectedIndex = 0;

            cmbSwitchTypes.Items.Insert(0, "Switch Primary Monitor");
            cmbSwitchTypes.Items.Insert(1, "Move Window to Monitor");
            cmbSwitchTypes.SelectedIndex = 0;
            
            ReloadList();
        }

        private void SetupEvents()
        {
            //Switch Type section
            grpSwitch.MouseEnter += new System.EventHandler(this.grpSwitch_MouseEnter);
            grpSwitch.MouseLeave += new System.EventHandler(this.grpSwitch_MouseLeave);
            labelType.MouseEnter += new System.EventHandler(this.grpSwitch_MouseEnter);
            labelType.MouseLeave += new System.EventHandler(this.grpSwitch_MouseLeave);
            cmbSwitchTypes.MouseEnter += new System.EventHandler(this.grpSwitch_MouseEnter);
            cmbSwitchTypes.MouseLeave += new System.EventHandler(this.grpSwitch_MouseLeave);
            
            grpDisplay.MouseEnter += new System.EventHandler(this.grpDisplay_MouseEnter);
            grpDisplay.MouseLeave += new System.EventHandler(this.grpDisplay_MouseLeave);
            lblDisplays.MouseEnter += new System.EventHandler(this.grpDisplay_MouseEnter);
            lblDisplays.MouseLeave += new System.EventHandler(this.grpDisplay_MouseLeave);
            cmbDisplays.MouseEnter += new System.EventHandler(this.grpDisplay_MouseEnter);
            cmbDisplays.MouseLeave += new System.EventHandler(this.grpDisplay_MouseLeave);

            grpWindow.MouseEnter += new System.EventHandler(this.grpWindow_MouseEnter);
            grpWindow.MouseLeave += new System.EventHandler(this.grpWindow_MouseLeave);
            labelWindow.MouseEnter += new System.EventHandler(this.grpWindow_MouseEnter);
            labelWindow.MouseLeave += new System.EventHandler(this.grpWindow_MouseLeave); 
            textWinTitle.MouseEnter += new System.EventHandler(this.grpWindow_MouseEnter);
            textWinTitle.MouseLeave += new System.EventHandler(this.grpWindow_MouseLeave);

            grpDelay.MouseEnter += new System.EventHandler(this.grpDelay_MouseEnter);
            grpDelay.MouseLeave += new System.EventHandler(this.grpDelay_MouseLeave);
            numDelay.MouseEnter += new System.EventHandler(this.grpDelay_MouseEnter);
            numDelay.MouseLeave += new System.EventHandler(this.grpDelay_MouseLeave);
            labelDelay.MouseEnter += new System.EventHandler(this.grpDelay_MouseEnter);
            labelDelay.MouseLeave += new System.EventHandler(this.grpDelay_MouseLeave);
            
            grpSummary.MouseEnter += new System.EventHandler(this.grpSummary_MouseEnter);
            grpSummary.MouseLeave += new System.EventHandler(this.grpSummary_MouseLeave);
            lblSummary.MouseEnter += new System.EventHandler(this.grpSummary_MouseEnter);
            lblSummary.MouseLeave += new System.EventHandler(this.grpSummary_MouseLeave);

            grpPrimMon.MouseEnter += new System.EventHandler(this.grpPrimMon_MouseEnter);
            grpPrimMon.MouseLeave += new System.EventHandler(this.grpPrimMon_MouseLeave);
            labelPrimMon.MouseEnter += new System.EventHandler(this.grpPrimMon_MouseEnter);
            labelPrimMon.MouseLeave += new System.EventHandler(this.grpPrimMon_MouseLeave);
            cmbDisplays2.MouseEnter += new System.EventHandler(this.grpPrimMon_MouseEnter);
            cmbDisplays2.MouseLeave += new System.EventHandler(this.grpPrimMon_MouseLeave);
            
        }

        private void ReloadList()
        {
            listRules.Items.Clear();
            int numProfiles = ProfileHandler.GetInstance().GetNumProfiles();

            for (int i = 0; i < numProfiles; i++)
            {
                listRules.Items.Add(ProfileHandler.GetInstance().GetProfileName(i));
            }
            listRules.Columns[0].Width = -1;
        }

        [ConditionalAttribute("CONSOLE")]
        private void SetupConsole()
        {
            WinApi.User_32.AllocConsole();
        }

        [ConditionalAttribute("DEBUG")]
        private void SetupDebugFile()
        {
            logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\APDS\\debug.log";
            SetupConsole();
        }

        #endregion

        #region Context Menu
        /// <summary>
        /// All events for the context menu items
        /// </summary>

        private void cmsNtfIcon0_Click(object sender, EventArgs e)
        {
            allowshow = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ntfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            allowshow = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void cmsNtfIcon1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Core Functionality
        /// <summary>
        /// Functionality to do with calling the Display Switcher or Window Mover singletons
        /// in order to actually perform functionality. Also contains threading stuff.
        /// </summary>


        private void ProcessWinOpen(object sender, WinHookEventArgs e)
        {
            SwitchProfile p = ProfileHandler.GetInstance().FindMatch(e.wName);
            if (p != null)
            {
                WriteDebugMessage("Found window: " + e.wName);
                CreateDisplaySwitchThread(e, p);
            }            
        }


        [ConditionalAttribute("CONSOLE")]
        public static void DebugLog(string message)
        {
            Console.WriteLine(message);
        }


        [ConditionalAttribute("DEBUG")]
        public static void WriteDebugMessage(string message)
        {
            string logMessage = "[APDS " + System.DateTime.Now + "] - " + message;
            using (StreamWriter wr =
                new StreamWriter(logFilePath, true))
            {
                wr.WriteLine(logMessage);
            }
            DebugLog(logMessage);

        }

        void CreateDisplaySwitchThread(WinHookEventArgs e, SwitchProfile p)
        {
            switch (e.type)
            {
                case (Interop.ShellEvents.HSHELL_WINDOWCREATED):
                {
                    Thread switchMon;
                    WriteDebugMessage("Window Created. SwitchType: " + p.Type.ToString());
                    switch (p.Type)
                    {
                        case (SwitchProfile.SwitchType.SWITCH_MONITOR):
                        {
                            DisplaySwitcher.GetInstance().RefreshPrimaryDisplay();
                            switchMon = new System.Threading.Thread(() => DisplaySwitcher.GetInstance().SetPrimaryDisplay(p.MonitorToSwitchTo));
                            switchMon.Start();
                            break;
                        }
                        case (SwitchProfile.SwitchType.SWITCH_WINDOW):
                        {
                            switchMon = new System.Threading.Thread(() => MoveWindow(p.WindowTitle, p.MonitorToSwitchTo));
                            switchMon.Start();
                            break;
                        }
                    }

                    break;
                }
                case (Interop.ShellEvents.HSHELL_WINDOWDESTROYED):
                {
                    if (p.Type == SwitchProfile.SwitchType.SWITCH_MONITOR)
                    {
                        Thread processSwitch = new System.Threading.Thread(() => DelayedSwitch(p.Delay, DisplaySwitcher.GetInstance().PrimaryMonitor));
                        processSwitch.Start();
                    }
                    break;
                }
            }
        }

        private void DelayedSwitch(int delay, int monitor)
        {
            WriteDebugMessage("Setting Display " + monitor + " as primary monitor in " + delay + "ms.");
            Thread.Sleep(delay);
            DisplaySwitcher.GetInstance().SetPrimaryDisplay(monitor);
        }

        private void MoveWindow(string window, int monitor)
        {
            WriteDebugMessage("Moving window " + window + " to monitor " + monitor + "in 1 second.");
            Thread.Sleep(1000);
            WindowSwitcher.GetInstance().SetWindowMonitor(window, monitor);
        }

        private void RunEvents()
        {
            Application.DoEvents();
        }
        #endregion

        #region Tray
        /// <summary>
        /// Tray icon functions, minimizing, FormClosing override, 
        /// SetVisibleCore override for minimize to tray on start
        /// </summary>

        protected override void SetVisibleCore(bool value)
        {
            if (Settings.GetInstance().StartMinimizedToTray && (!allowshow))
            {
                value = false;
                this.WindowState = FormWindowState.Minimized;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Settings.GetInstance().MinimizeOnClose)
                {
                    e.Cancel = true;
                    MinimizeToTray();
                    return;
                }
            }

            Settings.GetInstance().SaveSettingsToFile();
            ProfileHandler.GetInstance().SaveProfilesToFile();
        }

        private void MinimizeToTray()
        {
            if (Settings.GetInstance().ShowBalloon)
            {
                ntfIcon.ShowBalloonTip(500);
            }

            this.Hide();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                MinimizeToTray();
            }
        }

        #endregion

        #region Menu
        /// <summary>
        /// All menu toolstrip functions
        /// </summary>

        private void minimizeToTrayWhenClosedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.GetInstance().MinimizeOnClose = !(Settings.GetInstance().MinimizeOnClose);
            minimizeToTrayWhenClosedToolStripMenuItem.Checked = Settings.GetInstance().MinimizeOnClose;
        }

        private void showBalloonTipWhenMinimizingToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.GetInstance().ShowBalloon = !(Settings.GetInstance().ShowBalloon);
            showBalloonTipWhenMinimizingToTrayToolStripMenuItem.Checked = Settings.GetInstance().ShowBalloon;
        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.GetInstance().StartOnStartup = !(Settings.GetInstance().StartOnStartup);
            startWithWindowsToolStripMenuItem.Checked = Settings.GetInstance().StartOnStartup;

            RegistryKey rkStartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (Settings.GetInstance().StartOnStartup)
            {
                rkStartup.SetValue("APDS", Application.ExecutablePath.ToString());
            }
            else
            {
                rkStartup.DeleteValue("APDS", false);
            }

            rkStartup.Close();
        }

        private void startMinimizedToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.GetInstance().StartMinimizedToTray = !(Settings.GetInstance().StartMinimizedToTray);
            startMinimizedToTrayToolStripMenuItem.Checked = Settings.GetInstance().StartMinimizedToTray;
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearAllRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileHandler.GetInstance().ClearAllProfiles();
            listRules.Items.Clear();
            listRules.Focus();

            grpDelay.Enabled = false;
            grpDisplay.Enabled = false;
            grpSummary.Enabled = false;
            grpSwitch.Enabled = false;
            grpWindow.Enabled = false;

            lblSummary.Text = "";

        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Automatic Primary Display Switcher. \n © 2015 Sam Evans-Turner.", "About APDS.", MessageBoxButtons.OK);
        }

        #endregion

        #region StatusStrip
        /// <summary>
        /// Setup the events for updating the status strip.
        /// 
        /// </summary>
        private void listRules_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "A list of all rules that will be applied by this program.";
        }

        private void listRules_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void grpSwitch_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "The type of switch that will occur. Change of primary monitor, or Move/Resize of window.";
        }

        private void grpSwitch_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void grpDisplay_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "The target monitor. The selected rule type will be applied to this monitor.";
        }

        private void grpDisplay_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void grpWindow_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "The title of the window to detect. This must be an exact match.";
        }

        private void grpWindow_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void grpDelay_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "The delay (in ms) before returning the primary monitor to the original setting.";
        }

        private void grpDelay_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void grpSummary_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "A summary of the selected rule.";
        }

        private void grpSummary_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void grpPrimMon_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Use this section to manually switch monitors if needed.";
        }

        private void grpPrimMon_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void btnDoPrimaryChange_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Change the primary display to the selected monitor above.";
        }

        private void btnDoPrimaryChange_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void btnAddRule_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Add a new rule.";
        }

        private void btnAddRule_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void btnDeleteRule_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Delete the currently selected rule.";
        }

        private void btnDeleteRule_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void btnIdentifyMonitors_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Brings up an identification window on each monitor connected.";
        }

        private void btnIdentifyMonitors_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void btnGrabWindow_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Grab the title from an open window.";
        }

        private void btnGrabWindow_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void clearAllRulesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Clear all rules in the file.";
        }

        private void clearAllRulesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Exit the program.";
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void minimizeToTrayWhenClosedToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "When the window is closed, will minimze to tray instead. Use the tray icon or menu item to exit.";
        }

        private void minimizeToTrayWhenClosedToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void showBalloonTipWhenMinimizingToTrayToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Show a reminder balloon tip when minimizing to tray.";
        }

        private void showBalloonTipWhenMinimizingToTrayToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void startWithWindowsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Start the application with Windows logon.";
        }

        private void startWithWindowsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void startMinimizedToTrayToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "Start the application minimized to tray. Recommended if starting with Windows logon.";
        }

        private void startMinimizedToTrayToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        private void aboutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            statusStripLabel.Text = "About APDS.";
        }

        private void aboutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            statusStripLabel.Text = "";
        }

        #endregion

        #region Buttons
        /// <summary>
        /// Setup the events for all button clicks on the window
        /// 
        /// </summary>

        private void btnDoPrimaryChange_Click(object sender, EventArgs e)
        {
            if (cmbDisplays2.SelectedIndex != -1)
            {
                DisplaySwitcher.GetInstance().SetPrimaryDisplay(cmbDisplays2.SelectedIndex);
            }
        }

        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            if(listRules.Items.Count > 0)
            {
                int index = listRules.SelectedIndices[0];
                ProfileHandler.GetInstance().RemoveSwitchProfile(index);
                listRules.Items.RemoveAt(index);
                listRules.Focus();
                if (index >= listRules.Items.Count)
                {
                    index -= 1;
                }

                if (listRules.Items.Count > 0)
                {
                    listRules.Items[index].Selected = true;
                }
                else
                {
                    ProfileHandler.GetInstance().ClearAllProfiles();
                    listRules.Items.Clear();
                    listRules.Focus();

                    grpDelay.Enabled = false;
                    grpDisplay.Enabled = false;
                    grpSummary.Enabled = false;
                    grpSwitch.Enabled = false;
                    grpWindow.Enabled = false;

                    lblSummary.Text = "";
                }
            }
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            ProfileHandler.GetInstance().AddNewSwitchProfile(SwitchProfile.SwitchType.SWITCH_MONITOR, "New Rule", 0, 0);
            listRules.Items.Add("New Rule");
            listRules.Columns[0].Width = -1;
        }

        private void btnGrabWindow_Click(object sender, EventArgs e)
        {
            frmGrabTitle form = new frmGrabTitle(RetrieveWinTitle);
            form.Show();
        }

        /// <summary>
        /// Callback from the frmGrabTitle form with the selected title.
        /// </summary>
        /// <param name="title">Selected title</param>
        private void RetrieveWinTitle(string title)
        {
            textWinTitle.Text = title;
        }

        private void btnIdentifyMonitors_Click(object sender, EventArgs e)
        {
            List<frmIdentifyWindow> monList = new List<frmIdentifyWindow>();
            for(int i = 0; i < DisplaySwitcher.GetInstance().GetNumDisplays(); i++)
            {
                frmIdentifyWindow f = new frmIdentifyWindow(i);
                f.Show();
            }

        }

        #endregion

        #region Field Events
        /// <summary>
        /// Events for changing of fields - selection in list view, etc.
        /// </summary>
        private void textWinTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateProfileDetails();
        }

        private void cmbDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProfileDetails();            
        }
        private void numDelay_ValueChanged(object sender, EventArgs e)
        {
            UpdateProfileDetails();
        }

        private void cmbSwitchTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSwitchTypes.SelectedIndex == (int)SwitchProfile.SwitchType.SWITCH_MONITOR)
            {
                if (cmbSwitchTypes.Enabled)
                {
                    grpDelay.Enabled = true;
                }
            }
            else
            {
                grpDelay.Enabled = false;
            }
            UpdateProfileDetails();
        }

        private void listRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listRules.SelectedIndices.Count > 0)
            {
                
                grpDelay.Enabled = true;
                grpDisplay.Enabled = true;
                grpSummary.Enabled = true;
                grpSwitch.Enabled = true;
                grpWindow.Enabled = true;

                SwitchProfile profile = ProfileHandler.GetInstance().GetProfile(listRules.SelectedIndices[0]);

                textWinTitle.Text = profile.WindowTitle;

                if(profile.Type == SwitchProfile.SwitchType.SWITCH_MONITOR)
                {
                    numDelay.Value = profile.Delay;
                }
                else
                {
                    numDelay.Value = 0;
                }

                cmbDisplays.SelectedIndex = profile.MonitorToSwitchTo;

                cmbSwitchTypes.SelectedIndex = (int)profile.Type;

            }
        }

        private void UpdateProfileDetails()
        {
            if (listRules.SelectedIndices.Count > 0)
            {
                int index = listRules.SelectedIndices[0];
                int newMonitor = cmbDisplays.SelectedIndex;
                SwitchProfile.SwitchType newType = (SwitchProfile.SwitchType)cmbSwitchTypes.SelectedIndex;
                int newDelay = 0;
                if (numDelay.Enabled)
                {
                    newDelay = (int)numDelay.Value;
                }
                string newTitle = textWinTitle.Text;

                //Reset the column width to autodetect.
                listRules.SelectedItems[0].Text = newTitle;
                listRules.Columns[0].Width = -1;

                ProfileHandler.GetInstance().UpdateSwitchProfile(index, newType, newTitle, newMonitor, newDelay);
                RefreshSummaryText(ProfileHandler.GetInstance().GetProfile(index));
            }
            else
            {
                lblSummary.Text = "";
            }
        }

        private void RefreshSummaryText(SwitchProfile profile)
        {
            lblSummary.Text = "";
            lblSummary.Text += "The currently selected rule will ";
            if(profile.Type == SwitchProfile.SwitchType.SWITCH_WINDOW)
            {
                lblSummary.Text += "move the window \"";
                lblSummary.Text += profile.WindowTitle + "\" to Monitor " + (profile.MonitorToSwitchTo + 1) + " - " + DisplaySwitcher.GetInstance().GetDeviceName(profile.MonitorToSwitchTo);
                lblSummary.Text += " and make it emulate full screen, whenever the window is opened.";
            }
            else
            {
                lblSummary.Text += "make Monitor " + (profile.MonitorToSwitchTo + 1) + " - \"" + DisplaySwitcher.GetInstance().GetDeviceName(profile.MonitorToSwitchTo);
                lblSummary.Text += "\" the primary monitor when \"" + profile.WindowTitle + "\" opens. When the window \"" + profile.WindowTitle + "\" closes, ";
                lblSummary.Text += "the primary monitor will be reset after a " + profile.Delay + " ms delay.";
            }
            
        }

        private void listRules_MouseUp(object sender, MouseEventArgs e)
        {
            if(listRules.SelectedIndices.Count == 0)
            {
                grpDelay.Enabled = false;
                grpDisplay.Enabled = false;
                grpSummary.Enabled = false;
                grpSwitch.Enabled = false;
                grpWindow.Enabled = false;

                lblSummary.Text = "";
            }
        }
        #endregion


    }
}
