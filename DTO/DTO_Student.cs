using System;
using System.Data;

namespace DTO
{
    public class DTO_Student : DTO_Person
    {
        // Mã học viên
        public string StudentID { get; set; }

        // Soft-delete flag
        public bool IsActive { get; set; } = true;  // Mặc định là đang hoạt động

        // Constructor không tham số
        public DTO_Student()
        {
        }

        // Constructor với tham số đầy đủ, bao gồm IsActive (mặc định true)
        public DTO_Student(string studentID, string fullName, string gender, DateTime dateOfBirth,
                          string phoneNumber, string email, string address, string identityNumber,
                          bool isActive = true)
        {
            StudentID      = studentID;
            FullName       = fullName;
            Gender         = gender;
            DateOfBirth    = dateOfBirth;
            PhoneNumber    = phoneNumber;
            Email          = email;
            Address        = address;
            IdentityNumber = identityNumber;
            IsActive       = isActive;
        }

        // Khởi tạo từ DataRow (trong DAL)
        public DTO_Student(DataRow row)
        {
            StudentID      = row["StudentID"].ToString();
            FullName       = row["FullName"].ToString();
            DateOfBirth    = row["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(row["DateOfBirth"]) : default;
            Gender         = row["Gender"].ToString();
            PhoneNumber    = row["PhoneNumber"].ToString();
            Email          = row["Email"].ToString();
            Address        = row["Address"].ToString();
            IdentityNumber = row["IdentityNumber"].ToString();
            // Đọc cột IsActive nếu có, ngược lại giữ mặc định true
            if (row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value)
                IsActive = Convert.ToBoolean(row["IsActive"]);
            else
                IsActive = true;
        }
    }
}
