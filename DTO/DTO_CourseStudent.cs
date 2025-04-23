using System;
using System.Data;

public class DTO_CourseStudent
{
    public string CourseID { get; set; }
    public string StudentID { get; set; }
    public DateTime EnrollDate { get; set; }

    // Constructor mặc định
    public DTO_CourseStudent() { }

    // Constructor đầy đủ tham số
    public DTO_CourseStudent(string courseID, string studentID, DateTime enrollDate)
    {
        CourseID = courseID;
        StudentID = studentID;
        EnrollDate = enrollDate;
    }

    // Constructor từ DataRow
    public DTO_CourseStudent(DataRow row)
    {
        CourseID = row["CourseID"].ToString();
        StudentID = row["StudentID"].ToString();
        EnrollDate = Convert.ToDateTime(row["EnrollDate"]);
    }
}
