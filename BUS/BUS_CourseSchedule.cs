using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_CourseSchedule
    {
        private static BUS_CourseSchedule instance;

        public static BUS_CourseSchedule Instance
        {
            get { if (instance == null) instance = new BUS_CourseSchedule(); return instance; }
            private set { instance = value; }
        }

        // Lấy tất cả CourseSchedules
        public List<DTO_CourseSchedule> GetAllCourseSchedules()
        {
            return DAL_CourseSchedule.Instance.GetAllCourseSchedules();
        }
        public List<DTO_CourseSchedule> GetAllCourseSchedulesByCourseID(string courseID)
        {
            return DAL_CourseSchedule.Instance.GetCourseSchedulesByCourseID(courseID);
        }


        // Lấy thông tin CourseSchedule theo ScheduleID
        public DTO_CourseSchedule GetCourseScheduleByID(int scheduleID)
        {
            return DAL_CourseSchedule.Instance.GetCourseScheduleByID(scheduleID);
        }

        // Thêm CourseSchedule mới
        public bool InsertCourseSchedule(DTO_CourseSchedule courseSchedule)
        {
            // Kiểm tra hợp lệ dữ liệu trước khi thêm
            if (string.IsNullOrEmpty(courseSchedule.CourseID) || string.IsNullOrEmpty(courseSchedule.RoomID))
            {
                throw new ArgumentException("Thông tin không hợp lệ.");
            }

            return DAL_CourseSchedule.Instance.InsertCourseSchedule(courseSchedule);
        }

        // Cập nhật thông tin CourseSchedule
        public bool UpdateCourseSchedule(DTO_CourseSchedule courseSchedule)
        {
            // Kiểm tra hợp lệ dữ liệu trước khi cập nhật
            if (courseSchedule.ScheduleID <= 0 || string.IsNullOrEmpty(courseSchedule.CourseID)  || string.IsNullOrEmpty(courseSchedule.RoomID))
            {
                throw new ArgumentException("Thông tin không hợp lệ.");
            }

            return DAL_CourseSchedule.Instance.UpdateCourseSchedule(courseSchedule);
        }

        // Xóa CourseSchedule
        public bool DeleteCourseSchedule(int scheduleID)
        {
            // Kiểm tra xem ScheduleID có hợp lệ không
            if (scheduleID <= 0)
            {
                throw new ArgumentException("ScheduleID không hợp lệ.");
            }

            return DAL_CourseSchedule.Instance.DeleteCourseSchedule(scheduleID);
        }

        // Kiểm tra trùng lịch giảng viên/phòng trong cùng ca học và ngày
        public bool IsScheduleConflict(string teacherID, string roomID, string timeSlotID, int dayOfWeek)
        {
            return DAL_CourseSchedule.Instance.IsScheduleConflict(teacherID, roomID, timeSlotID, dayOfWeek);
        }
    }
}
