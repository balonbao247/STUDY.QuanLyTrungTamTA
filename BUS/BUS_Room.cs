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
        public List<DTO_Room> GetAllRooms()
        {
            return DAL_Room.Instance.GetAllRooms();
        }

        public List<DTO_Room> GetActiveRooms()
        {
            return DAL_Room.Instance.GetActiveRooms();
        }

        public bool InsertRoom(DTO_Room room)
        {
            return DAL_Room.Instance.InsertRoom(room);
        }

        public bool UpdateRoom(DTO_Room room)
        {
            return DAL_Room.Instance.UpdateRoom(room);
        }

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
        public string GetCourseIDFromScheduleInfo(string timeSlotID, int dayOfWeek, string roomID)
        {
            return DAL_Room.Instance.GetCourseID(timeSlotID, dayOfWeek, roomID);
        }
    }
}
