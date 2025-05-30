﻿using System;
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
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
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
                        cmd.Parameters.AddRange(parameters); // Thêm tất cả tham số vào command
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
        public int ExecuteNonQuery(String query, SqlParameter[] parameters = null)
        {

            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters); // ✅ Add all SqlParameters correctly
                }

                data = cmd.ExecuteNonQuery(); 
                connection.Close();
            }

            return data;
        }
        public int ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(procedureName, connection);
                cmd.CommandType = CommandType.StoredProcedure; // ⚠️ QUAN TRỌNG

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                data = cmd.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
