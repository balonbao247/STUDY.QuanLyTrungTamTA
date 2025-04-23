using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_CourseSchedule
    {
        private static DAL_CourseSchedule instance;

        public static DAL_CourseSchedule Instance
        {
            get { if (instance == null) instance = new DAL_CourseSchedule(); return instance; }
            private set { instance = value; }
        }

        // Lấy tất cả CourseSchedules
        public List<DTO_CourseSchedule> GetAllCourseSchedules()
        {
            string query = "SELECT * FROM CourseSchedule";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_CourseSchedule> courseSchedules = new List<DTO_CourseSchedule>();

            foreach (DataRow row in dt.Rows)
            {
                courseSchedules.Add(new DTO_CourseSchedule(row)); // Sử dụng constructor của DTO_CourseSchedule để chuyển dữ liệu thành đối tượng
            }

            return courseSchedules;
        }
        // Lấy ds
        public List<DTO_CourseSchedule> GetCourseSchedulesByCourseID(string courseID)
        {
            string query = "SELECT * FROM CourseSchedule WHERE CourseID = @CourseID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@CourseID", courseID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            List<DTO_CourseSchedule> courseSchedules = new List<DTO_CourseSchedule>();

            foreach (DataRow row in dt.Rows)
            {
                courseSchedules.Add(new DTO_CourseSchedule(row)); // Sử dụng constructor của DTO_CourseSchedule để chuyển dữ liệu thành đối tượng
            }

            return courseSchedules;
        }


        // Lấy thông tin CourseSchedule theo ScheduleID
        public DTO_CourseSchedule GetCourseScheduleByID(int scheduleID)
        {
            string query = "SELECT * FROM CourseSchedule WHERE ScheduleID = @ScheduleID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ScheduleID", scheduleID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return new DTO_CourseSchedule(dt.Rows[0]); // Trả về đối tượng DTO_CourseSchedule từ dòng dữ liệu đầu tiên
            }

            return null; // Nếu không tìm thấy CourseSchedule
        }

        // Thêm CourseSchedule mới
        public bool InsertCourseSchedule(DTO_CourseSchedule courseSchedule)
        {
            string query = "INSERT INTO CourseSchedule (CourseID, DayOfWeek, TimeSlotID, RoomID) " +
                           "VALUES (@CourseID, @DayOfWeek, @TimeSlotID, @RoomID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseID", courseSchedule.CourseID),
                new SqlParameter("@DayOfWeek", courseSchedule.DayOfWeek),
                new SqlParameter("@TimeSlotID", courseSchedule.TimeSlotID),
                new SqlParameter("@RoomID", courseSchedule.RoomID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật thông tin CourseSchedule
        public bool UpdateCourseSchedule(DTO_CourseSchedule courseSchedule)
        {
            string query = "UPDATE CourseSchedule SET CourseID = @CourseID, DayOfWeek = @DayOfWeek, " +
                           "TimeSlotID = @TimeSlotID, RoomID = @RoomID WHERE ScheduleID = @ScheduleID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ScheduleID", courseSchedule.ScheduleID),
                new SqlParameter("@CourseID", courseSchedule.CourseID),
                new SqlParameter("@DayOfWeek", courseSchedule.DayOfWeek),
                new SqlParameter("@TimeSlotID", courseSchedule.TimeSlotID),
                new SqlParameter("@RoomID", courseSchedule.RoomID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa CourseSchedule
        public bool DeleteCourseSchedule(int scheduleID)
        {
            string query = "DELETE FROM CourseSchedule WHERE ScheduleID = @ScheduleID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ScheduleID", scheduleID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool IsScheduleConflict(string teacherID, string roomID, string timeSlotID, int dayOfWeek)
        {
            string query = @"
                SELECT * FROM CourseSchedule cs
                JOIN Courses c ON cs.CourseID = c.CourseID
                WHERE cs.DayOfWeek = @DayOfWeek
                  AND cs.TimeSlotID = @TimeSlotID
                  AND c.IsActive = 1
                  AND (c.TeacherID = @TeacherID OR cs.RoomID = @RoomID)
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DayOfWeek", dayOfWeek),
                new SqlParameter("@TimeSlotID", timeSlotID),
                new SqlParameter("@TeacherID", teacherID),
                new SqlParameter("@RoomID", roomID)
            };

            DataTable result = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            return result.Rows.Count > 0;
        }

    }
}
