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
        public string CourseID { get; set; }
        public string CourseName => lblName.Text;
        public string CourseCode => lblSubject.Text;
        public string TeacherName => lblTeacher.Text;
        public string SubjectName => lblSubject.Text;

        public frmCourse_Card()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void SetCourseInfo(string courseID, string teacherName, decimal price, string subject, string description,string SubjectID)
        {
            this.CourseID =  courseID;
            lblName.Text = $"Khóa: {courseID}";
            lblTeacher.Text = teacherName;
            lblPrice.Text = $"{price:N0} VNĐ";
            lblSubject.Text = subject;
            txtDesc.Text = description;
            // Lấy ảnh theo subjectID (đã add s01, s02, ... vào Resources)
            guna2PictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(SubjectID);
           
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public event EventHandler OnDeleteCourse;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OnDeleteCourse?.Invoke(this, e);
        }

        public event EventHandler<string> OnEditCourse;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OnEditCourse?.Invoke(this, CourseID);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblTeacher_Click(object sender, EventArgs e)
        {

        }
    }
}
