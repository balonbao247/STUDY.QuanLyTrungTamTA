using System.Data.SqlClient;
using System.Data;
using System;

namespace DAL
{
    public class DAL_ForEmployee
    {
        private static DAL_ForEmployee instance;
        public static DAL_ForEmployee Instance
        {
            get { if (instance == null) instance = new DAL_ForEmployee(); return instance; }
            private set { instance = value; }
        }

        //// Helper method to execute query and return DataTable
        //private DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        //{
        //    try
        //    {
        //        return DAL_DataProvider.Instance.ExecuteQuery(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the error (can be improved further by logging to a file or database)
        //        Console.WriteLine("Error executing query: " + ex.Message);
        //        throw; // Re-throw exception for further handling if necessary
        //    }
        //}

        //// Get List of Students (Updated SQL procedure)
        //public DataTable GetListStudent()
        //{
        //    string query = "exec sp_GetAllStudents"; // Thủ tục SQL lấy danh sách học viên
        //    return ExecuteQuery(query);
        //}
        //public bool DeleteStudent(int studentID)
        //{
        //    string query = "DELETE FROM Students WHERE StudentID = @StudentID";
        //    int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, new object[] { studentID });
        //    return result > 0; // Trả về true nếu xóa thành công
        //}
        ////get list of teachers
        //public DataTable GetListTeacher()
        //{
        //    string query = "exec sp_GetAllTeachers";
        //    return ExecuteQuery(query);
        //}

        //public bool DeleteTeacher(int teacherID )
        //{
        //    string query = "DELETE FROM Teachers WHERE TeacherID = @TeacherID";
        //    int result = DAL_DataProvider.Instance.ExecuteNonQuery(query, new object[] { teacherID });
        //    return result > 0;
        //}

    }
}
