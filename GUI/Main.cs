using GUI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI
{
    public partial class Main: Form
    {

      
        public Main()
        {
            InitializeComponent();
        }
       

        bool isCollapsed;
        private void Form1_Load(object sender, EventArgs e)
        {   //mặc định mở form Dashboard
            container(new Dashboard());
        }
        //hàm container để chứa các form con
        private void container(object form)
        {
          
            if (this.panel_container.Controls.Count > 0)
                this.panel_container.Controls.RemoveAt(0);
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_container.Controls.Add(fh);
            this.panel_container.Tag = fh;
            fh.Show();
            
        }
        //hàm set header,chỉnh màu sắc cho header
        private void SetHeader(string mainTitle, string subTitle, Color topColor, Color titleColor)
        {
            tieude.Text = mainTitle;
            tieude2.Text = subTitle;
            paneltop.BackColor = topColor;
            panel_tieude.BackColor = titleColor;
        }
        //nút Dashboard
        private void bDashboard_Click(object sender, EventArgs e)
        {   
            SetHeader("Trang chủ", "Home/Dashboard", Color.FromArgb(0, 123, 255), Color.FromArgb(173, 216, 230));
            container(new Dashboard());
        }
        //nút quản lý giáo viên
        private void bTeacher_Click(object sender, EventArgs e)
        {   
            SetHeader("Quản lý Giáo viên", "Home/Teacher", Color.FromArgb(214, 48, 49), Color.FromArgb(255, 118, 117));
            container(new Teacher());
        }
        //nut quan ly hoc sinh
        private void guna2Button4_Click(object sender, EventArgs e)
        {   SetHeader("Quản lý Học sinh", "Home/Student", Color.FromArgb(0, 184, 148), Color.FromArgb(85, 239, 196));
            container(new Student());
        }
        //nút quản lý lớp học
        private void guna2Button5_Click(object sender, EventArgs e)
        {   SetHeader("Quản lý Lớp học", "Home/Class", Color.FromArgb(255, 193, 7), Color.FromArgb(255, 213, 79));
            //container(new Course());
        }
        //tạo menu cho avatar
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(avatar, new Point(0, avatar.Height));
        }
        //form đổi mật khẩu
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPass resetPassForm = new ResetPass();
            // Center the form relative to the main form
            resetPassForm.StartPosition = FormStartPosition.CenterParent;

            // Show the form as a modal dialog (disables the main form)
            resetPassForm.ShowDialog();
            
        }
        //form đăng xuất, mở form login
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();

            // Close the current form (main dashboard)
            this.Hide();

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                sidebar.Width = sidebar.Width + 20;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    isCollapsed = false;
                    timer1.Stop();


                }
            }
            else
            {
                sidebar.Width = sidebar.Width - 20;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    isCollapsed = true;
                    timer1.Stop();
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
