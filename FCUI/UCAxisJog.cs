using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using FCPlc;

namespace FCUI
{
    public partial class UCAxisJog : UCBase
    {
        private Axis _axis;
        private Task axisReader;
        private IPlcController _plc;

        public Axis Axis
        {
            get
            {
                return _axis;
            }
            set
            {
                if (value != null)
                {
                    _axis = value;
                    this.titleLabel.Text = _axis.AxisName;
                }
            }
        }

        public IPlcController PlcController
        {
            get { return _plc; }
            set { _plc = value; }
        }

        private bool _active = false;
        public bool Active
        {
            get
            {
                bool axisselect;
                if (_plc.Read(_axis.SelectPLCKey, out axisselect))
                    return axisselect;
                return false;
            }
            set
            {
                _active = value;
                this.plusButton.Enabled = _active;
                this.minusButton.Enabled = _active;

                _plc.Write(_axis.SelectPLCKey, value);
            }
        }

        public void Start()
        {
            AxisReading(); 
        }
        
        public UCAxisJog()
        {
            InitializeComponent();
            this.plusButton.Enabled = _active;
            this.minusButton.Enabled = _active;
        }


        private void AxisReading()
        {
            double AxisValue;
            axisReader = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        if (_plc.Read(_axis.ReadPLCKey, out AxisValue))
                        {
                            if (valueLabel.InvokeRequired)
                                valueLabel.Invoke((Action)(() => { valueLabel.Text = AxisValue.ToString("N2"); }));
                            else
                                valueLabel.Text = AxisValue.ToString("N2");
                        }
                    }
                    finally
                    {
                        Thread.Sleep(200);
                    }
                }
            });
        }

        private void minusButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_active)
               _plc.Write(_axis.MinusActionPLCKey, true);
        }

        private void minusButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (_active)
                _plc.Write(_axis.MinusActionPLCKey, false);
        }

        private void plusButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_active)
                _plc.Write(_axis.PlusActionPLCKey, true);
        }

        private void plusButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (_active)
                _plc.Write(_axis.PlusActionPLCKey, false);
        }
    }
}
