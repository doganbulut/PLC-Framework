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
    public partial class frmLoadTest : Form
    {
        public frmLoadTest()
        {
            InitializeComponent();
        }

        private void frmLoadTest_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadHardWork()
        {
            backgroundWorker1.RunWorkerAsync();
            label1.Text = "Yükleniyor...";
        }


        private void HardWork()
        {
            for (int i = 0; i < 100; i++)
            {
                if (listBox1.InvokeRequired)
                    listBox1.Invoke(new MethodInvoker(() => listBox1.Items.Insert(0, i.ToString())));
                else
                    listBox1.Items.Insert(0, i.ToString());
                System.Threading.Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            HardWork();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Show Screen 
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() => this.Show()));
            else
                this.Show();
            //Show Screen 


            if (listBox1.InvokeRequired)
                listBox1.Invoke(new MethodInvoker(() => listBox1.Items.Insert(0, "Bitti")));
            else
                listBox1.Items.Insert(0, "Bitti");


            if (label1.InvokeRequired)
                label1.Invoke(new MethodInvoker(() => label1.Text = "Bitti"));
            else
                label1.Text = "Bitti";
        }
    }
}
