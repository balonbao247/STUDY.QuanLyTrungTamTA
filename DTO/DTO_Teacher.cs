using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Teacher:DTO_Person
    {
        public string TeacherID { get; set; }
        public string Specialty { get; set; } // <-- sửa chính tả
        public int Salary { get; set; }       // <-- mới thêm

        public bool IsActive { get; set; } = true;  // Mặc định là đang hoạt động

        public DTO_Teacher(string teacherID, string fullName, string gender, DateTime dateOfBirth,
                           string phoneNumber, string email, string address, string identityNumber, string specialty, int salary, bool isActive = true)
        {
            this.TeacherID = teacherID;
            this.FullName = fullName;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.IdentityNumber = identityNumber;
            this.Specialty = specialty;
            this.Salary = salary;
            this.IsActive       = isActive;
        }
        public DTO_Teacher()
        {
            // Constructor không tham số
        }


        // Constructor từ DataRow
        public DTO_Teacher(DataRow row)
        {
            this.TeacherID = row["TeacherID"].ToString();
            this.FullName = row["FullName"].ToString();
            this.Gender = row["Gender"].ToString();
            this.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
            this.PhoneNumber = row["PhoneNumber"].ToString();
            this.Email = row["Email"].ToString();
            this.Address = row["Address"].ToString();
            this.IdentityNumber = row["IdentityNumber"].ToString();
            this.Specialty = row["Specialty"].ToString();
            this.Salary = Convert.ToInt32(row["Salary"]);
            // Đọc cột IsActive nếu có, ngược lại giữ mặc định true
            if (row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value)
                IsActive = Convert.ToBoolean(row["IsActive"]);
            else
                IsActive = true;
        }
    }
}
