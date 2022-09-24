using FCPlc;
using FCUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCHMI
{
    public partial class FrmCalib : Form
    {
        private IPlcController plccontroller;

        public FrmCalib(IPlcController plccontroller)
        {
            InitializeComponent();
            this.plccontroller = plccontroller;
        }

        private void FrmCalib_Load(object sender, EventArgs e)
        {
            Axis axisX = new Axis();
            axisX.Id = 1;
            axisX.AxisId = 5;
            axisX.AxisName = "1X0";
            axisX.ReadPLCKey = ".Axis1X0.NcToPlc.ActPos";
            axisX.CalibPLCKey = ".stKaliciData.EksenSifirlamaDegerleri[5]";
            axisX.ValueFormat = "N2";
            axisX.ActiveCalibPLCKey = ".stKaliciData.EksenSifirlamaDegerleri[0]";
            axisX.ActiveCalibPLCKeyType = "Double";
            axisX.MinusActionPLCKey = ".b1X0JogMinus";
            axisX.PlusActionPLCKey = ".b1X0JogPlus";
            axisX.SelectPLCKey = ".bJogModeSelect";
            axisX.SpeedPLCKey = ".fJOGModeHiz";

            ucAxicCalib1.PlcController = plccontroller;
            ucAxicCalib1.Axis = axisX;
            ucAxicCalib1.Start();
            ucAxicCalib1.Active = true;

        }
    }
}
