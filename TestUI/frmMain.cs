using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCPlc;

namespace TestUI
{
    public partial class frmMain : Form
    {
        private static  IPlcController _plccontroller;
        private frmAlert pfrmAlert;
        frmUIThread frmUITh;

        public static IPlcController PlcController
        {
            get
            {
                if (_plccontroller == null)
                {
                    _plccontroller = new BeckhoffController();
                    _plccontroller.PLCConnectionString = "192.168.216.144.1.1";
                    _plccontroller.Connect();
                }
                return _plccontroller;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPLCTest_Click(object sender, EventArgs e)
        {
            frmPLC formPLC = new frmPLC();
            formPLC.Show();
        }

        private void btnDBTest_Click(object sender, EventArgs e)
        {
            frmDBDAL frmDal = new frmDBDAL();
            frmDal.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLog frmlog = new frmLog();
            frmlog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUIJog frmUIJog = new frmUIJog();
            frmUIJog.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pfrmAlert == null)
                pfrmAlert = new frmAlert();


            pfrmAlert.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSiemensTest frmSiemens = new FrmSiemensTest();
            frmSiemens.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLoadTest frmloadtest = new frmLoadTest();
            frmloadtest.LoadHardWork();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (frmUITh == null)
                 frmUITh = new frmUIThread();
            frmUITh.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FCUI.UCBase.LagDictinary = new Dictionary<string, string>();
            FCUI.UCBase.LagDictinary.Add("eksen", "axis");
            FCUI.UCBase.LagDictinary.Add("artı","plus");
            FCUI.UCBase.LagDictinary.Add("Eksen","Axis");
            FCUI.UCBase.LagDictinary.Add("Dil","Language");
        }
    }
}
