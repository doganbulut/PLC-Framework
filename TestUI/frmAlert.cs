using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestUI
{
    public partial class frmAlert : Form
    {
        public frmAlert()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucAlertControl1.AddMessage(textBox1.Text);
        }

        private void frmAlert_Load(object sender, EventArgs e)
        {
            PlcAlarm.AlarmsPlcController = frmMain.PlcController;
            List<FCUI.PlcAlarm> listalarm = new List<FCUI.PlcAlarm>();
            listalarm.Add(new FCUI.PlcAlarm { id = 1, Key = ".Hatalar[1]", SetKey = ".Hatalar[2]", Message = "1 Message" });
            listalarm.Add(new FCUI.PlcAlarm { id = 2, Key = ".Hatalar[3]", SetKey = ".Hatalar[4]", Message = "2 Message" });
            listalarm.Add(new FCUI.PlcAlarm { id = 3, Key = ".Hatalar[5]", SetKey = ".Hatalar[6]", Message = "3 Message" });
            listalarm.Add(new FCUI.PlcAlarm { id = 4, Key = ".Hatalar[7]", SetKey = ".Hatalar[8]", Message = "4 Message" });
            listalarm.Add(new FCUI.PlcAlarm { id = 5, Key = ".Hatalar[9]", SetKey = ".Hatalar[10]", Message = "5 Message" });
            PlcAlarm.InitAlarms(listalarm);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PlcAlarm.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
