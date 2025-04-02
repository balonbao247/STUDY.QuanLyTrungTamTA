using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ClassName { get; set; }

        public DTO_Student(string id, string fullName, DateTime birthDate, string gender,
                           string phone, string email, string address, string className)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            Phone = phone;
            Email = email;
            Address = address;
            ClassName = className;
        }
    }

}
