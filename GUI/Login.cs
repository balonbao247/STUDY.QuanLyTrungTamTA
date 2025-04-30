using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BUS;
using DAL;
using DTO;
namespace GUI
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            if (File.Exists("config.txt"))//Open Config to read information
            {
                StreamReader rd = new StreamReader("config.txt");
                String s = rd.ReadLine();

                if (s.Equals("windows"))
                {
                    Program.authen = "windows";
                    Program.server = rd.ReadLine();
                    Program.db = rd.ReadLine();
                    //MessageBox.Show(Program.server + ", " + Program.db);
                }
                else//SQL authentication
                {
                    Program.authen = "sql";
                    Program.server = rd.ReadLine();
                    Program.db = rd.ReadLine();
                    Program.uid = rd.ReadLine();
                    Program.pw = rd.ReadLine();
                }
                rd.Close();
            }
            else//Open config form to update information
            {
                Config f = new Config();
                f.ShowDialog();
            }
        }
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin tài khoản từ người dùng
                string username = txtUsername.Text;
                string password = txtPassword.Text;  // Mật khẩu đã được mã hóa nếu cần

             


                // Kiểm tra tài khoản từ cơ sở dữ liệu
                DTO_Account account = BUS_Account.Instance.Login(username,password);

                if (account.Role == "Teacher")
                {
                    
                    Session.CurrentUsername = username;

                    // Mở Main_Teacher
                    this.Hide();
                    Main_Teacher mainTeacher = new Main_Teacher();
                    mainTeacher.Show();

                    
                   
                }
                else if (account.Role == "Admin")
                {
                    Session.CurrentUsername = username;

                    // Mở Main_Admin
                    this.Hide();
                    Main mainAdmin = new Main();
                    mainAdmin.Show();
                    
                }
                
            }
            catch (Exception ex)
            {
                // Xử lý lỗi trong quá trình đăng nhập
                MessageBox.Show("Đăng nhập thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !PassCheckB.Checked;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgetPass forgetPass = new ForgetPass();
            forgetPass.Show();
            
        }
    }
}
