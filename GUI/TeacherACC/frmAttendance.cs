using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.TeacherACC
{
    public partial class frmAttendance: Form
    {
        public frmAttendance()
        {
            InitializeComponent();
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            List<DTO_Course> courses = BUS_Course.Instance.GetCoursesByTeacherID(Session.CurrentUsername);

            cboCourse.DataSource = courses;
            cboCourse.DisplayMember = "CourseID";   // Thuộc tính tên khóa học
            cboCourse.ValueMember = "CourseID";

            string courseId = cboCourse.SelectedValue.ToString();
            DataTable uniqueDates = BUS_StudentAttendance.Instance.GetDistinctAttendanceDatesByCourse(courseId);

            // Chuyển đổi DataTable để hiển thị ngày dưới định dạng 'dd/MM/yyyy'
            DataTable displayDates = uniqueDates.Copy();
            displayDates.Columns.Add("FormattedDate", typeof(string));

            foreach (DataRow row in displayDates.Rows)
            {
                row["FormattedDate"] = ((DateTime)row["AttendanceDate"]).ToString("dd/MM/yyyy");
            }

            // Gán lại DataSource cho ComboBox
            cboDate.DataSource = displayDates;
            cboDate.DisplayMember = "FormattedDate";  // Hiển thị cột mới chứa định dạng ngày
            cboDate.ValueMember = "AttendanceDate";


        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string courseId = cboCourse.SelectedValue.ToString();
            DataTable uniqueDates = BUS_StudentAttendance.Instance.GetDistinctAttendanceDatesByCourse(courseId);

            // Chuyển đổi DataTable để hiển thị ngày dưới định dạng 'dd/MM/yyyy'
            DataTable displayDates = uniqueDates.Copy();
            displayDates.Columns.Add("FormattedDate", typeof(string));

            foreach (DataRow row in displayDates.Rows)
            {
                row["FormattedDate"] = ((DateTime)row["AttendanceDate"]).ToString("dd/MM/yyyy");
            }

            // Gán lại DataSource cho ComboBox
            cboDate.DataSource = displayDates;
            cboDate.DisplayMember = "FormattedDate";  // Hiển thị cột mới chứa định dạng ngày
            cboDate.ValueMember = "AttendanceDate";
        }

        private void LoadAttendanceData()
        {
            if (cboCourse.SelectedValue == null || cboDate.SelectedValue == null)
                return;

            string courseId = cboCourse.SelectedValue.ToString();
            DateTime selectedDate = Convert.ToDateTime(cboDate.SelectedValue);

            DataTable attendanceData = BUS_StudentAttendance.Instance.GetAttendanceByCourseAndDate(courseId, selectedDate);

            dgvAttendance.Rows.Clear();

            foreach (DataRow row in attendanceData.Rows)
            {
                string studentId = row["StudentID"].ToString();
                DTO_Student student = BUS_Student.Instance.GetStudentByID(studentId);

                int rowIndex = dgvAttendance.Rows.Add();
                dgvAttendance.Rows[rowIndex].Cells["AttendanceID"].Value = row["AttendanceID"];
                dgvAttendance.Rows[rowIndex].Cells["StudentID"].Value = student.StudentID;
                dgvAttendance.Rows[rowIndex].Cells["StudentName"].Value = student.FullName;
                dgvAttendance.Rows[rowIndex].Cells["Gender"].Value = student.Gender;
                dgvAttendance.Rows[rowIndex].Cells["Status"].Value = row["Status"];

                // Tích vào checkbox nếu Status = "Có học"
                bool isPresent = row["Status"].ToString().Trim().Equals("Có học", StringComparison.OrdinalIgnoreCase);
                dgvAttendance.Rows[rowIndex].Cells["Check"].Value = isPresent;
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;

                string attendanceId = row.Cells["AttendanceID"].Value?.ToString();
                bool isChecked = Convert.ToBoolean(row.Cells["Check"].Value);

                string status = isChecked ? "Có học" : "Absent";

                if (!string.IsNullOrEmpty(attendanceId))
                {
                    BUS_StudentAttendance.Instance.UpdateAttendanceStatus(attendanceId, status);
                }
            }

            MessageBox.Show("Đã lưu điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
