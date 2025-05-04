using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
namespace GUI.ADD_Form
{
    public partial class FormEDITTeacher: Form
    {
        private DTO_Teacher Teacher;
        public FormEDITTeacher(DTO_Teacher Teacher)
        {
            InitializeComponent();
            // Lấy thông tin
            this.Teacher=Teacher;
            txtTeacherID.Text = Teacher.TeacherID;  // <-- Load ID vào đây
            txtFullName.Text = Teacher.FullName;
            cboGender.SelectedItem = Teacher.Gender;
            dtpDOB.Value = Teacher.DateOfBirth;
            txtPhone.Text = Teacher.PhoneNumber;
            txtEmail.Text = Teacher.Email;
            txtAddress.Text = Teacher.Address;
            txtCCCD.Text = Teacher.IdentityNumber;
            txtSpecialty.Text = Teacher.Specialty;
            txtSalary.Text = Teacher.Salary.ToString();
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
            // Reset tất cả lỗi trước đó
            errorProvider1.Clear();
            bool isValid = true;

            string identityCard = txtCCCD.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string gender = cboGender.SelectedItem?.ToString() ?? "";
          

            // Kiểm tra CCCD
            if (string.IsNullOrWhiteSpace(identityCard))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD");
                isValid = false;
            }
            else if (identityCard.Length != 12)
            {
                errorProvider1.SetError(txtCCCD, "CCCD phải đúng 12 số");
                isValid = false;
            }
            //else if (BUS_RelatedToEmployee.Instance.CheckExistTeacherID("HV" + identityCard))
            //{
            //    errorProvider1.SetError(txtCCCD, "CCCD đã tồn tại");
            //    isValid = false;
            //}

            // Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorProvider1.SetError(txtFullName, "Vui lòng nhập họ tên");
                isValid = false;

            }
            // Kiểm tra giới tính
            if (string.IsNullOrWhiteSpace(gender))
            {
                errorProvider1.SetError(cboGender, "Vui lòng chọn giới tính");
                isValid = false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(address))
            {
                errorProvider1.SetError(txtAddress, "Vui lòng nhập địa chỉ");
                isValid = false;
            }

            // Kiểm tra số điện thoại
            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại phải gồm 10 chữ số");
                isValid = false;
            }

            // Kiểm tra email
            if (!email.ToLower().EndsWith("@gmail.com"))
            {
                errorProvider1.SetError(txtEmail, "Email phải đúng định dạng @gmail.com");
                isValid = false;
            }

            // Nếu có lỗi thì return
            if (!isValid)
                return;
            DTO_Teacher updateTeacher = new DTO_Teacher(
                txtTeacherID.Text,        // TeacherID
                txtFullName.Text,         // FullName
                cboGender.SelectedItem.ToString(), // Gender
                dtpDOB.Value,             // DateOfBirth
                txtPhone.Text,            // PhoneNumber
                txtEmail.Text,            // Email
                txtAddress.Text,          // Address
                txtCCCD.Text,              // IdentityNumber
                txtSpecialty.Text,        // Specialty
                int.Parse(txtSalary.Text)        // Salary

            );
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            // Cập nhật thông tin giáo viên
            bool success = BUS_Teacher.Instance.UpdateTeacher(updateTeacher);
            if (success)
            {
                MessageBox.Show("Cập nhật giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
    }
}
