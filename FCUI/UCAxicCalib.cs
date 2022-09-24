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
    public partial class UCAxicCalib : UCBase
    {
        private Axis _axis;
        private IPlcController _plc;
        private Task axisReader;

        public double Value
        {
            set
            {
                this.valueLabel.Text = value.ToString(_axis.ValueFormat);
            }
        }

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
                    double val = 0;
                    if (_plc.Read(_axis.CalibPLCKey, out val))
                        calibrationValueTextBox.Value = (decimal)val;   
                }
            }
        }

        public IPlcController PlcController
        {
            get { return _plc; }
            set { _plc = value; }
        }


        private bool _active = false;
        public  bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                this.resetButton.Enabled = _active;
                this.resetButton.BackColor = this.resetButton.Enabled ? ColorTranslator.FromHtml("#ca0002") : ColorTranslator.FromHtml("#ddd");
            }
        }

        public UCAxicCalib()
        {
            InitializeComponent();
            this.resetButton.Enabled = _active;
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


        private void resetButton_Click(object sender, EventArgs e)
        {
            DialogResult dr =
               MessageBox.Show("Eksen değerlerini değiştirmek istediğinizden emin misiniz?",
               "Uyarı",
               MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (_plc.Write(_axis.CalibPLCKey, (double)calibrationValueTextBox.Value))
                {
                    if (_axis.ActiveCalibPLCKeyType == "Double")
                        _plc.Write(_axis.ActiveCalibPLCKey, (double)_axis.AxisId);
                    else if (_axis.ActiveCalibPLCKeyType == "Boolean")
                        _plc.Write(_axis.ActiveCalibPLCKey, true);
                }
            }
        }
    }
}
