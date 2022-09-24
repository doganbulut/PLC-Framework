using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL.Entity;


namespace TestD
{
    public partial class Form1 : Form
    {
        OperationTank op;

        public Form1()
        {
            InitializeComponent();
            op = new OperationTank();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = op.GetList().ToList();
        }
    }
}
