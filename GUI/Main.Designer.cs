namespace GUI
{
    partial class Main
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel_back = new Guna.UI2.WinForms.Guna2Panel();
            this.panel_container = new Guna.UI2.WinForms.Guna2Panel();
            this.panel_tieude = new Guna.UI2.WinForms.Guna2Panel();
            this.tieude2 = new System.Windows.Forms.Label();
            this.tieude = new System.Windows.Forms.Label();
            this.sidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.paneltop = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnToggle = new Guna.UI2.WinForms.Guna2Button();
            this.bTeacher = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.bDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.avatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Panel1.SuspendLayout();
            this.panel_back.SuspendLayout();
            this.panel_tieude.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.panel_back);
            this.guna2Panel1.Controls.Add(this.paneltop);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1192, 715);
            this.guna2Panel1.TabIndex = 0;
            // 
            // panel_back
            // 
            this.panel_back.BackColor = System.Drawing.Color.Silver;
            this.panel_back.Controls.Add(this.panel_container);
            this.panel_back.Controls.Add(this.panel_tieude);
            this.panel_back.Controls.Add(this.sidebar);
            this.panel_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_back.Location = new System.Drawing.Point(0, 100);
            this.panel_back.Name = "panel_back";
            this.panel_back.Size = new System.Drawing.Size(1192, 615);
            this.panel_back.TabIndex = 2;
            // 
            // panel_container
            // 
            this.panel_container.AutoScroll = true;
            this.panel_container.AutoSize = true;
            this.panel_container.BackColor = System.Drawing.Color.Transparent;
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.Location = new System.Drawing.Point(200, 57);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(992, 558);
            this.panel_container.TabIndex = 6;
            this.panel_container.UseTransparentBackground = true;
            // 
            // panel_tieude
            // 
            this.panel_tieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.panel_tieude.Controls.Add(this.tieude2);
            this.panel_tieude.Controls.Add(this.tieude);
            this.panel_tieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tieude.Location = new System.Drawing.Point(200, 0);
            this.panel_tieude.Name = "panel_tieude";
            this.panel_tieude.Size = new System.Drawing.Size(992, 57);
            this.panel_tieude.TabIndex = 5;
            // 
            // tieude2
            // 
            this.tieude2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tieude2.AutoSize = true;
            this.tieude2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieude2.Location = new System.Drawing.Point(839, 22);
            this.tieude2.Name = "tieude2";
            this.tieude2.Size = new System.Drawing.Size(131, 21);
            this.tieude2.TabIndex = 1;
            this.tieude2.Text = "Home/Dashboard";
            this.tieude2.Click += new System.EventHandler(this.label1_Click);
            // 
            // tieude
            // 
            this.tieude.AutoSize = true;
            this.tieude.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieude.Location = new System.Drawing.Point(6, 13);
            this.tieude.Name = "tieude";
            this.tieude.Size = new System.Drawing.Size(138, 32);
            this.tieude.TabIndex = 0;
            this.tieude.Text = "Dashboard";
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(95)))), ((int)(((byte)(255)))));
            this.sidebar.Controls.Add(this.btnToggle);
            this.sidebar.Controls.Add(this.bTeacher);
            this.sidebar.Controls.Add(this.guna2Button5);
            this.sidebar.Controls.Add(this.bDashboard);
            this.sidebar.Controls.Add(this.guna2Button4);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(200, 615);
            this.sidebar.MinimumSize = new System.Drawing.Size(55, 615);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(200, 615);
            this.sidebar.TabIndex = 4;
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(104)))), ((int)(((byte)(136)))));
            this.paneltop.BorderColor = System.Drawing.Color.DimGray;
            this.paneltop.Controls.Add(this.label1);
            this.paneltop.Controls.Add(this.avatar);
            this.paneltop.Controls.Add(this.guna2ControlBox2);
            this.paneltop.Controls.Add(this.guna2ControlBox3);
            this.paneltop.Controls.Add(this.guna2ControlBox1);
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.FillColor = System.Drawing.Color.Transparent;
            this.paneltop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.Size = new System.Drawing.Size(1192, 100);
            this.paneltop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "ADMIN";
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1147, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1099, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.paneltop;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(169, 48);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox3.Location = new System.Drawing.Point(1048, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 0;
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToggle.BorderThickness = 1;
            this.btnToggle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToggle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToggle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToggle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToggle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(88)))), ((int)(((byte)(226)))));
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnToggle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnToggle.Image = global::GUI.Properties.Resources._8491315_menu_list_icon;
            this.btnToggle.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnToggle.ImageSize = new System.Drawing.Size(50, 50);
            this.btnToggle.Location = new System.Drawing.Point(0, 0);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(200, 115);
            this.btnToggle.TabIndex = 3;
            this.btnToggle.Text = "MENU";
            this.btnToggle.UseTransparentBackground = true;
            this.btnToggle.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // bTeacher
            // 
            this.bTeacher.BackColor = System.Drawing.Color.Transparent;
            this.bTeacher.CheckedState.FillColor = System.Drawing.Color.SteelBlue;
            this.bTeacher.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bTeacher.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bTeacher.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bTeacher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bTeacher.FillColor = System.Drawing.Color.Transparent;
            this.bTeacher.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTeacher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bTeacher.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.bTeacher.HoverState.ForeColor = System.Drawing.Color.White;
            this.bTeacher.Image = global::GUI.Properties.Resources._6570722_doctor_education_learning_lecture_man_icon;
            this.bTeacher.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bTeacher.ImageSize = new System.Drawing.Size(35, 35);
            this.bTeacher.Location = new System.Drawing.Point(0, 231);
            this.bTeacher.Name = "bTeacher";
            this.bTeacher.Size = new System.Drawing.Size(200, 115);
            this.bTeacher.TabIndex = 3;
            this.bTeacher.Text = "Giáo viên";
            this.bTeacher.UseTransparentBackground = true;
            this.bTeacher.Click += new System.EventHandler(this.bTeacher_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Button5.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button5.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Image = global::GUI.Properties.Resources._6599587_course_e_learning_education_learning_online_icon;
            this.guna2Button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2Button5.Location = new System.Drawing.Point(0, 458);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(200, 115);
            this.guna2Button5.TabIndex = 3;
            this.guna2Button5.Text = "Khóa học";
            this.guna2Button5.UseTransparentBackground = true;
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // bDashboard
            // 
            this.bDashboard.BackColor = System.Drawing.Color.Transparent;
            this.bDashboard.CheckedState.FillColor = System.Drawing.Color.SteelBlue;
            this.bDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bDashboard.FillColor = System.Drawing.Color.Transparent;
            this.bDashboard.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.bDashboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bDashboard.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.bDashboard.HoverState.ForeColor = System.Drawing.Color.White;
            this.bDashboard.Image = global::GUI.Properties.Resources._1904661_building_dashboard_default_home_house_icon;
            this.bDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bDashboard.ImageSize = new System.Drawing.Size(35, 35);
            this.bDashboard.Location = new System.Drawing.Point(0, 116);
            this.bDashboard.Name = "bDashboard";
            this.bDashboard.Size = new System.Drawing.Size(200, 115);
            this.bDashboard.TabIndex = 3;
            this.bDashboard.Text = "Dashboard";
            this.bDashboard.Click += new System.EventHandler(this.bDashboard_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.CheckedState.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Button4.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button4.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = global::GUI.Properties.Resources._9027041_student_thin_icon;
            this.guna2Button4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button4.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2Button4.Location = new System.Drawing.Point(0, 345);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(200, 115);
            this.guna2Button4.TabIndex = 3;
            this.guna2Button4.Text = "Học viên";
            this.guna2Button4.UseTransparentBackground = true;
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // avatar
            // 
            this.avatar.Image = global::GUI.Properties.Resources.profile_3135768;
            this.avatar.ImageRotate = 0F;
            this.avatar.Location = new System.Drawing.Point(978, 12);
            this.avatar.Name = "avatar";
            this.avatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.avatar.Size = new System.Drawing.Size(64, 64);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatar.TabIndex = 1;
            this.avatar.TabStop = false;
            this.avatar.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1192, 715);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.panel_back.ResumeLayout(false);
            this.panel_back.PerformLayout();
            this.panel_tieude.ResumeLayout(false);
            this.panel_tieude.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.paneltop.ResumeLayout(false);
            this.paneltop.PerformLayout();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel paneltop;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel panel_back;
        private Guna.UI2.WinForms.Guna2CirclePictureBox avatar;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button bTeacher;
        private Guna.UI2.WinForms.Guna2Button bDashboard;
        private Guna.UI2.WinForms.Guna2Panel sidebar;
        private Guna.UI2.WinForms.Guna2Panel panel_tieude;
        private System.Windows.Forms.Label tieude;
        private System.Windows.Forms.Label tieude2;
        private Guna.UI2.WinForms.Guna2Panel panel_container;
        private Guna.UI2.WinForms.Guna2Button btnToggle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
    }
}

