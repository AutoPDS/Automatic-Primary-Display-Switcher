using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APDS
{
    public class SwitchProfile
    {
        public enum SwitchType
        {
            SWITCH_MONITOR,
            SWITCH_WINDOW
        }

        private SwitchType type;
        public SwitchType Type
        {
            get { return type; }
            set { type = value; }
        }
        private string windowTitle;
        public string WindowTitle
        {
            get { return windowTitle; }
            set { windowTitle = value; }
        }
        private int monitorToSwitchTo;
        public int MonitorToSwitchTo
        {
            get { return monitorToSwitchTo; }
            set { monitorToSwitchTo = value; }
        }
        private int delay;
        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        public SwitchProfile(SwitchType switchType, string winTitle, int monitorToSwitch, int del)
        {
            type = switchType;
            windowTitle = winTitle;
            monitorToSwitchTo = monitorToSwitch;
            delay = del;
        }

        private SwitchProfile()
        {

        }
    }
}
