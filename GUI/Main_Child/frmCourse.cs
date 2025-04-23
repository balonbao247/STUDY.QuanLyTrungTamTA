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

        private void frmCourse_Load(object sender, EventArgs e)
        {
           LoadCourse();
        }
        private void LoadCourse()
        {
            flowLayoutPanel1.Controls.Clear();
            BUS_Course busCourse = new BUS_Course();
            BUS_Teacher busTeacher = new BUS_Teacher();
            List<DTO_Course> activeList = busCourse.GetActiveCourses();
            foreach (var item in activeList)
            {
                try
                {
                    string subjectName = busCourse.GetSubjectNameByID(item.SubjectID); // Add this method in BUS_Course

                    string courseDescription = busCourse.GetDescriptionByID(item.SubjectID); // Add this method in BUS_Course


                    string teacherName = busTeacher.GetTeacherNameByID(item.TeacherID); // Add this method in BUS_Course

                    frmCourse_Card card = new frmCourse_Card();
                    card.SetCourseInfo(item.CourseID.ToString(), teacherName, item.Price, subjectName, courseDescription);
                    card.OnDeleteCourse += (s, args) =>
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khóa học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            string courseID = (s as frmCourse_Card).CourseID;
                            DeleteCourse(courseID);
                        }

                    };
                    card.Margin = new Padding(10);
                    card.Width = 400;
                    card.Height = 250;

                    flowLayoutPanel1.Controls.Add(card);
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
    }

}
