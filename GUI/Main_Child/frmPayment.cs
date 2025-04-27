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
namespace GUI
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        //thanh search
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void LoadAllPayments()
        {
            try
            {
                List<DTO_Payment> paymentList = BUS_Payment.Instance.GetAllPayments();  // Replace 'courseID' with the actual course ID you want to filter by

                // Lặp qua danh sách thanh toán và thêm dữ liệu vào DataGridView
                foreach (DTO_Payment payment in paymentList)
                {
                    bool isPaid = payment.PaymentStatus == "Paid";
                    

                    // Tạo mảng các giá trị để thêm vào dòng của DataGridView
                    object[] rowValues = new object[]
                    {
                    payment.PaymentID,
                    payment.StudentID,
                    payment.CourseID,
                    payment.TotalAmount.ToString("N0")+" VNĐ",
                    payment.PaymentDate,
                    payment.PaymentStatus,
                    payment.PaymentMethod,
                    isPaid
                    };
                   
                         // Thêm dòng vào DataGridView
                        dgvPayment.Rows.Add(rowValues);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách thanh toán: " + ex.Message);
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            LoadAllPayments();
        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                // Lấy giá trị của checkbox
                var cellValue = dgvPayment.Rows[e.RowIndex].Cells[7].Value;

                // Kiểm tra checkbox đã được chọn hay chưa (true nếu được chọn, false hoặc null nếu không được chọn)
                bool isChecked = cellValue != null && Convert.ToBoolean(cellValue);

                // Nếu checkbox không được chọn, set giá trị của ComboBox thành null
                if (!isChecked)
                {
                    // "PaymentMethod" là tên cột ComboBox, thay đổi tên này nếu cần
                    dgvPayment.Rows[e.RowIndex].Cells["cmbPaymentMethod"].Value = null;
                }
                if (isChecked)
                {
                    // Khi đánh dấu checkbox, tự động điền ngày thanh toán là ngày hôm nay
                    dgvPayment.Rows[e.RowIndex].Cells["PaymentDate"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    // Nếu bỏ chọn, có thể xóa ngày thanh toán (hoặc để null nếu bạn muốn)
                    dgvPayment.Rows[e.RowIndex].Cells["PaymentDate"].Value = DBNull.Value;
                }

                // Cập nhật trạng thái của ComboBox (read-only) tùy theo trạng thái checkbox
                cmbPaymentMethod.ReadOnly = !isChecked;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                   
                    bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
             

                    // Nếu checkbox được chọn, paymentStatus sẽ là "Paid", nếu không sẽ là "Pending"
                    string paymentStatus = isChecked ? "Paid" : "Pending";

          

                    string paymentMethod = row.Cells["cmbPaymentMethod"].Value?.ToString();
                 

                    // Kiểm tra nếu paymentMethod là null, truyền DBNull.Value
                    if (string.IsNullOrEmpty(paymentMethod))
                    {
                        paymentMethod = "Null";  // Hoặc sử dụng DBNull.Value nếu muốn
                    }
                    


                    // Cập nhật thanh toán cho từng dòng
                    bool isSuccess = BUS_Payment.Instance.UpdatePayment(paymentID, studentID, courseID, totalAmount, paymentStatus, paymentMethod,paymentDate);

                    //if (isSuccess)
                    //{
                    //    // Có thể thêm thông báo hoặc thay đổi trạng thái trong DataGridView nếu cần
                    //    row.Cells["Status"].Value = "Đã lưu"; // Ví dụ: thêm cột trạng thái "Đã lưu"
                    //}
                    //else
                    //{
                    //    // Nếu có lỗi, có thể thêm thông báo trong DataGridView
                    //    row.Cells["Status"].Value = "Lỗi";
                    //}
                }

                MessageBox.Show("Đã lưu tất cả dữ liệu thanh toán!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }

        }
     

    }
}

