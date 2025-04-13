using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Student: DTO_Person
    {
        // Các thuộc tính của Student
        public string StudentID { get; set; }
        // Constructor to create new student with 8 parameters
        public DTO_Student(string studentID, string fullName, string gender, DateTime dateOfBirth,
                            string phoneNumber, string email, string address, string identityNumber)
        {
            StudentID = studentID;
            FullName = fullName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            IdentityNumber = identityNumber;
        }
        public DTO_Student()
        {
            // Constructor không tham số
        }


        // Constructor để khởi tạo từ DataRow
        public DTO_Student(DataRow row)
        {
            StudentID = row["StudentID"].ToString();
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
