using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIS.UI
{
    public partial class MainPage : Form
    {
        public string ValueFromParent { get; set; }

        public MainPage(string initialValue)
        {
            InitializeComponent();
            ValueFromParent = initialValue;

        }
        
        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Employee Data")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                ResidentDataFrm empForm = new ResidentDataFrm();
                empForm.MdiParent = this;
                empForm.WindowState = FormWindowState.Normal;
               
                empForm.Show();
            }
        }

        private void studentRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Student Data")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                StudentDataFrm stdForm = new StudentDataFrm();
                stdForm.MdiParent = this;
                stdForm.WindowState = FormWindowState.Normal;
                stdForm.Show();
            }
        }

        private void guestRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Guest Data")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                GuestDataFrm gstForm = new GuestDataFrm();
                gstForm.MdiParent = this;
                gstForm.WindowState = FormWindowState.Normal;
                gstForm.Show();
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            
            if (ValueFromParent == "Admin")
            {
                menuStrip1.Items[0].Visible = true;
            }

            if (ValueFromParent == "Security Officer")
            {
                menuStrip1.Items[3].Visible = true;
                menuStrip1.Items[0].Visible = false;
                menuStrip1.Items[1].Visible = false;
                menuStrip1.Items[2].Visible = false;
            }

            /**code for status bar by Awais Ahmad 2016-11-21**/
            StatusBar mainStatusBar = new StatusBar();
 
            StatusBarPanel statusPanel = new StatusBarPanel();
            StatusBarPanel datetimePanel = new StatusBarPanel();
 
            // Set first panel properties and add to StatusBar
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = "Login Successfully .";
            statusPanel.ToolTipText = "Last Activity";
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);
 
            // Set second panel properties and add to StatusBar
            datetimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            datetimePanel.ToolTipText = "DateTime: " + System.DateTime.Today.ToString();
            datetimePanel.Text = System.DateTime.Today.ToLongDateString();
            datetimePanel.AutoSize = StatusBarPanelAutoSize.Contents;
            mainStatusBar.Panels.Add(datetimePanel);
 
            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);
            
            /**End of code addition by Awais Ahmad 2016-11-21**/

        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Create New User")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                CreateUser userForm = new CreateUser();
                userForm.MdiParent = this;
                userForm.WindowState = FormWindowState.Normal;
                userForm.Show();
            }
        }

        private void employeesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Reports")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                EmployeeReport empRpt = new EmployeeReport();
                empRpt.MdiParent = this;
                empRpt.WindowState = FormWindowState.Normal;
                empRpt.Show();
            }
        }

        private void aboutSISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "About Us")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                About abt = new About();
                abt.MdiParent = this;
                abt.WindowState = FormWindowState.Normal;
                abt.Show();
            }
        }

        private void entryExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Entry Data")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
 
            if (IsOpen == false)
            {
                EntryDataFrm entryForm = new EntryDataFrm();
                entryForm.MdiParent = this;
                entryForm.WindowState = FormWindowState.Normal;
                entryForm.Show();
            }
            
        }

        private void overNightStayRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Over Night Stay Request")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                OverNightStayReq newFrm = new OverNightStayReq();
                newFrm.MdiParent = this;
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.Show();
            }
        }

        private void overNightStayApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Over Night Stay Approval")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                OverNightStayApproval newFrm = new OverNightStayApproval();
                newFrm.MdiParent = this;
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.Show();
            }   */
        }

        private void overNightApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Over Night Stay Approval")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                OverNightStayApproval newFrm = new OverNightStayApproval();
                newFrm.MdiParent = this;
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.Show();
            }
        }

        private void vehileRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Vehicle Registration")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                VehicleDataFrm newFrm = new VehicleDataFrm();
                newFrm.MdiParent = this;
                newFrm.WindowState = FormWindowState.Normal;
                newFrm.Show();
            }
        }
 
        
    }
}
