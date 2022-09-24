using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCPlc;
using System.Threading;

namespace FCUI
{
    public partial class UCValueReader : UserControl
    {
        private IPlcController _plc;
        private string _plcKey;
        private Type _plcType;
        private int _cycle;
        private bool _stopper = false;
      
        public string PlcKey
        {
            get { return _plcKey; }
            set { _plcKey = value; }
        }
        
        private Task Reader;

        public void InitPLCKey<T>(string PlcKey,int Cycle)
        {
           _plcType = typeof(T);
           _plcKey = PlcKey;
           _cycle = Cycle;
           lblPLCKey.Text = PlcKey;
        }

        public UCValueReader()
        {
            InitializeComponent();
        }

        public IPlcController PlcController
        {
            get { return _plc; }
            set { _plc = value; }
        }

        public void StartRead<T>() where T : struct,IConvertible, IComparable
        {
            T readValue;
            T currentValue = default(T);
            _stopper = false;

            Reader = Task.Factory.StartNew(() =>
            {
                object eventlocker = new object();

                while (!_stopper)
                {
                    try
                    {
                        if (this.ParentForm.Visible)
                        {
                            object readValueObject;
                            if (_plc.ReadAny(_plcKey, _plcType, out readValueObject))
                            {
                                readValue = (T)Convert.ChangeType(readValueObject, _plcType);

                                if (readValue.CompareTo(currentValue) != 0)
                                {
                                    lock (eventlocker)
                                        currentValue = readValue;

                                    if (lblPLCValue.InvokeRequired)
                                        lblPLCValue.Invoke((Action)(() => { lblPLCValue.Text = currentValue.ToString(); }));
                                    else
                                        lblPLCValue.Text = currentValue.ToString();
                                }
                            }
                        }                                  
                    }
                    finally
                    {
                        Thread.Sleep(_cycle);
                    }
                }
            });
        }

        public void StopRead()
        {
            _stopper = true;
        }

    }
}
