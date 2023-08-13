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
    public partial class VehicleDataFrm : Form
    {
        int student_id;
        bool readOnly;
        private Vehicle Vehicledata = new Vehicle();
        VehicleManager vehMgr = new VehicleManager();

        public VehicleDataFrm(int res_id, string FName, string LName, string House_no, string CNIC, string Mobile_no, string PTCL_no, string Email_id, string veh_id, string ResType, string ReadOnly)
        {
            InitializeComponent();
            txtResID.Text = res_id.ToString();
            txtFName.Text = FName;
            txtLName.Text = LName;
            txtCNIC.Text = CNIC;
            txtHouseNo.Text = House_no;
            txtMobile.Text = Mobile_no;
            txtPTCL.Text = PTCL_no;
            txtEmail.Text = Email_id;
            txtResType.Text = ResType;

            if (ReadOnly == "Y")
            {
                readOnly = true;
                Vehicledata = vehMgr.GetvehByVehicleId(veh_id);
                txtRegNo.Text = Vehicledata.Vehicle_reg;
                txtModel.Text = Vehicledata.Model;
                txtColor.Text = Vehicledata.Color;
                txtMake.Text = Vehicledata.Make;
                txtRegNo.Enabled = false;
                txtModel.Enabled = false;
                txtColor.Enabled = false;
                txtMake.Enabled = false;
                btnClose.Text = "Close";
            }

        }

        public VehicleDataFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            //VehicleManager vehMgr = new VehicleManager();
            //Vehicledata.Vehicle_id = Convert.ToInt32(txtResID.ToString());
            Vehicledata.Vehicle_reg = txtRegNo.Text;
            Vehicledata.Make = txtMake.Text;
            Vehicledata.Model = txtModel.Text;
            Vehicledata.Color = txtColor.Text;


            if (Validate(Vehicledata) && !readOnly)
            {
                vehMgr.AttachVehicle(Vehicledata, Convert.ToInt32(txtResID.Text));
                resetEmployee();
                MessageBox.Show("Vehicle Attached with Resident "+ txtFName.Text +" "+ txtLName.Text +" Updated Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReset_Click(sender, e);
            }
            this.Close();
        }

        private void EmployeeDataFrm_Load(object sender, EventArgs e)
        {
            Guid gud = new Guid();
            gud = Guid.NewGuid();
            Vehicledata.RowState = Rowstate.Add;
        }

        #region buttons events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!readOnly)
            {
                VehicleManager vehMgr = new VehicleManager();
                //employeedata.Id_card = txtIDCard.Text;
                Vehicledata.Vehicle_reg = txtRegNo.Text;
                Vehicledata.Make = txtMake.Text;
                Vehicledata.Model = txtModel.Text;
                Vehicledata.Color = txtColor.Text;


                if (Validate(Vehicledata))
                {
                    if (Vehicledata.RowState == Rowstate.Add)
                    {
                        vehMgr.SaveVehicle(Vehicledata);
                    }
                    else
                    {
                        vehMgr.UpdateVehicle(Vehicledata);
                    }
                    resetEmployee();
                    MessageBox.Show("Vehicle Data Updated Successfully for Resident " + txtFName.Text + " " + txtLName.Text, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnReset_Click(sender, e);
                    txtRegNo.Enabled = false;
                    txtModel.Enabled = false;
                    txtColor.Enabled = false;
                    txtMake.Enabled = false;
                    txtIDCardSearch.Text = "";
                    readOnly = true;
                    

                }
            }
            else
            {
                MessageBox.Show("Data is Read Only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
        
        private void btn_AddFamily_Click(object sender, EventArgs e)
        {
            Vehicle veh = new Vehicle();
            veh.RowState = Rowstate.Add;
            veh.Vehicle_id = Vehicledata.Vehicle_id;
            string guid = System.Guid.NewGuid().ToString();
            //veh.Uniqueid = guid;
            //studentdata.Family_mem.Add(emp);
            bindGrid();

        }

       /* private void btnVehicle_Click(object sender, EventArgs e)
        {

            VehicleDetailFrm frm = new VehicleDetailFrm();
            frm.vehicle = studentdata.Vehicle;
            frm.ShowDialog();

        }       */

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDCardSearch.Text == "" || txtIDCardSearch.Text.Contains("'"))
            {
                MessageBox.Show("please enter valid Vehicle Registration", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDCardSearch.Focus();
                return;
            }
            {
                VehicleManager vehMgr = new VehicleManager();
                Vehicledata = vehMgr.GetvehByRegNo(txtIDCardSearch.Text);
                if (Vehicledata != null && Vehicledata.Vehicle_id > 0)
                {
                    //txtIDCard.Text = employeedata.Id_card;
                    student_id = Vehicledata.Vehicle_id;
                    txtRegNo.Text = Vehicledata.Vehicle_reg;
                    txtMake.Text = Vehicledata.Make;
                    txtModel.Text = Vehicledata.Model;
                    Vehicledata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                    txtRegNo.Enabled = true;
                    txtModel.Enabled = true;
                    txtColor.Enabled = true;
                    txtMake.Enabled = true;
                    readOnly = false;
                    
                }
                else
                {
                    MessageBox.Show("No Match found with this Vehicle Registration", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDCardSearch.Focus();
                    return;

                }
            }
        }

        #endregion 

        #region gridEvents

        private void dgFamilyMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //    e.RowIndex >= 0)
            //{
            //    string uniqueID = dgFamilyMember.Rows[e.RowIndex].Cells["unique"].Value.ToString();
            //    //Student selEmployee = studentdata.Family_mem.Find(p => p.Uniqueid == uniqueID);
            //    if (e.ColumnIndex == 7)
            //    {
            //        //VehicleDetailFrm frm = new VehicleDetailFrm();
            //        //if (selEmployee.Vehicle == null)
            //        //{
            //        //    selEmployee.Vehicle = new Vehicle();
            //        //    selEmployee.Vehicle.RowState = Rowstate.Add;
            //        //}
            //        //frm.vehicle = selEmployee.Vehicle;
            //        //frm.ShowDialog();


            //    }
            //    else if (e.ColumnIndex == 8)
            //    {
            //        selEmployee.RowState = Rowstate.Deleted;
            //        senderGrid.Rows.RemoveAt(e.RowIndex);
            //    }
            //}


        }

        //private void dgFamilyMember_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    string uniqueID = dgFamilyMember.Rows[e.RowIndex].Cells["unique"].Value.ToString();
        //    Employee selEmployee = employeedata.Family_mem.Find(p => p.Uniqueid == uniqueID);
        //    if (selEmployee != null)
        //    {
        //        selEmployee.Id_card = dgFamilyMember.Rows[e.RowIndex].Cells["Card_ID"].Value.ToString();
        //        selEmployee.First_name = dgFamilyMember.Rows[e.RowIndex].Cells["First_Name"].Value.ToString();
        //        selEmployee.Last_name = dgFamilyMember.Rows[e.RowIndex].Cells["Last_Name"].Value.ToString();
        //        selEmployee.CNIC = dgFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value.ToString();
        //        if (selEmployee.RowState == Rowstate.None)
        //        {
        //            selEmployee.RowState = Rowstate.Modified;
        //        }
        //    }
        //}

        #endregion

        #region private Methods

        private void resetEmployee()
        {
            Vehicledata.RowState = Rowstate.None;
            //Vehicledata.Vehicle.RowState = Rowstate.None;

            //foreach (Employee info in studentdata.Family_mem)
            //{
            //    if (info.RowState == Rowstate.Deleted)
            //    {
            //       // employeedata.Family_mem.Remove(info);
            //    }
            //    else
            //    {
            //        info.RowState = Rowstate.None;
            //        if (info.Vehicle != null)
            //        {
            //            info.Vehicle.RowState = Rowstate.None;
            //        }
            //    }
            //}
        }

        private void bindGrid()
        {
            //Collection coll = new Collection();
            //DataTable dt = //coll.ToDataTable(studentdata.First_name);
            //dgFamilyMember.AutoGenerateColumns = false;
            //dgFamilyMember.DataSource = dt;
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!readOnly)
            {
                Vehicle data = new Vehicle();
                data.RowState = Rowstate.Add;
                //txtIDCard.Text = employeedata.Id_card;
                txtRegNo.Text = data.Vehicle_reg;
                txtMake.Text = data.Make;
                txtModel.Text = data.Model;
                txtColor.Text = data.Color;
                txtIDCardSearch.Text = "";

                txtIDCardSearch.Enabled = true;
                txtIDCardSearch.Focus();
                bindGrid();
            }
            else
            {
                MessageBox.Show("Data is Read Only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //dgShowAllStudent.Rows.Clear();
        }

        private bool Validate(Vehicle pVehicle)
        {
            if (pVehicle.Color.Length == 0)
            {
                MessageBox.Show("Please enter the ID Card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pVehicle.Vehicle_reg.Length == 0)
            {
                MessageBox.Show("Please enter the First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pVehicle.Model.Length == 0)
            {
                MessageBox.Show("Please enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pVehicle.Make.Length == 0)
            {
                MessageBox.Show("Please enter the CNIC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        #endregion

        private void txtIDCard_Leave(object sender, EventArgs e)
        {
            if (txtModel.Text != "" && txtModel.Text != txtIDCardSearch.Text)
            {
                duplicateStudentCheck(txtModel.Text, "IDCard");
            }  
        }

        private bool duplicateStudentCheck(string searchtext, string SearchType)
        {
            StudentManager stdMgr = new StudentManager();

            if (SearchType == "IDCard")
            {
                Student std = stdMgr.GetStdByCNIC(searchtext);
                if (std != null && std.Std_id > 0)
                {
                   // txtIDCard.Text = "";
                   // txtIDCard.Focus();
                    MessageBox.Show("CNIC is already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            if (SearchType == "CNIC")
            {
                Student std = stdMgr.GetStdByCNIC(searchtext);
                if (std != null && std.Std_id > 0)
                {
                    txtModel.Text = "";
                    txtModel.Focus();
                    MessageBox.Show("CNIC is already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return true;
        }

        private void txtCNIC_Leave(object sender, EventArgs e)
        {
            if (txtModel.Text != "" )
            {
                duplicateStudentCheck(txtModel.Text, "CNIC");
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            StudentManager stdMgr = new StudentManager();

            List<Student> std = stdMgr.ShowAllStudents();
            //dgShowAllStudent.Rows.Clear();
            //dgShowAllStudent.AutoGenerateColumns = false;

            /*for (int i = 0; i < std.Count(); i++ )
            {
                dgShowAllStudent.Rows.Add(std[i].Std_id, std[i].First_name, std[i].Last_name, std[i].CNIC, std[i].P_std_id, std[i].veh_id );
            }  */
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (student_id.ToString() != "0")
            {
                SecurityManager secMgr = new SecurityManager();
                if (secMgr.GetStudentStatus(student_id.ToString()))
                {
                    StudentManager stdMgr = new StudentManager();

                    stdMgr.DeleteStudent(student_id);
                    MessageBox.Show("Student Marked Inactive Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cannot Mark Inactive, Guset is Entered in Colony", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //btnReset_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("No Student Selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //btnReset_Click(sender, e);
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
