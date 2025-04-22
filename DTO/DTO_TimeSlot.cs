using System;
using System.Data;

namespace DTO
{
    public class DTO_TimeSlot
    {
        public string TimeSlotID { get; set; }    // ID của thời gian học
        public string TimeSlotName { get; set; } // Tên ca học (ví dụ: Ca 1, Ca 2)
        public String StartTime { get; set; } // Thời gian bắt đầu
        public String EndTime { get; set; }   // Thời gian kết thúc

        // Constructor mặc định
        public DTO_TimeSlot() { }

        // Constructor với tham số
        public DTO_TimeSlot(string timeSlotID, string timeSlotName, String startTime, String endTime)
        {
            TimeSlotID = timeSlotID;
            TimeSlotName = timeSlotName;
            StartTime = startTime;
            EndTime = endTime;
        }

        // Constructor tạo từ DataRow
        public DTO_TimeSlot(DataRow row)
        {
            TimeSlotID = row["TimeSlotID"].ToString();
            TimeSlotName = row["TimeSlotName"].ToString();
            StartTime = row["StartTime"].ToString();
            EndTime = row["EndTime"].ToString();
        }
    }
}
