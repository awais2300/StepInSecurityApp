using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIS.Model;
using SIS.Manager;
using SIS.Data;

namespace SIS.UI
{
    public partial class ResidentDataFrm : Form
    {
        bool retrieve;
        int emp_id;
        private Resident Residentdata = new Resident();

        public ResidentDataFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            //Application.Exit();
            
            this.Close();
        }

        private void ResidentdataFrm_Load(object sender, EventArgs e)
        {
            Guid gud = new Guid();
            gud = Guid.NewGuid();
            Residentdata.RowState = Rowstate.Add;
        }

        #region buttons events

        private void btnSave_Click(object sender, EventArgs e)
        {

                ResidentManager resMgr = new ResidentManager();
                Residentdata.House_no = txtIDCard.Text;
                Residentdata.First_name = txtFirstName.Text;
                Residentdata.Last_name = txtLastName.Text;
                Residentdata.CNIC = txtCNIC.Text;
                Residentdata.Mobile_no = txtMobileNo.Text;
                Residentdata.PTCL_No = txtPTCLNo.Text;
                Residentdata.Email_ID = txtEmailID.Text;
                Residentdata.P_emp_id = null;

                if (Validate(Residentdata))
                {
                    if (Residentdata.RowState == Rowstate.Add)
                    {
                        resMgr.SaveResident(Residentdata);
                    }
                    else if (Residentdata.RowState == Rowstate.Modified)
                    {
                       
                        Residentdata.P_emp_id = Residentdata.Res_id;
                        if (Residentdata.Vehicle.RowState == Rowstate.Add)
                        {
                            VehicleManager vehMgr = new VehicleManager();
                            vehMgr.SaveVehicle(Residentdata.Vehicle);
                        }

                        if (Residentdata.Family_mem != null && Residentdata.Family_mem.Count != 0)
                        {
                            foreach (Resident info in Residentdata.Family_mem)
                            {
                                if (info.RowState == Rowstate.Add)
                                {
                                    resMgr.SaveResident(info);
                                }
                                else
                                {
                                    resMgr.UpdateResident(info);
                                }
                            }
                        }
                        else
                        {
                            resMgr.UpdateResident(Residentdata);
                        }

                    }
                    else
                    {
                        resMgr.UpdateResident(Residentdata);
                    }

                    resetEmployee();
                    MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReset_Click(sender, e);
                    
                }
         }
        
        private void btn_AddFamily_Click(object sender, EventArgs e)
        {
            Resident  res = new Resident();
            res.RowState = Rowstate.Add;
            res.P_emp_id = Residentdata.Res_id;
            res.Vehicle = Residentdata.Vehicle;
            string guid = System.Guid.NewGuid().ToString();
            res.Uniqueid = guid;
            Residentdata.Family_mem.Add(res);
            bindGrid();

            dgFamilyMember.Rows[dgFamilyMember.RowCount-1].Cells["House_no"].Value = Residentdata.House_no.ToString();
            dgFamilyMember.Rows[dgFamilyMember.RowCount - 1].Cells["House_no"].Style.BackColor = Color.LightGray;
            

        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            VehicleDataFrm frm = new VehicleDataFrm();
            frm.ShowDialog();
            /*VehicleDetailFrm frm = new VehicleDetailFrm();
            frm.vehicle = Residentdata.Vehicle;
            frm.ShowDialog();
            if (frm.vehicle.RowState == Rowstate.Modified || frm.vehicle.RowState == Rowstate.Add)
            { 
                Residentdata.Vehicle = frm.vehicle; 
            }   */
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDCardSearch.Text == "" || txtIDCardSearch.Text.Contains("'"))
            {
                MessageBox.Show("please enter valid House No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDCardSearch.Focus();
                return;
            }
            {
                ResidentManager resMgr = new ResidentManager();
                Residentdata = resMgr.GetResidentByHouseNo(txtIDCardSearch.Text);
                if (Residentdata != null && Residentdata.Res_id > 0)
                {
                    emp_id = Residentdata.Res_id;
                    txtIDCard.Text = Residentdata.House_no;
                    txtFirstName.Text = Residentdata.First_name;
                    txtLastName.Text = Residentdata.Last_name;
                    retrieve = true;
                    txtCNIC.Text = Residentdata.CNIC;
                    txtMobileNo.Text = Residentdata.Mobile_no;
                    txtPTCLNo.Text = Residentdata.PTCL_No;
                    txtEmailID.Text = Residentdata.Email_ID;
                    Residentdata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No Match Found with this ID Card", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDCardSearch.Focus();
                    Residentdata.RowState = Rowstate.Add;
                    return;

                }
            }
        }

