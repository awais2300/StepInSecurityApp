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
    public partial class EntryDataFrm : Form
    {
        private Employee employeedata = new Employee();
        private Guest guestdata = new Guest();
        private Student studentdata = new Student();
        string personList;
        SecurityManager secMgr = new SecurityManager();

        public EntryDataFrm()
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
            cbVisitorType.SelectedIndex = 0;
            lbl_date.Text = DateTime.Now.ToString("yyyy/M/d");
            txtTimeIn.Text = DateTime.Now.ToString("HH:mm:ss");
            txtTimeOut.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        #region buttons events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lbl_status.Text != "In-Active")
            {
                SecurityManager secMgr = new SecurityManager();

                if (cbVisitorType.SelectedItem.ToString() == "Employee")
                {
                    if (txtID.Text == null || txtID.Text == "")
                    {
                        MessageBox.Show("No Employee Selected!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    employeedata.Emp_id = Convert.ToInt32(txtID.Text);
                    employeedata.Id_card = txtIDCard.Text;
                    employeedata.First_name = txtFirstName.Text;
                    employeedata.Last_name = txtLastName.Text;
                    employeedata.CNIC = txtCNIC.Text;
                    employeedata.P_emp_id = null;
                    if (Validate(employeedata))
                    {
                        if (secMgr.GetEmpStatus(txtID.Text))
                        {
                            string ls_timeIn = lbl_date.Text + " " + txtTimeIn.Text;
                            secMgr.EmployeeTimeIn(employeedata, ls_timeIn);
                            resetEmployee();
                            MessageBox.Show("Employee Data Saved Successfully", "Time In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnReset_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Employee is already Entered, please Exit him First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (cbVisitorType.SelectedItem.ToString() == "Guest")
                {
                    if (txtID.Text == null || txtID.Text == "")
                    {
                        MessageBox.Show("No Guest Selected!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    guestdata.Gst_id = Convert.ToInt32(txtID.Text);
                    guestdata.First_name = txtFirstName.Text;
                    guestdata.Last_name = txtLastName.Text;
                    guestdata.CNIC = txtCNIC.Text;
                    guestdata.P_gst_id = null;


                    if (cb_whichEmpVisit.SelectedItem == null)
                    {
                        MessageBox.Show("Please Select Which employee to Visit, Then Time In, Thanks!!!", "Time In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (secMgr.GetGuestStatus(txtID.Text))
                    {
                        string ls_timeIn = lbl_date.Text + " " + txtTimeIn.Text;

                        //AddPersons addpersons = new AddPersons();
                        EmployeeManager empMgr = new EmployeeManager();
                        DataTable dt = new DataTable();
                        string selectedName = cb_whichEmpVisit.SelectedItem.ToString();
                        int index = selectedName.IndexOf(" ");
                        string FirstName = selectedName.Substring(0, index);
                        string Emp_name, Emp_ID;
                        dt = empMgr.GetEmpDetailsForVisits(FirstName);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                Emp_name = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                                Emp_ID = row["ID_Card"].ToString();
                                secMgr.GuestTimeIn(guestdata, ls_timeIn, Emp_name, Emp_ID, personList);
                            }
                        }

                        MessageBox.Show("Guest Data Saved Successfully, Kindly Issue Visitor's pass for this Guest Now!!!", "Time In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Guest is Already Entered, Please Exit him first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (cbVisitorType.SelectedItem.ToString() == "Student")
                {

                    if (txtID.Text == null || txtID.Text == "")
                    {
                        MessageBox.Show("No Student Selected!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    studentdata.Std_id = Convert.ToInt32(txtID.Text);
                    studentdata.First_name = txtFirstName.Text;
                    studentdata.Last_name = txtLastName.Text;
                    studentdata.CNIC = txtCNIC.Text;
                    studentdata.P_std_id = null;


                    if (secMgr.GetStudentStatus(txtID.Text))
                    {
                        string ls_timeIn = lbl_date.Text + " " + txtTimeIn.Text;
                        secMgr.StudentTimeIn(studentdata, ls_timeIn);
                        //resetEmployee();
                        MessageBox.Show("Student Data Saved Successfully", "Time In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Student is Already Entered, Please Exit him first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("User In-Active!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReset_Click(sender, e);
            }
                
         }
        
        private void btn_AddFamily_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.RowState = Rowstate.Add;
            emp.P_emp_id = employeedata.Emp_id;
            string guid = System.Guid.NewGuid().ToString();
            emp.Uniqueid = guid;
            employeedata.Family_mem.Add(emp);
            bindGrid();
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {

            VehicleDetailFrm frm = new VehicleDetailFrm();
            //frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            if (cbVisitorType.SelectedItem.ToString() == "Employee")
            {
                frm.vehicle = employeedata.Vehicle;
            }
            else if (cbVisitorType.SelectedItem.ToString() == "Student")
            {
                frm.vehicle = studentdata.Vehicle;
            }
            else if (cbVisitorType.SelectedItem.ToString() == "Guest")
            {
                frm.vehicle = guestdata.Vehicle;
            }
            frm.ShowDialog();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (cbVisitorType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Visitor Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (txtIDCardSearch.Text == "" || txtIDCardSearch.Text.Contains("'"))
            {
                MessageBox.Show("please enter valid card id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDCardSearch.Focus();
                return;
            }

            else if (cbVisitorType.SelectedItem.ToString() == "Employee")
            {
                EmployeeManager empMgr = new EmployeeManager();
                employeedata = empMgr.GetEmpByCarId(txtIDCardSearch.Text);
                if (employeedata != null && employeedata.Emp_id > 0)
                {
                    txtID.Text = employeedata.Emp_id.ToString();
                    txtIDCard.Text = employeedata.Id_card;
                    txtFirstName.Text = employeedata.First_name;
                    txtLastName.Text = employeedata.Last_name;
                    txtCNIC.Text = employeedata.CNIC;
                    lbl_status.Visible = true;
                    if (employeedata.status.ToString() == null || employeedata.status.ToString() == "OP")
                    {
                        lbl_status.ForeColor = System.Drawing.Color.Green;
                        lbl_status.Text = "Active";
                    }
                    else
                    {
                        lbl_status.ForeColor = System.Drawing.Color.Red;
                        lbl_status.Text = "In-Active";
                    }
                    employeedata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No data Entered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIDCardSearch.Focus();
                    return;

                }
                
            }
            else if (cbVisitorType.SelectedItem.ToString() == "Guest")
            {

                GuestManager gstMgr = new GuestManager();
                guestdata = gstMgr.GetGstByCNIC(txtIDCardSearch.Text);

                if (guestdata != null && guestdata.Gst_id > 0)
                {

                    //If Guest is already entered, then Show button to return Visitor's Pass
                    SecurityManager secMgr = new SecurityManager();
                    if (!secMgr.GetGuestStatus(guestdata.Gst_id.ToString()))
                    {
                        btn_returnPass.Visible = true;
                        btn_issuePass.Visible = false;
                    }
                    else
                    {
                        btn_returnPass.Visible = false;
                        btn_issuePass.Visible = true;
                    }


                    txtID.Text = guestdata.Gst_id.ToString();
                    txtFirstName.Text = guestdata.First_name;
                    txtLastName.Text = guestdata.Last_name;
                    txtCNIC.Text = guestdata.CNIC;
                    lbl_status.Visible = true;
                    if (guestdata.status.ToString() == null || guestdata.status.ToString() == "OP")
                    {
                        lbl_status.ForeColor = System.Drawing.Color.Green;
                        lbl_status.Text = "Active";
                    }
                    else
                    {
                        lbl_status.ForeColor = System.Drawing.Color.Red;
                        lbl_status.Text = "In-Active";
                        //lbl_status.Text = guestdata.status.ToString();
                    }
                    guestdata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Guest Not Found with this CNIC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDCardSearch.Focus();
                    return;

                }
            }

            else if (cbVisitorType.SelectedItem.ToString() == "Student")
            {

                StudentManager stdMgr = new StudentManager();
                studentdata = stdMgr.GetStdByCNIC(txtIDCardSearch.Text);
                if (studentdata != null && studentdata.Std_id > 0)
                {
                    //txtIDCard.Text = employeedata.Id_card;
                    txtID.Text = studentdata.Std_id.ToString();
                    txtFirstName.Text = studentdata.First_name;
                    txtLastName.Text = studentdata.Last_name;
                    txtCNIC.Text = studentdata.CNIC;
                    lbl_status.Visible = true;
                    if (studentdata.status.ToString() == null || studentdata.status.ToString() == "OP")
                    {
                        lbl_status.ForeColor = System.Drawing.Color.Green;
                        lbl_status.Text = "Active";
                    }
                    else
                    {
                        lbl_status.ForeColor = System.Drawing.Color.Red;
                        lbl_status.Text = "In-Active";
                        
                    }
                    
                    studentdata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please enter valid CNIC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIDCardSearch.Focus();
                    return;

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

        private void bindGrid()
        {
            Collection coll = new Collection();
            DataTable dt = coll.ToDataTableEmp(employeedata.Family_mem);
           // dgFamilyMember.AutoGenerateColumns = false;
           // dgFamilyMember.DataSource = dt;
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
            cb_whichEmpVisit.Items.Clear();
            cb_whichEmpVisit.ResetText();
            cbVisitorType.SelectedIndex = 0;
            btn_returnPass.Visible = false;


            lbl_date.Text = DateTime.Now.ToString("yyyy/M/d");
            txtTimeIn.Text = DateTime.Now.ToString("HH:mm:ss");
            
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
                }
            }
            if (SearchType == "CNIC")
            {
                Employee emp = empMGr.GetEmpByCNIC(searchtext);
                if (emp != null && emp.Emp_id > 0)
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
                duplicateEmployeeCheck(txtCNIC.Text, "CNIC");
            }
        }

        private void cbVisitorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVisitorType.SelectedItem.ToString() == "Guest")
            {
                lbl_whichEmpVisit.Visible = true;
                cb_whichEmpVisit.Visible = true;
                btn_persons.Visible = true;
                cb_whichEmpVisit.Items.Clear();
                cb_whichEmpVisit.ResetText();
                    EmployeeManager empMgr = new EmployeeManager();
                    DataTable dt = new DataTable();
                    dt = empMgr.GetEmpNamesForVisit();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            cb_whichEmpVisit.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString() + " (" + row["CNIC"].ToString()+")");
                        }
                    }

            }
            else
            {
                btn_issuePass.Visible = false;
                btn_returnPass.Visible = false;
                lbl_whichEmpVisit.Visible = false;
                cb_whichEmpVisit.Visible = false;
                btn_persons.Visible = false;
            }

            if ((cbVisitorType.SelectedIndex == 2) || (cbVisitorType.SelectedIndex == 3))
            {
                txtIDCard.Visible = false;
                lbl_IdCard.Visible = false;
                lbl_ID_Card.Text = "CNIC";

            }
            else
            {
                txtIDCard.Visible = true;
                lbl_IdCard.Visible = true;
                lbl_ID_Card.Text = "ID Card";
            }

            txtIDCard.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCNIC.Text = "";
            txtIDCardSearch.Text = "";
            lbl_status.Visible = false;

            txtIDCardSearch.Enabled = true;
            txtIDCardSearch.Focus();
            bindGrid();
        }

        private void btn_TimeOut_Click(object sender, EventArgs e)
        {
          
            if (txtTimeOut.Text == null || txtTimeOut.Text == "")
            {
                MessageBox.Show("Time Out Missing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbVisitorType.SelectedItem.ToString() == "Employee")
            {
                employeedata.Emp_id = Convert.ToInt32(txtID.Text);
                employeedata.Id_card = txtIDCard.Text;
                employeedata.First_name = txtFirstName.Text;
                employeedata.Last_name = txtLastName.Text;
                employeedata.CNIC = txtCNIC.Text;
                employeedata.P_emp_id = null;
                if (Validate(employeedata))
                {
                    if (!secMgr.GetEmpStatus(txtID.Text))
                    {
                        string ls_timeOut = lbl_date.Text + " " + txtTimeOut.Text;
                        secMgr.EmployeeTimeOut(employeedata, ls_timeOut);
                        resetEmployee();
                        MessageBox.Show("Employee Data Saved Successfully", "Time Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Employee is Not Entered, Please Contact Security Officer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (cbVisitorType.SelectedItem.ToString() == "Guest")
            {
                guestdata.Gst_id = Convert.ToInt32(txtID.Text);
                guestdata.First_name = txtFirstName.Text;
                guestdata.Last_name = txtLastName.Text;
                guestdata.CNIC = txtCNIC.Text;
                guestdata.P_gst_id = null;


                if (!secMgr.GetGuestStatus(txtID.Text))
                {
                    if (secMgr.GetVisitorPassStatus(txtID.Text))
                    {
                        string ls_timeOut = lbl_date.Text + " " + txtTimeOut.Text;
                        secMgr.GuestTimeOut(guestdata, ls_timeOut);
                        //resetEmployee();
                        MessageBox.Show("Guest Data Saved Successfully", "Time Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Kindly Return Visitor's Pass First, Then Time Out. Thanks!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Guest is Not Entered, Please Contact Security Officer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else if (cbVisitorType.SelectedItem.ToString() == "Student")
            {
                
                studentdata.Std_id = Convert.ToInt32(txtID.Text);
                studentdata.First_name = txtFirstName.Text;
                studentdata.Last_name = txtLastName.Text;
                studentdata.CNIC = txtCNIC.Text;
                studentdata.P_std_id = null;

                if (!secMgr.GetStudentStatus(txtID.Text))
                {
                    string ls_timeOut = lbl_date.Text + " " + txtTimeOut.Text;
                    secMgr.StudentTimeOut(studentdata, ls_timeOut);
                    //resetEmployee();
                    MessageBox.Show("Student Data Saved Successfully", "Time Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Student is Not Entered, Please Contact Security Officer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_issuePass_Click(object sender, EventArgs e)
        {
              if (cbVisitorType.SelectedItem.ToString() == "Guest")
                {
                    guestdata.Gst_id = Convert.ToInt32(txtID.Text);
                    guestdata.First_name = txtFirstName.Text;
                    guestdata.Last_name = txtLastName.Text;
                    guestdata.CNIC = txtCNIC.Text;
                    guestdata.P_gst_id = null;


                    if (!secMgr.GetGuestStatus(txtID.Text))
                    {
                        string ls_timeIn = lbl_date.Text + " " + txtTimeIn.Text;
                        secMgr.IssueVisitorPass(guestdata);
                        //resetEmployee();
                        MessageBox.Show("Visitor's Pass Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Visitor's Pass cannot be issued, because Guest is not Entered In", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void btn_persons_Click(object sender, EventArgs e)
        {
            AddPersons add = new AddPersons();
            add.ShowDialog();
            personList = add.personslist;
        }

        private void btn_returnPass_Click(object sender, EventArgs e)
        {
            if (cbVisitorType.SelectedItem.ToString() == "Guest")
            {
                guestdata.Gst_id = Convert.ToInt32(txtID.Text);
                guestdata.First_name = txtFirstName.Text;
                guestdata.Last_name = txtLastName.Text;
                guestdata.CNIC = txtCNIC.Text;
                guestdata.P_gst_id = null;


                if (!secMgr.GetGuestStatus(txtID.Text))
                {
                    string ls_timeIn = lbl_date.Text + " " + txtTimeIn.Text;
                    secMgr.ReturnVisitorPass(guestdata);
                    //resetEmployee();
                    MessageBox.Show("Visitor's Pass Returned Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Now Guest can be Timed Out from colony", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Visitor's Pass cannot be Returned, because Guest is not Entered In", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

}
