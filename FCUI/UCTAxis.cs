using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCPlc;
using System.Threading;

namespace FCUI
{
    public partial class UCTAxis : UCBase
    {
        private Axis _axis;
        private IPlcController _plc;
        private int sayac = 0;
        private bool isStopped = false;
      


        public Task axisReader { get; set; }

        public Axis Axis
        {
            get
            {
                return _axis;
            }
            set
            {
                _axis = value;
                this.titleLabel.Text = _axis.AxisName;
            }
        }

        public IPlcController PlcController
        {
            get { return _plc; }
            set { _plc = value; }
        }

        public UCTAxis()
        {
            InitializeComponent();
        }

        public void Start()
        {
            AxisReading();
        }


        private void Stop()
        {
 
        }

        private void AxisReading()
        {
            axisReader = Task.Factory.StartNew(() => //Task
            {
                while (true)
                {
                    try
                    {
                            ++sayac;

                            if (valueLabel.InvokeRequired)
                                valueLabel.Invoke((Action)(() => { valueLabel.Text = sayac.ToString(); }));
                            else
                                valueLabel.Text = sayac.ToString();

                            
                           // barrier.SignalAndWait();//Tek fark burası hepsini sync etmek için.. 
                        // memory barrier diye bir nesne var..  90 adet sinyal gittiği zaman kod çalışıyor..
                    }
                    finally
                    {
                        Thread.Sleep(0);// deneyelim..
                    }
                }
            });
        }
    }
}
