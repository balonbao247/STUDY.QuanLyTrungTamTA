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
    }
}
