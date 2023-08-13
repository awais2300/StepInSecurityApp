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
    public partial class GuestDataFrm : Form
    {
        int guest_id;
        bool retrieve;
        private Guest guestdata = new Guest();

        public GuestDataFrm()
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
            guestdata.RowState = Rowstate.Add;
        }

        #region buttons events

        private void btnSave_Click(object sender, EventArgs e)
        {

                GuestManager gstMgr = new GuestManager();
                //guestdata.Id_card = txtIDCard.Text;
                guestdata.First_name = txtFirstName.Text;
                guestdata.Last_name = txtLastName.Text;
                guestdata.CNIC = txtCNIC.Text;
                guestdata.P_gst_id = null;
                if (Validate(guestdata))
                {
                    if (guestdata.RowState == Rowstate.Add)   //|| guestdata.Family_mem[0].RowState )
                    {
                        gstMgr.SaveGuest(guestdata);
                    }
                else if (guestdata.RowState == Rowstate.Modified)
                {
                    guestdata.P_gst_id = guestdata.Gst_id;
                    if (guestdata.Family_mem == null)
                    {
                        foreach (Guest info in guestdata.Family_mem)
                        {
                            if (info.RowState == Rowstate.Add)
                            {
                                gstMgr.SaveGuest(info);
                            }
                            else
                            {
                                gstMgr.UpdateGuest(info);
                            }
                        }
                    }
                    else
                    {
                        gstMgr.UpdateGuest(guestdata);
                    }
                }
                else
                {
                    gstMgr.UpdateGuest(guestdata);
                }


                resetGuest();
                MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReset_Click(sender, e);
                }
         }
        
        private void btn_AddFamily_Click(object sender, EventArgs e)
        {
            Guest gst = new Guest();
            gst.RowState = Rowstate.Add;
            gst.P_gst_id = guestdata.Gst_id;
            string guid = System.Guid.NewGuid().ToString();
            gst.Uniqueid = guid;
            guestdata.Family_mem.Add(gst);
            bindGrid();
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {

            VehicleDetailFrm frm = new VehicleDetailFrm();
            frm.vehicle = guestdata.Vehicle;
            frm.ShowDialog();
            if (frm.vehicle.RowState == Rowstate.Modified || frm.vehicle.RowState == Rowstate.Add)
            {
                guestdata.Vehicle = frm.vehicle;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDCardSearch.Text == "" || txtIDCardSearch.Text.Contains("'"))
            {
                MessageBox.Show("Please enter valid CNIC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDCardSearch.Focus();
                return;
            }
            {
                GuestManager gstMgr = new GuestManager();
                guestdata = gstMgr.GetGstByCNIC(txtIDCardSearch.Text);
                if (guestdata != null && guestdata.Gst_id > 0)
                {
                    //txtIDCard.Text = guestdata.CNIC;
                    guest_id = guestdata.Gst_id;
                    txtFirstName.Text = guestdata.First_name;
                    txtLastName.Text = guestdata.Last_name;
                    retrieve = true;
                    txtCNIC.Text = guestdata.CNIC;
                    guestdata.RowState = Rowstate.Modified;
                    bindGrid();
                    txtIDCardSearch.Enabled = false;
                    
                   
                }
                else
                {
                    MessageBox.Show("No Match Found with this CNIC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDCardSearch.Focus();
                    guestdata.RowState = Rowstate.Add;
                    return;

                }
            }
        }

        #endregion 

        #region gridEvents

        private void dgGuestFamilyMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            GuestManager gstMgr = new GuestManager();
           
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string uniqueID = dgGuestFamilyMember.Rows[e.RowIndex].Cells["unique"].Value.ToString();
                Guest selGuest = guestdata.Family_mem.Find(p => p.Uniqueid == uniqueID);
                
                if (e.ColumnIndex == 6)
                {
                    selGuest.RowState = Rowstate.Deleted;
                    gstMgr.DeleteGuestFamilyMember(Convert.ToInt32(dgGuestFamilyMember.Rows[e.RowIndex].Cells["Gst_id"].Value.ToString()));
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Family Member deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }

        }

        private void dgGuestFamilyMember_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string uniqueID = dgGuestFamilyMember.Rows[e.RowIndex].Cells["unique"].Value.ToString();
            Guest selGuest = guestdata.Family_mem.Find(p => p.Uniqueid == uniqueID);
            if (selGuest != null)
            {
                selGuest.CNIC = dgGuestFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value.ToString();
                if (dgGuestFamilyMember.CurrentCell.ColumnIndex == 4)
                {
                    //Check duplicate ID card for family member
                    if (!duplicateGuestCheck(selGuest.CNIC, "CNIC"))
                    {
                        dgGuestFamilyMember.Rows[e.RowIndex].Cells["CNIC"].Value = null;
                    }
                }

                selGuest.First_name = dgGuestFamilyMember.Rows[e.RowIndex].Cells["First_Name"].Value.ToString();
                selGuest.Last_name = dgGuestFamilyMember.Rows[e.RowIndex].Cells["Last_Name"].Value.ToString();

                if (selGuest.RowState == Rowstate.None)
                {
                    selGuest.RowState = Rowstate.Modified;
                }
            }
        }

        #endregion

        #region private Methods

        private void resetGuest()
        {
            guestdata.RowState = Rowstate.None;
            guestdata.Vehicle.RowState = Rowstate.None;

            foreach (Guest info in guestdata.Family_mem)
            {
                if (info.RowState == Rowstate.Deleted)
                {
                    //guestdata.Family_mem.Remove(info);
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
            Collection coll2 = new Collection();
            DataTable dt = coll2.ToDataTableGst(guestdata.Family_mem);
            dgGuestFamilyMember.AutoGenerateColumns = false;
            dgGuestFamilyMember.DataSource = dt;
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            guestdata = new Guest();
            guestdata.RowState = Rowstate.Add;
            //txtIDCard.Text = guestdata.Id_card;
            txtFirstName.Text = guestdata.First_name;
            txtLastName.Text = guestdata.Last_name;
            txtCNIC.Text = guestdata.CNIC;
            txtIDCardSearch.Text = "";
            
            txtIDCardSearch.Enabled = true;
            txtIDCardSearch.Focus();
            bindGrid();
        }

        private bool Validate(Guest pGuest)
        {
            if (pGuest.First_name.Length == 0)
            {
                MessageBox.Show("Please enter the First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pGuest.Last_name.Length == 0)
            {
                MessageBox.Show("Please enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (pGuest.CNIC.Length == 0)
            {
                MessageBox.Show("Please enter the CNIC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dgGuestFamilyMember.RowCount > 0)
            {
                for (int i = 0; i < dgGuestFamilyMember.RowCount; i++)
                {
                    if (dgGuestFamilyMember[2, i].Value == null || dgGuestFamilyMember[3, i].Value == null || dgGuestFamilyMember[4, i].Value == null )
                    {
                        MessageBox.Show("Family Record is incomplete!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (dgGuestFamilyMember[2, i].Value.ToString() == String.Empty || dgGuestFamilyMember[3, i].Value.ToString() == String.Empty || dgGuestFamilyMember[4, i].Value.ToString() == String.Empty)
                    {
                        MessageBox.Show("Family Record is incomplete!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (dgGuestFamilyMember.Rows[i].Cells["CNIC"].Value.ToString() == pGuest.CNIC.ToString())
                    {
                        MessageBox.Show("Guest CNIC cannot be same as Family Member CNIC!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    }

                }
            }
            return true;

        }

        #endregion

        private bool duplicateGuestCheck(string searchtext, string SearchType)
        {
            GuestManager gstMgr = new GuestManager();

            if (SearchType == "CNIC")
            {
                Guest gst = gstMgr.GetGstByCNIC(searchtext);
                if (gst != null && gst.Gst_id > 0)
                {
                    //txtCNIC.Text = "";
                    txtCNIC.Focus();
                    MessageBox.Show("CNIC is already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            return true;
        }

      private void button1_Click(object sender, EventArgs e)
        {
            if (guest_id.ToString() != "0")
            {
                SecurityManager secMgr = new SecurityManager();
                if (secMgr.GetGuestStatus(guest_id.ToString()))
                {
                    GuestManager gstMgr = new GuestManager();
                    gstMgr.DeleteGuest(guest_id);
                    if (dgGuestFamilyMember.RowCount > 0)
                    {
                        for (int i = 0; i < dgGuestFamilyMember.RowCount; i++)
                        {
                            gstMgr.DeleteGuestFamilyMember(Convert.ToInt32(dgGuestFamilyMember.Rows[i].Cells["Gst_id"].Value.ToString()));
                        }
                    }
                    MessageBox.Show("Guest Marked Inactive Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No Guset selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            if (!retrieve)
            {
                duplicateGuestCheck(txtCNIC.Text, "CNIC");
            }
            else 
            {
                retrieve = false;
            }
            
        }
    }

}
