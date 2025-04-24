namespace GUI
{
    partial class frmRoom
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRooms;

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
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.btnADD = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboTimeSlot = new Guna.UI2.WinForms.Guna2ComboBox();
            this.iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            this.dtpNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.AutoScroll = true;
            this.flowLayoutPanelRooms.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(0, 58);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(1129, 461);
            this.flowLayoutPanelRooms.TabIndex = 0;
            // 
            // btnADD
            // 
            this.btnADD.AutoRoundedCorners = true;
            this.btnADD.BackColor = System.Drawing.Color.Transparent;
            this.btnADD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnADD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnADD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnADD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnADD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.btnADD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADD.ForeColor = System.Drawing.Color.White;
            this.btnADD.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnADD.Location = new System.Drawing.Point(297, 12);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(109, 40);
            this.btnADD.TabIndex = 6;
            this.btnADD.Text = "Thêm";
            // 
            // txtSearch
            // 
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeft = global::GUI.Properties.Resources._370082_find_search_zoom_magnifier_view_icon;
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm phòng";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(279, 40);
            this.txtSearch.TabIndex = 5;
            // 
            // cboTimeSlot
            // 
            this.cboTimeSlot.BackColor = System.Drawing.Color.Transparent;
            this.cboTimeSlot.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cboTimeSlot.BorderRadius = 10;
            this.cboTimeSlot.BorderThickness = 2;
            this.cboTimeSlot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTimeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeSlot.FocusedColor = System.Drawing.Color.RoyalBlue;
            this.cboTimeSlot.FocusedState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cboTimeSlot.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTimeSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTimeSlot.ItemHeight = 30;
            this.cboTimeSlot.ItemsAppearance.SelectedBackColor = System.Drawing.Color.SkyBlue;
            this.cboTimeSlot.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cboTimeSlot.Location = new System.Drawing.Point(557, 16);
            this.cboTimeSlot.Name = "cboTimeSlot";
            this.cboTimeSlot.Size = new System.Drawing.Size(140, 36);
            this.cboTimeSlot.TabIndex = 7;
            // 
            // iconDropDownButton1
            // 
            this.iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            this.iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownButton1.Name = "iconDropDownButton1";
            this.iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Checked = true;
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgay.Location = new System.Drawing.Point(713, 16);
            this.dtpNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 36);
            this.dtpNgay.TabIndex = 8;
            this.dtpNgay.Value = new System.DateTime(2025, 4, 24, 20, 36, 23, 96);
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
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.guna2Button1.Location = new System.Drawing.Point(954, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(109, 40);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "Tìm";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmRoom
            // 
            this.ClientSize = new System.Drawing.Size(1129, 519);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.cboTimeSlot);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flowLayoutPanelRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRoom";
            this.Text = "Quản lý phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRoom_Load);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnADD;
        private Guna.UI2.WinForms.Guna2ComboBox cboTimeSlot;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgay;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
