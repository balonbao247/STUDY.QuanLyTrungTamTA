using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Course
    {
        private static DAL_Course instance;

        public static DAL_Course Instance
        {
            get { if (instance == null) instance = new DAL_Course(); return instance; }
            private set { instance = value; }
        }
        public string GetNextCourseID()
        {
            string query = "SELECT TOP 1 CourseID FROM Courses ORDER BY CourseID DESC";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["CourseID"].ToString(); 
                int number = int.Parse(lastID.Substring(1));        
                number++;
                return "C" + number.ToString("D4");                 
            }
            else
            {
                return "C0001"; // Mã đầu tiên
            }
        }

        // Lấy tất cả Course
        public List<DTO_Course> GetAllCourses()
        {
            string query = "SELECT * FROM Courses";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Course> courses = new List<DTO_Course>();
            foreach (DataRow row in dt.Rows)
            {
                courses.Add(new DTO_Course(row));
            }
            return courses;
        }

        // Lấy tất cả Course còn hoạt động
        public List<DTO_Course> GetActiveCourses()
        {
            string query = "SELECT * FROM Courses WHERE IsActive = 1";
            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query);

            List<DTO_Course> courses = new List<DTO_Course>();
            foreach (DataRow row in dt.Rows)
            {
                courses.Add(new DTO_Course(row));
            }
            return courses;
        }

        // Lấy Course theo ID
        public DTO_Course GetCourseByID(string courseID)
        {
            string query = "SELECT * FROM Courses WHERE CourseID = @CourseID";
            SqlParameter[] parameters = { new SqlParameter("@CourseID", courseID) };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return new DTO_Course(dt.Rows[0]);

            return null;
        }

        // Thêm Course
        public bool InsertCourse(DTO_Course course)
        {
            string query = @"INSERT INTO Courses (CourseID, CourseName, SubjectID, TeacherID, StartDate, EndDate, Price, IsActive)
                             VALUES (@CourseID, @CourseName, @SubjectID, @TeacherID, @StartDate, @EndDate, @Price, @IsActive)";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", course.CourseID),
                new SqlParameter("@CourseName", course.CourseName),
                new SqlParameter("@SubjectID", course.SubjectID),
                new SqlParameter("@TeacherID", course.TeacherID),
                new SqlParameter("@StartDate", course.StartDate),
                new SqlParameter("@EndDate", course.EndDate),
                new SqlParameter("@Price", course.Price),
                new SqlParameter("@IsActive", course.IsActive)
            };

            return DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        // Cập nhật Course
        public bool UpdateCourse(DTO_Course course)
        {
            string query = @"UPDATE Courses SET
                                CourseName = @CourseName,
                                SubjectID = @SubjectID,
                                TeacherID = @TeacherID,
                                StartDate = @StartDate,
                                EndDate = @EndDate,
                                Price = @Price,
                                IsActive = @IsActive
                             WHERE CourseID = @CourseID";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", course.CourseID),
                new SqlParameter("@CourseName", course.CourseName),
                new SqlParameter("@SubjectID", course.SubjectID),
                new SqlParameter("@TeacherID", course.TeacherID),
                new SqlParameter("@StartDate", course.StartDate),
                new SqlParameter("@EndDate", course.EndDate),
                new SqlParameter("@Price", course.Price),
                new SqlParameter("@IsActive", course.IsActive)
            };

            return DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        // Xóa Course (mềm = set IsActive = 0)
        public bool DeleteCourse(string courseID)
        {
            string query = "UPDATE Courses SET IsActive = 0 WHERE CourseID = @CourseID";
            SqlParameter[] parameters = { new SqlParameter("@CourseID", courseID) };

            return DAL_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public string GetSubjectNameByID(string subjectID)
        {
            string query = "SELECT SubjectName FROM Subjects WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = { new SqlParameter("@SubjectID", subjectID) };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SubjectName"].ToString();
            }

            return null; // hoặc return string.Empty;
        }

        public string GetDescriptionByID(string subjectID)
        {
            string query = "SELECT Description FROM Subjects WHERE SubjectID = @SubjectID";
            SqlParameter[] parameters = { new SqlParameter("@SubjectID", subjectID) };

            DataTable dt = DAL_DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Description"].ToString();
            }

            return null; // hoặc return string.Empty;
        }
    }
}
