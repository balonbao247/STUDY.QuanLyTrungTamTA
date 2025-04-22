using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.ADD_Form;
using Guna.UI2.WinForms;
namespace GUI
{
    public partial class frmTeacher: Form
    {
        public frmTeacher()
        {
            InitializeComponent();
        }
       
        //thanh search
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            List<DTO_Teacher> allTeachers = BUS_Teacher.Instance.GetAllActiveTeachers();

            // Lọc danh sách theo tên vAo mã học viên
            var filtered = allTeachers
                .Where(s => s.FullName.ToLower().Contains(keyword) || s.TeacherID.ToLower().Contains(keyword))
                .ToList();

            // Cập nhật lại DataGridView
            dgvTeacher.Rows.Clear();

            foreach (DTO_Teacher item in filtered)
            {
                object[] rowValues = new object[]
                {
                item.TeacherID,
                item.FullName,
                item.Gender,
                item.DateOfBirth.ToString("dd/MM/yyyy"),
                item.PhoneNumber,
                item.Email,
                item.Address,
                item.IdentityNumber
                };

                dgvTeacher.Rows.Add(rowValues);
            }
        }
        PrintDocument printDocument = new PrintDocument();
        int rowIndex = 0;
        int pageNumber = 1;

        
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Times New Roman", 20, FontStyle.Bold);
            Font cellFont = new Font("Times New Roman", 15);
            Font smallFont = new Font("Times New Roman", 13);

            int y = 100;
            int x = e.MarginBounds.Left;
            int tableWidth = e.MarginBounds.Width;
            int colCount = dgvTeacher.Columns.Count;

            // AUTO-FIT COLUMN WIDTH
            int colWidth = tableWidth / colCount;

            // --- Header ---
            string title = "Teachers List";
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
                e.Graphics.DrawString(dgvTeacher.Columns[j].HeaderText, cellFont, Brushes.Black, new RectangleF(x, y, colWidth, 40));
                x += colWidth;
            }

            y += 40;
            x = e.MarginBounds.Left;

            // Draw Rows
            while (rowIndex < dgvTeacher.Rows.Count)
            {
                DataGridViewRow row = dgvTeacher.Rows[rowIndex];
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

        private void guna2dgvTeacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Teacher_Load(object sender, EventArgs e)
        {
            dgvTeacher.Rows.Clear();

            // Lấy danh sách học viên từ Business Layer
            List<DTO_Teacher> list = new BUS_Teacher().GetAllActiveTeachers();  // Khởi tạo đối tượng BUS_Teacher
           

            // Duyệt qua danh sách học viên và thêm vào DataGridView
            foreach (DTO_Teacher item in list)
            {
                // Tạo mảng các giá trị để thêm vào dòng của DataGridView
                object[] rowValues = new object[]
                {
                    item.TeacherID,            // ID học viên
                    item.FullName,             // Tên học viên
                    item.Gender,               // Giới tính
                    item.DateOfBirth.ToString("dd/MM/yyyy"), // Ngày sinh (định dạng ngày tháng)
                    item.PhoneNumber,          // Số điện thoại
                    item.Email,                // Email
                    item.Address,              // Địa chỉ
                    item.IdentityNumber,        // Số chứng minh nhân dân / CCCD
                    item.Specialty,
                    item.Salary
                };

                // Thêm dòng vào DataGridView
                dgvTeacher.Rows.Add(rowValues);
            }
        }


        private void dgvTeacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không nhấn vào header
            {
                dgvTeacher.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeacher.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa học viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvTeacher.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            string TeacherID = row.Cells[0].Value.ToString();
                            bool success = BUS_Teacher.Instance.DeleteTeacher(TeacherID);

                            if (success)
                            {
                                dgvTeacher.Rows.Remove(row); // Xóa khỏi DataGridView
                            }
                        }
                    }
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void iconButton1_Click(object sender, EventArgs e)
        {
           Teacher_Load(sender, e);
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            Teacher_Load(sender, e);
        }

        private void dgvTeacher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTeacher.Columns[e.ColumnIndex].Name == "Edit")
            {
                var btnCell = dgvTeacher.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                btnCell.Style.BackColor = Color.DodgerBlue;
                btnCell.Style.ForeColor = Color.White;
                btnCell.FlatStyle = FlatStyle.Flat;
            }
        }

        // Chỉnh sửa thông tin học viên
        private void dgvTeacher_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có học viên nào được chọn không
            if (dgvTeacher.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true; // Bật nút Chỉnh sửa khi có học viên được chọn
                btnDelete.Enabled = true; // Bật nút Xóa khi có học viên được chọn
            }
            else
            {
                btnEdit.Enabled = false; // Tắt nút Chỉnh sửa nếu không có học viên nào được chọn
                btnDelete.Enabled = false; // Tắt nút Xóa nếu không có học viên nào được chọn
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTeacher.SelectedRows[0];

            // ✅ Tạo DTO_Teacher từ dòng được chọn
            DTO_Teacher selectedTeacher = new DTO_Teacher
            {
                TeacherID = row.Cells[0].Value.ToString(),
                FullName = row.Cells[1].Value.ToString(),
                Gender = row.Cells[2].Value.ToString(),
                DateOfBirth = DateTime.ParseExact(row.Cells[3].Value.ToString(), "dd/MM/yyyy", null),
                PhoneNumber = row.Cells[4].Value.ToString(),
                Email = row.Cells[5].Value.ToString(),
                Address = row.Cells[6].Value.ToString(),
                IdentityNumber = row.Cells[7].Value.ToString(),
                Specialty = row.Cells[8].Value.ToString(),
                Salary = int.Parse(row.Cells[9].Value.ToString())
            };

            FormEDITTeacher formEDITTeacher = new FormEDITTeacher(selectedTeacher);
            BlurBackground blurBackground = new BlurBackground();
            blurBackground.Show();
            formEDITTeacher.ShowDialog();
            formEDITTeacher.FormClosed += (s, args) =>
            {
                blurBackground.Close();
            };
            //Mở FormAddTeacher
            // Khi form đóng lại, load lại danh sách
            Teacher_Load(null, null);
        }

        

        private void btnADD_Click(object sender, EventArgs e)
        {
            FormADDTeacher formADDTeacher = new FormADDTeacher();
            BlurBackground blurBackground = new BlurBackground();
            blurBackground.Show();
            formADDTeacher.ShowDialog();
            formADDTeacher.FormClosed += (s, args) =>
            {
                blurBackground.Close();
            };
            //Mở FormAddTeacher
            // Khi form đóng lại, load lại danh sách
            Teacher_Load(null, null);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        { // Setup
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            // Optional Preview
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument;
            ppd.ShowDialog();
        }
    }
}
