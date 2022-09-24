using FCPlc;
using System;
using System.Windows.Forms;

namespace FCAlarm
{
    public partial class frmAlarm : Form
    {
        private static IPlcController UretimController;
        private static IPlcController SogutmaController;

        public frmAlarm()
        {
            InitializeComponent();
        }

        public bool CreateController()
        {
            try
            {
                UretimController = new BeckhoffController();
                SogutmaController = new OpcController();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitController Error : " + ex.Message);
                return false;
            }
        }

        public bool ConnectController()
        {
            try
            {
                UretimController = new BeckhoffController();
                UretimController.PLCConnectionString = "192.168.216.144.1.1";
                UretimController.Connect();

                SogutmaController = new OpcController();
                SogutmaController.PLCConnectionString = "opcda://localhost/Matrikon.OPC.Simulation/{f8582cf2-88fb-11d0-b850-00c0f0104305}";
                SogutmaController.Connect();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ConnectController Error : " + ex.Message);
                return false;
            }
        }


        public bool InitController()
        {
            try
            {
                UretimController.OnPlcException += UretimController_OnPlcException;
                UretimController.OnPlcNotification += UretimController_OnPlcNotification;
                UretimController.OnPlcState += UretimController_OnPlcState;
                SogutmaController.OnPlcException += SogutmaController_OnPlcException;
                SogutmaController.OnPlcNotification += SogutmaController_OnPlcNotification;
                SogutmaController.OnPlcState += SogutmaController_OnPlcState;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitController Error : " + ex.Message);
                return false;
            }
        }

        void SogutmaController_OnPlcState(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            lstSogutmaAlarm.Items.Insert(0, "Soğutma sistemi plc durum :" + e.EventValue);
        }

        void SogutmaController_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            lstSogutmaAlarm.Items.Insert(0, "Soğutma sistemi plc okuma hatası : " + e.EventException);
        }

        void SogutmaController_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            lstSogutmaAlarm.Items.Insert(0, "Soğutma sistemi plc bilgi : " + e.EventValue);
        }

        void UretimController_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            lstUretimAlarm.Items.Insert(0, "Üretim sistemi plc okuma hatası: " + e.EventException);
        }

        void UretimController_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            lstUretimAlarm.Items.Insert(0, "Üretim sistemi plc bilgi : " + e.EventValue);
        }

        void UretimController_OnPlcState(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            lstUretimAlarm.Items.Insert(0, "Üretim sistemi plc durum : " + e.EventValue);
        }

        public bool TempControlProcess()
        {
            try
            {
                int bandtemp;
                if (UretimController.Read(".bandtemp", out bandtemp))
                {
                    if (bandtemp > 22)
                    {
                        int settemp = 22;
                        if (!SogutmaController.Write(".settemp", settemp))
                            return false;
                    }
                }
                else
                {
                    lstUretimAlarm.Items.Insert(0, "Üretim sistemi plc bandtemp okuanamadı");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("TempControlProcess Error : " + ex.Message);
                return false;
            }
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {
            TempControlProcess();
        }

    }
}
