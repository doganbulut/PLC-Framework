using FCPlc;
using FCUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCHMI
{
    public partial class FrmHMI : Form
    {
        private static IPlcController plccontroller;

        public FrmHMI()
        {
            InitializeComponent();
            plccontroller = new BeckhoffController();
            plccontroller.PLCConnectionString = "192.168.216.144.1.1";
            plccontroller.OnPlcException += plccontroller_OnPlcException;
            plccontroller.OnPlcNotification += plccontroller_OnPlcNotification;
            AddMessage(plccontroller.Connect() ? "Connected" : "Error not connect");

            if (plccontroller.ConnectionState() == true)
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


                ucAxis1.PlcController = plccontroller;
                ucAxis1.Axis = axisX;
                ucAxis1.Start();
            }

        }

        void plccontroller_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            AddMessage("OnPlcNotification : " + e.EventValue);
        }

        void plccontroller_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            AddMessage("OnPlcException : " + e.EventValue);
        }

        private void AddMessage(string message)
        {
            if (lstMessage.InvokeRequired)
            {
                lstMessage.Invoke((Action)(() => lstMessage.Items.Add(message)));
            }
            else
            {
                lstMessage.Items.Add(message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmJOG jog = new FrmJOG(plccontroller);
            jog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCalib calib = new FrmCalib(plccontroller);
            calib.Show();
        }

    }
}
