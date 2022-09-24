using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCPlc;
using FCLog;
using System.Windows.Forms;
using System.Drawing;

namespace BLL
{
    public class OperationPlc
    {

        #region[Tanımlamalar]

        public static IPlcController iPlcController;
        public ILogger logPLC;
        private PlcValueNotification<bool> bScadaRunning;
        private Control sync_PLC;


        public List<string> PLCErrors { get; set; }
        public List<string> PLCInfos { get; set; }
        public Panel CtrlPLCRunning { get; set; }

        #endregion

        public IPlcController PlcController
        {
            get
            {
                if (iPlcController == null)
                {
                    iPlcController = new BeckhoffController();
                    iPlcController.OnPlcException += new EventHandler<FCPlc.PlcEvents.PlcExceptionEventArgs>(iPlcController_OnPlcException);
                    iPlcController.OnPlcNotification += new EventHandler<FCPlc.PlcEvents.PlcBasicEventArgs>(iPlcController_OnPlcNotification);
                    iPlcController.PLCConnectionString = "192.168.2.26.1.1";
                    iPlcController.Connect();
                }
                return iPlcController;
            }
        }

        public OperationPlc()
        {
            PLCErrors = new List<string>();
            PLCInfos = new List<string>();
            sync_PLC = new Control();

            InitPlcOperation();
        }

        void iPlcController_OnPlcNotification(object sender, FCPlc.PlcEvents.PlcBasicEventArgs e)
        {
            if (sync_PLC.InvokeRequired)
            {
                sync_PLC.Invoke((Action)(() => { PLCInfos.Insert(0, e.EventValue); }));

            }
            else
            {
                PLCInfos.Insert(0, e.EventValue);
            }
        }

        void iPlcController_OnPlcException(object sender, FCPlc.PlcEvents.PlcExceptionEventArgs e)
        {
            if (sync_PLC.InvokeRequired)
            {
                sync_PLC.Invoke((Action)(() => { AddException(e.EventValue + " : " + e.EventException.Message); }));
            }
            else
            {
                AddException(e.EventValue + " : " + e.EventException.Message);
            }
        }


        private void AddException(string message)
        {
            if (!PLCErrors.Contains(message))
                PLCErrors.Insert(0, message);
        }

        private void InitPlcOperation()
        {
            bScadaRunning = new PlcValueNotification<bool>(CtrlPLCRunning);
            bScadaRunning.Init(PlcController, ".bScadaRunning", 100);
            bScadaRunning.FirstRunRead = true;
            bScadaRunning.OnValueChanged += new EventHandler<EventArgs<bool>>(bScadaRunning_OnValueChanged);
        }

        public void StartValueNotifications()
        {
            bScadaRunning.ValueOwner = CtrlPLCRunning;
            bScadaRunning.Start();
        }

        public void StopValueNotifications()
        {
            bScadaRunning.Stop();
        }

        void bScadaRunning_OnValueChanged(object sender, EventArgs<bool> e)
        {
            CtrlPLCRunning.BackColor = e.Value ? Color.Lime : Color.Red;
        }

       


    }
}
