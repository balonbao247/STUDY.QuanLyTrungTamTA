using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Teacher
    {
        public int TeacherID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }

        public DTO_Teacher() { }

        public DTO_Teacher(DataRow row)
        {
            TeacherID = Convert.ToInt32(row["TeacherID"]);
            FullName = row["FullName"].ToString();
            PhoneNumber = row["PhoneNumber"].ToString();
            Email = row["Email"].ToString();
            Specialty = row["Specialty"].ToString();
        }
    }
}
