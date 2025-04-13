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
    public partial class FormEDITStudent: Form
    {
        private DTO_Student Student;
        public FormEDITStudent(DTO_Student Student)
        {
            InitializeComponent();
            this.Student=Student;
            txtStudentID.Text = Student.StudentID;  // <-- Load ID vào đây
            txtFullName.Text = Student.FullName;
            cboGender.SelectedItem = Student.Gender;
            dtpDOB.Value = Student.DateOfBirth;
            txtPhone.Text = Student.PhoneNumber;
            txtEmail.Text = Student.Email;
            txtAddress.Text = Student.Address;
            txtCCCD.Text = Student.IdentityNumber;

            txtStudentID.ReadOnly = true;
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

        private void lblCCCD_Click(object sender, EventArgs e)
        {

        }

        private void lblDOB_Click(object sender, EventArgs e)
        {

        }
       

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {

        }

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
            //else if (BUS_RelatedToEmployee.Instance.CheckExistStudentID("HV" + identityCard))
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
            DTO_Student updateStudent = new DTO_Student(
                txtStudentID.Text,        // StudentID
                txtFullName.Text,         // FullName
                cboGender.SelectedItem.ToString(), // Gender
                dtpDOB.Value,             // DateOfBirth
                txtPhone.Text,            // PhoneNumber
                txtEmail.Text,            // Email
                txtAddress.Text,          // Address
                txtCCCD.Text              // IdentityNumber
            );
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            bool success = BUS_Student.Instance.UpdateStudent(updateStudent);
            if (success)
            {
                MessageBox.Show("Cập nhật học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }
    }
}
