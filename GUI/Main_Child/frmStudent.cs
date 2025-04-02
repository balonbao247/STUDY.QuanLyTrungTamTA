using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmStudent: Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }
       
        
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        PrintDocument printDocument = new PrintDocument();
        int rowIndex = 0;
        int pageNumber = 1;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            

        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Times New Roman", 20, FontStyle.Bold);
            Font cellFont = new Font("Times New Roman", 15);
            Font smallFont = new Font("Times New Roman", 13);

            int y = 100;
            int x = e.MarginBounds.Left;
            int tableWidth = e.MarginBounds.Width;
            int colCount = dgvStudent.Columns.Count;

            // AUTO-FIT COLUMN WIDTH
            int colWidth = tableWidth / colCount;

            // --- Header ---
            string title = "Students List";
            string broText = "BRO ENGLISH";
            string dateText = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            //Draw "BRO ENGLISH" top-right
            e.Graphics.DrawString(broText, headerFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString(broText, headerFont).Width, y - 70);

            // Centered Title
            SizeF titleSize = e.Graphics.MeasureString(title, headerFont);
            e.Graphics.DrawString(title, headerFont, Brushes.Black, e.MarginBounds.Left + (tableWidth - titleSize.Width) / 2, y - 50);

            // Print Date below title
            SizeF dateSize = e.Graphics.MeasureString(dateText, smallFont);
            e.Graphics.DrawString(dateText, smallFont, Brushes.Black, e.MarginBounds.Left + (tableWidth - dateSize.Width) / 2, y - 25);

            // Draw Column Headers 
            for (int j = 0; j < colCount; j++)
            {
                e.Graphics.DrawRectangle(Pens.Black, x, y, colWidth, 40);
                e.Graphics.DrawString(dgvStudent.Columns[j].HeaderText, cellFont, Brushes.Black, new RectangleF(x, y, colWidth, 40));
                x += colWidth;
            }

            y += 40;
            x = e.MarginBounds.Left;

            // Draw Rows
            while (rowIndex < dgvStudent.Rows.Count)
            {
                DataGridViewRow row = dgvStudent.Rows[rowIndex];
                if (!row.IsNewRow)
                {
                    x = e.MarginBounds.Left;
                    for (int j = 0; j < colCount; j++)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x, y, colWidth, 40);
                        e.Graphics.DrawString(row.Cells[j].FormattedValue?.ToString() ?? "", cellFont, Brushes.Black, new RectangleF(x, y, colWidth, 40));
                        x += colWidth;
                    }
                    y += 40;
                }
                rowIndex++;

                // --- Auto Page Break ---
                if (y > e.MarginBounds.Bottom - 60)
                {
                    e.HasMorePages = true;
                    pageNumber++;
                    return;
                }
            }

            //Footer --- Page Number bottom right
            string pageNumText = $"Page {pageNumber}";
            e.Graphics.DrawString(pageNumText, smallFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString(pageNumText, smallFont).Width, e.MarginBounds.Bottom + 20);

            // Reset for next
            rowIndex = 0;
            pageNumber = 1;
            e.HasMorePages = false;
        }

        private void guna2dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         
        
        private void Student_Load(object sender, EventArgs e)
        {
            dgvStudent.Rows.Clear();

            // Lấy danh sách học viên từ Business Layer
            List<DTO_Student> list = BUS_Employee.Instance.GetStudentList();

            // Duyệt qua danh sách học viên và thêm vào DataGridView
            foreach (DTO_Student item in list)
            {
                // Tạo mảng các giá trị để thêm vào dòng của DataGridView
                object[] rowValues = new object[]
                {
            item.StudentID,            // ID học viên
            item.FullName,             // Tên học viên
            item.Gender,               // Giới tính
            item.DateOfBirth.ToString("dd/MM/yyyy"), // Ngày sinh (định dạng ngày tháng)
            item.PhoneNumber,          // Số điện thoại
            item.Email,                 // Email
            item.Address,              // Địa chỉ
            item.IdentityNumber       // Số chứng minh nhân dân / CCCD
            
                };

                // Thêm dòng vào DataGridView
                dgvStudent.Rows.Add(rowValues);
            }
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   

        }

        private void btnIn(object sender, EventArgs e)
        {
            // Setup
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            // Optional Preview
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument;
            ppd.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           Student_Load(sender, e);
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            Student_Load(sender, e);
        }
    }
}
