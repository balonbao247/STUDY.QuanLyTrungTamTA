using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
 

    public class DAL_Payment
    {
        private static DAL_Payment instance;

        public static DAL_Payment Instance
        {
            get { if (instance == null) instance = new DAL_Payment(); return instance; }
        }
        // Lấy danh sách thanh toán của học viên theo khóa học
        public List<DTO_Payment> GetPaymentsByCourseID(string courseID)
        {
            string query = @"
            SELECT * 
            FROM Payments 
            WHERE CourseID = @CourseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@CourseID", courseID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            List<DTO_Payment> payments = new List<DTO_Payment>();

            foreach (DataRow row in dt.Rows)
            {
                payments.Add(new DTO_Payment(row));
            }

            return payments;
        }
        // Lấy PaymentID tiếp theo
        public string GetNextPaymentID()
        {
            string query = "SELECT TOP 1 PaymentID FROM Payments ORDER BY PaymentID DESC";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["PaymentID"].ToString(); // VD: PM000045
                int number = int.Parse(lastID.Substring(2));        // Lấy "000045" → 45
                number++;                                           // Tăng số lên 1
                return "PM" + number.ToString("D6");                 // PM000046
            }
            else
            {
                return "PM000001"; // Mã thanh toán đầu tiên
            }
        }


        // Lấy thông tin thanh toán của một học viên
        public DTO_Payment GetPaymentByStudentIDAndCourseID(string studentID, string courseID)
        {
            string query = @"
            SELECT * 
            FROM Payments 
            WHERE StudentID = @StudentID AND CourseID = @CourseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@StudentID", studentID),
            new SqlParameter("@CourseID", courseID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return new DTO_Payment(dt.Rows[0]);
            }

            return null;  // Trả về null nếu không tìm thấy thông tin thanh toán
        }

        // Thêm mới một bản ghi thanh toán
        public bool CreatePayment(string studentID, string courseID, decimal totalAmount)
        {
            // Generate a new PaymentID
            string paymentID = GetNextPaymentID();

            string query = @"
            INSERT INTO Payments (PaymentID, StudentID, CourseID, TotalAmount, PaymentStatus)
            VALUES (@PaymentID, @StudentID, @CourseID, @TotalAmount, 'Pending')";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PaymentID", paymentID),
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@TotalAmount", totalAmount)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;  // Trả về true nếu thêm thành công
        }

        // Cập nhật thông tin thanh toán (số tiền đã thanh toán, phương thức thanh toán và trạng thái thanh toán)
        public bool UpdatePayment(string paymentID, string studentID, string courseID, decimal totalAmount, string paymentStatus, string paymentMethod, string paymentDate)
        {
            string query = @"
        UPDATE Payments
        SET 
            TotalAmount = @TotalAmount, 
            PaymentStatus = @PaymentStatus, 
            PaymentMethod = @PaymentMethod, 
            StudentID = @StudentID,
            CourseID = @CourseID,
            PaymentDate = @PaymentDate
        WHERE PaymentID = @PaymentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@PaymentID", paymentID),
        new SqlParameter("@StudentID", studentID),
        new SqlParameter("@CourseID", courseID),
        new SqlParameter("@TotalAmount", totalAmount),
        new SqlParameter("@PaymentStatus", paymentStatus),
        new SqlParameter("@PaymentMethod", paymentMethod),
        new SqlParameter("@PaymentDate", paymentDate)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }



        // Xóa một bản ghi thanh toán (nếu cần)
        public bool DeletePayment(int paymentID)
        {
            string query = @"
            DELETE FROM Payments
            WHERE PaymentID = @PaymentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@PaymentID", paymentID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;  // Trả về true nếu xóa thành công
        }
        // Lấy tất cả thanh toán từ bảng Payments
        public List<DTO_Payment> GetAllPayments()
        {
            string query = "SELECT * FROM Payments";

            // Execute the query and get the result as a DataTable
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Payment> payments = new List<DTO_Payment>();

            // Convert each row from the DataTable into a DTO_Payment object
            foreach (DataRow row in dt.Rows)
            {
                payments.Add(new DTO_Payment(row));
            }

            return payments;
        }

    }

}
