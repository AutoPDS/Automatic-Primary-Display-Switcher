namespace APDS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            if (sphfForm != null)
            { 
                sphfForm.Dispose();
                sphfForm = null;
            }
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.btnIdentifyMonitors = new System.Windows.Forms.Button();
            this.cmbDisplays = new System.Windows.Forms.ComboBox();
            this.lblDisplays = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayWhenClosedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimizedToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listRules = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.grpSwitch = new System.Windows.Forms.GroupBox();
            this.cmbSwitchTypes = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.grpWindow = new System.Windows.Forms.GroupBox();
            this.btnGrabWindow = new System.Windows.Forms.Button();
            this.textWinTitle = new System.Windows.Forms.TextBox();
            this.labelWindow = new System.Windows.Forms.Label();
            this.grpDelay = new System.Windows.Forms.GroupBox();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.labelDelay = new System.Windows.Forms.Label();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.grpPrimMon = new System.Windows.Forms.GroupBox();
            this.cmbDisplays2 = new System.Windows.Forms.ComboBox();
            this.labelPrimMon = new System.Windows.Forms.Label();
            this.btnDoPrimaryChange = new System.Windows.Forms.Button();
            this.grpDisplay.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpSwitch.SuspendLayout();
            this.grpWindow.SuspendLayout();
            this.grpDelay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.grpPrimMon.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.btnIdentifyMonitors);
            this.grpDisplay.Controls.Add(this.cmbDisplays);
            this.grpDisplay.Controls.Add(this.lblDisplays);
            this.grpDisplay.Enabled = false;
            this.grpDisplay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grpDisplay.Location = new System.Drawing.Point(297, 91);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(428, 83);
            this.grpDisplay.TabIndex = 3;
            this.grpDisplay.TabStop = false;
            this.grpDisplay.Text = "Select Display";
            // 
            // btnIdentifyMonitors
            // 
            this.btnIdentifyMonitors.Location = new System.Drawing.Point(145, 49);
            this.btnIdentifyMonitors.Name = "btnIdentifyMonitors";
            this.btnIdentifyMonitors.Size = new System.Drawing.Size(151, 23);
            this.btnIdentifyMonitors.TabIndex = 5;
            this.btnIdentifyMonitors.Text = "Identify Monitors";
            this.btnIdentifyMonitors.UseVisualStyleBackColor = true;
            this.btnIdentifyMonitors.Click += new System.EventHandler(this.btnIdentifyMonitors_Click);
            this.btnIdentifyMonitors.MouseEnter += new System.EventHandler(this.btnIdentifyMonitors_MouseEnter);
            this.btnIdentifyMonitors.MouseLeave += new System.EventHandler(this.btnIdentifyMonitors_MouseLeave);
            // 
            // cmbDisplays
            // 
            this.cmbDisplays.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDisplays.FormattingEnabled = true;
            this.cmbDisplays.Location = new System.Drawing.Point(122, 20);
            this.cmbDisplays.Name = "cmbDisplays";
            this.cmbDisplays.Size = new System.Drawing.Size(247, 21);
            this.cmbDisplays.TabIndex = 3;
            this.cmbDisplays.SelectedIndexChanged += new System.EventHandler(this.cmbDisplays_SelectedIndexChanged);
            // 
            // lblDisplays
            // 
            this.lblDisplays.AutoSize = true;
            this.lblDisplays.Location = new System.Drawing.Point(69, 23);
            this.lblDisplays.Name = "lblDisplays";
            this.lblDisplays.Size = new System.Drawing.Size(47, 13);
            this.lblDisplays.TabIndex = 4;
            this.lblDisplays.Text = "Monitor:";
            // 
            // menuMain
            // 
            this.menuMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuMain.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(737, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllRulesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // clearAllRulesToolStripMenuItem
            // 
            this.clearAllRulesToolStripMenuItem.Name = "clearAllRulesToolStripMenuItem";
            this.clearAllRulesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearAllRulesToolStripMenuItem.Text = "&Clear All Rules";
            this.clearAllRulesToolStripMenuItem.Click += new System.EventHandler(this.clearAllRulesToolStripMenuItem_Click);
            this.clearAllRulesToolStripMenuItem.MouseEnter += new System.EventHandler(this.clearAllRulesToolStripMenuItem_MouseEnter);
            this.clearAllRulesToolStripMenuItem.MouseLeave += new System.EventHandler(this.clearAllRulesToolStripMenuItem_MouseLeave);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.exitToolStripMenuItem.MouseEnter += new System.EventHandler(this.exitToolStripMenuItem_MouseEnter);
            this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.exitToolStripMenuItem_MouseLeave);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToTrayWhenClosedToolStripMenuItem,
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem,
            this.startMinimizedToTrayToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // minimizeToTrayWhenClosedToolStripMenuItem
            // 
            this.minimizeToTrayWhenClosedToolStripMenuItem.Name = "minimizeToTrayWhenClosedToolStripMenuItem";
            this.minimizeToTrayWhenClosedToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.minimizeToTrayWhenClosedToolStripMenuItem.Text = "&Minimize to tray when closed";
            this.minimizeToTrayWhenClosedToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayWhenClosedToolStripMenuItem_Click);
            this.minimizeToTrayWhenClosedToolStripMenuItem.MouseEnter += new System.EventHandler(this.minimizeToTrayWhenClosedToolStripMenuItem_MouseEnter);
            this.minimizeToTrayWhenClosedToolStripMenuItem.MouseLeave += new System.EventHandler(this.minimizeToTrayWhenClosedToolStripMenuItem_MouseLeave);
            // 
            // showBalloonTipWhenMinimizingToTrayToolStripMenuItem
            // 
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem.Name = "showBalloonTipWhenMinimizingToTrayToolStripMenuItem";
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem.Text = "Show &balloon tip when minimizing to tray";
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem.Click += new System.EventHandler(this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem_Click);
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem.MouseEnter += new System.EventHandler(this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem_MouseEnter);
            this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem.MouseLeave += new System.EventHandler(this.showBalloonTipWhenMinimizingToTrayToolStripMenuItem_MouseLeave);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start with &Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            this.startWithWindowsToolStripMenuItem.MouseEnter += new System.EventHandler(this.startWithWindowsToolStripMenuItem_MouseEnter);
            this.startWithWindowsToolStripMenuItem.MouseLeave += new System.EventHandler(this.startWithWindowsToolStripMenuItem_MouseLeave);
            // 
            // startMinimizedToTrayToolStripMenuItem
            // 
            this.startMinimizedToTrayToolStripMenuItem.Name = "startMinimizedToTrayToolStripMenuItem";
            this.startMinimizedToTrayToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.startMinimizedToTrayToolStripMenuItem.Text = "&Start minimized to tray";
            this.startMinimizedToTrayToolStripMenuItem.Click += new System.EventHandler(this.startMinimizedToTrayToolStripMenuItem_Click);
            this.startMinimizedToTrayToolStripMenuItem.MouseEnter += new System.EventHandler(this.startMinimizedToTrayToolStripMenuItem_MouseEnter);
            this.startMinimizedToTrayToolStripMenuItem.MouseLeave += new System.EventHandler(this.startMinimizedToTrayToolStripMenuItem_MouseLeave);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            this.aboutToolStripMenuItem.MouseEnter += new System.EventHandler(this.aboutToolStripMenuItem_MouseEnter);
            this.aboutToolStripMenuItem.MouseLeave += new System.EventHandler(this.aboutToolStripMenuItem_MouseLeave);
            // 
            // listRules
            // 
            this.listRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listRules.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listRules.HideSelection = false;
            this.listRules.LabelWrap = false;
            this.listRules.Location = new System.Drawing.Point(5, 27);
            this.listRules.MultiSelect = false;
            this.listRules.Name = "listRules";
            this.listRules.Size = new System.Drawing.Size(286, 512);
            this.listRules.TabIndex = 7;
            this.listRules.UseCompatibleStateImageBehavior = false;
            this.listRules.View = System.Windows.Forms.View.Details;
            this.listRules.SelectedIndexChanged += new System.EventHandler(this.listRules_SelectedIndexChanged);
            this.listRules.MouseEnter += new System.EventHandler(this.listRules_MouseEnter);
            this.listRules.MouseLeave += new System.EventHandler(this.listRules_MouseLeave);
            this.listRules.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listRules_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 578);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(737, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnDeleteRule.Location = new System.Drawing.Point(155, 545);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(136, 29);
            this.btnDeleteRule.TabIndex = 9;
            this.btnDeleteRule.Text = "Delete Rule";
            this.btnDeleteRule.UseVisualStyleBackColor = true;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            this.btnDeleteRule.MouseEnter += new System.EventHandler(this.btnDeleteRule_MouseEnter);
            this.btnDeleteRule.MouseLeave += new System.EventHandler(this.btnDeleteRule_MouseLeave);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnAddRule.Location = new System.Drawing.Point(5, 545);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(136, 29);
            this.btnAddRule.TabIndex = 10;
            this.btnAddRule.Text = "Add Rule";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            this.btnAddRule.MouseEnter += new System.EventHandler(this.btnAddRule_MouseEnter);
            this.btnAddRule.MouseLeave += new System.EventHandler(this.btnAddRule_MouseLeave);
            // 
            // grpSwitch
            // 
            this.grpSwitch.Controls.Add(this.cmbSwitchTypes);
            this.grpSwitch.Controls.Add(this.labelType);
            this.grpSwitch.Enabled = false;
            this.grpSwitch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grpSwitch.Location = new System.Drawing.Point(297, 27);
            this.grpSwitch.Name = "grpSwitch";
            this.grpSwitch.Size = new System.Drawing.Size(428, 58);
            this.grpSwitch.TabIndex = 11;
            this.grpSwitch.TabStop = false;
            this.grpSwitch.Text = "Select Switch Type";
            // 
            // cmbSwitchTypes
            // 
            this.cmbSwitchTypes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSwitchTypes.FormattingEnabled = true;
            this.cmbSwitchTypes.Location = new System.Drawing.Point(122, 20);
            this.cmbSwitchTypes.Name = "cmbSwitchTypes";
            this.cmbSwitchTypes.Size = new System.Drawing.Size(247, 21);
            this.cmbSwitchTypes.TabIndex = 3;
            this.cmbSwitchTypes.SelectedIndexChanged += new System.EventHandler(this.cmbSwitchTypes_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(47, 23);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(69, 13);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "Switch Type:";
            // 
            // grpWindow
            // 
            this.grpWindow.Controls.Add(this.btnGrabWindow);
            this.grpWindow.Controls.Add(this.textWinTitle);
            this.grpWindow.Controls.Add(this.labelWindow);
            this.grpWindow.Enabled = false;
            this.grpWindow.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grpWindow.Location = new System.Drawing.Point(297, 180);
            this.grpWindow.Name = "grpWindow";
            this.grpWindow.Size = new System.Drawing.Size(428, 83);
            this.grpWindow.TabIndex = 5;
            this.grpWindow.TabStop = false;
            this.grpWindow.Text = "Select Window";
            // 
            // btnGrabWindow
            // 
            this.btnGrabWindow.Location = new System.Drawing.Point(145, 49);
            this.btnGrabWindow.Name = "btnGrabWindow";
            this.btnGrabWindow.Size = new System.Drawing.Size(151, 23);
            this.btnGrabWindow.TabIndex = 6;
            this.btnGrabWindow.Text = "Grab Window Title";
            this.btnGrabWindow.UseVisualStyleBackColor = true;
            this.btnGrabWindow.Click += new System.EventHandler(this.btnGrabWindow_Click);
            this.btnGrabWindow.MouseEnter += new System.EventHandler(this.btnGrabWindow_MouseEnter);
            this.btnGrabWindow.MouseLeave += new System.EventHandler(this.btnGrabWindow_MouseLeave);
            // 
            // textWinTitle
            // 
            this.textWinTitle.Location = new System.Drawing.Point(122, 20);
            this.textWinTitle.Name = "textWinTitle";
            this.textWinTitle.Size = new System.Drawing.Size(247, 21);
            this.textWinTitle.TabIndex = 5;
            this.textWinTitle.TextChanged += new System.EventHandler(this.textWinTitle_TextChanged);
            // 
            // labelWindow
            // 
            this.labelWindow.AutoSize = true;
            this.labelWindow.Location = new System.Drawing.Point(44, 23);
            this.labelWindow.Name = "labelWindow";
            this.labelWindow.Size = new System.Drawing.Size(72, 13);
            this.labelWindow.TabIndex = 4;
            this.labelWindow.Text = "Window Title:";
            // 
            // grpDelay
            // 
            this.grpDelay.Controls.Add(this.numDelay);
            this.grpDelay.Controls.Add(this.labelDelay);
            this.grpDelay.Enabled = false;
            this.grpDelay.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grpDelay.Location = new System.Drawing.Point(297, 269);
            this.grpDelay.Name = "grpDelay";
            this.grpDelay.Size = new System.Drawing.Size(428, 58);
            this.grpDelay.TabIndex = 7;
            this.grpDelay.TabStop = false;
            this.grpDelay.Text = "Set Delay";
            // 
            // numDelay
            // 
            this.numDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Location = new System.Drawing.Point(122, 21);
            this.numDelay.Maximum = new decimal(new int[] {
            99990,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(247, 21);
            this.numDelay.TabIndex = 7;
            this.numDelay.ValueChanged += new System.EventHandler(this.numDelay_ValueChanged);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(54, 23);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(62, 13);
            this.labelDelay.TabIndex = 4;
            this.labelDelay.Text = "Delay (ms):";
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lblSummary);
            this.grpSummary.Enabled = false;
            this.grpSummary.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grpSummary.Location = new System.Drawing.Point(297, 333);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(428, 117);
            this.grpSummary.TabIndex = 8;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary of selected rule";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblSummary.Location = new System.Drawing.Point(6, 23);
            this.lblSummary.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(0, 13);
            this.lblSummary.TabIndex = 4;
            // 
            // grpPrimMon
            // 
            this.grpPrimMon.Controls.Add(this.cmbDisplays2);
            this.grpPrimMon.Controls.Add(this.labelPrimMon);
            this.grpPrimMon.Controls.Add(this.btnDoPrimaryChange);
            this.grpPrimMon.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.grpPrimMon.Location = new System.Drawing.Point(297, 456);
            this.grpPrimMon.Name = "grpPrimMon";
            this.grpPrimMon.Size = new System.Drawing.Size(428, 83);
            this.grpPrimMon.TabIndex = 8;
            this.grpPrimMon.TabStop = false;
            this.grpPrimMon.Text = "Change Primary Monitor Manually";
            // 
            // cmbDisplays2
            // 
            this.cmbDisplays2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDisplays2.FormattingEnabled = true;
            this.cmbDisplays2.Location = new System.Drawing.Point(122, 20);
            this.cmbDisplays2.Name = "cmbDisplays2";
            this.cmbDisplays2.Size = new System.Drawing.Size(247, 21);
            this.cmbDisplays2.TabIndex = 7;
            // 
            // labelPrimMon
            // 
            this.labelPrimMon.AutoSize = true;
            this.labelPrimMon.Location = new System.Drawing.Point(69, 23);
            this.labelPrimMon.Name = "labelPrimMon";
            this.labelPrimMon.Size = new System.Drawing.Size(47, 13);
            this.labelPrimMon.TabIndex = 8;
            this.labelPrimMon.Text = "Monitor:";
            // 
            // btnDoPrimaryChange
            // 
            this.btnDoPrimaryChange.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnDoPrimaryChange.FlatAppearance.BorderSize = 0;
            this.btnDoPrimaryChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDoPrimaryChange.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnDoPrimaryChange.Location = new System.Drawing.Point(145, 49);
            this.btnDoPrimaryChange.Name = "btnDoPrimaryChange";
            this.btnDoPrimaryChange.Size = new System.Drawing.Size(151, 23);
            this.btnDoPrimaryChange.TabIndex = 6;
            this.btnDoPrimaryChange.Text = "Change Primary Monitor";
            this.btnDoPrimaryChange.UseVisualStyleBackColor = true;
            this.btnDoPrimaryChange.Click += new System.EventHandler(this.btnDoPrimaryChange_Click);
            this.btnDoPrimaryChange.MouseEnter += new System.EventHandler(this.btnDoPrimaryChange_MouseEnter);
            this.btnDoPrimaryChange.MouseLeave += new System.EventHandler(this.btnDoPrimaryChange_MouseLeave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(737, 600);
            this.Controls.Add(this.grpPrimMon);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.grpDelay);
            this.Controls.Add(this.grpWindow);
            this.Controls.Add(this.grpSwitch);
            this.Controls.Add(this.btnAddRule);
            this.Controls.Add(this.btnDeleteRule);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listRules);
            this.Controls.Add(this.grpDisplay);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(753, 639);
            this.Name = "frmMain";
            this.Text = "Automatic Primary Display Switcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.grpDisplay.ResumeLayout(false);
            this.grpDisplay.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpSwitch.ResumeLayout(false);
            this.grpSwitch.PerformLayout();
            this.grpWindow.ResumeLayout(false);
            this.grpWindow.PerformLayout();
            this.grpDelay.ResumeLayout(false);
            this.grpDelay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.grpPrimMon.ResumeLayout(false);
            this.grpPrimMon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.ComboBox cmbDisplays;
        private System.Windows.Forms.Label lblDisplays;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayWhenClosedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBalloonTipWhenMinimizingToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimizedToTrayToolStripMenuItem;
        private System.Windows.Forms.ListView listRules;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.GroupBox grpSwitch;
        private System.Windows.Forms.ComboBox cmbSwitchTypes;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.GroupBox grpWindow;
        private System.Windows.Forms.Label labelWindow;
        private System.Windows.Forms.TextBox textWinTitle;
        private System.Windows.Forms.Button btnGrabWindow;
        private System.Windows.Forms.Button btnIdentifyMonitors;
        private System.Windows.Forms.GroupBox grpDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.GroupBox grpPrimMon;
        private System.Windows.Forms.Button btnDoPrimaryChange;
        private System.Windows.Forms.ComboBox cmbDisplays2;
        private System.Windows.Forms.Label labelPrimMon;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.ToolStripMenuItem clearAllRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}