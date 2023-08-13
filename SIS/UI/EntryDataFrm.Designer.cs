namespace SIS.UI
{
    partial class EntryDataFrm
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
            this.Search_grp = new System.Windows.Forms.GroupBox();
            this.cbVisitorType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbl_ID_Card = new System.Windows.Forms.Label();
            this.txtIDCardSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_persons = new System.Windows.Forms.Button();
            this.cb_whichEmpVisit = new System.Windows.Forms.ComboBox();
            this.lbl_whichEmpVisit = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnVehicle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lbl_IdCard = new System.Windows.Forms.Label();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_TimeOut = new System.Windows.Forms.Button();
            this.lbl_date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_issuePass = new System.Windows.Forms.Button();
            this.btn_returnPass = new System.Windows.Forms.Button();
            this.Search_grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_grp
            // 
            this.Search_grp.Controls.Add(this.cbVisitorType);
            this.Search_grp.Controls.Add(this.label6);
            this.Search_grp.Controls.Add(this.btnSearch);
            this.Search_grp.Controls.Add(this.lbl_ID_Card);
            this.Search_grp.Controls.Add(this.txtIDCardSearch);
            this.Search_grp.Location = new System.Drawing.Point(12, 12);
            this.Search_grp.Name = "Search_grp";
            this.Search_grp.Size = new System.Drawing.Size(379, 80);
            this.Search_grp.TabIndex = 0;
            this.Search_grp.TabStop = false;
            this.Search_grp.Text = "Search";
            // 
            // cbVisitorType
            // 
            this.cbVisitorType.FormattingEnabled = true;
            this.cbVisitorType.Items.AddRange(new object[] {
            "Select Visitor Type",
            "Employee",
            "Guest",
            "Student"});
            this.cbVisitorType.Location = new System.Drawing.Point(77, 20);
            this.cbVisitorType.Name = "cbVisitorType";
            this.cbVisitorType.Size = new System.Drawing.Size(218, 21);
            this.cbVisitorType.TabIndex = 1;
            this.cbVisitorType.SelectedIndexChanged += new System.EventHandler(this.cbVisitorType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Visitor Type";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(298, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbl_ID_Card
            // 
            this.lbl_ID_Card.AutoSize = true;
            this.lbl_ID_Card.Location = new System.Drawing.Point(10, 52);
            this.lbl_ID_Card.Name = "lbl_ID_Card";
            this.lbl_ID_Card.Size = new System.Drawing.Size(43, 13);
            this.lbl_ID_Card.TabIndex = 1;
            this.lbl_ID_Card.Text = "ID Card";
            // 
            // txtIDCardSearch
            // 
            this.txtIDCardSearch.Location = new System.Drawing.Point(77, 48);
            this.txtIDCardSearch.Name = "txtIDCardSearch";
            this.txtIDCardSearch.Size = new System.Drawing.Size(218, 20);
            this.txtIDCardSearch.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_status);
            this.groupBox1.Controls.Add(this.btn_persons);
            this.groupBox1.Controls.Add(this.cb_whichEmpVisit);
            this.groupBox1.Controls.Add(this.lbl_whichEmpVisit);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.btnVehicle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCNIC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.lbl_IdCard);
            this.groupBox1.Controls.Add(this.txtIDCard);
            this.groupBox1.Location = new System.Drawing.Point(12, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(304, 50);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(43, 13);
            this.lbl_status.TabIndex = 11;
            this.lbl_status.Text = "Status";
            this.lbl_status.Visible = false;
            // 
            // btn_persons
            // 
            this.btn_persons.Location = new System.Drawing.Point(10, 149);
            this.btn_persons.Name = "btn_persons";
            this.btn_persons.Size = new System.Drawing.Size(171, 23);
            this.btn_persons.TabIndex = 10;
            this.btn_persons.Text = "Enter Persons Company Visitor";
            this.btn_persons.UseVisualStyleBackColor = true;
            this.btn_persons.Visible = false;
            this.btn_persons.Click += new System.EventHandler(this.btn_persons_Click);
            // 
            // cb_whichEmpVisit
            // 
            this.cb_whichEmpVisit.FormattingEnabled = true;
            this.cb_whichEmpVisit.Location = new System.Drawing.Point(131, 122);
            this.cb_whichEmpVisit.Name = "cb_whichEmpVisit";
            this.cb_whichEmpVisit.Size = new System.Drawing.Size(164, 21);
            this.cb_whichEmpVisit.TabIndex = 8;
            this.cb_whichEmpVisit.Visible = false;
            // 
            // lbl_whichEmpVisit
            // 
            this.lbl_whichEmpVisit.AutoSize = true;
            this.lbl_whichEmpVisit.Location = new System.Drawing.Point(8, 128);
            this.lbl_whichEmpVisit.Name = "lbl_whichEmpVisit";
            this.lbl_whichEmpVisit.Size = new System.Drawing.Size(124, 13);
            this.lbl_whichEmpVisit.TabIndex = 9;
            this.lbl_whichEmpVisit.Text = "Which Employee to Visit:";
            this.lbl_whichEmpVisit.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(77, 18);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(218, 20);
            this.txtID.TabIndex = 4;
            this.txtID.Visible = false;
            // 
            // btnVehicle
            // 
            this.btnVehicle.Location = new System.Drawing.Point(187, 149);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(108, 23);
            this.btnVehicle.TabIndex = 9;
            this.btnVehicle.Text = "Show Vehicle Info";
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
            this.txtCNIC.Location = new System.Drawing.Point(77, 97);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(218, 20);
            this.txtCNIC.TabIndex = 7;
            this.txtCNIC.Leave += new System.EventHandler(this.txtCNIC_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(77, 71);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(218, 20);
            this.txtLastName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(77, 45);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(218, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // lbl_IdCard
            // 
            this.lbl_IdCard.AutoSize = true;
            this.lbl_IdCard.Location = new System.Drawing.Point(7, 25);
            this.lbl_IdCard.Name = "lbl_IdCard";
            this.lbl_IdCard.Size = new System.Drawing.Size(43, 13);
            this.lbl_IdCard.TabIndex = 1;
            this.lbl_IdCard.Text = "ID Card";
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(77, 19);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(215, 20);
            this.txtIDCard.TabIndex = 0;
            this.txtIDCard.Leave += new System.EventHandler(this.txtIDCard_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(303, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Time In";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(316, 393);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(229, 393);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_TimeOut);
            this.groupBox2.Controls.Add(this.lbl_date);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTimeOut);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtTimeIn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 85);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timings";
            // 
            // btn_TimeOut
            // 
            this.btn_TimeOut.Location = new System.Drawing.Point(303, 46);
            this.btn_TimeOut.Name = "btn_TimeOut";
            this.btn_TimeOut.Size = new System.Drawing.Size(68, 23);
            this.btn_TimeOut.TabIndex = 13;
            this.btn_TimeOut.Text = "Time Out";
            this.btn_TimeOut.UseVisualStyleBackColor = true;
            this.btn_TimeOut.Click += new System.EventHandler(this.btn_TimeOut_Click);
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(77, 28);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(35, 13);
            this.lbl_date.TabIndex = 7;
            this.lbl_date.Text = "label9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Date";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(217, 49);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(78, 20);
            this.txtTimeOut.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Time Out";
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Location = new System.Drawing.Point(77, 49);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(75, 20);
            this.txtTimeIn.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Time In";
            // 
            // btn_issuePass
            // 
            this.btn_issuePass.Location = new System.Drawing.Point(116, 393);
            this.btn_issuePass.Name = "btn_issuePass";
            this.btn_issuePass.Size = new System.Drawing.Size(107, 23);
            this.btn_issuePass.TabIndex = 14;
            this.btn_issuePass.Text = "Issue Visitor\'s Pass";
            this.btn_issuePass.UseVisualStyleBackColor = true;
            this.btn_issuePass.Visible = false;
            this.btn_issuePass.Click += new System.EventHandler(this.btn_issuePass_Click);
            // 
            // btn_returnPass
            // 
            this.btn_returnPass.Location = new System.Drawing.Point(116, 393);
            this.btn_returnPass.Name = "btn_returnPass";
            this.btn_returnPass.Size = new System.Drawing.Size(107, 23);
            this.btn_returnPass.TabIndex = 17;
            this.btn_returnPass.Text = "Return Visitor Pass";
            this.btn_returnPass.UseVisualStyleBackColor = true;
            this.btn_returnPass.Visible = false;
            this.btn_returnPass.Click += new System.EventHandler(this.btn_returnPass_Click);
            // 
            // EntryDataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Search_grp);
            this.Controls.Add(this.btn_returnPass);
            this.Controls.Add(this.btn_issuePass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EntryDataFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Entry Data";
            this.Load += new System.EventHandler(this.EmployeeDataFrm_Load);
            this.Search_grp.ResumeLayout(false);
            this.Search_grp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Search_grp;
        private System.Windows.Forms.TextBox txtIDCardSearch;
        private System.Windows.Forms.Label lbl_ID_Card;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVehicle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lbl_IdCard;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbVisitorType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_TimeOut;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btn_issuePass;
        private System.Windows.Forms.Label lbl_whichEmpVisit;
        private System.Windows.Forms.ComboBox cb_whichEmpVisit;
        private System.Windows.Forms.Button btn_persons;
        private System.Windows.Forms.Button btn_returnPass;
        private System.Windows.Forms.Label lbl_status;
    }
}