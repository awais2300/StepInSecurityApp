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
    public partial class OverNightStayApproval : Form
    {
        
        public OverNightStayApproval()
        {
            InitializeComponent();
        }

        private void cb_visitorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_reqStatus.Items.Clear();
            cb_reqStatus.ResetText();
            cb_selectReq.Items.Clear();
            cb_selectReq.ResetText();
            cb_reqStatus.Items.Add("Open Requests").ToString();

            label3.Text = "";
            label8.Text = "";
            label9.Text = "";
            label11.Text = "";
            label12.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

       

        private void OverNightStayReq_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //update OVER_NIGHTSTAY_STATUS in ENTRY_EXIT_DATA table
            if (cb_reqStatus.SelectedItem == null || cb_visitorType.SelectedItem == null || cb_selectReq.SelectedItem == null)
            {
                MessageBox.Show("Values cannot be NULL!!! ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SecurityManager secMgr = new SecurityManager();
            secMgr.ApproveOverNightReq(label3.Text);
            MessageBox.Show("Request Approved Successfully!!! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label7.Text = "Approved";

        }

        private void cb_selectReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_visitorType.SelectedItem.ToString() == "Employee")
            {
                EmployeeManager empMgr = new EmployeeManager();
                DataTable dt = new DataTable();

                string selectedName = cb_selectReq.SelectedItem.ToString();
                int index = selectedName.IndexOf(" ");
                string FirstName = selectedName.Substring(0, index);

                dt = empMgr.GetEmpDetails(FirstName);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        label3.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        
                        label3.Text = row["Emp_id"].ToString();
                        label8.Text = row["First_Name"].ToString();
                        label9.Text = row["Last_Name"].ToString();
                        label11.Text = row["CNIC"].ToString();
                        label12.Text = row["visits"].ToString();
                        label6.Text = row["over_nightstay_duration"].ToString();

                        if (row["over_nightstay_status"].ToString() == "R")
                        {
                            label7.Text = "Requested";
                            
                        }
                    }
                }
            }
            else if (cb_visitorType.SelectedItem.ToString() == "Guest")
            {
                GuestManager gstMgr = new GuestManager();
                DataTable dt = new DataTable();

                string selectedName = cb_selectReq.SelectedItem.ToString();
                int index = selectedName.IndexOf(" ");
                string FirstName = selectedName.Substring(0, index);


                dt = gstMgr.GetGstDetails(FirstName);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        label3.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        label3.Text = row["Gst_id"].ToString();
                        label8.Text = row["First_Name"].ToString();
                        label9.Text = row["Last_Name"].ToString();
                        label11.Text = row["CNIC"].ToString();
                        label12.Text = row["visits"].ToString();
                        label6.Text = row["over_nightstay_duration"].ToString();

                        if (row["over_nightstay_status"].ToString() == "R")
                        {
                            label7.Text = "Requested";

                        }
                    }
                }

            }
            else if (cb_visitorType.SelectedItem.ToString() == "Student")
            {
                StudentManager stdMgr = new StudentManager();
                DataTable dt = new DataTable();

                string selectedName = cb_selectReq.SelectedItem.ToString();
                int index = selectedName.IndexOf(" ");
                string FirstName = selectedName.Substring(0, index);

                dt = stdMgr.GetStdDetails(FirstName);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        label3.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        label3.Text = row["Std_id"].ToString();
                        label8.Text = row["First_Name"].ToString();
                        label9.Text = row["Last_Name"].ToString();
                        label11.Text = row["CNIC"].ToString();
                        label12.Text = row["visits"].ToString();
                        label6.Text = row["over_nightstay_duration"].ToString();

                        if (row["over_nightstay_status"].ToString() == "R")
                        {
                            label7.Text = "Requested";

                        }
                    }
                }

            }
        }

        private void cb_reqStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_selectReq.Items.Clear();
            cb_selectReq.ResetText();
            label3.Text = "";
            label8.Text = "";
            label9.Text = "";
            label11.Text = "";
            label12.Text = "";
            label6.Text = "";
            label7.Text = "";

            if (cb_visitorType.SelectedItem.ToString() == "Employee")
            {
                EmployeeManager empMgr = new EmployeeManager();
                DataTable dt = new DataTable();
                dt = empMgr.GetEmpNamesForApproval();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cb_selectReq.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString());
                    }
                }
            }
            else if (cb_visitorType.SelectedItem.ToString() == "Guest")
            {
                GuestManager gstMgr = new GuestManager();
                DataTable dt = new DataTable();
                dt = gstMgr.GetGstNamesForApproval();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cb_selectReq.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString());
                    }
                }
            }
            else if (cb_visitorType.SelectedItem.ToString() == "Student")
            {
                StudentManager stdMgr = new StudentManager();
                DataTable dt = new DataTable();
                dt = stdMgr.GetStdNamesForApproval();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cb_selectReq.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString());
                    }
                }

            }
        }

      
      
    }
}
