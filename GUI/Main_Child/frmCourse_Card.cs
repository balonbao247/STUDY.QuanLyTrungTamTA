using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Main_Child
{
    public partial class frmCourse_Card: UserControl
    {
        // Thông tin khóa học
        public string CourseID { get; set; }
        public string CourseName => lblName.Text;
        public string CourseCode => lblSubject.Text;
        public string TeacherName => lblTeacher.Text;
        public string SubjectName => lblSubject.Text;

        public frmCourse_Card()
        {
            InitializeComponent();
        }


        // Phương thức để thiết lập thông tin khóa học
        public void SetCourseInfo(string courseID, string teacherName, decimal price, string subject, string description,string SubjectID)
        {
            // Gán giá trị cho các thuộc tính
            this.CourseID =  courseID;
            lblName.Text = $"Khóa: {courseID}";
            lblTeacher.Text = teacherName;
            lblPrice.Text = $"{price:N0} VNĐ";
            lblSubject.Text = subject;
            txtDesc.Text = description;
            // Lấy ảnh theo subjectID (đã add s01, s02, ... vào Resources)
            guna2PictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(SubjectID);
           
        }

        // Phương thức để thiết lập thông tin khóa học từ DTO_Course
        public event EventHandler OnDeleteCourse;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OnDeleteCourse?.Invoke(this, e);
        }

        // Phương thức để thiết lập thông tin khóa học từ DTO_Course
        public event EventHandler<string> OnEditCourse;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OnEditCourse?.Invoke(this, CourseID);
        }

 
    }
}
