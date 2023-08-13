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
    public partial class OverNightStayReq : Form
    {
        
        public OverNightStayReq()
        {
            InitializeComponent();
        }

        private void cb_visitorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_visitorName.Items.Clear();
            cb_visitorName.ResetText();
            label3.Text = "";
            label8.Text = "";
            label9.Text = "";
            label11.Text = "";
            label12.Text = "";

            if (cb_visitorType.SelectedItem.ToString() == "Employee")
            {
               EmployeeManager empMgr = new EmployeeManager();  
               DataTable dt = new DataTable();
               dt = empMgr.GetEmpNames();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cb_visitorName.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString());
                    }
                }
            }
            else if (cb_visitorType.SelectedItem.ToString() == "Guest")
            {
                GuestManager gstMgr = new GuestManager();
                DataTable dt = new DataTable();
                dt = gstMgr.GetGstNames();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cb_visitorName.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString());
                    }
                }
            }
            else if (cb_visitorType.SelectedItem.ToString() == "Student")
            {
                StudentManager stdMgr = new StudentManager();
                DataTable dt = new DataTable();
                dt = stdMgr.GetStdNames();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cb_visitorName.Items.Add(row["First_Name"].ToString() + " " + row["Last_Name"].ToString());
                    }
                }
 
            }
        }

        private void cb_visitorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_visitorType.SelectedItem.ToString() == "Employee")
            {
                EmployeeManager empMgr = new EmployeeManager();
                DataTable dt = new DataTable();

                string selectedName = cb_visitorName.SelectedItem.ToString();
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
                        label3.Text = row["Emp_id"].ToString();
                        label8.Text = row["First_Name"].ToString();
                        label9.Text = row["Last_Name"].ToString();
                        label11.Text = row["CNIC"].ToString();
                        label12.Text = row["visits"].ToString();
                    }
                }
            }
            else if (cb_visitorType.SelectedItem.ToString() == "Guest")
            {
                GuestManager gstMgr = new GuestManager();
                DataTable dt = new DataTable();

                string selectedName = cb_visitorName.SelectedItem.ToString();
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
                        label3.Text = row["Gst_id"].ToString();
                        label8.Text = row["First_Name"].ToString();
                        label9.Text = row["Last_Name"].ToString();
                        label11.Text = row["CNIC"].ToString();
                        label12.Text = row["visits"].ToString();
                    }
                }

            }
            else if (cb_visitorType.SelectedItem.ToString() == "Student")
            {
                StudentManager stdMgr = new StudentManager();
                DataTable dt = new DataTable();

                string selectedName = cb_visitorName.SelectedItem.ToString();
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
                    label3.Text = row["Std_id"].ToString();
                    label8.Text = row["First_Name"].ToString();
                    label9.Text = row["Last_Name"].ToString();
                    label11.Text = row["CNIC"].ToString();
                    label12.Text = row["visits"].ToString();
                    }
                }

            }

        }

        private void OverNightStayReq_Load(object sender, EventArgs e)
        {
            txt_duration.Text = "0";
            label3.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
           
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //update OVER_NIGHTSTAY_STATUS in ENTRY_EXIT_DATA table

            if ( cb_visitorName.SelectedItem == null || cb_visitorType.SelectedItem == null )
            {
                MessageBox.Show("Values cannot be NULL!!! ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            SecurityManager secMgr = new SecurityManager();
            secMgr.GenerateOverNightReq(label3.Text, txt_duration.Text);
            MessageBox.Show("Over Night Stay Request Generated Successfully, and forward to Security Officer for approval", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

      
      
    }
}
