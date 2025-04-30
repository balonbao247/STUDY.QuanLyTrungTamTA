using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Subject
    {
        private static DAL_Subject instance;

        public static DAL_Subject Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAL_Subject();
                return instance;
            }
            private set { instance = value; }
        }

        // Constructor mặc định
        private DAL_Subject() { }

        // Hàm lấy tất cả môn học
        public List<DTO_Subject> GetAllSubjects()
        {
            string query = "SELECT * FROM Subjects";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Subject> subjects = new List<DTO_Subject>();
            foreach (DataRow row in dt.Rows)
            {
                subjects.Add(new DTO_Subject(row["SubjectID"].ToString(), row["SubjectName"].ToString(), row["Description"].ToString()));
            }
            return subjects;
        }

        // Hàm lấy môn học theo ID
        public DTO_Subject GetSubjectByID(string subjectID)
        {
            string query = "SELECT * FROM Subjects WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SubjectID", subjectID)
            };
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
                return new DTO_Subject(dt.Rows[0]["SubjectID"].ToString(), dt.Rows[0]["SubjectName"].ToString(), dt.Rows[0]["Description"].ToString());

            return null;
        }

        // Thêm môn học mới
        public bool InsertSubject(DTO_Subject subject)
        {
            string query = "INSERT INTO Subjects (SubjectID, SubjectName, Description) VALUES (@SubjectID, @SubjectName, @Description)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SubjectID", subject.SubjectID),
                new SqlParameter("@SubjectName", subject.SubjectName),
                new SqlParameter("@Description", subject.Description)
            };
            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật môn học
        public bool UpdateSubject(DTO_Subject subject)
        {
            string query = "UPDATE Subjects SET SubjectName = @SubjectName, Description = @Description WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SubjectID", subject.SubjectID),
                new SqlParameter("@SubjectName", subject.SubjectName),
                new SqlParameter("@Description", subject.Description)
            };
            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa môn học
        public bool DeleteSubject(string subjectID)
        {
            string query = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SubjectID", subjectID)
            };
            int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool CheckExistIdentityNumber(string identityNumber)
        {
            string query = "SELECT COUNT(*) FROM Students WHERE IdentityNumber = @IdentityNumber";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IdentityNumber", identityNumber)
            };

            // Execute the query to get the result as a DataTable
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            // Extract the count from the first row and first column
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);  // Access the first column of the first row
                return count > 0;  // Return true if count is greater than 0, meaning the IdentityNumber exists
            }

            return false;
        }
    }
}
