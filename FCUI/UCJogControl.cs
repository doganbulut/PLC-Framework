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
    public partial class UCJogControl : UCBase
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
        public  bool Active
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
                    if (control is UCAxisJog)
                    {
                        ((UCAxisJog)control).Active = _active;
                    }
                }
                if (_active)
                {
                    jogModeSpeedTrackBar.Enabled = true;
                    btnActive.BackColor = Color.Lime;
                }
                else
                {
                    jogModeSpeedTrackBar.Enabled = false;
                    btnActive.BackColor = Color.Red;
                }
            }
        }

        public UCJogControl()
        {
            InitializeComponent();
        }

        public UCJogControl(List<Axis> Axixes,IPlcController PLC)
        {
            _axises = Axixes;
            _plc = PLC;
            InitializeComponent();

            foreach (var axis in _axises)
            {
                var jogAxis = new UCAxisJog();
                jogAxis.Axis = axis;
                pnlAxis.Controls.Add(jogAxis);
            }
        }

        private void UCJog_Load(object sender, EventArgs e)
        {
           
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            Active = !Active;
        }

        private void jogModeSpeedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (Active)
            {
                foreach (var axis in _axises)
                {
                    _plc.Write(axis.SpeedPLCKey, (ushort)jogModeSpeedTrackBar.Value);
                }
            }
        }


    }
}
