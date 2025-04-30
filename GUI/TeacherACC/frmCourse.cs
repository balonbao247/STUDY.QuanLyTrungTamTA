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

namespace GUI.TeacherACC
{
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnIn(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
       

        private void frmCourse_Load(object sender, EventArgs e)
        {
           LoadCourse();
        }
        private void LoadCourse()
        {
            flowLayoutPanel1.Controls.Clear();
            BUS_Course busCourse = new BUS_Course();
            BUS_Teacher busTeacher = new BUS_Teacher();
        

            List<DTO_Course> activeList = busCourse.GetCoursesByTeacherID(Session.CurrentUsername);
                foreach (var item in activeList)
                {
                    try
                    {
                        string subjectName = busCourse.GetSubjectNameByID(item.SubjectID); // Add this method in BUS_Course

                        string courseDescription = busCourse.GetDescriptionByID(item.SubjectID); // Add this method in BUS_Course


                        string teacherName = busTeacher.GetTeacherNameByID(item.TeacherID); // Add this method in BUS_Course

                        frmCourse_Card card = new frmCourse_Card();
                        card.SetCourseInfo(item.CourseID.ToString(), teacherName, item.Price, subjectName, courseDescription, item.SubjectID);
                   

                        card.Margin = new Padding(10);
                        card.Width = 400;
                        card.Height = 250;

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

        private void btnADD_Click(object sender, EventArgs e)
        {
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
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
