using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    public partial class ForgetPass: Form

    {
        private string verifyCode;
        public ForgetPass()
        {
            InitializeComponent();
        }
        // Khi nhấn nút "Đóng" sẽ đóng form
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Khi nhấn nút "Quên mật khẩu" sẽ mở form đăng nhập
        private void labelQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login newlog = new Login();
            newlog.Show();
        }

        // Kiểm tra xem có nhập tên đăng nhập hay không
        private void btnSend_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your Username.");
                return;
            }

            string email = BUS_Account.Instance.GetEmailByUsername(username);
            if (email == null)
            {
                MessageBox.Show("Username not found!");
                return;
            }
            // Gửi mã xác thực đến email
            Random random = new Random();
            verifyCode = random.Next(100000, 1000000).ToString();

            SendEmail(email, verifyCode);
            MessageBox.Show("Verification code has been sent to your email.");
        }
        // Gửi email xác thực
        public bool SendEmail(string email, string verificationCode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("tonlegiabao@gmail.com"); // Email gửi đi
                mail.To.Add(email); // Email người nhận
                mail.Subject = "Verification Code - Computer Management Center";
                mail.Body = $"Your verification code is: {verificationCode}";
              
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("tonlegiabao@gmail.com", "yryb wegt fcel vmsw"); // App Password
                smtp.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                // Có thể log lỗi tại đây
                return false;
            }
        }
        // Kiểm tra mã xác thực
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string verificationCode = txtCode.Text.Trim();
            string newPassword = txtNewPass.Text.Trim();
            string confirmedNewPassword = txtRePass.Text.Trim();

            // Kiểm tra các trường hợp lỗi
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(verificationCode) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmedNewPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmedNewPassword)
            {
                MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mã xác thực so với mã đã gửi
            if (verificationCode != verifyCode)
            {
                MessageBox.Show("Invalid verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đổi mật khẩu trong database
            bool isPasswordChanged = BUS_Account.Instance.ChangePassword(username, newPassword);

            if (isPasswordChanged)
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login newlog = new Login();
                newlog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error occurred while changing password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra xem mật khẩu có hiển thị hay không
        private void PassCheckB_CheckedChanged(object sender, EventArgs e)
        {
            txtRePass.UseSystemPasswordChar = !PassCheckB.Checked;
        }

        // Kiểm tra xem mật khẩu có hiển thị hay không
        private void ForgetPass_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
