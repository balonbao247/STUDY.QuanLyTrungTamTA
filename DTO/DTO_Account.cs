using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }

        public DTO_Account() { }

        public DTO_Account(string username, string password, bool isActive, string role)
        {
            Username = username;
            Password = password;
            IsActive = isActive;
            Role = role;
        }
        public DTO_Account(DataRow row)
        {
          

            if (row["Username"] != DBNull.Value)
                Username = row["Username"].ToString();

            if (row["Password"] != DBNull.Value)
                Password = row["Password"].ToString();

            if (row["Role"] != DBNull.Value)
                Role = row["Role"].ToString();

            if (row["IsActive"] != DBNull.Value)
                IsActive = Convert.ToBoolean(row["IsActive"]);
        }
    }

}
