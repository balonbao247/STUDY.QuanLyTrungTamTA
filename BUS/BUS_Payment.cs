using System;
using System.Collections.Generic;
using DAL;
using DTO;
namespace BUS
{
   

    namespace BUS
    {
        public class BUS_Payment
        {
            private static BUS_Payment instance;

            public static BUS_Payment Instance
            {
                get { if (instance == null) instance = new BUS_Payment(); return instance; }
            }

            // Lấy danh sách thanh toán của học viên theo khóa học
            public List<DTO_Payment> GetPaymentsByCourseID(string courseID)
            {
                // Business logic: kiểm tra khóa học hợp lệ trước khi truy vấn dữ liệu
                if (string.IsNullOrEmpty(courseID))
                    throw new ArgumentException("Course ID không hợp lệ");

                return DAL_Payment.Instance.GetPaymentsByCourseID(courseID);
            }

            // Lấy thông tin thanh toán của một học viên
            public DTO_Payment GetPaymentByStudentIDAndCourseID(string studentID, string courseID)
            {
                // Business logic: kiểm tra thông tin học viên và khóa học hợp lệ
                if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(courseID))
                    throw new ArgumentException("Student ID hoặc Course ID không hợp lệ");

                return DAL_Payment.Instance.GetPaymentByStudentIDAndCourseID(studentID, courseID);
            }

            // Thêm mới một bản ghi thanh toán
            public bool CreatePayment(string studentID, string courseID, decimal totalAmount)
            {
                // Business logic: kiểm tra tính hợp lệ của các thông tin đầu vào
                if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(courseID))
                    throw new ArgumentException("Student ID hoặc Course ID không hợp lệ");

                if (totalAmount <= 0)
                    throw new ArgumentException("Số tiền thanh toán phải lớn hơn 0");

                // Call the DAL layer to insert the payment
                return DAL_Payment.Instance.CreatePayment(studentID, courseID, totalAmount);
            }
            // Cập nhật thông tin thanh toán 
            public bool UpdatePayment(string paymentID, string studentID, string courseID,decimal totalAmount, string paymentStatus, string paymentMethod, string paymentDate)
            {
                try
                {
                    // Gọi DAL để thực hiện cập nhật trong cơ sở dữ liệu
                    bool result = DAL_Payment.Instance.UpdatePayment(paymentID, studentID, courseID, totalAmount, paymentStatus, paymentMethod,paymentDate);
                    return result; // Trả về kết quả của việc cập nhật
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi khi cập nhật thanh toán: " + ex.Message);
                    return false;
                }
            }

            // Xóa một bản ghi thanh toán
            public bool DeletePayment(int paymentID)
            {
                // Business logic: kiểm tra ID thanh toán hợp lệ
                if (paymentID <= 0)
                    throw new ArgumentException("Payment ID không hợp lệ");

                return DAL_Payment.Instance.DeletePayment(paymentID);
            }
            // Lấy tất cả thanh toán
            public List<DTO_Payment> GetAllPayments()
            {
                return DAL_Payment.Instance.GetAllPayments();
            }

        }
    }

}
