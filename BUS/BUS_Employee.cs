using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Employee
    {
        private static BUS_Employee instance;
        public static BUS_Employee Instance
        {
            get { if (instance == null) instance = new BUS_Employee(); return instance; }
            private set { instance = value; }
        }
        public List<DTO_Student> GetStudentList()
        {
            List<DTO_Student> listStudent = new List<DTO_Student>();

            // Gọi phương thức từ DAL để lấy dữ liệu (DataTable)
            DataTable dataTable = DAL_ForEmployee.Instance.GetListStudent();

            // Duyệt qua từng dòng trong DataTable và chuyển đổi thành đối tượng DTO_Student
            foreach (DataRow data in dataTable.Rows)
            {
                // Chuyển DataRow thành DTO_Student và thêm vào danh sách
                listStudent.Add(new DTO_Student(data));
            }

            // Trả về danh sách học viên
            return listStudent;
        }
        public bool DeleteStudent(int studentID)
        {
            return DAL_ForEmployee.Instance.DeleteStudent(studentID);
        }

        public List<DTO_Teacher> GetTeacherList()
        {
            List<DTO_Teacher> listTeacher = new List<DTO_Teacher>();

            // Gọi phương thức từ DAL để lấy dữ liệu (DataTable)
            DataTable dataTable = DAL_ForEmployee.Instance.GetListTeacher();

            // Duyệt qua từng dòng trong DataTable và chuyển đổi thành đối tượng DTO_Teacher
            foreach (DataRow data in dataTable.Rows)
            {
                // Chuyển DataRow thành DTO_Teacher và thêm vào danh sách
                listTeacher.Add(new DTO_Teacher(data));
            }

            // Trả về danh sách học viên
            return listTeacher;
        }
        public bool DeleteTeacher(int TeacherID)
        {
            return DAL_ForEmployee.Instance.DeleteTeacher(TeacherID);
        }
    }
}
