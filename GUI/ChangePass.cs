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
using System.Windows.Forms;
using BUS;
using DAL;
using DTO;
using GUI.ADD_Form;
namespace GUI
{
    public partial class ChangePass: Form
    {
        public ChangePass()
        {
            InitializeComponent();
            this.AcceptButton=btnChangePass;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPass.Text.Trim();
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtRePass.Text.Trim();
            // Kiểm tra người dùng đã đăng nhập chưa
            string username = Session.CurrentUsername;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Bạn phải đăng nhập trước khi thay đổi mật khẩu.");
                return;
            }

            // Kiểm tra các trường hợp mật khẩu cũ, mới và xác nhận
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Kiểm tra mật khẩu cũ
            DTO_Account account = BUS_Account.Instance.Login(username, oldPassword);
            if (account == null)
            {
                MessageBox.Show("Mật khẩu cũ không đúng.");
                return;
            }

            // Kiểm tra mật khẩu mới và xác nhận có khớp không
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.");
                return;
            }

            // Nếu tất cả hợp lệ, thay đổi mật khẩu
            bool result = BUS_Account.Instance.ChangePassword(username, newPassword);

            if (result)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is BlurBackground)
                    {
                        form.Hide();
                    }
                }
                MessageBox.Show("Mật khẩu đã được thay đổi thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thay đổi mật khẩu.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();
                }
            }
            this.Close();
        }

        private void PassCheckB_CheckedChanged(object sender, EventArgs e)
        {
            txtRePass.UseSystemPasswordChar = !PassCheckB.Checked;
        }
    }
}
