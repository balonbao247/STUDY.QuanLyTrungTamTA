using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Account
    {
        private static DAL_Account instance;
        public static DAL_Account Instance
        {
            get
            {
                if (instance == null) instance = new DAL_Account();
                return instance;
            }
            private set { instance = value; }
        }
        //
        // Đăng nhập và kiểm tra tài khoản
        public DTO_Account Login(string username, string password)
        {
            string query = "SELECT * FROM Accounts WHERE Username = @username AND Password = @password";
            SqlParameter[] parameters = {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
        };

            try
            {
                DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    // Chuyển DataRow thành DTO_Account tùy theo class của bạn
                    return new DTO_Account(dt.Rows[0]);
                }
                else
                {
                    return null; // Không đúng username/password
                }
            }
            catch (Exception ex)
            {
                // Có thể log lỗi ở đây nếu cần
                throw new Exception("Lỗi truy vấn Login: " + ex.Message);
            }
        }
        // Thêm tài khoản mới
        public bool InsertAccount(DTO_Account account)
        {
            string query = "INSERT INTO Accounts (Username, Password, Role, IsActive) " +
                           "VALUES (@Username, @Password, @Role, @IsActive)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", account.Username),
                new SqlParameter("@Password", account.Password),
                new SqlParameter("@Role", account.Role),
                new SqlParameter("@IsActive", account.IsActive)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public DTO_Account GetAccountByUsernameAndPassword(string username, string password)
        {
            string query = "SELECT * FROM Accounts WHERE Username = @Username AND Password = @Password AND IsActive = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username),
        new SqlParameter("@Password", password) // Mật khẩu đã được hash trước khi truyền vào
            };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return new DTO_Account(dt.Rows[0]); // Trả về đối tượng DTO_Account
            }
            return null; // Nếu không tìm thấy tài khoản
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(DTO_Account account)
        {
            string query = "UPDATE Accounts SET " +
                           " Password = @Password, Role = @Role, IsActive = @IsActive " +
                           "WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", account.Username),
                new SqlParameter("@Password", account.Password),
                new SqlParameter("@Role", account.Role),
                new SqlParameter("@IsActive", account.IsActive)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa tài khoản (update trạng thái IsActive = 0)
        public bool DeleteAccount(string accountID)
        {
            string query = "UPDATE Accounts SET IsActive = 0 WHERE AccountID = @AccountID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountID", accountID)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Lấy tất cả tài khoản
        public List<DTO_Account> GetAllAccounts()
        {
            string query = "SELECT AccountID, Username, Password, Role, IsActive FROM Accounts";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Account> accounts = new List<DTO_Account>();
            foreach (DataRow row in dt.Rows)
            {
                accounts.Add(new DTO_Account(row));
            }
            return accounts;
        }

        // Lấy tài khoản đang hoạt động
        public List<DTO_Account> GetAllActiveAccounts()
        {
            string query = "SELECT AccountID, Username, Password, Role, IsActive FROM Accounts WHERE IsActive = 1";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Account> accounts = new List<DTO_Account>();
            foreach (DataRow row in dt.Rows)
            {
                accounts.Add(new DTO_Account(row));
            }
            return accounts;
        }



        // Lấy tổng số tài khoản đang hoạt động
        public int GetTotalActiveAccounts()
        {
            string query = "SELECT COUNT(*) AS Total FROM Accounts WHERE IsActive = 1";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Total"]);
            }
            return 0;
        }
        public string GetEmailByUsername(string username)
        {
            // 1. Lấy role từ Accounts
            string queryRole = $"SELECT Role FROM Accounts WHERE Username = '{username}'";
            DataTable dtRole = DAL_DataProvider.Instance.ExecuteQuery(queryRole);

            if (dtRole.Rows.Count == 0)
                return null;

            string role = dtRole.Rows[0]["Role"].ToString();

            // 2. Từ role xác định bảng cần lấy email
            string queryEmail = "";

            if (role == "Teacher")
            {
                queryEmail = $"SELECT Email FROM Teachers WHERE TeacherID = '{username}'";
            }
            else if (role == "Student")
            {
                queryEmail = $"SELECT Email FROM Students WHERE StudentID = '{username}'";
            }
            else
            {
                return null; // Unknown role
            }

            DataTable dtEmail = DAL_DataProvider.Instance.ExecuteQuery(queryEmail);

            if (dtEmail.Rows.Count > 0)
                return dtEmail.Rows[0]["Email"].ToString();
            else
                return null;
        }
        public bool ChangePasswordInDatabase(string username, string newHashedPassword)
        {
            string query = "UPDATE Accounts SET Password = @NewPassword WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username),
        new SqlParameter("@NewPassword", newHashedPassword)
            };

            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

    }
}
