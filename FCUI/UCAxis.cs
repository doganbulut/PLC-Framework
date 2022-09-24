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
    public partial class UCAxis : UCBase
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

        public UCAxis()
        {
            InitializeComponent();
            SetLanguage();
        }

        public void Start()
        {
            AxisReading();
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
                        if (this.ParentForm.Visible)
                            if (_plc.Read(_axis.ReadPLCKey, out AxisValue))
                            {
                                if (valueLabel.InvokeRequired)
                                    valueLabel.Invoke((Action)(() => { valueLabel.Text = AxisValue.ToString(_axis.ValueFormat); }));
                                else
                                    valueLabel.Text = AxisValue.ToString(_axis.ValueFormat);
                            }
                    }
                    finally
                    {
                        Thread.Sleep(200);
                    }
                }
            });
        }
    }
}
