using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Student
    {
        private DAL_Student dalStudent = new DAL_Student();

        public List<DTO_Student> GetStudentList()
        {
            return dalStudent.GetAllStudents();
        }
    }
}