        #endregion 

        #region gridEvents

        private void dgFamilyMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            ResidentManager empMgr = new ResidentManager();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string uniqueID = dgFamilyMember.Rows[e.RowIndex].Cells["uniqueID"].Value.ToString();
                Resident selEmployee = new Resident();
               
                if (e.ColumnIndex == 10)
                {
                    string House_no = dgFamilyMember.Rows[e.RowIndex].Cells["House_no"].Value.ToString();
                    string Vehicle_id = dgFamilyMember.Rows[e.RowIndex].Cells["veh_id"].Value.ToString();
                    string IsReadOnly;
                    if (Vehicle_id == null || Vehicle_id == "" )
                    {
                        IsReadOnly = "N";
                    }
                    else
                    {
                        IsReadOnly = "Y";
                    }
                    //VehicleDetailFrm frm = new VehicleDetailFrm();
                    VehicleDataFrm frm = new VehicleDataFrm(Convert.ToInt32(dgFamilyMember.Rows[e.RowIndex].Cells["Res_id"].Value.ToString()),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["First_Name"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["Last_Name"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["House_no"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["Mobile_no"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["PTCL_no"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["Email_id"].Value.ToString(),
                                                            dgFamilyMember.Rows[e.RowIndex].Cells["veh_id"].Value.ToString(),
                                                            "Family Member", IsReadOnly);
                    frm.Show();
                    /*if (House_no != "" && House_no != null)
                    {
                        selEmployee = Residentdata.Family_mem.Find(p => p.House_no == House_no);
                        frm.vehicle = selEmployee.Vehicle;
                        frm.ShowDialog();
                        
                    }
                    else
                    {
                        selEmployee.Vehicle = new Vehicle();
                        selEmployee.Vehicle.RowState = Rowstate.Add;
                        frm.ShowDialog();
                    }  */

                }
                else if (e.ColumnIndex == 10)
                {
                    selEmployee.RowState = Rowstate.Deleted;
                    empMgr.DeleteResidentFamilyMem(dgFamilyMember.Rows[e.RowIndex].Cells["First_Name"].Value.ToString(), 
                                                    dgFamilyMember.Rows[e.RowIndex].Cells["Last_Name"].Value.ToString(), 
                                                        dgFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value.ToString());
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Family Member deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }


        }

        private void dgFamilyMember_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            string Unique_ID = dgFamilyMember.Rows[e.RowIndex].Cells["uniqueID"].Value.ToString();

            Resident selEmployee = Residentdata.Family_mem.Find(p => p.Uniqueid == Unique_ID);
            //Resident selEmployee = new Resident();

            if (selEmployee != null)
            {
                selEmployee.House_no = dgFamilyMember.Rows[e.RowIndex].Cells["House_no"].Value.ToString();
                
                //Check duplicate ID card for family member
                if (dgFamilyMember.CurrentCell.ColumnIndex == 2)
                {
                    if (!duplicateEmployeeCheck(selEmployee.House_no, "House_no"))
                    {
                        dgFamilyMember.Rows[e.RowIndex].Cells["House_no"].Value = null;
                    }
                }
                else if (dgFamilyMember.CurrentCell.ColumnIndex == 3)
                {
                    selEmployee.First_name = dgFamilyMember.Rows[e.RowIndex].Cells["First_Name"].Value.ToString();
                }
                else if (dgFamilyMember.CurrentCell.ColumnIndex == 4)
                {
                    selEmployee.Last_name = dgFamilyMember.Rows[e.RowIndex].Cells["Last_Name"].Value.ToString();
                }
                else if (dgFamilyMember.CurrentCell.ColumnIndex == 5)
                {
                    selEmployee.CNIC = dgFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value.ToString();
                }
                else if (dgFamilyMember.CurrentCell.ColumnIndex == 6)
                {
                    selEmployee.Mobile_no = dgFamilyMember.Rows[e.RowIndex].Cells["Mobile_no"].Value.ToString();
                }
                else if (dgFamilyMember.CurrentCell.ColumnIndex == 7)
                {
                    selEmployee.PTCL_No = dgFamilyMember.Rows[e.RowIndex].Cells["PTCL_no"].Value.ToString();
                }
                else if (dgFamilyMember.CurrentCell.ColumnIndex == 8)
                {
                    selEmployee.Email_ID = dgFamilyMember.Rows[e.RowIndex].Cells["Email_id"].Value.ToString();
                }

                if (dgFamilyMember.CurrentCell.ColumnIndex == 5)
                {
                    //Check duplicate CNIC card for family member
                    if (!duplicateEmployeeCheck(selEmployee.CNIC, "CNIC"))
                    {
                        dgFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value = null;
                    }
                }  

                if (selEmployee.RowState == Rowstate.None)
                {
                    selEmployee.RowState = Rowstate.Modified;
                }
            }
        }

        #endregion

        #region private Methods

        private void resetEmployee()
        {
            Residentdata.RowState = Rowstate.None;
            Residentdata.Vehicle.RowState = Rowstate.None;

            foreach (Resident info in Residentdata.Family_mem)
            {
                if (info.RowState == Rowstate.Deleted)
                {
                   // Residentdata.Family_mem.Remove(info);
                }
                else
                {
                    info.RowState = Rowstate.None;
                    if (info.Vehicle != null)
                    {
                        info.Vehicle.RowState = Rowstate.None;
                    }
                }
            }
        }

        public void bindGrid()
        {
            Collection coll1 = new Collection();
            DataTable dt = coll1.ToDataTableEmp(Residentdata.Family_mem);
            dgFamilyMember.AutoGenerateColumns = false;
            dgFamilyMember.DataSource = dt;

            for (int i = 0; i < dgFamilyMember.RowCount; i++)

            {
                dgFamilyMember.Rows[i].Cells["House_no"].Style.BackColor = Color.LightGray ;
                dgFamilyMember.Rows[i].Cells["veh_id"].Style.BackColor = Color.LightGray;
                dgFamilyMember.Rows[i].Cells["Attach_Vehicle"].Style.BackColor = Color.LightGray;
                dgFamilyMember.Rows[i].Cells["Remove"].Style.BackColor = Color.LightGray;
            }
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            Residentdata = new Resident();
            Residentdata.RowState = Rowstate.Add;
            txtIDCard.Text = Residentdata.House_no;
            txtFirstName.Text = Residentdata.First_name;
            txtLastName.Text = Residentdata.Last_name;
            txtCNIC.Text = Residentdata.CNIC;
            txtMobileNo.Text = Residentdata.Mobile_no;
            txtPTCLNo.Text = Residentdata.PTCL_No;
            txtEmailID.Text = Residentdata.Email_ID;
            txtIDCardSearch.Text = "";
            
            txtIDCardSearch.Enabled = true;
            txtIDCardSearch.Focus();
            bindGrid();
        }

        private bool Validate(Resident pResident)
        {
            if (pResident.House_no.Length == 0)
            {
                MessageBox.Show("Please enter the ID Card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pResident.First_name.Length == 0)
            {
                MessageBox.Show("Please enter the First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pResident.Last_name.Length == 0)
            {
                MessageBox.Show("Please enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pResident.CNIC.Length == 0)
            {
                MessageBox.Show("Please enter the CNIC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgFamilyMember.RowCount > 0)
            {
                for (int i = 0; i < dgFamilyMember.RowCount; i++)
                {
                   if (dgFamilyMember[0, i].Value == null || dgFamilyMember[3, i].Value == null || dgFamilyMember[4, i].Value == null || dgFamilyMember[5, i].Value == null)
                   {
                        MessageBox.Show("Family Record is incomplete!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                   }
                   if (dgFamilyMember[0, i].Value.ToString() == String.Empty || dgFamilyMember[3, i].Value.ToString() == String.Empty || dgFamilyMember[4, i].Value.ToString() == String.Empty || dgFamilyMember[5, i].Value.ToString() == String.Empty )
                   {
                        MessageBox.Show("Family Record is incomplete!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                   }
                 /*  if (dgFamilyMember[0, i].Value.ToString() == pResident.Id_card.ToString())
                   {
                       MessageBox.Show("Employee ID Card cannot be same as Family Card ID !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return false;
 
                   }  */
                   if (dgFamilyMember[5, i].Value.ToString() == pResident.CNIC.ToString())
                   {
                       MessageBox.Show("Employee CNIC cannot be same as Family CNIC!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return false;

                   }
                   
                }

            }
         return true;

        }
        #endregion

        private void txtIDCard_Leave(object sender, EventArgs e)
        {
            if (txtIDCard.Text !="" && txtIDCard.Text != txtIDCardSearch.Text)
            {
                duplicateEmployeeCheck(txtIDCard.Text, "IDCard");
                
            }
        }

        private bool duplicateEmployeeCheck(string searchtext, string SearchType)
        {
            EmployeeManager empMGr = new EmployeeManager();

            if (SearchType == "IDCard")
            {
                Employee emp = empMGr.GetEmpByCarId(searchtext);
                if (emp != null && emp.Emp_id > 0)
                {
                    txtIDCard.Text = "";
                    txtIDCard.Focus();
                    MessageBox.Show("ID card is already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;

                }
            }
            if (SearchType == "CNIC")
            {
                Employee emp = empMGr.GetEmpByCNIC(searchtext);
                if (emp != null && emp.Emp_id > 0)
                {
                    //txtCNIC.Text = "";
                    txtCNIC.Focus();
                    MessageBox.Show("CNIC is already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            return true;
        }

       /* private void txtCNIC_Leave(object sender, EventArgs e)
        {
            if (txtCNIC.Text != "" )
            {
                duplicateEmployeeCheck(txtCNIC.Text, "CNIC");
            }
        }    */

        private void btn_deleteEmp_Click(object sender, EventArgs e)
        {
            if ( emp_id.ToString() != "0")
            {
                SecurityManager secMgr = new SecurityManager();
                if (secMgr.GetEmpStatus(emp_id.ToString()))
                {
                    EmployeeManager empMgr = new EmployeeManager();
                    empMgr.DeleteEmployee(emp_id);
                    if (dgFamilyMember.RowCount > 0)
                    {
                        for (int i = 0; i < dgFamilyMember.RowCount; i++)
                        {
                            empMgr.DeleteEmployee(Convert.ToInt32(dgFamilyMember.Rows[i].Cells["Emp_iD"].Value.ToString()));
                        }

                    }
                    MessageBox.Show("Employee Marked Inactive Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cannot Mark Inactive, Employee is Entered in Colony", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnReset_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("No Employee Selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            if (!retrieve)
            {
                duplicateEmployeeCheck(txtCNIC.Text, "CNIC");
            }
            else
            {
                retrieve = false;
            }

        }

        private void txtIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnSearch_Click(sender, e);
            }
        }

    }

}
