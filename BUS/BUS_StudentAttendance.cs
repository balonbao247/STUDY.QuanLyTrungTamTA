using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_StudentAttendance
    {
        private static BUS_StudentAttendance instance;

        public static BUS_StudentAttendance Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_StudentAttendance();
                return instance;
            }
            private set { instance = value; }
        }

        private DAL_StudentAttendance dal = new DAL_StudentAttendance();

        // Thêm danh sách điểm danh cho khóa học
        public void InsertAttendanceForCourse(string courseId, int numberOfClasses)
        {
            dal.InsertAttendanceForCourse(courseId, numberOfClasses);
        }

        // Lấy danh sách điểm danh theo học viên
        public DataTable GetAttendanceByStudent(string studentId)
        {
            return dal.GetAttendanceByStudent(studentId);
        }

        // Lấy danh sách điểm danh theo khóa học
        public DataTable GetAttendanceByCourse(string courseId)
        {
            return dal.GetAttendanceByCourse(courseId);
        }

        // Cập nhật trạng thái điểm danh
        public void UpdateAttendanceStatus(string attendanceId, string status)
        {
            dal.UpdateAttendanceStatus(attendanceId, status);
        }

        // Lấy danh sách điểm danh theo khóa học và ngày
        public DataTable GetDistinctAttendanceDatesByCourse(string courseId)
        {
            return DAL_StudentAttendance.Instance.GetDistinctAttendanceDatesByCourse(courseId);
        }
        // Lấy danh sách điểm danh theo khóa học và ngày
        public DataTable GetAttendanceByCourseAndDate(string courseId, DateTime date)
        {
            return DAL_StudentAttendance.Instance.GetAttendanceByCourseAndDate(courseId, date);
        }
        
    }
}
