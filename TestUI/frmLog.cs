using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCLog;


namespace TestUI
{
    public partial class frmLog : Form
    {

        private ILogger logPLC;
        private ILogger logDB;

        public frmLog()
        {
            InitializeComponent();
         
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            logPLC = new Logger("PLC\\Log.txt");
            if (!logPLC.initialize())
            {
                MessageBox.Show("Log sistemi oluşmadı");
            }

            logDB = new Logger("DB\\Log.txt");
            if (!logDB.initialize())
            {
                MessageBox.Show("Log sistemi oluşmadı");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "PLC Error Message";
            Exception ex = new Exception();
            string messageFormat = "PLC Message Format: message: {0}, exception: {1}";

            logPLC.Debug(message);
            logPLC.Debug(message, ex);
            logPLC.DebugFormat(messageFormat, message, ex.Message);

            logPLC.Error(message);
            logPLC.Error(message, ex);
            logPLC.ErrorFormat(messageFormat, message, ex.Message);

            logPLC.Fatal(message);
            logPLC.Fatal(message, ex);
            logPLC.FatalFormat(messageFormat, message, ex.Message);

            logPLC.Info(message);
            logPLC.Info(message, ex);
            logPLC.InfoFormat(messageFormat, message, ex.Message);

            logPLC.Warn(message);
            logPLC.Warn(message, ex);
            logPLC.WarnFormat(messageFormat, message, ex.Message);
        }

        private void btnDBLog_Click(object sender, EventArgs e)
        {
            string message = "DB Error Message";
            Exception ex = new Exception();
            string messageFormat = "DB Message Format: message: {0}, exception: {1}";

            logDB.Debug(message);
            logDB.Debug(message, ex);
            logDB.DebugFormat(messageFormat, message, ex.Message);

            logDB.Error(message);
            logDB.Error(message, ex);
            logDB.ErrorFormat(messageFormat, message, ex.Message);

            logDB.Fatal(message);
            logDB.Fatal(message, ex);
            logDB.FatalFormat(messageFormat, message, ex.Message);

            logDB.Info(message);
            logDB.Info(message, ex);
            logDB.InfoFormat(messageFormat, message, ex.Message);

            logDB.Warn(message);
            logDB.Warn(message, ex);
            logDB.WarnFormat(messageFormat, message, ex.Message);
        }
    }
}
