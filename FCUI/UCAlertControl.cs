using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCUI
{
    public partial class UCAlertControl : UCBase
    {

        static IList<string> _alerts;
        bool _hide = false;

        public bool HideAlarm 
        {
            get 
            {
                return _hide;
            }

            set 
            {
                if (value)
                {
                    this.Height = 25;
                }
                else 
                {
                    this.Height = 100;
                }
                _hide = value;
            }
        }


        


        public UCAlertControl()
        {
            InitializeComponent();
            _alerts = new List<string>();
        }

        public void ClearMessages()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    _alerts.Clear();
                    txtMessage.Text = string.Empty;
                }));
            }
            else
            {
                _alerts.Clear();
                txtMessage.Text = string.Empty;
            }
        }

        public void AddMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    AddMessageList(message);
                }));
            }
            else
            {
                AddMessageList(message);
            }
        }


        private void AddMessageList(string message)
        {
            if (!_alerts.Contains(message))
            {
                _alerts.Add(message);
                txtMessage.Text = message + "\r\n\r\n" + txtMessage.Text;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            HideAlarm = !HideAlarm;
        }

    }
}
