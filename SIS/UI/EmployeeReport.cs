using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIS.UI;
using SIS.TestSISDataSetTableAdapters;
using Microsoft.Reporting.WinForms;

namespace SIS.UI
{
    public partial class EmployeeReport : Form
    {
        public EmployeeReport()
        {
            InitializeComponent();
        }

        private void EmployeeReport_Load(object sender, EventArgs e)
        {
            
            cb_tableList.Items.Insert(0,"Select Report");
            cb_tableList.SelectedIndex = 0;
            this.reportViewer1.RefreshReport(); 
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer6.RefreshReport();
            this.reportViewer7.RefreshReport();
            this.reportViewer8.RefreshReport();
            this.reportViewer9.RefreshReport();
            this.reportViewer10.RefreshReport();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            string startDate;
            string endDate;

            if ( cb_tableList.SelectedItem.ToString() == "Employee List" )
            {
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer1.Visible = true;
                this.reportViewer5.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;
                this.employeeTableAdapter.Fill(this.testSISDataSet.Employee);
                this.reportViewer1.RefreshReport(); 
            }
            else if (cb_tableList.SelectedItem.ToString() == "Guest List")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer2.Visible = true;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;
                this.guestTableAdapter.Fill(this.testSISDataSet.Guest);
                this.reportViewer2.RefreshReport();
                           
            }
            else if (cb_tableList.SelectedItem.ToString() == "Student List")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = true;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;
                this.studentTableAdapter.Fill(this.testSISDataSet.Student );  
                this.reportViewer3.RefreshReport();
            }
            else if (cb_tableList.SelectedItem.ToString() == "Vehicle List")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = true;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;
                this.vehicleTableAdapter.Fill(this.testSISDataSet.Vehicle);
                this.reportViewer4.RefreshReport();
            }
            else if (cb_tableList.SelectedItem.ToString() == "Visitors didnot have Over Night Permission")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = true;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;

                if (txt_DateFrom.Text == "" || txt_DateTo.Text == "")
                {
                    startDate = "01-01-2001";
                    endDate = "01-01-2099";

                    //MessageBox.Show("Date from Or Date To cannot be empty!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return;
                }
                else
                {
                    startDate = txt_DateFrom.Text;
                    endDate = txt_DateTo.Text;
                }

                DateTime dt;
                bool isDate = true;

                try
                {
                    dt = DateTime.Parse(startDate);
                    dt = DateTime.Parse(endDate);
                }
                catch
                {
                    isDate = false;

                }
                if (!isDate)
                {
                    MessageBox.Show("Date format is not Valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.dailyVehicleReportTableAdapter.Dispose();
                this.overNightStayReportTableAdapter.Fill(this.testSISDataSet.OverNightStayReport, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                this.reportViewer5.RefreshReport();
            }
            else if (cb_tableList.SelectedItem.ToString() == "Visitors Daily Entry/Exit report")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = true;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;

                if (txt_DateFrom.Text == "" || txt_DateTo.Text == "")
                {
                    startDate = "01-01-2001";
                    endDate = "01-01-2099";
                }
                else
                {
                    startDate = txt_DateFrom.Text;
                    endDate = txt_DateTo.Text;
                }
                DateTime dt;
                bool isDate = true;

                try
                {
                    dt = DateTime.Parse(startDate);
                    dt = DateTime.Parse(endDate);
                }
                catch
                {
                    isDate = false;

                }
                if (!isDate)
                {
                    MessageBox.Show("Date format is not Valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.dailyVisitorsReportTableAdapter.Dispose();
                this.dailyVisitorsReportTableAdapter.Fill(this.testSISDataSet.DailyVisitorsReport, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                this.reportViewer6.RefreshReport();
            }
            else if (cb_tableList.SelectedItem.ToString() == "Visitors didnot returned Visitor Pass")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = true;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;

                if (txt_DateFrom.Text == "" || txt_DateTo.Text == "")
                {
                    startDate = "01-01-2001";
                    endDate = "01-01-2099";
                }
                else
                {
                    startDate = txt_DateFrom.Text;
                    endDate = txt_DateTo.Text;
                }
                DateTime dt;
                bool isDate = true;

                try
                {
                    dt = DateTime.Parse(startDate);
                    dt = DateTime.Parse(endDate);
                }
                catch
                {
                    isDate = false;

                }
                if (!isDate)
                {
                    MessageBox.Show("Date format is not Valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.visitorPassNotReturnedTableAdapter.Dispose();
                this.visitorPassNotReturnedTableAdapter.Fill(this.testSISDataSet.VisitorPassNotReturned , Convert.ToDateTime(startDate) , Convert.ToDateTime(endDate));
                this.reportViewer7.RefreshReport();
            }
            else if (cb_tableList.SelectedItem.ToString() == "Vehicle Daily Entry/Exit Report")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = true;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = false;

                if (txt_DateFrom.Text == "" || txt_DateTo.Text == "")
                {
                    startDate = "01-01-2001";
                    endDate = "01-01-2099";
                }
                else
                {
                    startDate = txt_DateFrom.Text;
                    endDate = txt_DateTo.Text;
                }
                DateTime dt;
                bool isDate = true;

                try
                {
                    dt = DateTime.Parse(startDate);
                    dt = DateTime.Parse(endDate);
                }
                catch
                {
                    isDate = false;

                }
                if (!isDate)
                {
                    MessageBox.Show("Date format is not Valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.dailyVehicleReportTableAdapter.Dispose();
                this.dailyVehicleReportTableAdapter.Fill(this.testSISDataSet.DailyVehicleReport, Convert.ToDateTime(startDate) , Convert.ToDateTime(endDate));
                this.reportViewer8.RefreshReport();

            }
            else if (cb_tableList.SelectedItem.ToString() == "School Daily Report")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = true;
                this.reportViewer10.Visible = false;

                if (txt_DateFrom.Text == "" || txt_DateTo.Text == "")
                {
                    startDate = "01-01-2001";
                    endDate = "01-01-2099";
                }
                else
                {
                    startDate = txt_DateFrom.Text;
                    endDate = txt_DateTo.Text;
                }
                DateTime dt;
                bool isDate = true;

                try
                {
                    dt = DateTime.Parse(startDate);
                    dt = DateTime.Parse(endDate);
                }
                catch
                {
                    isDate = false;

                }
                if (!isDate)
                {
                    MessageBox.Show("Date format is not Valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.dailyStudentReportTableAdapter.Dispose();
                this.dailyStudentReportTableAdapter.Fill(this.testSISDataSet.DailyStudentReport, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                this.reportViewer9.RefreshReport();
            }

            else if (cb_tableList.SelectedItem.ToString() == "Guests Visited which Employees")
            {
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.reportViewer3.Visible = false;
                this.reportViewer4.Visible = false;
                this.reportViewer5.Visible = false;
                this.reportViewer6.Visible = false;
                this.reportViewer7.Visible = false;
                this.reportViewer8.Visible = false;
                this.reportViewer9.Visible = false;
                this.reportViewer10.Visible = true;

                if (txt_DateFrom.Text == "" || txt_DateTo.Text == "")
                {
                    startDate = "01-01-2001";
                    endDate = "01-01-2099";
                }
                else
                {
                    startDate = txt_DateFrom.Text;
                    endDate = txt_DateTo.Text;
                }
                DateTime dt;
                bool isDate = true;

                try
                {
                    dt = DateTime.Parse(startDate);
                    dt = DateTime.Parse(endDate);
                }
                catch
                {
                    isDate = false;
                    
                }
                if (!isDate) 
                { 
                    MessageBox.Show("Date format is not Valid!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this.dailyVisitorReport_wrt_EmpTableAdapter.Dispose();
                this.dailyVisitorReport_wrt_EmpTableAdapter.Fill(this.testSISDataSet.DailyVisitorReport_wrt_Emp, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                this.reportViewer10.RefreshReport();
            }
                 
            else
            {
                MessageBox.Show("No Report Selected!!!");
            }
        }

        private void cb_tableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tableList.SelectedItem.ToString() == "Vehicle Daily Entry/Exit Report" || cb_tableList.SelectedItem.ToString() == "Visitors Daily Entry/Exit report" || cb_tableList.SelectedItem.ToString() == "Visitors didnot have Over Night Permission" || cb_tableList.SelectedItem.ToString() == "Visitors didnot returned Visitor Pass" || cb_tableList.SelectedItem.ToString() == "School Daily Report" || cb_tableList.SelectedItem.ToString() == "Guests Visited which Employees")
            {
                txt_DateFrom.Visible = true;
                txt_DateTo.Visible = true;
                lbl_dateFrom.Visible = true;
                lbl_dateTo.Visible = true;
                lbl_dateFormat.Visible = true;
            }
            else 
            {
                txt_DateFrom.Visible = false;
                txt_DateTo.Visible = false;
                lbl_dateFrom.Visible = false;
                lbl_dateTo.Visible = false;
                lbl_dateFormat.Visible = false;
            }

        }

              
    }
}
