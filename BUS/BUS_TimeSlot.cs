using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_TimeSlot
    {
        private static BUS_TimeSlot instance;

        public static BUS_TimeSlot Instance
        {
            get { if (instance == null) instance = new BUS_TimeSlot(); return instance; }
            private set { instance = value; }
        }

        // Lấy tất cả TimeSlots
        public List<DTO_TimeSlot> GetAllTimeSlots()
        {
            return DAL_TimeSlot.Instance.GetAllTimeSlots();
        }

        // Lấy thông tin TimeSlot theo TimeSlotID
        public DTO_TimeSlot GetTimeSlotByID(int timeSlotID)
        {
            return DAL_TimeSlot.Instance.GetTimeSlotByID(timeSlotID);
        }

        // Thêm TimeSlot mới
        public bool InsertTimeSlot(DTO_TimeSlot timeSlot)
        {
            // Kiểm tra hợp lệ dữ liệu trước khi thêm
            if (string.IsNullOrEmpty(timeSlot.TimeSlotName))
            {
                throw new ArgumentException("Thông tin không hợp lệ.");
            }

            return DAL_TimeSlot.Instance.InsertTimeSlot(timeSlot);
        }

        // Cập nhật thông tin TimeSlot
        public bool UpdateTimeSlot(DTO_TimeSlot timeSlot)
        {
            // Kiểm tra hợp lệ dữ liệu trước khi cập nhật
            if ( string.IsNullOrEmpty(timeSlot.TimeSlotName))
            {
                throw new ArgumentException("Thông tin không hợp lệ.");
            }

            return DAL_TimeSlot.Instance.UpdateTimeSlot(timeSlot);
        }

        // Xóa TimeSlot
        public bool DeleteTimeSlot(int timeSlotID)
        {
            // Kiểm tra xem TimeSlotID có hợp lệ không
            if (timeSlotID <= 0)
            {
                throw new ArgumentException("TimeSlotID không hợp lệ.");
            }

            return DAL_TimeSlot.Instance.DeleteTimeSlot(timeSlotID);
        }
    }
}
