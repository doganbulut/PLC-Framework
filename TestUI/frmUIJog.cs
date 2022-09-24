using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCUI;

namespace TestUI
{
    public partial class frmUIJog : Form
    {
        private UCAxisJog axisJogX;
        private UCAxicCalib axisCalibX;
        private UCAxis axisUX;


        public frmUIJog()
        {
            InitializeComponent();
        }

        private void frmUIJog_Load(object sender, EventArgs e)
        {
            Axis axisX = new Axis();
            axisX.Id = 1;
            axisX.AxisId = 5;
            axisX.AxisName = "X0";
            axisX.ReadPLCKey = ".AxisX0.NcToPlc.ActPos";
            axisX.CalibPLCKey = ".stKaliciData.EksenSifirlamaDegerleri[5]";
            axisX.ValueFormat = "N2";
            axisX.ActiveCalibPLCKey = ".stKaliciData.EksenSifirlamaDegerleri[0]";
            axisX.ActiveCalibPLCKeyType = "Double";
            axisX.MinusActionPLCKey = ".bX0JogMinus";
            axisX.PlusActionPLCKey = ".bX0JogPlus";
            axisX.SelectPLCKey = ".bJogModeSelect";
            axisX.SpeedPLCKey = ".fJOGModeHiz";

            axisJogX = new UCAxisJog();
            axisJogX.PlcController = frmMain.PlcController;
            axisJogX.Axis = axisX;
            axisJogX.Dock = DockStyle.Top;
            pnlJog.Controls.Add(axisJogX);
            axisJogX.Start();
            axisJogX.Active = true;

            axisUX = new UCAxis();
            axisUX.PlcController = frmMain.PlcController;
            axisUX.Axis = axisX;
            axisUX.Dock = DockStyle.Top;
            pnlAxis.Controls.Add(axisUX);
            axisUX.Start();

            axisCalibX = new UCAxicCalib();
            axisCalibX.PlcController = frmMain.PlcController;
            axisCalibX.Axis = axisX;
            axisCalibX.Dock = DockStyle.Top;
            pnlCalib.Controls.Add(axisCalibX);
            axisCalibX.Start();
            axisCalibX.Active = true;

        }
    }
}
