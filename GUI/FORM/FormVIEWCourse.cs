using BUS;
using DTO;
using GUI.ADD_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.FORM
{
    public partial class FormVIEWCourse: Form
    {
        public FormVIEWCourse()
        {
            InitializeComponent();
        }
        private string editingCourseID = null;
        public FormVIEWCourse(string courseID) : this()
        {
            editingCourseID = courseID;
            LoadCourseInfo(courseID); // hàm riêng để load dữ liệu lên form
        }
        private void LoadCourseInfo(string courseID)
        {
            BUS_Course bus = new BUS_Course();
            DTO_Course course = bus.GetCourseByID(courseID); // tạo hàm này trong BUS
          
            List<DTO_CourseSchedule> courseSchedules = BUS_CourseSchedule.Instance.GetAllCourseSchedulesByCourseID(courseID);
            if (course != null)
            {
                txtCourseId.Text = course.CourseID;
                cmbSubject.SelectedValue = course.SubjectID;
                cmbTeacherName.SelectedValue = course.TeacherID;

                textBoxTeacherID.Text= course.TeacherID;
                dtpStartDate.Value = course.StartDate;
                numTotalSessions.SelectedItem = course.NumberOfMeetings.ToString();
                cmbRoom.SelectedValue =courseSchedules.First().RoomID;
                txtPrice.Text = course.Price.ToString();
                if (courseSchedules.Count > 0)
                {
                    var firstSchedule = courseSchedules.First(); // Lấy lịch học đầu tiên

                    // Phân tích nhóm ngày học đã lưu
                    if (firstSchedule.DayOfWeek == 1 )
                        comboBoxDays.SelectedValue = 0; // "T2 - T4 - T6"
                    else if (firstSchedule.DayOfWeek == 2)
                        comboBoxDays.SelectedIndex = 1; // "T3 - T5 - T7"
                    else if (firstSchedule.DayOfWeek == 6)
                        comboBoxDays.SelectedIndex = 2; // "T7 - CN"
                }


                List<DTO_Student> students = BUS_CourseStudent.Instance.GetStudentsByCourseID(courseID);

                // Xoá dữ liệu cũ trước khi thêm mới
                dgvHocVienTam.Rows.Clear();

              
                foreach (var student in students)
                {
                    dgvHocVienTam.Rows.Add(student.StudentID, student.FullName);
                }
                // ... set các giá trị khác nữa
            }
        }

           public event EventHandler OnCourseSaved;

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnCourseSaved?.Invoke(this, EventArgs.Empty);
            foreach (Form form in Application.OpenForms)
            {
                if (form is BlurBackground)
                {
                    form.Hide();

                }
            }
            this.Close();

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

        private List<DTO_Student> allHocVien = new List<DTO_Student>();
        private List<DTO_Teacher> allgiaovien = new List<DTO_Teacher>();
        private List<DTO_TimeSlot> allTimeSlot = new List<DTO_TimeSlot>();
        private List<DTO_Room> allRooms = new List<DTO_Room>();

        //FORM LOAD
        private void FormVIEWCourse_Load(object sender, EventArgs e)
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
            LoadCourseInfo(editingCourseID);
        }
    }


}
