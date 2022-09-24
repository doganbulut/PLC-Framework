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
using System.Threading;

namespace TestUI
{
    public partial class frmPLC : Form
    {
        private IPlcController plccontroller;
        private PlcValueNotification<bool> bManualKontrol;
        private PlcValueNotification<Int16> nSayac;

        public frmPLC()
        {
            InitializeComponent();
        }

        private void frmPLC_Load(object sender, EventArgs e)
        {
            plccontroller = frmMain.PlcController;
            plccontroller.OnPlcException += plccontroller_OnPlcException;
            plccontroller.OnPlcNotification += plccontroller_OnPlcNotification;
            plccontroller.PLCConnectionString = "192.168.216.144.1.1";
            lblConInfo.Text = plccontroller.Connect() ? "Connected" : "Error not connect";

            //Boolean bir Tetik
            bManualKontrol = new PlcValueNotification<bool>(this);
            bManualKontrol.ValueOwner = lstBoolChange;
            bManualKontrol.ExceptionOwner = lstValueError;
            bManualKontrol.Init(plccontroller,".bManualKontrol", 50);
            bManualKontrol.FirstRunRead = true;
            bManualKontrol.OnValueChanged += bManualKontrol_OnValueChanged;
            bManualKontrol.OnInternalException += bManualKontrol_OnInternalException;

            nSayac = new PlcValueNotification<short>(this);
            nSayac.ValueOwner = lstBoolChange;
            nSayac.ExceptionOwner = lstValueError;
            nSayac.Init(plccontroller, ".nSayac", 50);
            nSayac.FirstRunRead = true;
            nSayac.OnValueChanged += new EventHandler<EventArgs<short>>(nSayac_OnValueChanged);
        }


        Task TaskStringReader;
        void ReadStringPLCValueSample()
        {
            string strPLCKey = ".sUsedFilePath";
            string strValue ="";

            string intPLCKey = ".stKaliciData.nMotorHataZamani";
            UInt16 intValue = UInt16.MinValue;
            

            TaskStringReader = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        //String Okuma///////////////////////////
                        string localstrValue = "";
                        if (plccontroller.Read(strPLCKey, 255, out localstrValue))
                        {
                            if (strValue != localstrValue)
                            {
                                strValue = localstrValue;
                                if (lstBoolChange.InvokeRequired)
                                    lstBoolChange.Invoke((Action)(() =>
                                    {
                                        lstBoolChange.Items.Insert(0, strValue);
                                    }));
                                else
                                    lstBoolChange.Items.Insert(0, strValue);
                            }
                        }
                        else
                        {
                            //string error log vs
                        }
                        /////////////////////

                        ///int Okuma
                        UInt16 localintValue;
                        if (plccontroller.Read(intPLCKey, out localintValue))
                        {
                            if (intValue != localintValue)
                            {
                                intValue = localintValue;
                                if (lstBoolChange.InvokeRequired)
                                    lstBoolChange.Invoke((Action)(() =>
                                    {
                                        lstBoolChange.Items.Insert(0, intValue.ToString());
                                    }));
                                else
                                    lstBoolChange.Items.Insert(0, intValue.ToString());
                            }
                        }
                        else
                        {
                            //string error log vs
                        }


                    }
                    finally
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        void nSayac_OnValueChanged(object sender, EventArgs<short> e)
        {
            if (lstBoolChange.InvokeRequired)
                lstBoolChange.Invoke((Action)(() =>
                {
                    lstBoolChange.Items.Insert(0, e.Value);
                }));
            else
                lstBoolChange.Items.Insert(0, e.Value);
        }

        void bManualKontrol_OnInternalException(object sender, EventArgs<string> e)
        {
            lstValueError.Items.Insert(0, "Exception : " + e.Value);
        }

        void bManualKontrol_OnValueChanged(object sender, EventArgs<bool> e)
        {
            lstBoolChange.Items.Insert(0, e.Value);
        }


        void plccontroller_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            lstPLCNoitification.Items.Add(e.EventValue);
        }

        void plccontroller_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            lstPLCError.Items.Insert(0, "Value : " + e.EventValue + " Exception:" + e.EventException);
        }

        private void btnBoolWrite_Click(object sender, EventArgs e)
        {
            bool val ;
            Int16 valint16;

            if (Boolean.TryParse(txtBoolValue.Text, out val))
            {
                if (plccontroller.Write(txtBoolPLC.Text, val))
                {
                    lstPLCError.Items.Insert(0, "Write Success");
                    lblBoolResult.Text = val.ToString();
                }
                else
                {
                    lstPLCError.Items.Insert(0, "Write Error");
                }
            }
            else if (Int16.TryParse(txtBoolValue.Text, out valint16))
            {
                if (plccontroller.Write(txtBoolPLC.Text, valint16))
                {
                    lstPLCError.Items.Insert(0, "Write Success");
                    lblBoolResult.Text = valint16.ToString();
                }
                else
                {
                    lstPLCError.Items.Insert(0, "Write Error");
                }    
            }


        }

        private void btnReadBool_Click(object sender, EventArgs e)
        {
            bool val;
            if (plccontroller.Read(txtBoolPLC.Text, out val))
            {
                lstPLCError.Items.Insert(0, "Read Success");
                lblBoolResult.Text = val.ToString();
            }
            else 
            {
                lstPLCError.Items.Insert(0, "Read Error");
            }
        }

        private void btnCreateBoolEvent_Click(object sender, EventArgs e)
        {
            bManualKontrol.Start();
            nSayac.Start();
     
        }

        private void btnStopChange_Click(object sender, EventArgs e)
        {
            bManualKontrol.Stop();
            nSayac.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadStringPLCValueSample();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucValueReader1.PlcController = plccontroller;
            ucValueReader1.InitPLCKey<int>(".nLastFrezeSelection", 100);
            ucValueReader1.StartRead<int>();
        }

    }
}
