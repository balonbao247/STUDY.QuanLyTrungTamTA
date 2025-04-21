using System;

namespace DTO
{
    public class DTO_Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string SubjectID { get; set; }   // Mã môn học
        public string TimeSlotID { get; set; }  // Mã thời gian

        // Constructor không tham số
        public DTO_Course() { }

        // Constructor có tham số (tuỳ chọn, nếu cần)
        public DTO_Course(string courseId, string courseName, DateTime startDate, DateTime endDate, decimal price, bool isActive, string subjectId, string timeSlotId)
        {
            CourseID = courseId;
            CourseName = courseName;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            IsActive = isActive;
            SubjectID = subjectId;
            TimeSlotID = timeSlotId;
        }
    }
}
