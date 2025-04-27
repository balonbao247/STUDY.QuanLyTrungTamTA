using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_CourseStudent
    {
        private static DAL_CourseStudent instance;

        public static DAL_CourseStudent Instance
        {
            get { if (instance == null) instance = new DAL_CourseStudent(); return instance; }
        }

        private DAL_CourseStudent() { }

        // Thêm học viên vào khóa học
        public bool AddStudentToCourse(string courseID, string studentID, DateTime enrollDate)
        {
            string query = "INSERT INTO CourseStudent (CourseID, StudentID, EnrollDate) VALUES (@CourseID, @StudentID, @EnrollDate)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@EnrollDate", enrollDate)
            };

            return DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
        // Lấy học viên theo khóa học
        public List<DTO_Student> GetStudentsByCourseID(string courseID)
        {
            string query = @"
        SELECT s.* 
        FROM Students s
        JOIN CourseStudent cs ON s.StudentID = cs.StudentID
        WHERE cs.CourseID = @CourseID
        AND s.IsActive = 1"; 

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@CourseID", courseID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            List<DTO_Student> students = new List<DTO_Student>();

            foreach (DataRow row in dt.Rows)
            {
                students.Add(new DTO_Student(row));
            }

            return students;
        }


        // Kiểm tra xung đột lịch học của học viên (nếu học viên đã học 1 khóa khác cùng ca và ngày trong cùng thời gian)
        public bool IsStudentScheduleConflict(string studentID, int dayOfWeek, string timeSlotID, DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM CourseStudent cs
                JOIN Courses c ON cs.CourseID = c.CourseID
                JOIN CourseSchedule s ON c.CourseID = s.CourseID
                WHERE cs.StudentID = @StudentID
                  AND s.DayOfWeek = @DayOfWeek
                  AND s.TimeSlotID = @TimeSlotID
                  AND c.IsActive = 1
                  AND NOT (c.EndDate < @StartDate OR c.StartDate > @EndDate)
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@DayOfWeek", dayOfWeek),
                new SqlParameter("@TimeSlotID", timeSlotID),
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            object result = DAL_DataProvider.Instance.ExecuteQuery(query, parameters).Rows[0][0];
            return Convert.ToInt32(result) > 0;
        }
        public decimal GetTotalIncome()
        {
            string query = @"
                SELECT ISNULL(SUM(c.Price), 0)
                FROM Courses c
                JOIN CourseStudent cs ON c.CourseID = cs.CourseID
            ";

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }

            return 0; // Nếu không có dữ liệu, trả về 0
        }


    }
}
