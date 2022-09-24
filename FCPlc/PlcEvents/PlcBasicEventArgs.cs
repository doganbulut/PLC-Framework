using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCPlc.PlcEvents
{
    public class PlcBasicEventArgs : EventArgs
    {
        public string EventValue { get; set; }

        public PlcBasicEventArgs(string EventValue)
        {
            this.EventValue = EventValue;
        }
    }
}
