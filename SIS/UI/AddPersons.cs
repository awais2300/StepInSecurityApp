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
    public partial class AddPersons : Form
    {
        public string personslist;

        public AddPersons()
        {
            InitializeComponent();
        }

        public void btn_enter_Click(object sender, EventArgs e)
        {
            personslist = textBox1.Text;
            this.Close();
        }
 
    }
}
