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
    public partial class EmployeeDataFrm : Form
    {
        bool retrieve;
        int emp_id;
        private Employee employeedata = new Employee();

        public EmployeeDataFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            //Application.Exit();
            
            this.Close();
        }

        private void EmployeeDataFrm_Load(object sender, EventArgs e)
        {
            Guid gud = new Guid();
            gud = Guid.NewGuid();
            employeedata.RowState = Rowstate.Add;
        }

        #region buttons events

        private void btnSave_Click(object sender, EventArgs e)
        {
          
                EmployeeManager empMgr = new EmployeeManager();
                employeedata.Id_card = txtIDCard.Text;
                employeedata.First_name = txtFirstName.Text;
                employeedata.Last_name = txtLastName.Text;
                employeedata.CNIC = txtCNIC.Text;
                employeedata.P_emp_id = null;
                if (Validate(employeedata))
                {
                    if (employeedata.RowState == Rowstate.Add)
                    {
                        empMgr.SaveEmployee(employeedata);
                    }
                    else if (employeedata.RowState == Rowstate.Modified)
                    {
                       
                        employeedata.P_emp_id = employeedata.Emp_id;
                        if (employeedata.Vehicle.RowState == Rowstate.Add)
                        {
                            VehicleManager vehMgr = new VehicleManager();
                            vehMgr.SaveVehicle(employeedata.Vehicle);
                        }

                        if (employeedata.Family_mem != null && employeedata.Family_mem.Count != 0)
                        {
                            foreach (Employee info in employeedata.Family_mem)
                            {
                                if (info.RowState == Rowstate.Add)
                                {
                                    empMgr.SaveEmployee(info);
                                }
                                else
                                {
                                    empMgr.UpdateEmployee(info);
                                }
                            }
                        }
                        else
                        {
                            empMgr.UpdateEmployee(employeedata);
                        }

                    }
                    else
                    {
                        empMgr.UpdateEmployee(employeedata);
                    }

                    resetEmployee();
                    MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReset_Click(sender, e);
                    
                }
         }
        
        private void btn_AddFamily_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.RowState = Rowstate.Add;
            emp.P_emp_id = employeedata.Emp_id;
            emp.Vehicle = employeedata.Vehicle;
            string guid = System.Guid.NewGuid().ToString();
            emp.Uniqueid = guid;
            employeedata.Family_mem.Add(emp);
            bindGrid();

        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            VehicleDataFrm frm = new VehicleDataFrm();
            frm.ShowDialog();
            /*VehicleDetailFrm frm = new VehicleDetailFrm();
            frm.vehicle = employeedata.Vehicle;
            frm.ShowDialog();
            if (frm.vehicle.RowState == Rowstate.Modified || frm.vehicle.RowState == Rowstate.Add)
            { 
                employeedata.Vehicle = frm.vehicle; 
            }   */
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDCardSearch.Text == "" || txtIDCardSearch.Text.Contains("'"))
            {
                MessageBox.Show("please enter valid card id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDCardSearch.Focus();
                return;
            }
            {
                EmployeeManager empMgr = new EmployeeManager();
                employeedata = empMgr.GetEmpByCarId(txtIDCardSearch.Text);
                if (employeedata != null && employeedata.Emp_id > 0)
                {
                    emp_id = employeedata.Emp_id;
                    txtIDCard.Text = employeedata.Id_card;
                    txtFirstName.Text = employeedata.First_name;
                    txtLastName.Text = employeedata.Last_name;
                    retrieve = true;
                    txtCNIC.Text = employeedata.CNIC;         
                    employeedata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No Match Found with this ID Card", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDCardSearch.Focus();
                    employeedata.RowState = Rowstate.Add;
                    return;

                }
            }
        }

        #endregion 

        #region gridEvents

        private void dgFamilyMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            EmployeeManager empMgr = new EmployeeManager();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string uniqueID = dgFamilyMember.Rows[e.RowIndex].Cells["unique"].Value.ToString();
                Employee selEmployee = new Employee();
               
                if (e.ColumnIndex == 7)
                {
                    string Card_ID = dgFamilyMember.Rows[e.RowIndex].Cells["Card_ID"].Value.ToString();
                    VehicleDetailFrm frm = new VehicleDetailFrm();
                    if (Card_ID != "" && Card_ID != null)
                    {
                        selEmployee = employeedata.Family_mem.Find(p => p.Id_card == Card_ID);
                        frm.vehicle = selEmployee.Vehicle;
                        frm.ShowDialog();
                        
                    }
                    else
                    {
                        selEmployee.Vehicle = new Vehicle();
                        selEmployee.Vehicle.RowState = Rowstate.Add;
                        frm.ShowDialog();
                    }

                }
                else if (e.ColumnIndex == 8)
                {
                    selEmployee.RowState = Rowstate.Deleted;
                    empMgr.DeleteEmployeeFamilyMem(Convert.ToInt32(dgFamilyMember.Rows[e.RowIndex].Cells["Emp_iD"].Value.ToString()));
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Family Member deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void dgFamilyMember_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            string uniqueID = dgFamilyMember.Rows[e.RowIndex].Cells["unique"].Value.ToString();
            
            Employee selEmployee = employeedata.Family_mem.Find(p => p.Uniqueid == uniqueID);
            if (selEmployee != null)
            {
                selEmployee.Id_card = dgFamilyMember.Rows[e.RowIndex].Cells["Card_ID"].Value.ToString();
                //Check duplicate ID card for family member
                if (dgFamilyMember.CurrentCell.ColumnIndex == 0)
                {
                    if (!duplicateEmployeeCheck(selEmployee.Id_card, "IDCard"))
                    {
                        dgFamilyMember.Rows[e.RowIndex].Cells["Card_ID"].Value = null;
                    }
                }

                selEmployee.First_name = dgFamilyMember.Rows[e.RowIndex].Cells["First_Name"].Value.ToString();
                selEmployee.Last_name = dgFamilyMember.Rows[e.RowIndex].Cells["Last_Name"].Value.ToString();
                selEmployee.CNIC = dgFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value.ToString();
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
            employeedata.RowState = Rowstate.None;
            employeedata.Vehicle.RowState = Rowstate.None;

            foreach (Employee info in employeedata.Family_mem)
            {
                if (info.RowState == Rowstate.Deleted)
                {
                   // employeedata.Family_mem.Remove(info);
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
            DataTable dt = coll1.ToDataTableEmp(employeedata.Family_mem);
            dgFamilyMember.AutoGenerateColumns = false;
            dgFamilyMember.DataSource = dt;
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            employeedata = new Employee();
            employeedata.RowState = Rowstate.Add;
            txtIDCard.Text = employeedata.Id_card;
            txtFirstName.Text = employeedata.First_name;
            txtLastName.Text = employeedata.Last_name;
            txtCNIC.Text = employeedata.CNIC;
            txtIDCardSearch.Text = "";
            
            txtIDCardSearch.Enabled = true;
            txtIDCardSearch.Focus();
            bindGrid();
        }

        private bool Validate(Employee pemployee)
        {
            if (pemployee.Id_card.Length == 0)
            {
                MessageBox.Show("Please enter the ID Card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pemployee.First_name.Length == 0)
            {
                MessageBox.Show("Please enter the First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pemployee.Last_name.Length == 0)
            {
                MessageBox.Show("Please enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pemployee.CNIC.Length == 0)
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
                   if (dgFamilyMember[0, i].Value.ToString() == pemployee.Id_card.ToString() )
                   {
                       MessageBox.Show("Employee ID Card cannot be same as Family Card ID !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return false;
 
                   }
                   if (dgFamilyMember[5, i].Value.ToString() == pemployee.CNIC.ToString())
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }

}
