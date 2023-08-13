using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIS.Model;

namespace SIS.UI
{
    public partial class VehicleDetailFrm : Form
    {
        public Vehicle vehicle;
        public VehicleDetailFrm()
        {
            InitializeComponent();
        }

        private void VehicleDetailFrm_Load(object sender, EventArgs e)
        {
            if (vehicle != null)
            {
                txtMake.Text = vehicle.Make; 
                txtVehReg.Text = vehicle.Vehicle_reg;
                txtModel.Text = vehicle.Model;
                txtColor.Text = vehicle.Color;
            }
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            if (vehicle.Vehicle_reg == null)
            {
                vehicle = new Vehicle();
                vehicle.RowState = Rowstate.Add;
            }
            vehicle.Make = txtMake.Text;
            vehicle.Vehicle_reg = txtVehReg.Text;
            vehicle.Model = txtModel.Text;
            vehicle.Color = txtColor.Text;
            if (vehicle.RowState != Rowstate.Add)
            {
                vehicle.RowState = Rowstate.Modified;

            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
