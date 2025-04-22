using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_TimeSlot
    {
        private static DAL_TimeSlot instance;

        public static DAL_TimeSlot Instance
        {
            get { if (instance == null) instance = new DAL_TimeSlot(); return instance; }
            private set { instance = value; }
        }

        // Lấy tất cả TimeSlot
        public List<DTO_TimeSlot> GetAllTimeSlots()
        {
            string query = "SELECT * FROM TimeSlot";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_TimeSlot> timeSlots = new List<DTO_TimeSlot>();

            foreach (DataRow row in dt.Rows)
            {
                timeSlots.Add(new DTO_TimeSlot(row)); // Sử dụng constructor của DTO_TimeSlot để chuyển dữ liệu thành đối tượng
            }

            return timeSlots;
        }

        // Lấy thông tin TimeSlot theo ID
        public DTO_TimeSlot GetTimeSlotByID(int timeSlotID)
        {
            string query = "SELECT * FROM TimeSlot WHERE TimeSlotID = @TimeSlotID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TimeSlotID", timeSlotID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return new DTO_TimeSlot(dt.Rows[0]); // Trả về đối tượng DTO_TimeSlot từ dòng dữ liệu đầu tiên
            }

            return null; // Nếu không tìm thấy TimeSlot
        }

        // Thêm TimeSlot mới
        public bool InsertTimeSlot(DTO_TimeSlot timeSlot)
        {
            string query = "INSERT INTO TimeSlot (TimeSlotName, StartTime, EndTime) " +
                           "VALUES (@TimeSlotName, @StartTime, @EndTime)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TimeSlotName", timeSlot.TimeSlotName),
                new SqlParameter("@StartTime", timeSlot.StartTime),
                new SqlParameter("@EndTime", timeSlot.EndTime)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật thông tin TimeSlot
        public bool UpdateTimeSlot(DTO_TimeSlot timeSlot)
        {
            string query = "UPDATE TimeSlot SET TimeSlotName = @TimeSlotName, StartTime = @StartTime, EndTime = @EndTime " +
                           "WHERE TimeSlotID = @TimeSlotID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TimeSlotID", timeSlot.TimeSlotID),
                new SqlParameter("@TimeSlotName", timeSlot.TimeSlotName),
                new SqlParameter("@StartTime", timeSlot.StartTime),
                new SqlParameter("@EndTime", timeSlot.EndTime)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa TimeSlot
        public bool DeleteTimeSlot(int timeSlotID)
        {
            string query = "DELETE FROM TimeSlot WHERE TimeSlotID = @TimeSlotID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TimeSlotID", timeSlotID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
