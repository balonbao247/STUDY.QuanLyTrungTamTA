namespace GUI
{
    partial class frmStudentEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtStudentID
            this.txtStudentID.Location = new System.Drawing.Point(20, 20);
            this.txtStudentID.ReadOnly = true;
            this.txtStudentID.Size = new System.Drawing.Size(250, 22);

            // txtFullName
            this.txtFullName.Location = new System.Drawing.Point(20, 60);
            this.txtFullName.Size = new System.Drawing.Size(250, 22);

            // txtClassName
            this.txtClassName.Location = new System.Drawing.Point(20, 100);
            this.txtClassName.Size = new System.Drawing.Size(250, 22);

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(20, 140);
            this.txtPhone.Size = new System.Drawing.Size(250, 22);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 180);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // frmStudentEdit
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSave);
            this.Text = "Sửa thông tin học viên";
            this.ResumeLayout(false);
        }
    }
}
