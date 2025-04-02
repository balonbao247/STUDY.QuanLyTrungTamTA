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
            DataTable dataTable = DAL_Employee.Instance.GetListStudent();

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
            return DAL_Employee.Instance.DeleteStudent(studentID);
        }
    }
}
