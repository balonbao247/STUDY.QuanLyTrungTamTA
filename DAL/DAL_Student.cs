using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Student
    {
        private static DAL_Student instance;

        public static DAL_Student Instance
        {
            get { if (instance == null) instance = new DAL_Student(); return instance; }
            private set { instance = value; }
        }

        // Lấy StudentID tiếp theo
        public string GetNextStudentID()
        {
            string query = "SELECT TOP 1 StudentID FROM Students ORDER BY StudentID DESC";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["StudentID"].ToString(); // VD: STU000045
                int number = int.Parse(lastID.Substring(3));        // Lấy "000045" → 45
                number++;
                return "STU" + number.ToString("D6");               // STU000046
            }
            else
            {
                return "STU000001"; // Mã đầu tiên
            }
        }

        // Thêm sinh viên mới
        public bool InsertStudent(DTO_Student student)
        {
            string query = "INSERT INTO Students (StudentID, FullName, Gender, DateOfBirth, PhoneNumber, Email, Address, IdentityNumber) " +
                           "VALUES (@StudentID, @FullName, @Gender, @DateOfBirth, @PhoneNumber, @Email, @Address, @IdentityNumber)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", student.StudentID),
                new SqlParameter("@FullName", student.FullName),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@Address", student.Address),
                new SqlParameter("@IdentityNumber", student.IdentityNumber)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật thông tin sinh viên
        public bool UpdateStudent(DTO_Student student)
        {
            string query = "UPDATE Students SET " +
                           "FullName = @FullName, Gender = @Gender, DateOfBirth = @DateOfBirth, PhoneNumber = @PhoneNumber, " +
                           "Email = @Email, Address = @Address, IdentityNumber = @IdentityNumber " +
                           "WHERE StudentID = @StudentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", student.StudentID),
                new SqlParameter("@FullName", student.FullName),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@Address", student.Address),
                new SqlParameter("@IdentityNumber", student.IdentityNumber)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa sinh viên
        public bool DeleteStudent(string studentID)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Lấy tất cả sinh viên
        public List<DTO_Student> GetAllStudents()
        {
            string query = "SELECT * FROM Students";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query); // Thực thi truy vấn

            List<DTO_Student> students = new List<DTO_Student>();

            // Duyệt qua từng dòng dữ liệu và chuyển thành đối tượng DTO_Student
            foreach (DataRow row in dt.Rows)
            {
                students.Add(new DTO_Student(row)); // Sử dụng constructor của DTO_Student để chuyển dữ liệu thành đối tượng
            }

            return students;
        }

        // Lấy thông tin sinh viên theo StudentID
        public DTO_Student GetStudentByID(string studentID)
        {
            string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return new DTO_Student(dt.Rows[0]); // Trả về đối tượng DTO_Student từ dòng dữ liệu đầu tiên
            }

            return null; // Nếu không tìm thấy sinh viên
        }
    }
}
