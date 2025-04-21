using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_Course
    {
        // CREATE
        public bool AddCourse(DTO_Course course)
        {
            string query = @"INSERT INTO Courses (CourseName, Description, StartDate, EndDate, Price, IsActive, SubjectID, TimeSlotID)
                     VALUES (@CourseName, @Description, @StartDate, @EndDate, @Price, @IsActive, @SubjectID, @TimeSlotID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseName", course.CourseName),
                new SqlParameter("@StartDate", course.StartDate),
                new SqlParameter("@EndDate", course.EndDate),
                new SqlParameter("@Price", course.Price),
                new SqlParameter("@IsActive", course.IsActive),
                new SqlParameter("@SubjectID", course.SubjectID ?? (object)DBNull.Value),  // Thêm SubjectID
                new SqlParameter("@TimeSlotID", course.TimeSlotID ?? (object)DBNull.Value) // Thêm TimeSlotID
            };

            return DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public string GetNextCourseID()
        {
            string query = "SELECT TOP 1 CourseID FROM Courses ORDER BY CourseID DESC";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["CourseID"].ToString(); // VD: C0045
                int number = int.Parse(lastID.Substring(1));       // Lấy "0045" → 45
                number++;
                return "C" + number.ToString("D4");                // → C0046
            }
            else
            {
                return "C0001"; // Mã đầu tiên
            }
        }

        // READ - Get all active courses
        public List<DTO_Course> GetAllCourses()
        {
            List<DTO_Course> courses = new List<DTO_Course>();
            string query = "SELECT * FROM Courses WHERE IsActive = 1";

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_Course course = new DTO_Course
                {
                    CourseID = row["CourseID"].ToString(),
                    CourseName = row["CourseName"].ToString(),
                    StartDate = Convert.ToDateTime(row["StartDate"]),
                    EndDate = Convert.ToDateTime(row["EndDate"]),
                    Price = Convert.ToDecimal(row["Price"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    SubjectID = row["SubjectID"]?.ToString(),   // Lấy SubjectID
                    TimeSlotID = row["TimeSlotID"]?.ToString()  // Lấy TimeSlotID
                };

                courses.Add(course);
            }

            return courses;
        }


        // UPDATE
        public bool UpdateCourse(DTO_Course course)
        {
            string query = @"UPDATE Courses 
                     SET CourseName = @CourseName, Description = @Description,
                         StartDate = @StartDate, EndDate = @EndDate, Price = @Price, 
                         SubjectID = @SubjectID, TimeSlotID = @TimeSlotID
                     WHERE CourseID = @CourseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseName", course.CourseName),
                new SqlParameter("@StartDate", course.StartDate),
                new SqlParameter("@EndDate", course.EndDate),
                new SqlParameter("@Price", course.Price),
                new SqlParameter("@SubjectID", course.SubjectID ?? (object)DBNull.Value),
                new SqlParameter("@TimeSlotID", course.TimeSlotID ?? (object)DBNull.Value),
                new SqlParameter("@CourseID", course.CourseID)
            };

            return DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }


        public bool DeleteCourse(string CourseID)
        {
            string query = "UPDATE Courses SET IsActive = 0 WHERE CourseID = @CourseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseID", CourseID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // GET BY ID (nếu cần)
        public DTO_Course GetCourseById(int courseId)
        {
            string query = "SELECT * FROM Courses WHERE CourseID = @CourseID AND IsActive = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseID", courseId)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new DTO_Course
            {
                CourseID = row["CourseID"].ToString(),
                CourseName = row["CourseName"].ToString(),
           
                StartDate = Convert.ToDateTime(row["StartDate"]),
                EndDate = Convert.ToDateTime(row["EndDate"]),
                Price = Convert.ToDecimal(row["Price"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }
        public string GetSubjectNameByID(string subjectID)
        {
            string query = "SELECT SubjectName FROM Subject WHERE SubjectID = @subjectID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@subjectID", SqlDbType.VarChar) { Value = subjectID }
            };

            DataTable result = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["SubjectName"].ToString();
            }
            return null;
        }
        public string GetDescriptionByID(string subjectID)
        {
            string query = "SELECT Description FROM Subject WHERE SubjectID = @subjectID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@subjectID", SqlDbType.VarChar) { Value = subjectID }
            };

            DataTable result = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["Description"].ToString();
            }
            return null;
        }


    }

}
