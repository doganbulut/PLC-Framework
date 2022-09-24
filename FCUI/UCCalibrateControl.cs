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

namespace FCUI
{
    public partial class UCCalibrateControl : UCBase
    {
        private List<Axis> _axises;
        private IPlcController _plc;

        public IPlcController PlcController
        {
            get { return _plc; }
            set { _plc = value; }
        }

        public List<Axis> Axises
        {
            get
            {
                return _axises;
            }
            set
            {
                _axises = value;
            }
        }


        private bool _active = false;
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                foreach (var control in pnlAxis.Controls)
                {
                    if (control is UCAxicCalib)
                    {
                        ((UCAxicCalib)control).Active = _active;
                    }
                }

                if (_active)
                    btnActive.BackColor = Color.Lime;
                else
                    btnActive.BackColor = Color.Red;
                
            }
        }


        public UCCalibrateControl()
        {
            InitializeComponent();
        }

        public UCCalibrateControl(List<Axis> Axixes,IPlcController PLC)
        {
            _axises = Axixes;
            _plc = PLC;
            InitializeComponent();

            foreach (var axis in _axises)
            {
                var calibAxis = new UCAxicCalib();
                calibAxis.Axis = axis;
                pnlAxis.Controls.Add(calibAxis);
            }
        }

        private void UCCalibrateControl_Load(object sender, EventArgs e)
        {
           
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            Active = !Active;
        }


    }
}
