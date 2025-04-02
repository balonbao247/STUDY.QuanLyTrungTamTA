using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Student
    {
        // Các thuộc tính của Student
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }

        // Constructor để khởi tạo từ DataRow
        public DTO_Student(DataRow row)
        {
            StudentID = Convert.ToInt32(row["StudentID"]);
            FullName = row["FullName"].ToString();
            DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
            Gender = row["Gender"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            Email = row["Email"].ToString();
            Address = row["Address"].ToString();
            IdentityNumber = row["IdentityNumber"].ToString();
        }
    }

}
