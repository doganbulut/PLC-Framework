using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCUI;
using System.Threading;
using System.Threading.Tasks;

namespace TestUI
{
    public partial class frmUIThread : Form
    {
        static Barrier barrier;
        List<UCTAxis> uctaxis = new List<UCTAxis>();

        public frmUIThread()
        {
            InitializeComponent();
        }

        private void frmUIThread_Load(object sender, EventArgs e)
        {
            barrier = new Barrier(50);
            // 90 adetlik barrier

            List<UCTAxis> uctaxis = new List<UCTAxis>(); // nesneler

            for (int i = 0; i < 50; i++) // 90 nesne create
            {
                UCTAxis axis = new UCTAxis();
                axis.Axis = new Axis();
                axis.Axis.AxisName = "(" + i.ToString() + ")";
                axis.Dock = DockStyle.Top;
                //axis.barrier = barrier;//barrier
                tl1.Controls.Add(axis);
                uctaxis.Add(axis);

            }

            foreach (var axis in uctaxis)
            {
                axis.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
