using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Teacher
    {
        private static DAL_Teacher instance;

        public static DAL_Teacher Instance
        {
            get { if (instance == null) instance = new DAL_Teacher(); return instance; }
            private set { instance = value; }
        }
        public string GetNextTeacherID()
        {
            string query = "SELECT TOP 1 TeacherID FROM Teachers ORDER BY TeacherID DESC";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["TeacherID"].ToString(); // VD: TEA000045
                int number = int.Parse(lastID.Substring(3));        // Lấy "000045" → 45
                number++;
                return "TEA" + number.ToString("D6");               // TEA000046
            }
            else
            {
                return "TEA000001"; // Mã đầu tiên
            }
        }
        //insert 
        public bool InsertTeacher(DTO_Teacher teacher)
        {
            string query = "INSERT INTO Teachers (TeacherID, FullName, Gender, DateOfBirth, PhoneNumber, Email, Address, IdentityNumber, Specialty, Salary) " +
                           "VALUES (@TeacherID, @FullName, @Gender, @DateOfBirth, @PhoneNumber, @Email, @Address, @IdentityNumber, @Specialty, @Salary)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherID", teacher.TeacherID),
                new SqlParameter("@FullName", teacher.FullName),
                new SqlParameter("@Gender", teacher.Gender),
                new SqlParameter("@DateOfBirth", teacher.DateOfBirth),
                new SqlParameter("@PhoneNumber", teacher.PhoneNumber),
                new SqlParameter("@Email", teacher.Email),
                new SqlParameter("@Address", teacher.Address),
                new SqlParameter("@IdentityNumber", teacher.IdentityNumber),
                new SqlParameter("@Specialty", teacher.Specialty),
                new SqlParameter("@Salary", teacher.Salary)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool UpdateTeacher(DTO_Teacher teacher)
        {
            string query = @"UPDATE Teachers SET 
                        FullName = @FullName, 
                        Gender = @Gender, 
                        DateOfBirth = @DateOfBirth, 
                        PhoneNumber = @PhoneNumber, 
                        Email = @Email, 
                        Address = @Address, 
                        IdentityNumber = @IdentityNumber,
                        Specialty = @Specialty,
                        Salary = @Salary 
                    WHERE TeacherID = @TeacherID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherID", teacher.TeacherID),
                new SqlParameter("@FullName", teacher.FullName),
                new SqlParameter("@Gender", teacher.Gender),
                new SqlParameter("@DateOfBirth", teacher.DateOfBirth),
                new SqlParameter("@PhoneNumber", teacher.PhoneNumber),
                new SqlParameter("@Email", teacher.Email),
                new SqlParameter("@Address", teacher.Address),
                new SqlParameter("@IdentityNumber", teacher.IdentityNumber),
                new SqlParameter("@Specialty", teacher.Specialty),
                new SqlParameter("@Salary", teacher.Salary)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        //delete
        public bool DeleteTeacher(string teacherID)
        {
            string query = "UPDATE Teachers SET IsActive = 0 WHERE TeacherID = @TeacherID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherID", teacherID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0; // Trả về true nếu có dòng dữ liệu được xóa
        }
        //get list of teachers
        public List<DTO_Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM Teachers";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query); // Gọi phương thức ExecuteQuery để thực hiện truy vấn

            List<DTO_Teacher> teachers = new List<DTO_Teacher>();

            // Duyệt qua từng dòng trong DataTable và chuyển thành đối tượng DTO_Teacher
            foreach (DataRow row in dt.Rows)
            {
                teachers.Add(new DTO_Teacher(row)); // DTO_Teacher cần có constructor nhận DataRow
            }

            return teachers; // Trả về danh sách giáo viên
        }
        //get list of teachers
        public List<DTO_Teacher> GetAllActiveTeachers()
        {
            string query = "SELECT * FROM Teachers Where isActive=1";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query); // Gọi phương thức ExecuteQuery để thực hiện truy vấn

            List<DTO_Teacher> teachers = new List<DTO_Teacher>();

            // Duyệt qua từng dòng trong DataTable và chuyển thành đối tượng DTO_Teacher
            foreach (DataRow row in dt.Rows)
            {
                teachers.Add(new DTO_Teacher(row)); // DTO_Teacher cần có constructor nhận DataRow
            }

            return teachers; // Trả về danh sách giáo viên
        }

        public string GetTeacherNameByID(string teacherID)
        {
            string query = "SELECT FullName FROM Teachers WHERE TeacherID = @TeacherID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherID", teacherID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["FullName"].ToString();
            }
            return string.Empty;
        }
        // Lấy tổng chi (lương giáo viên)
        public decimal GetTotalExpense()
        {
            string query = "SELECT ISNULL(SUM(Salary), 0) FROM Teachers";

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }

            return 0; // Nếu không có dữ liệu, trả về 0
        }
        // Lấy tổng số giáo viên
        public int GetTotalTeachers()
        {
            string query = "SELECT COUNT(*) FROM Teachers";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0; // Nếu không có dữ liệu, trả về 0
        }
        // Lấy tổng số buổi dạy và lương theo giáo viên

        public DataTable GetSalaryTable()
        {
            string query = @"
    SELECT 
        t.TeacherID,
        t.FullName,
        ISNULL(SUM(c.NumberOfMeetings), 0) AS TotalMeetings,
        t.Salary,
        (ISNULL(SUM(c.NumberOfMeetings), 0) * t.Salary) AS TotalSalary
    FROM Teachers t
    LEFT JOIN Courses c ON t.TeacherID = c.TeacherID AND c.IsActive = 1
    WHERE t.IsActive = 1
    GROUP BY t.TeacherID, t.FullName, t.Salary
    ORDER BY t.FullName";

            return DAL_DataProvider.Instance.ExecuteQuery(query);
        }



        // Phương thức tính lương
        public List<(DTO_Teacher Teacher, int TotalMeetings)> GetTeacherSalaries()
        {
            DataTable dt = GetSalaryTable(); // Lấy bảng lương từ phương thức GetSalaryTable

            List<(DTO_Teacher, int)> teacherSalaries = new List<(DTO_Teacher, int)>();

            foreach (DataRow row in dt.Rows)
            {
                // Tạo DTO_Teacher từ DataRow, kiểm tra các cột cần thiết trước khi gán giá trị
                DTO_Teacher teacher = new DTO_Teacher
                {
                    TeacherID = row["TeacherID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    // Kiểm tra nếu có cột Gender, DateOfBirth, v.v.
                    Gender = row.Table.Columns.Contains("Gender") && row["Gender"] != DBNull.Value ? row["Gender"].ToString() : "",
                    DateOfBirth = row.Table.Columns.Contains("DateOfBirth") && row["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(row["DateOfBirth"]) : DateTime.MinValue,
                    PhoneNumber = row.Table.Columns.Contains("PhoneNumber") && row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : "",
                    Email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Address = row.Table.Columns.Contains("Address") && row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    IdentityNumber = row.Table.Columns.Contains("IdentityNumber") && row["IdentityNumber"] != DBNull.Value ? row["IdentityNumber"].ToString() : "",
                    Specialty = row.Table.Columns.Contains("Specialty") && row["Specialty"] != DBNull.Value ? row["Specialty"].ToString() : "",
                    Salary = row.Table.Columns.Contains("Salary") && row["Salary"] != DBNull.Value ? Convert.ToInt32(row["Salary"]) : 0,
                    IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value ? Convert.ToBoolean(row["IsActive"]) : true
                };

                // Lấy số buổi học từ cột "Tổng Số Buổi"
                int totalMeetings = Convert.ToInt32(row["TotalMeetings"]);

                // Thêm vào danh sách
                teacherSalaries.Add((teacher, totalMeetings));
            }

            return teacherSalaries;
        }
        public bool CheckExistIdentityNumber(string identityNumber)
        {
            string query = "SELECT COUNT(*) FROM Teachers WHERE IdentityNumber = @IdentityNumber";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IdentityNumber", identityNumber)
            };

            // Execute the query to get the result as a DataTable
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            // Extract the count from the first row and first column
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);  // Access the first column of the first row
                return count > 0;  // Return true if count is greater than 0, meaning the IdentityNumber exists
            }

            return false;
        }







    }
}
