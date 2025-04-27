using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Student
    {
        // Singleton design pattern
        private static BUS_Student instance;
        public static BUS_Student Instance
        {
            get
            {
                if (instance == null) instance = new BUS_Student();
                return instance;
            }
        }
        // Thêm một giáo viên mới vào cơ sở dữ liệu
        public bool InsertStudent(DTO_Student Student)
        {
            // Gọi phương thức DAL để thêm giáo viên
            return DAL_Student.Instance.InsertStudent(Student);
        }

        // Cập nhật thông tin của giáo viên
        public bool UpdateStudent(DTO_Student Student)
        {
            // Gọi phương thức DAL để cập nhật thông tin giáo viên
            return DAL_Student.Instance.UpdateStudent(Student);
        }

        // Xóa giáo viên khỏi cơ sở dữ liệu
        public bool DeleteStudent(string StudentID)
        {
            // Gọi phương thức DAL để xóa giáo viên
            return DAL_Student.Instance.DeleteStudent(StudentID);
        }

        // Lấy tất cả giáo viên trong cơ sở dữ liệu (nếu cần)
        public List<DTO_Student> GetAllStudents()
        {
            
            return DAL_Student.Instance.GetAllStudents();
        }

        // Lấy tất cả giáo viên trong cơ sở dữ liệu (nếu cần)
        public List<DTO_Student> GetAllActiveStudents()
        {
            return DAL_Student.Instance.GetAllActiveStudents();
        }

        //Lấy mã học viên tăng dần
        public string GetNextStudentID()
        {
            return DAL_Student.Instance.GetNextStudentID();
        }
        //Lấy tổng học viên
        public int GetTotalStudent()
        {
            return DAL_Student.Instance.GetTotalStudents();
        }

    }

}

