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
using BUS.BUS;
using System.Diagnostics;

namespace GUI
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        // Load form payment
        private void frmPayment_Load(object sender, EventArgs e)
        {
            //Gọi hàm load cho DataGridView
            LoadAllPayments();
        }

        // Gọi từ TextChanged của ô search
        private void txtPaymentSearch_TextChanged(object sender, EventArgs e)
        {
            //Gọi hàm load cho DataGridView
            LoadPaymentGrid();
        }

        // Gọi từ SelectedIndexChanged của combo
        private void cboPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPaymentGrid();
        }

        //Hàm load dữ liệu thanh toán vào DataGridView
        public void LoadAllPayments()
        {
            try
            {   // Xóa tất cả các dòng hiện có trong DataGridView trước khi thêm dữ liệu mới
                dgvPayment.Rows.Clear();

                // Lấy danh sách thanh toán từ lớp BUS
                List<DTO_Payment> paymentList = BUS_Payment.Instance.GetAllPayments();  // Replace 'courseID' with the actual course ID you want to filter by

                // Lặp qua danh sách thanh toán và thêm dữ liệu vào DataGridView
                foreach (DTO_Payment payment in paymentList)
                {
                    // Tạo mảng các giá trị để thêm vào dòng của DataGridView
                    object[] rowValues = new object[]
                    {
                    payment.PaymentID,
                    payment.StudentID,
                    payment.CourseID,
                    payment.TotalAmount.ToString("N0")+" VNĐ",
                    payment.PaymentDate,
                    payment.PaymentStatus,
                    payment.PaymentMethod
    
                    };
                   
                    // Thêm dòng vào DataGridView
                  
                    int rowIndex = dgvPayment.Rows.Add(rowValues);
                    DataGridViewRow addedRow = dgvPayment.Rows[rowIndex];

                    // Nếu PaymentMethod là Bank Transfer hoặc Direct Payment => Disable hàng
                    if (payment.PaymentMethod == "Bank Transfer" || payment.PaymentMethod == "Direct Payment")
                    {
                        addedRow.ReadOnly = true;
                        addedRow.DefaultCellStyle.BackColor =System.Drawing.Color.FromArgb(230, 230, 230); // Tuỳ chọn: đổi màu để nhìn rõ
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách thanh toán: " + ex.Message);
            }
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvPayment.Rows)
                {
                    if (row.IsNewRow) continue;  // Bỏ qua dòng mới chưa có dữ liệu

                    // Lấy giá trị từ các cột trong DataGridView
                    string paymentID = row.Cells["PaymentID"].Value.ToString();

                    string studentID = row.Cells["StudentID"].Value.ToString();

                    string courseID = row.Cells["CourseID"].Value.ToString();

                    string paymentDate = row.Cells["PaymentDate"].Value?.ToString();


                    string totalAmountStr = row.Cells["TotalAmount"].Value?.ToString();
                    if (!string.IsNullOrEmpty(totalAmountStr))
                    {
                        totalAmountStr = totalAmountStr.Replace(" VNĐ", "").Replace(",", "").Trim();  // Loại bỏ " VNĐ" và dấu phẩy
                    }
                    decimal totalAmount = 0;
                    if (decimal.TryParse(totalAmountStr, out totalAmount) == false)
                    {
                        MessageBox.Show($"Số tiền không hợp lệ cho Payment ID: {paymentID}!");
                        continue;  // Tiếp tục với bản ghi tiếp theo
                    }

                    string paymentMethod = row.Cells["cmbPaymentMethod"].Value?.ToString();
                    paymentMethod = string.IsNullOrEmpty(paymentMethod) ? "Chưa" : paymentMethod;

                    string paymentStatus = (paymentMethod == "Chưa") ? "Pending" : "Paid";
                    bool isSuccess = BUS_Payment.Instance.UpdatePayment(paymentID, studentID, courseID, totalAmount, paymentStatus, paymentMethod, paymentDate);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
            MessageBox.Show("Đã lưu tất cả dữ liệu thanh toán!");
            LoadAllPayments();

        }
        //reload
        private void iconButton2_Click(object sender, EventArgs e)
        {
            LoadAllPayments();
            txtPaymentSearch.Clear();
            cboPaymentStatus.SelectedIndex = 0;
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu (có thể là filtered hoặc full list tuỳ bạn)
                List<DTO_Payment> data = BUS_Payment.Instance.GetAllPayments();

                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Gọi hàm export, hàm sẽ lưu file lên Desktop và trả về đường dẫn
                string filePath = ExportDanhSachPayment(data, DateTime.Now);

                // 3. Thông báo & mở file PDF vừa tạo
                MessageBox.Show($"Xuất PDF thành công:\n{filePath}", "In thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở file với trình đọc PDF mặc định
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in danh sách:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string ExportDanhSachPayment(List<DTO_Payment> data, DateTime reportDate)
        {
            // Tên file: DanhSachThanhToan_yyyyMMdd_HHmmss.pdf
            string fileName = $"DanhSachThanhToan_{reportDate:yyyyMMdd_HHmmss}.pdf";
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName
            );

            // Khởi tạo document (A4 ngang để đủ cột)
            Document document = new Document(PageSize.A4.Rotate(), 36, 36, 54, 36);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Đặt font unicode (Times New Roman)
            BaseFont baseFont = BaseFont.CreateFont(
                "C:\\Windows\\Fonts\\times.ttf",
                BaseFont.IDENTITY_H,
                BaseFont.EMBEDDED
            );
            Font normalFont = new Font(baseFont, 10);
            Font boldFont = new Font(baseFont, 10);
            Font headerFont = new Font(baseFont, 14);
            Font titleFont = new Font(baseFont, 16);

            // Header công ty
            document.Add(new Paragraph("BRO ENGLISH", titleFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("Số 7 ABC, Thủ Đức, TP.HCM", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph("ĐT: 0123456789 - Email: broenglish@email.com", normalFont)
            { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            // Tiêu đề báo cáo
            document.Add(new Paragraph("DANH SÁCH THANH TOÁN", headerFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph($"Ngày xuất: {reportDate:dd/MM/yyyy}", normalFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            // Tạo bảng với 7 cột: STT, PaymentID, StudentID, CourseID, PaymentDate, Status, Method
            PdfPTable table = new PdfPTable(7) { WidthPercentage = 100 };
            // Tỉ lệ rộng các cột
            table.SetWidths(new float[] { 5f, 15f, 15f, 15f, 15f,15f, 15f, 20f });

            // Hàm helper thêm ô header
            void AddHeaderCell(string text)
            {
                PdfPCell cell = new PdfPCell(new Phrase(text, boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment   = Element.ALIGN_MIDDLE,
                    BackgroundColor     = BaseColor.LIGHT_GRAY,
                    Padding             = 5
                };
                table.AddCell(cell);
            }

            // Thêm header
            AddHeaderCell("STT");
            AddHeaderCell("Payment ID");
            AddHeaderCell("Student ID");
            AddHeaderCell("Course ID");
            AddHeaderCell("Số tiền");
            AddHeaderCell("Ngày thanh toán");
            AddHeaderCell("Trạng thái");
            AddHeaderCell("Phương thức");

            // Thêm dữ liệu
            for (int i = 0; i < data.Count; i++)
            {
                var p = data[i];
                // STT
                table.AddCell(new PdfPCell(new Phrase((i + 1).ToString(), normalFont))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding             = 5
                });
                // PaymentID
                table.AddCell(new PdfPCell(new Phrase(p.PaymentID, normalFont)) { Padding = 5 });
                // StudentID
                table.AddCell(new PdfPCell(new Phrase(p.StudentID, normalFont)) { Padding = 5 });
                // CourseID
                table.AddCell(new PdfPCell(new Phrase(p.CourseID, normalFont)) { Padding = 5 });
                // TotalAmount
                table.AddCell(new PdfPCell(new Phrase(p.TotalAmount.ToString("N0") + " VNĐ", normalFont))
                { Padding = 5 });
                // PaymentDate
                table.AddCell(new PdfPCell(new Phrase(p.PaymentDate, normalFont))
                { Padding = 5 });
                // Status
                table.AddCell(new PdfPCell(new Phrase(p.PaymentStatus, normalFont)) { Padding = 5 });
                // Method
                table.AddCell(new PdfPCell(new Phrase(p.PaymentMethod, normalFont)) { Padding = 5 });
            }

            document.Add(table);

            // Footer: ngày, người lập
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(
                $"TP.HCM, ngày {reportDate.Day} tháng {reportDate.Month} năm {reportDate.Year}",
                normalFont
            )
            { Alignment = Element.ALIGN_RIGHT, IndentationRight = 100 });
            document.Add(new Paragraph("NGƯỜI LẬP DANH SÁCH", boldFont)
            { Alignment = Element.ALIGN_RIGHT, IndentationRight = 100 });

            document.Close();
            return filePath;
        }

        // Hàm chung để load lại dgvPayment
        private void LoadPaymentGrid()
        {
            string keyword = txtPaymentSearch.Text.Trim().ToLower();
            string statusFilter = cboPaymentStatus.SelectedItem?.ToString().ToLower() ?? "all";

            // Lấy dữ liệu gốc
            List<DTO_Payment> all = BUS_Payment.Instance.GetAllPayments();

            //  Lọc theo status
            var filtered = (statusFilter == "all")
                ? all
                : all.Where(p => p.PaymentStatus.ToLower() == statusFilter).ToList();

            //  Lọc tiếp theo keyword (PaymentID, StudentID, CourseID)
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered
                    .Where(p =>
                        p.PaymentID.ToLower().Contains(keyword) ||
                        p.StudentID.ToLower().Contains(keyword) ||
                        p.CourseID.ToLower().Contains(keyword)
                    )
                    .ToList();
            }

            //  Đổ dữ liệu lên DataGridView
            dgvPayment.Rows.Clear();
            foreach (var p in filtered)
            {
                int rowIndex = dgvPayment.Rows.Add(
                    p.PaymentID,
                    p.StudentID,
                    p.CourseID,
                    p.TotalAmount.ToString("N0") + " VNĐ",
                    p.PaymentDate,
                    p.PaymentStatus,
                    p.PaymentMethod
                );

                DataGridViewRow addedRow = dgvPayment.Rows[rowIndex];

                // Nếu đã thanh toán qua Bank Transfer hoặc Direct Payment thì khoá dòng
                if (p.PaymentMethod == "Bank Transfer" || p.PaymentMethod == "Direct Payment")
                {
                    addedRow.ReadOnly = true;
                    addedRow.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 230, 230); // Màu xám nhạt
                }
            }
        }

        

        private void dgvPayment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dgvPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo không xử lý dòng header hoặc dòng trống
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var changedColumn = dgvPayment.Columns[e.ColumnIndex].Name;
            if (changedColumn == "cmbPaymentMethod")
            {
                DataGridViewRow row = dgvPayment.Rows[e.RowIndex];
                var selectedValue = row.Cells["cmbPaymentMethod"].Value?.ToString();

                if (!string.IsNullOrEmpty(selectedValue) && selectedValue != "Chưa")
                {
                    row.Cells["PaymentDate"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    row.Cells["PaymentDate"].Value = null; // hoặc "" nếu bạn muốn xoá ngày
                }
            }
        }
    }

}

