using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Resources
{
    public partial class Dashboard: Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
       
            decimal income = BUS_CourseStudent.Instance.GetTotalIncome();
            decimal expense = BUS_Teacher.Instance.GetTotalExpense();
            int StudentCount = BUS_Student.Instance.GetTotalStudent();
            int TeacherCount = BUS_Teacher.Instance.GetTotalTeachers();


            lblStudent.Text = StudentCount.ToString();
            lblTeacher.Text = TeacherCount.ToString();

            lblIncome.Text = income.ToString("N0") + " VNĐ";
            lblExpense.Text = expense.ToString("N0") + " VNĐ";

            var data = DAL_Course.Instance.GetCourseCountBySubject();

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // Tạo Legend (chú thích)
            Legend legend = new Legend
            {
                Docking = Docking.Right,
                Font = new Font("Segoe UI", 10),
                Alignment = StringAlignment.Center
            };
            chart1.Legends.Add(legend);

            // Tạo series
            var series = new Series
            {
                ChartType = SeriesChartType.Pie,
                Font = new Font("Segoe UI", 10),
                IsValueShownAsLabel = true,            // Hiện số lượng hoặc %
                LabelForeColor = Color.Black,           // Màu chữ
                ["PieLabelStyle"] = "Inside",            // Label nằm bên trong
                ["PieDrawingStyle"] = "SoftEdge"         // Bo tròn các khối
            };

            foreach (var item in data)
            {
                // Xử lý bỏ "Tiếng Anh " ở đầu
                string subjectName = item.Key;
                if (subjectName.StartsWith("Tiếng Anh "))
                {
                    subjectName = subjectName.Substring("Tiếng Anh ".Length);
                }

                int pointIndex = series.Points.AddXY(subjectName, item.Value);
                series.Points[pointIndex].LegendText = subjectName;
                series.Points[pointIndex].Label = string.Format("{0}%", Math.Round((double)item.Value * 100 / data.Values.Sum(), 1));
            }

            // Thêm màu ngẫu nhiên cho từng phần
            Random rnd = new Random();
            foreach (var point in series.Points)
            {
                point.Color = Color.FromArgb(rnd.Next(100, 256), rnd.Next(100, 256), rnd.Next(100, 256));
            }

            chart1.Series.Add(series);

            // Thêm tiêu đề
            Title title = new Title("Tỷ lệ khoá học theo môn", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.Black);
            chart1.Titles.Add(title);
        }

        private void guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {
           

        }
    }
}
