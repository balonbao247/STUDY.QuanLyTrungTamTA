using BUS;
using BUS.BUS;

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
    public partial class FormADDCourse : Form
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


      
        //Thanh search tìm học viên để thêm vào gridview tạm
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedIndex != -1)
            {
                string selectedText = lstSuggestions.SelectedItem.ToString();
                string maHV = selectedText.Split('(', ')')[1]; // lấy MaHV từ chuỗi hiển thị

                DTO_Student selectedStudent = allHocVien.FirstOrDefault(hv => hv.StudentID == maHV);
                if (selectedStudent != null)
                {    // Kiểm tra số lượng học viên trong dgvHocVienTam
                    int studentCount = dgvHocVienTam.Rows.Count;
                    var selectedRoom = cmbRoom.SelectedItem as DTO_Room;
                    if (selectedRoom != null)
                    {
                        int roomCapacity = selectedRoom.Capacity;
                        // Nếu số lượng học viên đã đạt hoặc vượt sức chứa phòng, không cho phép thêm học viên mới
                        if (studentCount >= roomCapacity)
                        {
                            MessageBox.Show($"Số lượng học viên đã đạt giới hạn của phòng ({roomCapacity} học viên).");
                            return;
                        }
                    }
                    int index = dgvHocVienTam.Rows.Add();
                    dgvHocVienTam.Rows[index].Cells["Column1"].Value = selectedStudent.StudentID;
                    dgvHocVienTam.Rows[index].Cells["Column2"].Value = selectedStudent.FullName;
                    // ... add thêm cột nếu cần
                }

                txtSearch.Text = "";
                lstSuggestions.Visible = false;
            }
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
        //Kiểm tra học viên đã tồn tại trong danh sách tạm chưa
        private bool DaTonTaiTrongGrid(string maHV)
        {
            foreach (DataGridViewRow row in dgvHocVienTam.Rows)
            {
                if (row.Cells["Column1"].Value?.ToString() == maHV)
                    return true;
            }
            return false;
        }


        //Tìm kiếm học viên trong danh sách
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
        //Xóa học viên trong danh sách tạm
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
        //Ẩn danh sách khi click bên ngoài
        private void FormADDCourse_Click(object sender, EventArgs e)
        {
            // Ẩn danh sách khi click bên ngoài
            lstSuggestions.Visible = false;
        }
        //Thay đổi tên giảng viên sẽ tự động nhập TeacherID
        private void cmbTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy TeacherID của giảng viên đã chọn
            string selectedTeacherID = cmbTeacherName.SelectedValue.ToString();

            // Lấy tên giảng viên từ ComboBox
            string teacherName = cmbTeacherName.Text;
            cmbTeacherName.Text = teacherName;
            textBoxTeacherID.Text = selectedTeacherID;
        }

        //Nút save course
        public event EventHandler OnCourseSaved;
        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedSubject = cmbSubject.SelectedItem as DTO_Subject;
            if (selectedSubject == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
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
            int numberOfMeetings = int.Parse(numTotalSessions.SelectedItem.ToString());
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            price = decimal.Parse(txtPrice.Text);

            // Kiểm tra tính hợp lệ của dữ liệu
            if (string.IsNullOrEmpty(courseName))
            {
                MessageBox.Show("Tên khóa học không được bỏ trống.");
                return;
            }

            if (startDate >= endDate)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.");
                return;
            }
            if (price<=0)
            {
                MessageBox.Show("Học phí phải lớn hơn 0 .");
                return;
            }

            // Tạo đối tượng khóa học
            DTO_Course newCourse = new DTO_Course
            {
                CourseID = courseID,
                CourseName = courseName,
                SubjectID = subjectID,
                NumberOfMeetings= numberOfMeetings,
                TeacherID = teacherID,
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                IsActive = true
            };

            // Tạo danh sách các ngày học từ ToggleSwitch
            List<int> selectedDays = new List<int>();

            switch (comboBoxDays.SelectedItem.ToString())
            {
                case "T2 - T4 - T6":
                    selectedDays.AddRange(new[] { 1, 3, 5 });

                    break;

                case "T3 - T5 - T7":
                    selectedDays.AddRange(new[] { 2, 4, 6 });
                    break;

                case "T7 - CN":
                    selectedDays.AddRange(new[] { 6, 7 });
                    break;

                default:
                    // Có thể xử lý lỗi nếu cần
                    break;
            }

            if (selectedDays.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ngày học trong tuần.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xung đột lịch trước khi lưu khóa học
            foreach (int dayOfWeek in selectedDays)
            {
                string timeSlotID = cmbTimeSlot.SelectedValue.ToString();
                string roomID = cmbRoom.SelectedValue.ToString();

                // Kiểm tra xung đột lịch học của giảng viên
                bool isConflict = BUS_CourseSchedule.Instance.IsScheduleConflict(teacherID, roomID, timeSlotID, dayOfWeek, startDate, endDate);

                if (isConflict)
                {
                    var selectedSlot = cmbTimeSlot.SelectedItem as DTO_TimeSlot;
                    string timeSlotName = selectedSlot != null ? selectedSlot.TimeSlotName : "Không rõ";
                    string dayText = GetDayName(dayOfWeek);

                    MessageBox.Show(
                        $"⚠️ Lịch bị trùng vào {dayText} - {timeSlotName}.\n\n" +
                        $"👉 Vui lòng chọn **giảng viên khác**, **phòng khác** hoặc **ca học khác** để tránh trùng lịch.",
                        "Xung đột lịch học",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return; // Dừng lại nếu có xung đột, không lưu khóa học nữa.
                }

                // Kiểm tra xung đột lịch học của học viên trong danh sách
                foreach (DataGridViewRow row in dgvHocVienTam.Rows)
                {
                    string studentID = row.Cells["Column1"].Value?.ToString();
                    if (!string.IsNullOrEmpty(studentID))
                    {
                        bool isStudentConflict = BUS_CourseStudent.Instance.IsScheduleConflict(studentID, dayOfWeek, timeSlotID, startDate, endDate);

                        if (isStudentConflict)
                        {
                            MessageBox.Show($"Học viên {studentID} đã có lịch học trùng vào ngày {GetDayName(dayOfWeek)}.");
                            return; // Dừng lại nếu có xung đột lịch học của học viên
                        }



                    }
                }
            }
            if (dgvHocVienTam.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm học viên vào khóa học.");
                return;
            }
            // Nếu không có xung đột, lưu khóa học vào cơ sở dữ liệu
            bool resultCourse = BUS_Course.Instance.AddCourse(newCourse);

            if (!resultCourse)
            {
                MessageBox.Show("Lưu khóa học không thành công.");
                return;
            }

            // Lưu lịch học cho khóa học
            foreach (int dayOfWeek in selectedDays)
            {
                DTO_CourseSchedule schedule = new DTO_CourseSchedule
                {
                    CourseID = courseID,
                    DayOfWeek = dayOfWeek,
                    TimeSlotID = (string)cmbTimeSlot.SelectedValue,
                    RoomID = (string)cmbRoom.SelectedValue
                };

                bool resultSchedule = BUS_CourseSchedule.Instance.InsertCourseSchedule(schedule);
                if (!resultSchedule)
                {
                    MessageBox.Show($"Lưu lịch học cho ngày {dayOfWeek} không thành công.");
                    return;
                }
            }


            // Lưu danh sách học viên tham gia khóa học
            foreach (DataGridViewRow row in dgvHocVienTam.Rows)
            {
                string studentID = row.Cells["Column1"].Value?.ToString();
                if (!string.IsNullOrEmpty(studentID))
                {
                    bool added = BUS_CourseStudent.Instance.AddStudentToCourse(courseID, studentID);
                    if (!added)
                    {
                        MessageBox.Show($"Không thể thêm học viên {studentID} vào khóa học.");
                        return;
                    }
                    bool resultPayment = BUS_Payment.Instance.CreatePayment(studentID, courseID, price);
                    if (!resultPayment)
                    {
                        MessageBox.Show($"Không thể tạo thanh toán cho học viên {studentID}.", "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Lưu thông tin lịch học cho khóa học
            BUS_StudentAttendance.Instance.InsertAttendanceForCourse(courseID, numberOfMeetings);

            MessageBox.Show("Khóa học và lịch học đã được lưu thành công!");

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
        //Lấy tên ngày trong tuần
        private string GetDayName(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 1: return "Thứ Hai";
                case 2: return "Thứ Ba";
                case 3: return "Thứ Tư";
                case 4: return "Thứ Năm";
                case 5: return "Thứ Sáu";
                case 6: return "Thứ Bảy";
                case 7: return "Chủ Nhật";
                default: return "";
            }
        }
        //Tự động nhập ngày kết thúc theo số buổi học
        private void UpdateEndDate()
        {
            try
            {
                DateTime startDate = dtpStartDate.Value;

                // Lấy lịch học từ combobox (ví dụ: "T2 - T4 - T6")
                string selectedSchedule = comboBoxDays.SelectedItem?.ToString();
                List<int> selectedDays = GetDaysFromCombo(selectedSchedule);

                // Lấy số buổi học (giả sử là NumericUpDown)
                int totalSessions = 0;

                if (int.TryParse(numTotalSessions.SelectedItem?.ToString(), out int value))
                {
                    totalSessions = value;
                }
                else
                {
                    // Có thể gán mặc định hoặc báo lỗi
                    totalSessions = 0;
                }

                if (selectedDays.Count == 0 || totalSessions <= 0)
                {
                    dtpEndDate.Value = startDate;
                    return;
                }

                DateTime endDate = CalculateEndDate(startDate, selectedDays, totalSessions);
                dtpEndDate.Value = endDate;
            }
            catch
            {
                // Có thể log lỗi hoặc báo người dùng
            }
        }
        //Tính ngày kết thúc dựa trên ngày bắt đầu, số buổi học và lịch học
        public DateTime CalculateEndDate(DateTime startDate, List<int> selectedDays, int totalSessions)
        {
            HashSet<DayOfWeek> selectedDayOfWeeks = new HashSet<DayOfWeek>(
                selectedDays.Select(d => (DayOfWeek)(d % 7)) // 1->Monday, 7->Sunday = 0
            );

            DateTime currentDate = startDate;
            int sessionCount = 0;

            while (sessionCount < totalSessions)
            {
                if (selectedDayOfWeeks.Contains(currentDate.DayOfWeek))
                {
                    sessionCount++;
                }

                if (sessionCount < totalSessions)
                {
                    currentDate = currentDate.AddDays(1);
                }
            }

            return currentDate;
        }
        //Lấy danh sách các ngày học từ ComboBox
        private List<int> GetDaysFromCombo(string comboText)
        {
            switch (comboText)
            {
                case "T2 - T4 - T6": return new List<int> { 1, 3, 5 };
                case "T3 - T5 - T7": return new List<int> { 2, 4, 6 };
                case "T7 - CN": return new List<int> { 6, 7 };
                default: return new List<int>();
            }
        }
        //Tự đông nhập ngay kết thúc theo số buổi học
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
        }


        //Nút cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Tắt blur background
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            this.Close();
        }

  

        //Lấy thông tin phòng học
        DTO_Room previousRoom = null;
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {   //Kiểm tra xem phòng đã được chọn chưa
            var selectedRoom = cmbRoom.SelectedItem as DTO_Room;
            if (selectedRoom != null)
            {
                int roomCapacity = selectedRoom.Capacity;
                int studentCount = dgvHocVienTam.Rows.Count;

                if (studentCount > roomCapacity)
                {
                    MessageBox.Show(
                        $"Số lượng học viên đã vượt quá sức chứa của phòng ({roomCapacity} học viên).",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Khôi phục lại phòng trước đó
                    cmbRoom.SelectedItem = previousRoom;
                    return;
                }

                // Nếu hợp lệ, cập nhật previousRoom
                previousRoom = selectedRoom;
            }

            UpdateEndDate();

        }

        //Thay đổi ngày học sẽ update lại ngày kết thúc
        private void comboBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
        }
    }
}
