using FCPlc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FCUI
{
    
    internal class PlcRunTimeAlarm
    {
        public PlcRunTimeAlarm(IPlcController PlcController)
        {
            _plcController = PlcController;
        }

        private IPlcController _plcController;

        public int id { get; set; }
        public string Key { get; set; }
        public string SetKey { get; set; }
        public string Message { get; set; }
        
        public DateTime SendTime { get; set; }
        public DateTime SetTime { get; set; }
        public DateTime DelTime { get; set; }


        public bool? AlarmValue
        {
            get
            {
                bool readvalue;
                if (_plcController.Read(Key, out readvalue))
                {
                    return readvalue;
                }
                else
                    return null;
            }
        }

        public bool? AlarmSetValue
        {
            get 
            {
                bool readvalue;
                if (_plcController.Read(SetKey, out readvalue))
                    return readvalue;
                else
                    return null;
            }
            set 
            {
                _plcController.Write(SetKey, value.Value);
            }
        }

    }
}
