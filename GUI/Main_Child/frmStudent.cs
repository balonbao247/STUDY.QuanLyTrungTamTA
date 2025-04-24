using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.ADD_Form;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace GUI
{
    public partial class frmStudent: Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }
       
        //thanh search
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            List<DTO_Student> allStudents = BUS_Student.Instance.GetAllActiveStudents();

            // Lọc danh sách theo tên vAo mã học viên
            var filtered = allStudents
                .Where(s => s.FullName.ToLower().Contains(keyword) || s.StudentID.ToLower().Contains(keyword))
                .ToList();

            // Cập nhật lại DataGridView
            dgvStudent.Rows.Clear();

            foreach (DTO_Student item in filtered)
            {
                object[] rowValues = new object[]
                {
                item.StudentID,
                item.FullName,
                item.Gender,
                item.DateOfBirth.ToString("dd/MM/yyyy"),
                item.PhoneNumber,
                item.Email,
                item.Address,
                item.IdentityNumber
                };

                dgvStudent.Rows.Add(rowValues);
            }
        }
       
        int rowIndex = 0;
        int pageNumber = 1;

        //button ADD
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormADDStudent formADDStudent = new FormADDStudent();
            BlurBackground blurBackground = new BlurBackground();
            blurBackground.Show();
            formADDStudent.ShowDialog();
            formADDStudent.FormClosed += (s, args) =>
            {
                blurBackground.Close();
            };
            //Mở FormAddStudent
            // Khi form đóng lại, load lại danh sách
            Student_Load(null, null);

        }
       

        private void guna2dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Student_Load(object sender, EventArgs e)
        {
            dgvStudent.Rows.Clear();

            // Lấy danh sách học viên từ Business Layer
            List<DTO_Student> list = new BUS_Student().GetAllActiveStudents();  // Khởi tạo đối tượng BUS_Student

          
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
                    item.Email,                // Email
                    item.Address,              // Địa chỉ
                    item.IdentityNumber        // Số chứng minh nhân dân / CCCD
                };

                // Thêm dòng vào DataGridView
                dgvStudent.Rows.Add(rowValues);
            }
        }


        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không nhấn vào header
            {
                dgvStudent.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa học viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvStudent.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            string studentID = row.Cells[0].Value.ToString();
                            bool success = BUS_Student.Instance.DeleteStudent(studentID);

                            if (success)
                            {
                                dgvStudent.Rows.Remove(row); // Xóa khỏi DataGridView
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

        private void btnIn(object sender, EventArgs e)
        {
            List<DTO_Student> students = BUS_Student.Instance.GetAllActiveStudents();

            // Gọi hàm xuất PDF
            string filePath = ExportDanhSachHocVien(students, DateTime.Now);

            // Thông báo và mở file
            MessageBox.Show("Xuất danh sách học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           Student_Load(sender, e);
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            Student_Load(sender, e);
        }

     

        // Chỉnh sửa thông tin học viên
        private void dgvStudent_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có học viên nào được chọn không
            if (dgvStudent.SelectedRows.Count > 0)
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
            DataGridViewRow row = dgvStudent.SelectedRows[0];

            // ✅ Tạo DTO_Student từ dòng được chọn
            DTO_Student selectedStudent = new DTO_Student
            {
                StudentID = row.Cells[0].Value.ToString(),
                FullName = row.Cells[1].Value.ToString(),
                Gender = row.Cells[2].Value.ToString(),
                DateOfBirth = DateTime.ParseExact(row.Cells[3].Value.ToString(), "dd/MM/yyyy", null),
                PhoneNumber = row.Cells[4].Value.ToString(),
                Email = row.Cells[5].Value.ToString(),
                Address = row.Cells[6].Value.ToString(),
                IdentityNumber = row.Cells[7].Value.ToString()
            };

            FormEDITStudent formEDITStudent = new FormEDITStudent(selectedStudent);
            BlurBackground blurBackground = new BlurBackground();
            blurBackground.Show();
            formEDITStudent.ShowDialog();
            formEDITStudent.FormClosed += (s, args) =>
            {
                blurBackground.Close();
            };
            //Mở FormAddStudent
            // Khi form đóng lại, load lại danh sách
            Student_Load(null, null);
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
        public static string ExportDanhSachHocVien(List<DTO_Student> data, DateTime reportDate)
        {
            string fileName = $"DanhSachHocVien_{reportDate:yyyyMMdd_HHmmss}.pdf";

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            Document document = new Document(PageSize.A4.Rotate(), 36, 36, 54, 36);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            //writer.PageEvent = new PageEventHelper();
            document.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Define the fonts you need

            Font normalFont = new Font(baseFont, 10);
            Font boldFont = new Font(baseFont, 10);
            Font headerFont = new Font(baseFont, 14);
            Font titleFont = new Font(baseFont, 16);

            document.Add(new Paragraph("BRO ENGLISH", titleFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("Số 7 ABC, Thủ Đức, TP.HCM", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("ĐT: 0123456789 - Email: broenglish@email.com", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("DANH SÁCH HỌC VIÊN", headerFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph($"Ngày xuất: {reportDate:dd/MM/yyyy}", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 5, 20, 25, 25, 15, 10 });

            void AddCell(string text, Font font, int align = Element.ALIGN_CENTER)
            {
                PdfPCell cell = new PdfPCell(new Phrase(text, font))
                {
                    HorizontalAlignment = align,
                    Padding = 5,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                };
                table.AddCell(cell);
            }

            AddCell("STT", boldFont);
            AddCell("Mã Học Viên", boldFont);
            AddCell("Họ Tên", boldFont);
            AddCell("Email", boldFont);
            AddCell("SĐT", boldFont);
            AddCell("Giới Tính", boldFont);

            for (int i = 0; i < data.Count; i++)
            {
                var hv = data[i];
                table.AddCell(new PdfPCell(new Phrase((i + 1).ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(hv.StudentID, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(hv.FullName, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(hv.Email, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(hv.PhoneNumber, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(hv.Gender, normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            }

            document.Add(table);
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph($"TP.HCM, ngày {reportDate.Day} tháng {reportDate.Month} năm {reportDate.Year}", normalFont) { Alignment = Element.ALIGN_RIGHT, IndentationRight = 100 });
            document.Add(new Paragraph("NGƯỜI LẬP DANH SÁCH", boldFont) { Alignment = Element.ALIGN_RIGHT, IndentationRight = 100 });
            document.Close();
            return filePath;
        }

    


    }
}
