using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Student
    {
        private string connectionString = "your_connection_string_here";

        public List<DTO_Student> GetAllStudents()
        {
            List<DTO_Student> students = new List<DTO_Student>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new DTO_Student(
                        reader["StudentID"].ToString(),
                        reader["FullName"].ToString(),
                        Convert.ToDateTime(reader["BirthDate"]),
                        reader["Gender"].ToString(),
                        reader["Phone"].ToString(),
                        reader["Email"].ToString(),
                        reader["Address"].ToString(),
                        reader["ClassName"].ToString()
                    ));
                }
            }
            return students;
        }
    }

}
