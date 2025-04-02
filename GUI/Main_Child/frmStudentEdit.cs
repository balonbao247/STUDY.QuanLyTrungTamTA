using System;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class frmStudentEdit : Form
    {
        private DTO_Student student;

        public frmStudentEdit(DTO_Student student)
        {
            InitializeComponent();
            this.student = student;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            txtStudentID.Text = student.Id;
            txtFullName.Text = student.FullName;
            txtClassName.Text = student.ClassName;
            txtPhone.Text = student.Phone;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin học viên từ TextBox
            student.FullName = txtFullName.Text;
            student.ClassName = txtClassName.Text;
            student.Phone = txtPhone.Text;

            // Gọi BUS để cập nhật vào database (nếu có)
            // busStudent.UpdateStudent(student);

            MessageBox.Show("Đã cập nhật học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Đóng form sau khi lưu
        }
    }
}
