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





    }
}
