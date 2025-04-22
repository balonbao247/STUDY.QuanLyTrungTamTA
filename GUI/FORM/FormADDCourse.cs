using BUS;
using DTO;
using GUI.ADD_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.FORM
{
    public partial class FormADDCourse: Form
    {
        public FormADDCourse()
        {
            InitializeComponent();

        }
        private List<DTO_Student> allHocVien = new List<DTO_Student>();
        private List<DTO_Teacher> allgiaovien = new List<DTO_Teacher>();
        private List<DTO_TimeSlot> allTimeSlot = new List<DTO_TimeSlot>();
        private List<DTO_Room> allRooms = new List<DTO_Room>();

        //FORM LOAD
        private void FormADDCourse_Load(object sender, EventArgs e)
        {
            //  Load Students
            allHocVien = BUS_Student.Instance.GetAllActiveStudents();

            // Load Teachers
            allgiaovien = BUS_Teacher.Instance.GetAllActiveTeachers();
            cmbTeacherName.DataSource = allgiaovien;
            cmbTeacherName.DisplayMember = "FullName";
            cmbTeacherName.ValueMember = "TeacherID";

            // Load Course ID
            txtCourseId.Text = BUS_Course.Instance.GetNextCourseID();

            // Load Time Slots
            allTimeSlot = BUS_TimeSlot.Instance.GetAllTimeSlots();
            cmbTimeSlot.DataSource = allTimeSlot;
            cmbTimeSlot.DisplayMember = "TimeSlotName";
            cmbTimeSlot.ValueMember = "TimeSlotID";

            // Load Rooms
            allRooms = BUS_Room.Instance.GetAllRooms();
            cmbRoom.DataSource = allRooms;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";

            // Load Subjects 
            List<DTO_Subject> allSubjects = BUS_Subject.Instance.GetAllSubjects();
            cmbSubject.DataSource = allSubjects;
            cmbSubject.DisplayMember = "SubjectName"; 
            cmbSubject.ValueMember = "SubjectID";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedIndex != -1)
            {
                string selectedText = lstSuggestions.SelectedItem.ToString();
                string maHV = selectedText.Split('(', ')')[1]; // lấy MaHV từ chuỗi hiển thị

                DTO_Student selectedStudent = allHocVien.FirstOrDefault(hv => hv.StudentID == maHV);
                if (selectedStudent != null)
                {
                    int index = dgvHocVienTam.Rows.Add();
                    dgvHocVienTam.Rows[index].Cells["Column1"].Value = selectedStudent.StudentID;
                    dgvHocVienTam.Rows[index].Cells["Column2"].Value = selectedStudent.FullName;
                    // ... add thêm cột nếu cần
                }

                txtSearch.Text = "";
                lstSuggestions.Visible = false;
            }
        }
        //Nút cancel
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
        //Thanh search tìm học viên để thên vào gridview tạm

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var ketQua = allHocVien
                .Where(hv => hv.FullName.ToLower().Contains(keyword))
                .Where(hv => !DaTonTaiTrongGrid(hv.StudentID)) // ❌ bỏ nếu đã có
                .ToList();

            lstSuggestions.Items.Clear();
            foreach (var hv in ketQua)
            {
                lstSuggestions.Items.Add($"{hv.FullName} ({hv.StudentID})");
            }

            lstSuggestions.Visible = ketQua.Count > 0;
        }
        private bool DaTonTaiTrongGrid(string maHV)
        {
            foreach (DataGridViewRow row in dgvHocVienTam.Rows)
            {
                if (row.Cells["Column1"].Value?.ToString() == maHV)
                    return true;
            }
            return false;
        }

        

        private void txtSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var ketQua = allHocVien
                .Where(hv => hv.FullName.ToLower().Contains(keyword))
                .Where(hv => !DaTonTaiTrongGrid(hv.StudentID)) // ❌ bỏ nếu đã có
                .ToList();

            lstSuggestions.Items.Clear();
            foreach (var hv in ketQua)
            {
                lstSuggestions.Items.Add($"{hv.FullName} ({hv.StudentID})");
            }

            lstSuggestions.Visible = ketQua.Count > 0;
        }

        private void dgvHocVienTam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào cột cuối (cột chỉ định để xóa)
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHocVienTam.Columns.Count - 1)
            {
                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa học viên này?", "Xóa học viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Xóa dòng học viên
                    dgvHocVienTam.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void FormADDCourse_Click(object sender, EventArgs e)
        {
            // Ẩn danh sách khi click bên ngoài
            lstSuggestions.Visible = false;
        }

        private void cmbTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy TeacherID của giảng viên đã chọn
            string selectedTeacherID = cmbTeacherName.SelectedValue.ToString();

            // Lấy tên giảng viên từ ComboBox
            string teacherName = cmbTeacherName.Text;

            // Hiển thị tên giảng viên vào TextBox
            cmbTeacherName.Text = teacherName;

            // Nếu muốn hiển thị cả Teacher ID trong TextBox (có thể tùy chỉnh)
            textBoxTeacherID.Text = selectedTeacherID;
        }
        public event EventHandler OnCourseSaved;
        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedSubject = cmbSubject.SelectedItem as DTO_Subject;
            if (selectedSubject == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá phải là một số hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (price < 0)
            {
                MessageBox.Show("Giá không được âm.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            // Thu thập dữ liệu khóa học
            string courseID = txtCourseId.Text;
            string courseName = selectedSubject.SubjectName;
            string subjectID = cmbSubject.SelectedValue.ToString();
            string teacherID = cmbTeacherName.SelectedValue.ToString();
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            price = decimal.Parse(txtPrice.Text);
            //bool isActive = chkIsActive.Checked;

            // Kiểm tra tính hợp lệ của dữ liệu
            if (string.IsNullOrEmpty(courseName))
            {
                MessageBox.Show("Course name is required.");
                return;
            }

            if (startDate >= endDate)
            {
                MessageBox.Show("End date must be later than start date.");
                return;
            }

            // Tạo đối tượng khóa học
            DTO_Course newCourse = new DTO_Course
            {
                CourseID = courseID,
                CourseName = courseName,
                SubjectID = subjectID,
                TeacherID = teacherID,
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                IsActive = true
            };

            // Lưu khóa học vào cơ sở dữ liệu
            bool resultCourse = BUS_Course.Instance.AddCourse(newCourse);

            if (!resultCourse)
            {
                MessageBox.Show("Failed to save the course.");
                return;
            }

            // Tạo danh sách các ngày học từ ToggleSwitch
            List<int> selectedDays = new List<int>();

            // Kiểm tra trạng thái của các ToggleSwitch (Tượng trưng cho các ngày trong tuần)
            if (toggleMonday.Checked) selectedDays.Add(1);  // Thứ Hai
            if (toggleTuesday.Checked) selectedDays.Add(2); // Thứ Ba
            if (toggleWednesday.Checked) selectedDays.Add(3); // Thứ Tư
            if (toggleThursday.Checked) selectedDays.Add(4); // Thứ Năm
            if (toggleFriday.Checked) selectedDays.Add(5); // Thứ Sáu
            if (toggleSaturday.Checked) selectedDays.Add(6); // Thứ Bảy
            if (toggleSunday.Checked) selectedDays.Add(7); // Chủ Nhật

            // Lưu lịch học cho khóa học
            foreach (int dayOfWeek in selectedDays)
            {
                DTO_CourseSchedule schedule = new DTO_CourseSchedule
                {
                    CourseID = courseID,
                    DayOfWeek = dayOfWeek,
                    TimeSlotID = (string)cmbTimeSlot.SelectedValue,  // Lấy giá trị từ ComboBox
                    RoomID = (string)cmbRoom.SelectedValue        // Lấy giá trị từ ComboBox
                };

                // Lưu lịch học vào cơ sở dữ liệu
                bool resultSchedule = BUS_CourseSchedule.Instance.InsertCourseSchedule(schedule);
                if (!resultSchedule)
                {
                    MessageBox.Show($"Failed to save schedule for day {dayOfWeek}");
                    return;
                }
            }

            MessageBox.Show("Course and schedules saved successfully!");

            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            this.Close();
            OnCourseSaved?.Invoke(this, EventArgs.Empty);
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
