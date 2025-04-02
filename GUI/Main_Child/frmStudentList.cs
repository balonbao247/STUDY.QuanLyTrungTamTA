using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS;  // Import tầng BUS
using DTO;  // Import tầng DTO

namespace GUI
{
    public partial class frmStudentList : Form
    {
        //private BUS_Student busStudent = new BUS_Student();

        public frmStudentList()
        {
            InitializeComponent();
        }

        private void frmStudentList_Load(object sender, EventArgs e)
        {
            CustomizeGridView();
            LoadStudentList();
        }

        private void CustomizeGridView()
        {
            // Tùy chỉnh giao diện DataGridView
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.EnableHeadersVisualStyles = false;

            dgvStudents.DefaultCellStyle.Font = new Font("Arial", 10);
            dgvStudents.DefaultCellStyle.BackColor = Color.Beige;
            dgvStudents.DefaultCellStyle.ForeColor = Color.Black;

            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;

            // Thêm cột vào DataGridView
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add("StudentID", "Mã HV");
            dgvStudents.Columns.Add("FullName", "Họ và Tên");
            dgvStudents.Columns.Add("ClassName", "Lớp Học");
            dgvStudents.Columns.Add("Phone", "Số Điện Thoại");

            // Cột Checkbox
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Chọn";
            chkColumn.Name = "Select";
            dgvStudents.Columns.Add(chkColumn);

            // Cột Button "Sửa"
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Hành Động";
            btnColumn.Text = "Sửa";
            btnColumn.UseColumnTextForButtonValue = true;
            dgvStudents.Columns.Add(btnColumn);
        }

        private void LoadStudentList()
        {
            dgvStudents.Rows.Add("HV001", "Nguyễn Văn A", "IELTS 6.5", "0987654321", false);
            dgvStudents.Rows.Add("HV002", "Trần Thị B", "TOEIC 700", "0977123456", false);
            dgvStudents.Rows.Add("HV003", "Lê Văn C", "Basic English", "0912233445", false);
            //List<DTO_Student> students = busStudent.GetStudentList();
            //dgvStudents.Rows.Clear();

            //foreach (var student in students)
            //{
            //    dgvStudents.Rows.Add(student.Id, student.FullName, student.ClassName, student.Phone, false);
            //}
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgvStudents.Columns["Hành Động"].Index && e.RowIndex >= 0)
            //{
            //    string studentID = dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();
            //    DTO_Student student = busStudent.GetStudentByID(studentID);

            //    frmStudent form = new frmStudent(student); // Mở form sửa
            //    form.ShowDialog();
            //    LoadStudentList(); // Refresh lại danh sách sau khi sửa
            //}
        }
    }
}
