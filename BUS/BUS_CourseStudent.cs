using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_CourseStudent
    {
        private static BUS_CourseStudent instance;

        public static BUS_CourseStudent Instance
        {
            get { if (instance == null) instance = new BUS_CourseStudent(); return instance; }
        }

        private BUS_CourseStudent() { }

        // Hàm kiểm tra xung đột lịch học của học viên
        public bool IsScheduleConflict(string studentID, int dayOfWeek, string timeSlotID, DateTime startDate, DateTime endDate)
        {
            return DAL_CourseStudent.Instance.IsStudentScheduleConflict(studentID, dayOfWeek, timeSlotID, startDate, endDate);
        }
        // Thêm học viên vào khóa học
        public bool AddStudentToCourse(string courseID,string studentID )
        {
            return DAL_CourseStudent.Instance.AddStudentToCourse(courseID, studentID, DateTime.Now);
        }
        // Lấy danh sách học viên theo khóa học
        public List<DTO_Student> GetStudentsByCourseID(string courseID)
        {
            return DAL_CourseStudent.Instance.GetStudentsByCourseID(courseID);
        }
        
        public decimal GetTotalIncome()
        {
            return DAL_CourseStudent.Instance.GetTotalIncome();
        }


    }
}
