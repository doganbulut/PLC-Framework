using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCPlc.PlcEvents
{
    public class PlcExceptionEventArgs : EventArgs
    {
        public string EventValue { get; set; }
        public Exception EventException { get; set; }

        public PlcExceptionEventArgs(Exception EventException, string EventValue)
        {
            this.EventValue = EventValue;
            this.EventException = EventException;
        }
    }

}
