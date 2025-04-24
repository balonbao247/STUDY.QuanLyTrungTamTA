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
      
        int rowIndex = 0;
        int pageNumber = 1;

        
        

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
        { 
            List<DTO_Teacher> teachers = BUS_Teacher.Instance.GetAllActiveTeachers();

            // Gọi hàm xuất PDF
            string filePath = ExportDanhSachGiaoVien(teachers, DateTime.Now);

            // Thông báo và mở file
            MessageBox.Show("Xuất danh sách giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static string ExportDanhSachGiaoVien(List<DTO_Teacher> data, DateTime reportDate)
        {
            string fileName = $"DanhSachGiaoVien_{reportDate:yyyyMMdd_HHmmss}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            Document document = new Document(PageSize.A4.Rotate(), 36, 36, 54, 36);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            Font normalFont = new Font(baseFont, 10);
            Font boldFont = new Font(baseFont, 10);
            Font headerFont = new Font(baseFont, 14);
            Font titleFont = new Font(baseFont, 16);

            document.Add(new Paragraph("BRO ENGLISH", titleFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("Số 7 abc, Thủ Đức, TP.HCM", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("ĐT: 0123456789 - Email: broenglish@email.com", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("DANH SÁCH GIÁO VIÊN", headerFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph($"Ngày xuất: {reportDate:dd/MM/yyyy}", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 5, 15, 20, 25, 15, 15, 10 });

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
            AddCell("Mã GV", boldFont);
            AddCell("Họ Tên", boldFont);
            AddCell("Email", boldFont);
            AddCell("SĐT", boldFont);
            AddCell("Chuyên Môn", boldFont);
            AddCell("Lương", boldFont);

            for (int i = 0; i < data.Count; i++)
            {
                var gv = data[i];
                table.AddCell(new PdfPCell(new Phrase((i + 1).ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(gv.TeacherID, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(gv.FullName, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(gv.Email, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(gv.PhoneNumber, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(gv.Specialty, normalFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase($"{gv.Salary:N0}", normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });
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
