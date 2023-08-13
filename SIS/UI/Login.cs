using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using SIS.Model;
using SIS.Manager;
using SIS.Data;

namespace SIS.UI
{
    public partial class Login : Form
    {
        private DataAccess da = new DataAccess();
        public bool loginSuccessfully;
        public string loginUser;

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string Command = "select password, user_type from security_info where user_code = @user_code";
            string DB_password, User_type;
     
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@user_code", txtUsername.Text.ToString()),
                };

                DataTable dt = da.ExecuteParamerizedSelectCommand(Command, CommandType.Text, parameters);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DB_password = row["password"].ToString();
                        User_type = row["user_type"].ToString();

                        if (DB_password == txtPassword.Text.ToString())
                        {
                           
                            loginSuccessfully = true;
                            //loginUser = txtUsername.Text.ToString();
                            loginUser = User_type;
                            this.Close();
                        }
                        else
                        {
                            string message = "Sorry! Password is incorrect";
                            string caption = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;
                            result = MessageBox.Show(message, caption, buttons);
                            loginSuccessfully = false;
                        }

                    }

                }
                else
                {
                        string message = "Sorry! Username is incorrect";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                        loginSuccessfully = false;
                }

                     
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btn_Login_Click(sender, e);
            }
        }

       
        

    }
}
