using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.ADD_Form;
using GUI.FORM;

namespace GUI.Main_Child
{
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }

        // Phương thức này sẽ được gọi khi form được load
        private void DeleteCourse(string courseID)
        {
            // Xóa khóa học khi nút xóa được nhấn
            BUS_Course busCourse = new BUS_Course();
            bool result = busCourse.DeleteCourse(courseID);

            if (result)
            {
                // Xóa card trong FlowLayoutPanel
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is frmCourse_Card card && card.CourseID == courseID)
                    {
                        flowLayoutPanel1.Controls.Remove(ctrl);
                        break;
                    }
                }

                MessageBox.Show("Khóa học đã bị xóa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi khi xóa khóa học!");
            }

        }

        // Khi nhấn nút "Đóng" sẽ đóng form
        private void frmCourse_Load(object sender, EventArgs e)
        {
           LoadCourse();
        }
        //Hàm load khóa học
        private void LoadCourse()
        {
            // Tải danh sách khóa học từ cơ sở dữ liệu và hiển thị lên giao diện
            flowLayoutPanel1.Controls.Clear();
            // Tạo đối tượng BUS_Course và BUS_Teacher
            BUS_Course busCourse = new BUS_Course();
            BUS_Teacher busTeacher = new BUS_Teacher();
            List<DTO_Course> activeList = busCourse.GetActiveCourses();
            foreach (var item in activeList)
            {   // Lặp qua danh sách khóa học
                try
                {
                    string subjectName = busCourse.GetSubjectNameByID(item.SubjectID); // Add this method in BUS_Course

                    string courseDescription = busCourse.GetDescriptionByID(item.SubjectID); // Add this method in BUS_Course


                    string teacherName = busTeacher.GetTeacherNameByID(item.TeacherID); // Add this method in BUS_Course

                    // Tạo một control mới cho khóa học
                    frmCourse_Card card = new frmCourse_Card();
                    card.SetCourseInfo(item.CourseID.ToString(), teacherName, item.Price, subjectName, courseDescription, item.SubjectID);
                    card.OnDeleteCourse += (s, args) =>
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khóa học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            string courseID = (s as frmCourse_Card).CourseID;
                            DeleteCourse(courseID);
                        }

                    };
                    // Thiết lập các thuộc tính cho card
                    card.Margin = new Padding(10);
                    card.Width = 400;
                    card.Height = 250;
                    // Thêm card vào FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(card);
                    card.OnEditCourse += (s, courseID) =>
                    {
                        FormVIEWCourse formEdit = new FormVIEWCourse(courseID); // truyền CourseID để load lên form
                        BlurBackground blur = new BlurBackground();

                        formEdit.OnCourseSaved += (ss, ee) =>
                        {
                            LoadCourse(); // Refresh lại danh sách khi lưu xong
                        };
                        
                        blur.Show();
                        formEdit.ShowDialog();
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo card: " + ex.Message);
                }
            }
        }
        // Khi nhấn nút "Thêm" sẽ mở form thêm khóa học
        private void btnADD_Click(object sender, EventArgs e)
        {
            // Mở form thêm khóa học
            FormADDCourse formADDCourse = new FormADDCourse();
            BlurBackground blurBackground = new BlurBackground();
            formADDCourse.OnCourseSaved += (s, args) =>
            {
                // Khi khóa học được lưu, tải lại các card
                LoadCourse();
            };
            blurBackground.Show();
            formADDCourse.ShowDialog();
        }


        // Khi nhấn nút "Tìm kiếm" sẽ tìm kiếm khóa học theo từ khóa
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ TextBox
            string keyword = txtSearch.Text.Trim().ToLower();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is frmCourse_Card course)
                {
                    // Lấy các thông tin cần tìm
                    string courseName = course.CourseName.ToLower();     // Tên khoá
                    string courseCode = course.CourseCode.ToLower();     // Mã khoá
                    string teacherName = course.TeacherName.ToLower();   // Tên giáo viên
                  

                    // Nếu từ khoá nằm trong bất kỳ thông tin nào -> Hiện
                    bool match = courseName.Contains(keyword)
                                 || courseCode.Contains(keyword)
                                 || teacherName.Contains(keyword);

                    course.Visible = match;
                }
            }
        }
    }

}
