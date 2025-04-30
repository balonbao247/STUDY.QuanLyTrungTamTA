using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_StudentAttendance
    {
        private static DAL_StudentAttendance instance;

        public static DAL_StudentAttendance Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAL_StudentAttendance();
                return instance;
            }
            private set { instance = value; }
        }

        private DAL_DataProvider dataProvider = DAL_DataProvider.Instance;

        // Thêm điểm danh cho học viên theo khóa học (dùng stored procedure)
        public void InsertAttendanceForCourse(string courseId, int numberOfClasses)
        {
            // Tạo chuỗi SQL gọi stored procedure trực tiếp
            string sql = $"EXEC InsertAttendanceForCourse '{courseId}', {numberOfClasses}";

            dataProvider.ExecuteNonQuery(sql);
        }

        // Lấy danh sách điểm danh theo học viên
        public DataTable GetAttendanceByStudent(string studentId)
        {
            string query = "SELECT AttendanceID, CourseID, AttendanceDate, Status " +
                           "FROM StudentAttendance WHERE StudentID = @StudentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", SqlDbType.VarChar) { Value = studentId }
            };

            return dataProvider.ExecuteQuery(query, parameters);
        }

        // Lấy danh sách điểm danh theo khóa học
        public DataTable GetAttendanceByCourse(string courseId)
        {
            string query = "SELECT AttendanceID, StudentID, AttendanceDate, Status " +
                           "FROM StudentAttendance WHERE CourseID = @CourseID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseID", SqlDbType.VarChar) { Value = courseId }
            };

            return dataProvider.ExecuteQuery(query, parameters);
        }

        // Cập nhật trạng thái điểm danh
        public void UpdateAttendanceStatus(string attendanceId, string status)
        {
            string query = "UPDATE StudentAttendance SET Status = @Status WHERE AttendanceID = @AttendanceID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AttendanceID", SqlDbType.VarChar) { Value = attendanceId },
                new SqlParameter("@Status", SqlDbType.NVarChar) { Value = status }
            };

            dataProvider.ExecuteNonQuery(query, parameters);
        }
        
        // Lấy danh sách ngày học duy nhất theo khóa học
        public DataTable GetDistinctAttendanceDatesByCourse(string courseId)
        {
            string query = @"
                    SELECT DISTINCT AttendanceDate
                    FROM StudentAttendance
                    WHERE CourseID = @CourseID
                    ORDER BY AttendanceDate"; 

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@CourseID", SqlDbType.VarChar) { Value = courseId }
            };

            return dataProvider.ExecuteQuery(query, parameters);
        }

        public DataTable GetAttendanceByCourseAndDate(string courseId, DateTime attendanceDate)
        {
            string query = "SELECT sa.AttendanceID, sa.StudentID, s.FullName, sa.AttendanceDate, sa.Status " +
                           "FROM StudentAttendance sa " +
                           "JOIN Students s ON sa.StudentID = s.StudentID " +
                           "WHERE sa.CourseID = @CourseID AND sa.AttendanceDate = @Date AND s.IsActive = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@CourseID", courseId),
        new SqlParameter("@Date", attendanceDate.Date)
            };

            return dataProvider.ExecuteQuery(query, parameters);
        }


    }
}
