using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Account
    {
        private static BUS_Account instance;

        public static BUS_Account Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_Account();
                return instance;
            }
            private set { instance = value; }
        }

        // Thêm tài khoản mới
        public bool InsertAccount(DTO_Account account)
        {
            try
            {
                // Kiểm tra điều kiện hợp lệ của tài khoản trước khi thêm vào cơ sở dữ liệu
                if (string.IsNullOrEmpty(account.Username) || string.IsNullOrEmpty(account.Password))
                    throw new ArgumentException("Username và Password không được để trống");

                return DAL_Account.Instance.InsertAccount(account); // Gọi DAL để thực hiện
            }
            catch (ArgumentException ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi không xác định: {ex.Message}");
                return false;
            }
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(DTO_Account account)
        {
            try
            {
                // Kiểm tra thông tin hợp lệ
                if (string.IsNullOrEmpty(account.Username))
                    throw new ArgumentException("Username không được để trống");

                return DAL_Account.Instance.UpdateAccount(account); // Gọi DAL để thực hiện
            }
            catch (ArgumentException ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi không xác định: {ex.Message}");
                return false;
            }
        }

        // Xóa tài khoản (chuyển trạng thái IsActive = 0)
        public bool DeleteAccount(string accountID)
        {
            try
            {
                // Kiểm tra ID tài khoản hợp lệ
                if (string.IsNullOrEmpty(accountID))
                    throw new ArgumentException("AccountID không được để trống");

                return DAL_Account.Instance.DeleteAccount(accountID); // Gọi DAL để thực hiện
            }
            catch (ArgumentException ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi không xác định: {ex.Message}");
                return false;
            }
        }

        // Lấy tất cả tài khoản
        public List<DTO_Account> GetAllAccounts()
        {
            try
            {
                return DAL_Account.Instance.GetAllAccounts(); // Gọi DAL để thực hiện
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi khi lấy tất cả tài khoản: {ex.Message}");
                return null;
            }
        }

       

        // Lấy tất cả tài khoản đang hoạt động
        public List<DTO_Account> GetAllActiveAccounts()
        {
            try
            {
                return DAL_Account.Instance.GetAllActiveAccounts(); // Gọi DAL để thực hiện
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi khi lấy tài khoản đang hoạt động: {ex.Message}");
                return null;
            }
        }

        // Lấy tổng số tài khoản đang hoạt động
        public int GetTotalActiveAccounts()
        {
            try
            {
                return DAL_Account.Instance.GetTotalActiveAccounts(); // Gọi DAL để thực hiện
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine($"Lỗi khi lấy tổng số tài khoản đang hoạt động: {ex.Message}");
                return 0;
            }
        }

        // Đăng nhập và kiểm tra tài khoản
        public DTO_Account Login(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);

                // Gọi phương thức DAL để kiểm tra tài khoản
                DTO_Account account = DAL_Account.Instance.GetAccountByUsernameAndPassword(username, hashedPassword);
                if (account != null)
                {
                    return account; // Nếu tài khoản hợp lệ, trả về đối tượng account
                }
                else
                {
                    throw new Exception("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và thông báo
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }
        }

        // Hàm lấy email từ username
        public string GetEmailByUsername(string username)
        {
            return DAL_Account.Instance.GetEmailByUsername(username);
        }

        public bool ChangePassword(string username, string newPassword)
        {
            // 1. Hash mật khẩu mới
            string hashedPassword = HashPassword(newPassword);

            // 2. Gọi xuống DAL để update
            return DAL_Account.Instance.ChangePasswordInDatabase(username, hashedPassword);
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // chuyển thành chuỗi hex thường
            }
        }
    }
}
