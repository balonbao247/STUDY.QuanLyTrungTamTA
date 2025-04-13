using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Person
    {
        public string FullName { get; set; }
        public string Gender { get; set; }           // "Nam" hoặc "Nữ"
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
    }
}
