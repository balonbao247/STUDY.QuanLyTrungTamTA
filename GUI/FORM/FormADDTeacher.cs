using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
namespace GUI.ADD_Form
{
    public partial class FormADDTeacher: Form
    {
      
        public FormADDTeacher()
        {
            InitializeComponent();
            

            txtTeacherID.ReadOnly = true;
        }

        // Khi nhấn nút "Đóng" sẽ đóng form
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

        // Khi nhấn nút "Lưu" sẽ lưu thông tin giáo viên
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset tất cả lỗi trước đó
                errorProvider1.Clear();
                bool isValid = true;

                // Lấy giá trị từ các textbox và combobox
                string identityCard = txtCCCD.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                string gender = cboGender.SelectedItem?.ToString() ?? "";
                string specialty = txtSpecialty.Text.Trim();

                // Kiểm tra nếu Salary có đúng định dạng
                int salary;
                if (!int.TryParse(txtSalary.Text.Trim(), out salary))
                {
                    // Không phải số nguyên
                    errorProvider1.SetError(txtSalary, "Lương phải là số nguyên");
                    isValid = false;
                }
                else if (salary < 0)
                {
                    // Số nguyên nhưng âm
                    errorProvider1.SetError(txtSalary, "Lương không được âm");
                    isValid = false;
                }

                // Kiểm tra các trường thông tin
                if (string.IsNullOrWhiteSpace(identityCard))
                {
                    errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD");
                    isValid = false;
                }
                else if (identityCard.Length != 12 || !identityCard.All(char.IsDigit))
                {
                    errorProvider1.SetError(txtCCCD, "CCCD phải đúng 12 số");
                    isValid = false;
                }
                else if (BUS_Teacher.Instance.CheckExistIdentityNumber(identityCard))
                {
                    errorProvider1.SetError(txtCCCD, "CCCD đã tồn tại");
                    isValid = false;
                }

                //Kiểm tra Họ tên
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    errorProvider1.SetError(txtFullName, "Vui lòng nhập họ tên");
                    isValid = false;
                }
                else if (!Regex.IsMatch(fullName, @"^[a-zA-ZÀ-Ỷà-ỷ\s]+$"))
                {
                    errorProvider1.SetError(txtFullName, "Họ tên chỉ được chứa chữ cái và khoảng trắng");
                    isValid = false;
                }
                //Kiểm tra chuyên môn
                if (string.IsNullOrWhiteSpace(specialty))
                {
                    errorProvider1.SetError(txtSpecialty,"Vui lòng nhập chuyên môn");
                    isValid = false;
                }
                //kiểm tra giới tính
                if (string.IsNullOrWhiteSpace(gender))
                {
                    errorProvider1.SetError(cboGender, "Vui lòng chọn giới tính");
                    isValid = false;
                }
                //kiểm tra địa chỉ
                if (string.IsNullOrWhiteSpace(address))
                {
                    errorProvider1.SetError(txtAddress, "Vui lòng nhập địa chỉ");
                    isValid = false;
                }
                //kiểm tra số điện thoại
                if (phone.Length != 10 || !phone.All(char.IsDigit))
                {
                    errorProvider1.SetError(txtPhone, "Số điện thoại phải gồm 10 chữ số");
                    isValid = false;
                }

                // Kiểm tra email
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email.ToLower(), emailPattern))
                {
                    errorProvider1.SetError(txtEmail, "Email không hợp lệ");
                    isValid = false;
                }

                // Nếu có lỗi thì return
                if (!isValid) return;

                // Tạo đối tượng DTO_Account và DTO_Teacher
                DTO_Account newAccount = new DTO_Account(
                    txtTeacherID.Text,                          // Username
                    GeneratePasswordFromCCCD(txtCCCD.Text),     // Password
                    true,                                       // Role
                    "Teacher"                                   // IsActive (1 -> true)
                );

                DTO_Teacher newTeacher = new DTO_Teacher(
                    txtTeacherID.Text,        // TeacherID
                    txtFullName.Text,         // FullName
                    cboGender.SelectedItem.ToString(), // Gender
                    dtpDOB.Value,             // DateOfBirth
                    txtPhone.Text,            // PhoneNumber
                    txtEmail.Text,            // Email
                    txtAddress.Text,          // Address
                    txtCCCD.Text,             // IdentityNumber
                    txtSpecialty.Text,        // Specialty
                    salary                    // Salary
                );

                // Ẩn form BlurBackground
                foreach (Form form in Application.OpenForms)
                {
                    if (form is BlurBackground)
                    {
                        form.Hide();
                    }
                }

                // Thực hiện thêm tài khoản và giáo viên
                bool accountResult = BUS_Account.Instance.InsertAccount(newAccount);
                bool teacherResult = BUS_Teacher.Instance.InsertTeacher(newTeacher);

                // Hiển thị kết quả
                if (accountResult && teacherResult)
                {
                    MessageBox.Show("Thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm giáo viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Hàm tạo mật khẩu từ CCCD 6 số cuối
        public static string GeneratePasswordFromCCCD(string cccd)
        {
            if (string.IsNullOrEmpty(cccd) || cccd.Length < 6)
            {
                throw new ArgumentException("Mã CCCD không hợp lệ");
            }

            // Lấy 6 số cuối của CCCD
            string lastSixDigits = cccd.Substring(cccd.Length - 6);

            // Hash 6 số cuối bằng SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(lastSixDigits));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Chuyển kết quả thành chuỗi hex
            }
        }
        //Load form
        private void FormADDTeacher_Load(object sender, EventArgs e)
        {
            txtTeacherID.Text = BUS_Teacher.Instance.GetNextTeacherID();
            txtTeacherID.ReadOnly = true;
        }



    }
}
