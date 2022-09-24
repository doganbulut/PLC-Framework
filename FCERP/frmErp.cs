using FCPlc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCERP
{
    public partial class frmErp : Form
    {
        private static IPlcController PompaController;
        List<PlcValueNotification<bool>> Pomps;
        List<bool> pompstate = new List<bool>(); 


        public frmErp()
        {
            InitializeComponent();
        }

        public void InitPomps()
        {
            PompaController = new BeckhoffController();
            PompaController.PLCConnectionString = "192.168.216.144.1.1";
            PompaController.Connect();
            PompaController.OnPlcException += PompaController_OnPlcException;
            PompaController.OnPlcNotification += PompaController_OnPlcNotification;
            PompaController.OnPlcState += PompaController_OnPlcState;

            Pomps = new List<PlcValueNotification<bool>>();

            PlcValueNotification<bool> pomp1 = new PlcValueNotification<bool>(this);
            pomp1.ValueOwner = groupBox1;
            pomp1.ExceptionOwner = lstPomp1;
            pomp1.Init(PompaController, ".pomp1run", 50);
            pomp1.FirstRunRead = true;
            pomp1.OnValueChanged += pomp1_OnValueChanged;
            Pomps.Add(pomp1);

            PlcValueNotification<bool> pomp2 = new PlcValueNotification<bool>(this);
            pomp2.ValueOwner = groupBox2;
            pomp2.ExceptionOwner = lstPomp2;
            pomp2.Init(PompaController, ".pomp2run", 50);
            pomp2.FirstRunRead = true;
            pomp2.OnValueChanged += pomp2_OnValueChanged;
            Pomps.Add(pomp2);

            PlcValueNotification<bool> pomp3 = new PlcValueNotification<bool>(this);
            pomp3.ValueOwner = groupBox3;
            pomp3.ExceptionOwner = lstPomp3;
            pomp3.Init(PompaController, ".pomp3run", 50);
            pomp3.FirstRunRead = true;
            pomp3.OnValueChanged += pomp3_OnValueChanged;
            Pomps.Add(pomp3);

            pompstate.Add(false);
            pompstate.Add(false);
            pompstate.Add(false);
        }

        void pomp3_OnValueChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value)
            {
                WriteFile("Pompa3", "Akış Başladı : " + DateTime.Now.ToString(), "");
                pompstate[2] = true;
            }
            else
            {
                int value;
                if (PompaController.Read(".pomp3value", out value))
                {
                    WriteFile("Pompa3", "Miktar : ", value.ToString());
                }
                WriteFile("Pompa3", "Akış Durdu : " + DateTime.Now.ToString(), "");
                pompstate[2] = false;
            }
        }

        void pomp2_OnValueChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value)
            {
                WriteFile("Pompa2", "Akış Başladı : " + DateTime.Now.ToString(), "");
                pompstate[1] = true;
            }
            else
            {
                int value;
                if (PompaController.Read(".pomp2value", out value))
                {
                    WriteFile("Pompa2", "Miktar : ", value.ToString());
                }
                WriteFile("Pompa2", "Akış Durdu : " + DateTime.Now.ToString(), "");
                pompstate[1] = false;
            }
        }

        void pomp1_OnValueChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value)
            {
                WriteFile("Pompa1", "Akış Başladı : " + DateTime.Now.ToString(), "");
                pompstate[0] = true;
            }
            else
            {
                int value;
                if (PompaController.Read(".pomp1value", out value))
                {
                    WriteFile("Pompa1", "Miktar : ", value.ToString());
                }
                WriteFile("Pompa1", "Akış Durdu : " + DateTime.Now.ToString(), "");
                pompstate[0] = false;
            }
        }

        void PompaController_OnPlcState(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            MessageBox.Show("Pompa sistemi plc durum :" + e.EventValue);
        }

        void PompaController_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            MessageBox.Show("Pompa sistemi plc bilgi :" + e.EventValue);
        }

        void PompaController_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            MessageBox.Show("Pompa sistemi plc hata :" + e.EventValue);
        }


        public void WriteFile(string Pomp,string State,string Value)
        {
            if (Pomp == "Pompa1")
            {
                lstPomp1.Items.Add(Pomp + State + Value);
            }else if (Pomp == "Pompa2")
            {
                lstPomp2.Items.Add(Pomp + State + Value);
            }else if (Pomp == "Pompa3")
            {
                lstPomp3.Items.Add(Pomp + State + Value);
            }
        }

    }
}
