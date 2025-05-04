using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Room
    {
        private static DAL_Room instance;
        public static DAL_Room Instance
        {
            get { if (instance == null) instance = new DAL_Room(); return instance; }
            private set { instance = value; }
        }

        // Lấy tất cả phòng
        public List<DTO_Room> GetAllRooms()
        {
            string query = "SELECT * FROM Rooms";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Room> list = new List<DTO_Room>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DTO_Room(row));
            }

            return list;
        }

        // Lấy danh sách phòng đang hoạt động
        public List<DTO_Room> GetActiveRooms()
        {
            string query = "SELECT * FROM Rooms WHERE IsActive = 1";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Room> list = new List<DTO_Room>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DTO_Room(row));
            }

            return list;
        }
        //
        public bool IsRoomNameExists(string roomName)
        {
            string query = "SELECT * FROM Rooms WHERE RoomName = @RoomName";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@RoomName", roomName)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0;
        }


        //Get id
        public string GenerateNewRoomID()
        {
            string query = "SELECT TOP 1 RoomID FROM Rooms ORDER BY RoomID DESC";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["RoomID"].ToString(); // VD: "R012"
                int numberPart = int.Parse(lastID.Substring(1)); // Cắt "012" → 12
                numberPart++; // Tăng lên 13
                return $"R{numberPart:000}"; // Kết quả: "R013"
            }
            else
            {
                return "R001"; // Nếu chưa có phòng nào
            }
        }


        // Thêm phòng
        public bool InsertRoom(DTO_Room room)
        {
            string query = "INSERT INTO Rooms (RoomID, RoomName, Capacity, IsActive) " +
                           "VALUES (@RoomID, @RoomName, @Capacity, @IsActive)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RoomID", room.RoomID),
                new SqlParameter("@RoomName", room.RoomName),
                new SqlParameter("@Capacity", room.Capacity),
                new SqlParameter("@IsActive", room.IsActive)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật phòng
        public bool UpdateRoom(DTO_Room room)
        {
            string query = "UPDATE Rooms SET RoomName = @RoomName, Capacity = @Capacity, IsActive = @IsActive " +
                           "WHERE RoomID = @RoomID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RoomID", room.RoomID),
                new SqlParameter("@RoomName", room.RoomName),
                new SqlParameter("@Capacity", room.Capacity),
                new SqlParameter("@IsActive", room.IsActive)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa mềm (deactivate)
        public bool DeactivateRoom(string roomID)
        {
            string query = "UPDATE Rooms SET IsActive = 0 WHERE RoomID = @RoomID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RoomID", roomID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Hàm lấy danh sách phòng trống theo ca học và ngày
        public List<DTO_Room> GetAvailableRooms(string timeSlotID, DateTime selectedDate)
        {
            string query = @"
                SELECT r.RoomID, r.RoomName, r.Capacity, r.IsActive
                FROM Rooms r
                LEFT JOIN CourseSchedule cs ON r.RoomID = cs.RoomID
                JOIN Courses c ON cs.CourseID = c.CourseID
                WHERE cs.TimeSlotID = @TimeSlotID
                  AND cs.DayOfWeek = @DayOfWeek
                  AND c.StartDate <= @SelectedDate
                  AND c.EndDate >= @SelectedDate
                  AND c.IsActive = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TimeSlotID", timeSlotID),
                new SqlParameter("@DayOfWeek", (int)selectedDate.DayOfWeek),
                new SqlParameter("@SelectedDate", selectedDate)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            List<DTO_Room> availableRooms = new List<DTO_Room>();

            foreach (DataRow row in dt.Rows)
            {
                availableRooms.Add(new DTO_Room(row)); // Tạo đối tượng DTO_Room từ DataRow
            }

            return availableRooms;
        }
        // Hàm kiểm tra xem phòng có trống hay không
        public bool CheckRoomAvailability(string roomID, string timeSlotID, DateTime selectedDate)
        {
            string query = @"
        SELECT COUNT(*) AS RoomCount
        FROM CourseSchedule cs
        JOIN Courses c ON cs.CourseID = c.CourseID
        WHERE cs.RoomID = @RoomID
          AND cs.TimeSlotID = @TimeSlotID
          AND cs.DayOfWeek = @DayOfWeek
          AND c.StartDate <= @SelectedDate
          AND c.EndDate >= @SelectedDate
          AND c.IsActive = 1";

            // Tạo các tham số cho câu truy vấn SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RoomID", roomID),
                new SqlParameter("@TimeSlotID", timeSlotID),
                new SqlParameter("@DayOfWeek", (int)selectedDate.DayOfWeek), // Convert DayOfWeek sang int (0 = Sunday, 1 = Monday,...)
                new SqlParameter("@SelectedDate", selectedDate)
            };

            // Thực thi câu truy vấn và nhận kết quả
            DataTable result = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            // Kiểm tra nếu có ít nhất 1 lớp trong phòng vào thời gian đó
            int count = Convert.ToInt32(result.Rows[0]["RoomCount"]);

            // Nếu count = 0 thì phòng không có lớp, tức là phòng có sẵn
            return count == 0;
        }

        public string GetCourseID(string timeSlotID, int dayOfWeek, string roomID)
        {
            string query = @"
    SELECT cs.CourseID
    FROM CourseSchedule cs
    JOIN Courses c ON cs.CourseID = c.CourseID
    WHERE cs.TimeSlotID = @TimeSlotID
      AND cs.DayOfWeek = @DayOfWeek
      AND cs.RoomID = @RoomID
      AND c.IsActive = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@TimeSlotID", timeSlotID),
        new SqlParameter("@DayOfWeek", dayOfWeek),
        new SqlParameter("@RoomID", roomID)
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["CourseID"].ToString();
            }

            return null; // không tìm thấy
        }



    }
}
