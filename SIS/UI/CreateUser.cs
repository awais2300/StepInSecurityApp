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
    public partial class CreateUser : Form
    {
        private Security user = new Security();

        public CreateUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "" || txt_con_password.Text == "")
            {
                MessageBox.Show("Values cannot be NULL!!! ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            SecurityManager secMngr = new SecurityManager();
            user.user_code = txt_username.Text.ToString();

            string user_type;

            if (checkBox1.Checked)
            {
                user.user_type = "Admin";
            }
            else if (checkBox2.Checked)
            {
                user.user_type = "Security Officer";
            }
            else
            {
                user.user_type = Convert.ToString(' ');
            }

            if (secMngr.ValidUser(user))
            {

                if (txt_password.Text.ToString() == txt_con_password.Text.ToString())
                {
                    user.password = txt_password.Text.ToString();
                    secMngr.CreateNewUser(user);
                    MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_username.Text = "";
                    txt_password.Text = "";
                    txt_con_password.Text = "";
                    checkBox1.ResetText();
                    checkBox2.ResetText();
                }
                else
                {
                    string message = "Sorry! Password does not match";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
            else
            {
                MessageBox.Show("Cannot Save!! User " + user.user_type + " Already Exists, Please contact System developer. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                //MessageBox.Show("Cannot check, because Security Officer is checked!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox1.Checked = false;
                return;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //MessageBox.Show("Cannot check, because Administrator is checked!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox2.Checked = false;
                return;
            }

        }
    }
}
