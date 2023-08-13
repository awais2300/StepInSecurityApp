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
    public partial class StudentDataFrm : Form
    {
        int student_id;
        private Student studentdata = new Student();

        public StudentDataFrm()
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
            studentdata.RowState = Rowstate.Add;
        }

        #region buttons events

        private void btnSave_Click(object sender, EventArgs e)
        {
          
                StudentManager stdMgr = new StudentManager();
                //employeedata.Id_card = txtIDCard.Text;
                studentdata.First_name = txtFirstName.Text;
                studentdata.Last_name = txtLastName.Text;
                studentdata.CNIC = txtCNIC.Text;
                studentdata.P_std_id = null;
                if (Validate(studentdata))
                {
                    if (studentdata.RowState == Rowstate.Add)
                {
                    stdMgr.SaveStudent(studentdata);
                }
                else
                {
                    stdMgr.UpdateStudent(studentdata);
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
            emp.P_emp_id = studentdata.Std_id;
            string guid = System.Guid.NewGuid().ToString();
            emp.Uniqueid = guid;
            //studentdata.Family_mem.Add(emp);
            bindGrid();

        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {

            VehicleDetailFrm frm = new VehicleDetailFrm();
            frm.vehicle = studentdata.Vehicle;
            frm.ShowDialog();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDCardSearch.Text == "" || txtIDCardSearch.Text.Contains("'"))
            {
                MessageBox.Show("please enter valid CNIC No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDCardSearch.Focus();
                return;
            }
            {
                StudentManager stdMgr = new StudentManager();
                studentdata = stdMgr.GetStdByCNIC(txtIDCardSearch.Text);
                if (studentdata != null && studentdata.Std_id > 0)
                {
                    //txtIDCard.Text = employeedata.Id_card;
                    student_id = studentdata.Std_id;
                    txtFirstName.Text = studentdata.First_name;
                    txtLastName.Text = studentdata.Last_name;
                    txtCNIC.Text = studentdata.CNIC;
                    studentdata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No Match found with this CNIC/B-Form", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            studentdata.RowState = Rowstate.None;
            studentdata.Vehicle.RowState = Rowstate.None;

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
            studentdata = new Student();
            studentdata.RowState = Rowstate.Add;
            //txtIDCard.Text = employeedata.Id_card;
            txtFirstName.Text = studentdata.First_name;
            txtLastName.Text = studentdata.Last_name;
            txtCNIC.Text = studentdata.CNIC;
            txtIDCardSearch.Text = "";
            
            txtIDCardSearch.Enabled = true;
            txtIDCardSearch.Focus();
            bindGrid();

            dgShowAllStudent.Rows.Clear();
        }

        private bool Validate(Student pstudent)
        {
            //if (pstudent.Id_card.Length == 0)
            //{
            //    MessageBox.Show("Please enter the ID Card", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            if (pstudent.First_name.Length == 0)
            {
                MessageBox.Show("Please enter the First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pstudent.Last_name.Length == 0)
            {
                MessageBox.Show("Please enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pstudent.CNIC.Length == 0)
            {
                MessageBox.Show("Please enter the CNIC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        #endregion

        private void txtIDCard_Leave(object sender, EventArgs e)
        {
            if (txtCNIC.Text != "" && txtCNIC.Text != txtIDCardSearch.Text)
            {
                duplicateStudentCheck(txtCNIC.Text, "IDCard");
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
                    txtCNIC.Text = "";
                    txtCNIC.Focus();
                    MessageBox.Show("CNIC is already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return true;
        }

        private void txtCNIC_Leave(object sender, EventArgs e)
        {
            if (txtCNIC.Text != "" )
            {
                duplicateStudentCheck(txtCNIC.Text, "CNIC");
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            StudentManager stdMgr = new StudentManager();

            List<Student> std = stdMgr.ShowAllStudents();
            dgShowAllStudent.Rows.Clear();
            dgShowAllStudent.AutoGenerateColumns = false;

            for (int i = 0; i < std.Count(); i++ )
            {
                dgShowAllStudent.Rows.Add(std[i].Std_id, std[i].First_name, std[i].Last_name, std[i].CNIC, std[i].P_std_id, std[i].veh_id );
            }
            
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
                    btnReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cannot Mark Inactive, Guset is Entered in Colony", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnReset_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("No Student Selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnReset_Click(sender, e);
            }
        }

       
    }

}
