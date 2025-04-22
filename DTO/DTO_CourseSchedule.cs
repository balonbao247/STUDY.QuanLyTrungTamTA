using System;
using System.Data;

public class DTO_CourseSchedule
{
    public int ScheduleID { get; set; }
    public string CourseID { get; set; }
    public int DayOfWeek { get; set; }        
    public string TimeSlotID { get; set; }
    public string RoomID { get; set; }

    // Constructor mặc định
    public DTO_CourseSchedule() { }

    // Constructor đầy đủ tham số
    public DTO_CourseSchedule(int scheduleID, string courseID, int dayOfWeek, string timeSlotID, string roomID)
    {
        ScheduleID = scheduleID;
        CourseID = courseID;
        DayOfWeek = dayOfWeek;
        TimeSlotID = timeSlotID;
        RoomID = roomID;
    }

    // Constructor từ DataRow
    public DTO_CourseSchedule(DataRow row)
    {
        ScheduleID = Convert.ToInt32(row["ScheduleID"]);
        CourseID = row["CourseID"].ToString();
        DayOfWeek = Convert.ToInt32(row["DayOfWeek"]);
        TimeSlotID = row["TimeSlotID"].ToString();
        RoomID = row["RoomID"].ToString();
    }
}
