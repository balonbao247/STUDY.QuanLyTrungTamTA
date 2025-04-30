using DTO;
using System;
using DAL;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class BUS_Teacher
    {
        // Singleton design pattern
        private static BUS_Teacher instance;
        public static BUS_Teacher Instance
        {
            get { if (instance == null) instance = new BUS_Teacher(); return instance; }
            private set { instance = value; }
        }
        // Thêm một giáo viên mới vào cơ sở dữ liệu
        public bool InsertTeacher(DTO_Teacher teacher)
        {
            // Gọi phương thức DAL để thêm giáo viên
            return DAL_Teacher.Instance.InsertTeacher(teacher);
        }

        // Cập nhật thông tin của giáo viên
        public bool UpdateTeacher(DTO_Teacher teacher)
        {
            // Gọi phương thức DAL để cập nhật thông tin giáo viên
            return DAL_Teacher.Instance.UpdateTeacher(teacher);
        }

        // Xóa giáo viên khỏi cơ sở dữ liệu
        public bool DeleteTeacher(string teacherID)
        {
            // Gọi phương thức DAL để xóa giáo viên
            return DAL_Teacher.Instance.DeleteTeacher(teacherID);
        }

        // Lấy tất cả giáo viên trong cơ sở dữ liệu (nếu cần)
        public List<DTO_Teacher> GetAllTeachers()
        {
            // Gọi phương thức DAL để lấy tất cả giáo viên
            return DAL_Teacher.Instance.GetAllTeachers();
        }
        // Lấy tất cả giáo viên trong cơ sở dữ liệu có active
        public List<DTO_Teacher> GetAllActiveTeachers()
        {
            // Gọi phương thức DAL để lấy tất cả giáo viên
            return DAL_Teacher.Instance.GetAllActiveTeachers();
        }
        //Lấy mã giáo viên tăng dần
        public string GetNextTeacherID()
        {
            return DAL_Teacher.Instance.GetNextTeacherID();
        }
        public string GetTeacherNameByID(string teacherID)
        {
            return DAL_Teacher.Instance.GetTeacherNameByID(teacherID);
        }
        public decimal GetTotalExpense()
        {
            return DAL_Teacher.Instance.GetTotalExpense();
        }
        //Lấy tổng giáo viên
        public int GetTotalTeachers()
        {
            return DAL_Teacher.Instance.GetTotalTeachers();
        }
        public List<(DTO_Teacher Teacher, int TotalMeetings)> GetTeacherSalaries()
        {
            return DAL_Teacher.Instance.GetTeacherSalaries();
        }
        public DataTable GetSalaryTable()
        {
            return DAL_Teacher.Instance.GetSalaryTable();
        }
        public Boolean CheckExistIdentityNumber(string identityNumber)
        {
            return DAL_Teacher.Instance.CheckExistIdentityNumber(identityNumber);
        }

    }
}
