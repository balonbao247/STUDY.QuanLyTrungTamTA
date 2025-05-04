using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Room
    {
        private static BUS_Room instance;

        // Property Instance sử dụng Singleton Pattern
        public static BUS_Room Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_Room();
                return instance;
            }
            private set { instance = value; }
        }
        // Constructor
        public List<DTO_Room> GetAllRooms()
        {
            return DAL_Room.Instance.GetAllRooms();
        }
        // Hàm lấy danh sách phòng học đang hoạt động
        public List<DTO_Room> GetActiveRooms()
        {
            return DAL_Room.Instance.GetActiveRooms();
        }
        // Hàm lấy danh sách phòng học
        public bool InsertRoom(DTO_Room room)
        {
            return DAL_Room.Instance.InsertRoom(room);
        }
        // Hàm lấy thông tin phòng theo ID
        public bool UpdateRoom(DTO_Room room)
        {
            return DAL_Room.Instance.UpdateRoom(room);
        }
        // Hàm xóa phòng học
        public bool DeactivateRoom(string roomID)
        {
            return DAL_Room.Instance.DeactivateRoom(roomID);
        }

        // Hàm kiểm tra phòng trống theo ca và ngày
        public List<DTO_Room> GetAvailableRooms(string timeSlotID, DateTime selectedDate)
        {
            // Gọi DAL để kiểm tra các phòng có sẵn
            return DAL_Room.Instance.GetAvailableRooms(timeSlotID, selectedDate);
        }

        // Hàm kiểm tra phòng có tồn tại không
        public bool CheckRoomAvailability(string roomID, string timeSlotID, DateTime selectedDate)
        {
            return DAL.DAL_Room.Instance.CheckRoomAvailability(roomID, timeSlotID, selectedDate);
        }
        // Hàm lấy thông tin lớp học theo ID
        public string GetCourseIDFromScheduleInfo(string timeSlotID, int dayOfWeek, string roomID)
        {
            return DAL_Room.Instance.GetCourseID(timeSlotID, dayOfWeek, roomID);
        }
        // Hàm lấy danh sách phòng học theo tên
        public string GenerateRoomID()
        {
            return DAL_Room.Instance.GenerateNewRoomID();
        }

        // Hàm kiểm tra tên phòng đã tồn tại chưa
        public bool IsRoomNameExists(string roomName)
        {
            return DAL_Room.Instance.IsRoomNameExists(roomName);
        }


    }
}
