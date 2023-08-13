namespace SIS.UI
{
    partial class MainPage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehileRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entryExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overNightStayRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overNightStayApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overNightApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.securityToolStripMenuItem,
            this.registrationToolStripMenuItem,
            this.processToolStripMenuItem,
            this.overNightApprovalToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.securityToolStripMenuItem.Text = "Security";
            this.securityToolStripMenuItem.Visible = false;
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.createUserToolStripMenuItem.Text = "Create User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserToolStripMenuItem_Click);
            // 
            // registrationToolStripMenuItem
            // 
            this.registrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeRegistrationToolStripMenuItem,
            this.guestRegistrationToolStripMenuItem,
            this.studentRegistrationToolStripMenuItem,
            this.vehileRegistrationToolStripMenuItem});
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.registrationToolStripMenuItem.Text = "Registration";
            // 
            // employeeRegistrationToolStripMenuItem
            // 
            this.employeeRegistrationToolStripMenuItem.Name = "employeeRegistrationToolStripMenuItem";
            this.employeeRegistrationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.employeeRegistrationToolStripMenuItem.Text = "Resident Registration";
            this.employeeRegistrationToolStripMenuItem.Click += new System.EventHandler(this.employeeRegistrationToolStripMenuItem_Click);
            // 
            // guestRegistrationToolStripMenuItem
            // 
            this.guestRegistrationToolStripMenuItem.Name = "guestRegistrationToolStripMenuItem";
            this.guestRegistrationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.guestRegistrationToolStripMenuItem.Text = "Guest Registration";
            this.guestRegistrationToolStripMenuItem.Click += new System.EventHandler(this.guestRegistrationToolStripMenuItem_Click);
            // 
            // studentRegistrationToolStripMenuItem
            // 
            this.studentRegistrationToolStripMenuItem.Name = "studentRegistrationToolStripMenuItem";
            this.studentRegistrationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.studentRegistrationToolStripMenuItem.Text = "Student Registration Form";
            this.studentRegistrationToolStripMenuItem.Visible = false;
            this.studentRegistrationToolStripMenuItem.Click += new System.EventHandler(this.studentRegistrationToolStripMenuItem_Click);
            // 
            // vehileRegistrationToolStripMenuItem
            // 
            this.vehileRegistrationToolStripMenuItem.Name = "vehileRegistrationToolStripMenuItem";
            this.vehileRegistrationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.vehileRegistrationToolStripMenuItem.Text = "Vehicle Registration";
            this.vehileRegistrationToolStripMenuItem.Click += new System.EventHandler(this.vehileRegistrationToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entryExitToolStripMenuItem,
            this.overNightStayRequestToolStripMenuItem,
            this.overNightStayApprovalToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // entryExitToolStripMenuItem
            // 
            this.entryExitToolStripMenuItem.Name = "entryExitToolStripMenuItem";
            this.entryExitToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.entryExitToolStripMenuItem.Text = "Entry/Exit Data";
            this.entryExitToolStripMenuItem.Click += new System.EventHandler(this.entryExitToolStripMenuItem_Click);
            // 
            // overNightStayRequestToolStripMenuItem
            // 
            this.overNightStayRequestToolStripMenuItem.Name = "overNightStayRequestToolStripMenuItem";
            this.overNightStayRequestToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.overNightStayRequestToolStripMenuItem.Text = "Over Night Stay Request";
            this.overNightStayRequestToolStripMenuItem.Click += new System.EventHandler(this.overNightStayRequestToolStripMenuItem_Click);
            // 
            // overNightStayApprovalToolStripMenuItem
            // 
            this.overNightStayApprovalToolStripMenuItem.Name = "overNightStayApprovalToolStripMenuItem";
            this.overNightStayApprovalToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.overNightStayApprovalToolStripMenuItem.Text = "Over Night Stay Approval";
            this.overNightStayApprovalToolStripMenuItem.Visible = false;
            this.overNightStayApprovalToolStripMenuItem.Click += new System.EventHandler(this.overNightStayApprovalToolStripMenuItem_Click);
            // 
            // overNightApprovalToolStripMenuItem
            // 
            this.overNightApprovalToolStripMenuItem.Name = "overNightApprovalToolStripMenuItem";
            this.overNightApprovalToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.overNightApprovalToolStripMenuItem.Text = "Over Night Approval";
            this.overNightApprovalToolStripMenuItem.Visible = false;
            this.overNightApprovalToolStripMenuItem.Click += new System.EventHandler(this.overNightApprovalToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // employeesReportToolStripMenuItem
            // 
            this.employeesReportToolStripMenuItem.Name = "employeesReportToolStripMenuItem";
            this.employeesReportToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.employeesReportToolStripMenuItem.Text = "Main Report";
            this.employeesReportToolStripMenuItem.Click += new System.EventHandler(this.employeesReportToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSISToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutSISToolStripMenuItem
            // 
            this.aboutSISToolStripMenuItem.Name = "aboutSISToolStripMenuItem";
            this.aboutSISToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutSISToolStripMenuItem.Text = "About Us";
            this.aboutSISToolStripMenuItem.Click += new System.EventHandler(this.aboutSISToolStripMenuItem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 522);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "Welcome to Step In Security System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guestRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entryExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overNightStayRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overNightStayApprovalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overNightApprovalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehileRegistrationToolStripMenuItem;
    }
}