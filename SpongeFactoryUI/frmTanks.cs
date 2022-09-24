using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL.Entity;



namespace FactoryUI
{
    public partial class frmTanks : Form
    {
        private OperationTank op;
        

        public frmTanks()
        {
            InitializeComponent();
        }

        private void frmTanks_Load(object sender, EventArgs e)
        {
            op = new OperationTank();
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Tank tank = op.GetTank(Convert.ToInt32(txtId.Text));
            if (tank == null)
            {
                MessageBox.Show("null");
            }
            else
            {
                lstTank.Items.Insert(0, tank.Id + " - " + tank.Name +" - "+ tank.Capacity);
                OperationTank.FactTank optank = new OperationTank.FactTank();
                optank.Id = tank.Id;
                optank.Name = tank.Name;
             
                
                double? val = optank.GetBar;
                lstTank.Items.Insert(0, "Aktif Seviye : " + val);

                 if (val.HasValue)
                     ++val;
                 optank.GetBar = val;

            }   
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OperationTank.FactTank tank = new OperationTank.FactTank { Name = tBoxTankName.Text, Capacity = (int)txtCapacity.Value, Metarial = txtMetarial.Text, Temp = (int)txtTemperature.Value, FactoryId = 1 };
            long id = op.InsertTank(tank);
            if (id == 0)
                MessageBox.Show("Kaydedilemedi");
            else
            {
                MessageBox.Show("KayıtNo : " + id);
                if (tank.GetBar.HasValue)
                    MessageBox.Show("PLC Value" + tank.GetBar.Value.ToString());
            }

        }
        
        private void btnAll_Click(object sender, EventArgs e)
        {
            grdTank.DataSource = op.GetList();
        }
    }
}
