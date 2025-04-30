namespace GUI.TeacherACC
{
    partial class frmAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cboCourse = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboDate = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvAttendance = new Guna.UI2.WinForms.Guna2DataGridView();
            this.AttendanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.cboCourse);
            this.guna2Panel1.Controls.Add(this.cboDate);
            this.guna2Panel1.Controls.Add(this.btnSave);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1113, 62);
            this.guna2Panel1.TabIndex = 15;
            // 
            // cboCourse
            // 
            this.cboCourse.BackColor = System.Drawing.Color.Transparent;
            this.cboCourse.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cboCourse.BorderRadius = 10;
            this.cboCourse.BorderThickness = 2;
            this.cboCourse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FocusedColor = System.Drawing.Color.RoyalBlue;
            this.cboCourse.FocusedState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCourse.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cboCourse.ItemHeight = 30;
            this.cboCourse.Items.AddRange(new object[] {
            "Ca1 - Sáng"});
            this.cboCourse.ItemsAppearance.SelectedBackColor = System.Drawing.Color.SkyBlue;
            this.cboCourse.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cboCourse.Location = new System.Drawing.Point(29, 12);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(180, 36);
            this.cboCourse.TabIndex = 15;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // cboDate
            // 
            this.cboDate.BackColor = System.Drawing.Color.Transparent;
            this.cboDate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cboDate.BorderRadius = 10;
            this.cboDate.BorderThickness = 2;
            this.cboDate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.FocusedColor = System.Drawing.Color.RoyalBlue;
            this.cboDate.FocusedState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cboDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cboDate.IntegralHeight = false;
            this.cboDate.ItemHeight = 30;
            this.cboDate.ItemsAppearance.SelectedBackColor = System.Drawing.Color.SkyBlue;
            this.cboDate.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cboDate.Location = new System.Drawing.Point(230, 12);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(180, 36);
            this.cboDate.TabIndex = 15;
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.guna2Button1.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(442, 8);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(109, 40);
            this.guna2Button1.TabIndex = 13;
            this.guna2Button1.Text = "Tìm";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.dgvAttendance);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 62);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1113, 418);
            this.guna2Panel2.TabIndex = 16;
            this.guna2Panel2.UseTransparentBackground = true;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AllowUserToResizeColumns = false;
            this.dgvAttendance.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAttendance.ColumnHeadersHeight = 60;
            this.dgvAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttendanceID,
            this.StudentID,
            this.StudentName,
            this.Gender,
            this.Status,
            this.Check});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendance.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAttendance.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAttendance.Location = new System.Drawing.Point(12, 0);
            this.dgvAttendance.Margin = new System.Windows.Forms.Padding(20);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAttendance.RowTemplate.DividerHeight = 5;
            this.dgvAttendance.RowTemplate.Height = 45;
            this.dgvAttendance.Size = new System.Drawing.Size(1089, 414);
            this.dgvAttendance.TabIndex = 7;
            this.dgvAttendance.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAttendance.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAttendance.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAttendance.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAttendance.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAttendance.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvAttendance.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAttendance.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvAttendance.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAttendance.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAttendance.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAttendance.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAttendance.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvAttendance.ThemeStyle.ReadOnly = false;
            this.dgvAttendance.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAttendance.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAttendance.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAttendance.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvAttendance.ThemeStyle.RowsStyle.Height = 45;
            this.dgvAttendance.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAttendance.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // AttendanceID
            // 
            this.AttendanceID.HeaderText = "Attendance ID";
            this.AttendanceID.Name = "AttendanceID";
            // 
            // StudentID
            // 
            this.StudentID.FillWeight = 74.23858F;
            this.StudentID.HeaderText = "ID";
            this.StudentID.Name = "StudentID";
            // 
            // StudentName
            // 
            this.StudentName.FillWeight = 74.23858F;
            this.StudentName.HeaderText = "Name";
            this.StudentName.Name = "StudentName";
            // 
            // Gender
            // 
            this.Gender.FillWeight = 74.23858F;
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            // 
            // Status
            // 
            this.Status.FillWeight = 74.23858F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Check
            // 
            this.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Check.FillWeight = 203.0457F;
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Check.Width = 80;
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnSave.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(992, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 480);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAttendance";
            this.Text = "Quản lý điểm danh học viên";
            this.Load += new System.EventHandler(this.frmAttendance_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboDate;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2ComboBox cboCourse;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAttendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}