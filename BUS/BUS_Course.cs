﻿using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Course
    {
        private static BUS_Course instance;

        public static BUS_Course Instance
        {
            get { if (instance == null) instance = new BUS_Course(); return instance; }
            private set { instance = value; }
        }

        // Lấy tất cả khóa học
        public List<DTO_Course> GetAllCourses()
        {
            return DAL_Course.Instance.GetAllCourses();
        }

        // Lấy tất cả khóa học còn hoạt động
        public List<DTO_Course> GetActiveCourses()
        {
            return DAL_Course.Instance.GetAllActiveCourses();
        }

        // Lấy khóa học theo ID
        public DTO_Course GetCourseByID(string courseID)
        {
            return DAL_Course.Instance.GetCourseByID(courseID);
        }

        // Thêm khóa học
        public bool AddCourse(DTO_Course course)
        {
            return DAL_Course.Instance.InsertCourse(course);
        }

        // Cập nhật khóa học
        public bool UpdateCourse(DTO_Course course)
        {
            return DAL_Course.Instance.UpdateCourse(course);
        }

        // Xóa mềm khóa học (IsActive = false)
        public bool DeleteCourse(string courseID)
        {
            return DAL_Course.Instance.DeleteCourse(courseID);
        }
        // Lấy danh sách khóa học theo SubjectID
        public string GetSubjectNameByID(string subjectID)
        {
            return DAL_Course.Instance.GetSubjectNameByID(subjectID);
        }
        // Lấy danh sách khóa học theo SubjectID
        public string GetDescriptionByID(string subjectID)
        {
            return DAL_Course.Instance.GetDescriptionByID(subjectID);
        }
        //lấy ID khóa học tiếp theo
        public string GetNextCourseID()
        {
            return DAL_Course.Instance.GetNextCourseID();
        }
        //Đếm học viên
        public int GetStudentCountByCourseID(string courseID)
        {
            return DAL_Course.Instance.GetStudentCountByCourseID(courseID);
        }
        //
        public Dictionary<string, int> GetCourseCountBySubject()
        {
            return DAL_Course.Instance.GetCourseCountBySubject();
        }
        // Lấy tất cả khóa học theo TeacherID
        public List<DTO_Course> GetCoursesByTeacherID(string teacherID)
        {
            return DAL_Course.Instance.GetActiveCoursesByTeacher(teacherID); // Gọi đến DAL để lấy dữ liệu
        }

        public int CountCourse()
        {
            return DAL_Course.Instance.GetActiveCourseCount();
        }
    }
}
