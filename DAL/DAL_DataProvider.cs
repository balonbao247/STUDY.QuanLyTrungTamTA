using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class DAL_DataProvider
    {
        private static string connectionString;
        private static DAL_DataProvider instance;
        public static DAL_DataProvider Instance
        {
            get { if (instance == null) instance = new DAL_DataProvider(); return instance; }
            private set { instance = value; }
        }

        static DAL_DataProvider()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            if (File.Exists("config.txt"))
            {
                StreamReader rd = new StreamReader("config.txt");
                string authMode = rd.ReadLine();
                string server = rd.ReadLine();
                string DataProvider = rd.ReadLine();

                if (authMode == "windows")
                {
                    connectionString = $"Data Source={server};Initial Catalog={DataProvider};Integrated Security=True;";
                }
                else
                {
                    string uid = rd.ReadLine();
                    string pw = rd.ReadLine();
                    connectionString = $"Data Source={server};Initial Catalog={DataProvider};User ID={uid};Password={pw};";
                }

                rd.Close();
            }
            else
            {
                throw new Exception("Không tìm thấy file config.txt!");
            }
        }
        // Phương thức thực thi truy vấn SQL
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Nếu có tham số, thêm chúng vào command
                    if (parameters != null)
                    {
                        string[] parameterNames = query.Split(' ');
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                        }
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(result);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thực thi truy vấn: " + ex.Message);
                }
            }
            return result;
        }
        // Trả về số dòng thành công trong cơ sở dữ liệu sừ dụng cho INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(String query, object[] parameters = null)
        {

            int data = 0;
            // Sử dụng using trong trường hợp SQL Connection có lỗi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở ra một kết nối
                connection.Open();
                // Câu lệnh truy vấn
                SqlCommand cmd = new SqlCommand(query, connection);

                // Được dùng để gán giá trị cho parameters
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, parameters[i++]);
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                // Đóng kết nối
                connection.Close();
            }
            // Trả về bảng dữ liệu
            return data;
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
