namespace SIS.UI
{
    partial class EmployeeDataFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Search_grp = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDCardSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVehicle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgFamilyMember = new System.Windows.Forms.DataGridView();
            this.Card_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unique = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_iD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehicle_Reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehicle_Detail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_AddFamily = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_deleteEmp = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Search_grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilyMember)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_grp
            // 
            this.Search_grp.Controls.Add(this.btnSearch);
            this.Search_grp.Controls.Add(this.label1);
            this.Search_grp.Controls.Add(this.txtIDCardSearch);
            this.Search_grp.Location = new System.Drawing.Point(12, 12);
            this.Search_grp.Name = "Search_grp";
            this.Search_grp.Size = new System.Drawing.Size(379, 49);
            this.Search_grp.TabIndex = 0;
            this.Search_grp.TabStop = false;
            this.Search_grp.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(298, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "House No.";
            // 
            // txtIDCardSearch
            // 
            this.txtIDCardSearch.Location = new System.Drawing.Point(84, 19);
            this.txtIDCardSearch.Name = "txtIDCardSearch";
            this.txtIDCardSearch.Size = new System.Drawing.Size(209, 20);
            this.txtIDCardSearch.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnVehicle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCNIC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDCard);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 227);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Email Id";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(84, 169);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(209, 20);
            this.textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "PTCL No.";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mobile No.";
            // 
            // btnVehicle
            // 
            this.btnVehicle.Location = new System.Drawing.Point(84, 198);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(136, 23);
            this.btnVehicle.TabIndex = 8;
            this.btnVehicle.Text = "Vehicle Registration";
            this.btnVehicle.UseVisualStyleBackColor = true;
            this.btnVehicle.Click += new System.EventHandler(this.btnVehicle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "CNIC";
            // 
            // txtCNIC
            // 
            this.txtCNIC.Location = new System.Drawing.Point(84, 93);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(209, 20);
            this.txtCNIC.TabIndex = 6;
            this.txtCNIC.TextChanged += new System.EventHandler(this.txtCNIC_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(84, 68);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(209, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(84, 43);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(209, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "House No.";
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(84, 18);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(209, 20);
            this.txtIDCard.TabIndex = 0;
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(608, 482);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(684, 482);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgFamilyMember
            // 
            this.dgFamilyMember.AllowUserToAddRows = false;
            this.dgFamilyMember.AllowUserToDeleteRows = false;
            this.dgFamilyMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFamilyMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Card_ID,
            this.unique,
            this.Emp_iD,
            this.First_Name,
            this.Last_Name,
            this.CNIC,
            this.Vehicle_Reg,
            this.Vehicle_Detail,
            this.Delete});
            this.dgFamilyMember.Location = new System.Drawing.Point(7, 19);
            this.dgFamilyMember.Name = "dgFamilyMember";
            this.dgFamilyMember.Size = new System.Drawing.Size(732, 151);
            this.dgFamilyMember.TabIndex = 5;
            this.dgFamilyMember.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFamilyMember_CellContentClick);
            this.dgFamilyMember.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFamilyMember_CellEndEdit);
            this.dgFamilyMember.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.txtIDCard_Leave);
            // 
            // Card_ID
            // 
            this.Card_ID.DataPropertyName = "Id_card";
            this.Card_ID.HeaderText = "Card ID";
            this.Card_ID.Name = "Card_ID";
            // 
            // unique
            // 
            this.unique.DataPropertyName = "Uniqueid";
            this.unique.HeaderText = "unique";
            this.unique.Name = "unique";
            this.unique.Visible = false;
            // 
            // Emp_iD
            // 
            this.Emp_iD.DataPropertyName = "Emp_id";
            this.Emp_iD.HeaderText = "Emp_id";
            this.Emp_iD.Name = "Emp_iD";
            this.Emp_iD.Visible = false;
            // 
            // First_Name
            // 
            this.First_Name.DataPropertyName = "First_Name";
            this.First_Name.HeaderText = "FirstName";
            this.First_Name.Name = "First_Name";
            // 
            // Last_Name
            // 
            this.Last_Name.DataPropertyName = "Last_Name";
            this.Last_Name.HeaderText = "Last Name";
            this.Last_Name.Name = "Last_Name";
            // 
            // CNIC
            // 
            this.CNIC.DataPropertyName = "CNIC";
            this.CNIC.HeaderText = "CNIC";
            this.CNIC.Name = "CNIC";
            // 
            // Vehicle_Reg
            // 
            this.Vehicle_Reg.HeaderText = "Vehicle Reg";
            this.Vehicle_Reg.Name = "Vehicle_Reg";
            this.Vehicle_Reg.Visible = false;
            // 
            // Vehicle_Detail
            // 
            this.Vehicle_Detail.HeaderText = "Vehicle_Detail";
            this.Vehicle_Detail.Name = "Vehicle_Detail";
            this.Vehicle_Detail.Text = "Vehcle Detail";
            this.Vehicle_Detail.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // btn_AddFamily
            // 
            this.btn_AddFamily.Location = new System.Drawing.Point(456, 482);
            this.btn_AddFamily.Name = "btn_AddFamily";
            this.btn_AddFamily.Size = new System.Drawing.Size(75, 23);
            this.btn_AddFamily.TabIndex = 6;
            this.btn_AddFamily.Text = "Add Family";
            this.btn_AddFamily.UseVisualStyleBackColor = true;
            this.btn_AddFamily.Click += new System.EventHandler(this.btn_AddFamily_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(532, 482);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgFamilyMember);
            this.groupBox2.Location = new System.Drawing.Point(12, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 176);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Family Members/Dependants";
            // 
            // btn_deleteEmp
            // 
            this.btn_deleteEmp.Location = new System.Drawing.Point(319, 482);
            this.btn_deleteEmp.Name = "btn_deleteEmp";
            this.btn_deleteEmp.Size = new System.Drawing.Size(136, 23);
            this.btn_deleteEmp.TabIndex = 9;
            this.btn_deleteEmp.Text = "Mark Inactive";
            this.btn_deleteEmp.UseVisualStyleBackColor = true;
            this.btn_deleteEmp.Click += new System.EventHandler(this.btn_deleteEmp_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // EmployeeDataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 509);
            this.Controls.Add(this.btn_deleteEmp);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btn_AddFamily);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Search_grp);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeDataFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Resident Registration";
            this.Load += new System.EventHandler(this.EmployeeDataFrm_Load);
            this.Search_grp.ResumeLayout(false);
            this.Search_grp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilyMember)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Search_grp;
        private System.Windows.Forms.TextBox txtIDCardSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVehicle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgFamilyMember;
        private System.Windows.Forms.Button btn_AddFamily;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Card_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn unique;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_iD;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehicle_Reg;
        private System.Windows.Forms.DataGridViewButtonColumn Vehicle_Detail;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button btn_deleteEmp;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
    }
}