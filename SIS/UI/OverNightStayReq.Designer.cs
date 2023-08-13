namespace SIS.UI
{
    partial class OverNightStayReq
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_firstName = new System.Windows.Forms.Label();
            this.lbl_lastName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_visitorID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_noOfVisits = new System.Windows.Forms.Label();
            this.lbl_cnic = new System.Windows.Forms.Label();
            this.cb_visitorType = new System.Windows.Forms.ComboBox();
            this.cb_visitorName = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_duration = new System.Windows.Forms.Label();
            this.txt_duration = new System.Windows.Forms.TextBox();
            this.testSISDataSet = new SIS.TestSISDataSet();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableAdapter = new SIS.TestSISDataSetTableAdapters.StudentTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testSISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visitor Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Visitor Name:";
            // 
            // lbl_firstName
            // 
            this.lbl_firstName.AutoSize = true;
            this.lbl_firstName.Location = new System.Drawing.Point(9, 54);
            this.lbl_firstName.Name = "lbl_firstName";
            this.lbl_firstName.Size = new System.Drawing.Size(60, 13);
            this.lbl_firstName.TabIndex = 2;
            this.lbl_firstName.Text = "First Name:";
            // 
            // lbl_lastName
            // 
            this.lbl_lastName.AutoSize = true;
            this.lbl_lastName.Location = new System.Drawing.Point(9, 83);
            this.lbl_lastName.Name = "lbl_lastName";
            this.lbl_lastName.Size = new System.Drawing.Size(61, 13);
            this.lbl_lastName.TabIndex = 3;
            this.lbl_lastName.Text = "Last Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_visitorID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbl_noOfVisits);
            this.groupBox1.Controls.Add(this.lbl_cnic);
            this.groupBox1.Controls.Add(this.lbl_firstName);
            this.groupBox1.Controls.Add(this.lbl_lastName);
            this.groupBox1.Location = new System.Drawing.Point(12, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visitor Details";
            // 
            // lbl_visitorID
            // 
            this.lbl_visitorID.AutoSize = true;
            this.lbl_visitorID.Location = new System.Drawing.Point(9, 26);
            this.lbl_visitorID.Name = "lbl_visitorID";
            this.lbl_visitorID.Size = new System.Drawing.Size(49, 13);
            this.lbl_visitorID.TabIndex = 13;
            this.lbl_visitorID.Text = "Visitor ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(396, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(396, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "label11";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            // 
            // lbl_noOfVisits
            // 
            this.lbl_noOfVisits.AutoSize = true;
            this.lbl_noOfVisits.Location = new System.Drawing.Point(251, 26);
            this.lbl_noOfVisits.Name = "lbl_noOfVisits";
            this.lbl_noOfVisits.Size = new System.Drawing.Size(66, 13);
            this.lbl_noOfVisits.TabIndex = 5;
            this.lbl_noOfVisits.Text = "No. of Visits:";
            // 
            // lbl_cnic
            // 
            this.lbl_cnic.AutoSize = true;
            this.lbl_cnic.Location = new System.Drawing.Point(251, 54);
            this.lbl_cnic.Name = "lbl_cnic";
            this.lbl_cnic.Size = new System.Drawing.Size(35, 13);
            this.lbl_cnic.TabIndex = 4;
            this.lbl_cnic.Text = "CNIC:";
            // 
            // cb_visitorType
            // 
            this.cb_visitorType.FormattingEnabled = true;
            this.cb_visitorType.Items.AddRange(new object[] {
            "Employee",
            "Guest",
            "Student"});
            this.cb_visitorType.Location = new System.Drawing.Point(97, 36);
            this.cb_visitorType.Name = "cb_visitorType";
            this.cb_visitorType.Size = new System.Drawing.Size(198, 21);
            this.cb_visitorType.TabIndex = 5;
            this.cb_visitorType.SelectedIndexChanged += new System.EventHandler(this.cb_visitorType_SelectedIndexChanged);
            // 
            // cb_visitorName
            // 
            this.cb_visitorName.FormattingEnabled = true;
            this.cb_visitorName.Location = new System.Drawing.Point(97, 69);
            this.cb_visitorName.Name = "cb_visitorName";
            this.cb_visitorName.Size = new System.Drawing.Size(198, 21);
            this.cb_visitorName.TabIndex = 6;
            this.cb_visitorName.SelectedIndexChanged += new System.EventHandler(this.cb_visitorName_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(449, 102);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(103, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Generate Request";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_duration
            // 
            this.lbl_duration.AutoSize = true;
            this.lbl_duration.Location = new System.Drawing.Point(21, 107);
            this.lbl_duration.Name = "lbl_duration";
            this.lbl_duration.Size = new System.Drawing.Size(159, 13);
            this.lbl_duration.TabIndex = 8;
            this.lbl_duration.Text = "Over Night Duration Requested:";
            // 
            // txt_duration
            // 
            this.txt_duration.Location = new System.Drawing.Point(205, 100);
            this.txt_duration.Name = "txt_duration";
            this.txt_duration.Size = new System.Drawing.Size(90, 20);
            this.txt_duration.TabIndex = 9;
            // 
            // testSISDataSet
            // 
            this.testSISDataSet.DataSetName = "TestSISDataSet";
            this.testSISDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.testSISDataSet;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // OverNightStayReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 261);
            this.Controls.Add(this.txt_duration);
            this.Controls.Add(this.lbl_duration);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cb_visitorName);
            this.Controls.Add(this.cb_visitorType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OverNightStayReq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Over Night Stay Request";
            this.Load += new System.EventHandler(this.OverNightStayReq_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testSISDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_firstName;
        private System.Windows.Forms.Label lbl_lastName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_noOfVisits;
        private System.Windows.Forms.Label lbl_cnic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_visitorType;
        private System.Windows.Forms.ComboBox cb_visitorName;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_duration;
        private System.Windows.Forms.TextBox txt_duration;
        private TestSISDataSet testSISDataSet;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private TestSISDataSetTableAdapters.StudentTableAdapter studentTableAdapter;
        private System.Windows.Forms.Label lbl_visitorID;
        private System.Windows.Forms.Label label3;
    }
}