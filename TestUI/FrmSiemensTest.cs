using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCPlc;

namespace TestUI
{
    public partial class FrmSiemensTest : Form
    {
        private IPlcController plc; 

        public FrmSiemensTest()
        {
            InitializeComponent();
            
          
        }

        void plc_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            label1.Text = e.EventValue;
        }

        void plc_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            label1.Text = e.EventException.Message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plc.Connect();
        }

        private void FrmSiemensTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            plc.DisConnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plc.DisConnect();
        }

        private void FrmSiemensTest_Load(object sender, EventArgs e)
        {
            plc = new S7300Controller();
            plc.OnPlcException += new EventHandler<FCPlc.PlcEvents.PlcExceptionEventArgs>(plc_OnPlcException);
            plc.OnPlcNotification += new EventHandler<FCPlc.PlcEvents.PlcBasicEventArgs>(plc_OnPlcNotification);
            plc.PLCConnectionString = "192.168.2.1";
            plc.Connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object[] val;
            plc.ReadAny("dbGenelParams", out val);
            foreach (var item in val)
            {
                listBox1.Items.Add(item.ToString());
            }
        }


    }
}
