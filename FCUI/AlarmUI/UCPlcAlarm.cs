using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RaiPlc;
using System.Threading.Tasks;
using System.Threading;

namespace RaiUI
{
    public partial class UCPlcAlarm : UserControl
    {
        private Task errorReader;
        private List<PlcRunTimeAlarm> _Alarms;
        public IPlcController AlarmsPlcController { get; set; }
        private bool SetError = false;
        private int SelectedError = 0;

        public UCPlcAlarm()
        {
            InitializeComponent();
            _Alarms = new List<PlcRunTimeAlarm>();
        }

        public void Start()
        {
            ErrorReading();
        }

        public void InitAlarms(List<PlcAlarm> Alarms)
        {
            foreach (var alarm in Alarms)
            {
                PlcRunTimeAlarm palarm = new PlcRunTimeAlarm(AlarmsPlcController);
                palarm.id = alarm.id;
                palarm.Key = alarm.Key;
                palarm.SetKey = alarm.SetKey;
                palarm.Message = alarm.Message;
                _Alarms.Add(palarm);

                if (palarm.AlarmValue.HasValue && palarm.AlarmValue.Value)
                    AddAlarm(palarm);
            }
        }

        private void ErrorReading()
        {
            errorReader = Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    try
                    {
                        foreach (var palarm in _Alarms)
                            if (palarm.AlarmValue.HasValue && palarm.AlarmValue.Value)
                            {
                                if (lstError.InvokeRequired)
                                    lstError.Invoke(new MethodInvoker(() => { AddAlarm(palarm); }));
                                else
                                    AddAlarm(palarm);
                            }
                            else if (palarm.AlarmValue.HasValue && !palarm.AlarmValue.Value)
                            {
                                if (lstError.InvokeRequired)
                                    lstError.Invoke(new MethodInvoker(() => { DelAlarm(palarm); }));
                                else
                                    DelAlarm(palarm);
                            }
                    }
                    finally
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        private void AddAlarm(PlcRunTimeAlarm alarm)
        {
            bool found = false;

            foreach (ListViewItem item in lstError.Items)
                if (item.Text == alarm.id.ToString() && (item.BackColor == Color.Red || item.BackColor == Color.Blue))
                    found = true;

            if (!found)
            {
                ListViewItem lvi = new ListViewItem(alarm.id.ToString());
                lvi.Tag = 1;
                lvi.BackColor = Color.Red;
                lvi.SubItems.Add(DateTime.Now.ToString());
                lvi.SubItems.Add("");
                lvi.SubItems.Add(alarm.Message);
                lvi.SubItems.Add("Alarm");
                lstError.Items.Insert(0, lvi);
            }
        }

        private void SetAlarm(PlcRunTimeAlarm alarm)
        {
            for (int i = 0; i < lstError.Items.Count; i++)
            {
                ListViewItem lvi = lstError.Items[i];
                if (lvi.Text == alarm.id.ToString() && lvi.BackColor == Color.Red)
                {
                    lvi.BackColor = Color.Blue;
                    lvi.SubItems[2].Text = DateTime.Now.ToString();
                    break;
                }
            }
        }


        private void DelAlarm(PlcRunTimeAlarm alarm)
        {
            for (int i = 0; i < lstError.Items.Count; i++)
            {
                ListViewItem lvi = lstError.Items[i];
                if (lvi.Text == alarm.id.ToString())
                {
                    if (lvi.BackColor == Color.Red)
                    {
                        lvi.BackColor = Color.Silver;
                        lvi.SubItems[2].Text = DateTime.Now.ToString();
                        break;
                    }
                    else if (lvi.BackColor == Color.Blue)
                    {
                        lvi.BackColor = Color.Green;
                        lvi.SubItems[2].Text = DateTime.Now.ToString();
                        break;
                    }
                }
            }
        }

        private void lstError_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSet.Text = "-";
            SetError = false;
            SelectedError = 0;


            if (lstError.SelectedItems != null && lstError.SelectedItems.Count == 1)
            {
                if (lstError.SelectedItems[0].BackColor == Color.Red)
                {
                    btnSet.Text = "Onay (" + lstError.SelectedItems[0].Text + ")";
                    SetError = true;
                    SelectedError = int.Parse(lstError.SelectedItems[0].Text);
                }      
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (SetError)
            {
                foreach (var palarm in _Alarms)
                    if (palarm.id == SelectedError)
                    {
                        if (AlarmsPlcController.Write(palarm.SetKey, true))
                        {
                            SetAlarm(palarm);
                            break;
                        }
                    }
            }
        }

    }
}
