using System;
using System.Data;

namespace DTO
{
    public class DTO_Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string SubjectID { get; set; }
        public string TeacherID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public DTO_Course() { }

        public DTO_Course(DataRow row)
        {
            CourseID = row["CourseID"].ToString();
            CourseName = row["CourseName"].ToString();
            SubjectID = row["SubjectID"].ToString();
            TeacherID = row["TeacherID"].ToString();
            StartDate = Convert.ToDateTime(row["StartDate"]);
            EndDate = Convert.ToDateTime(row["EndDate"]);
            Price = Convert.ToDecimal(row["Price"]);
            IsActive = Convert.ToBoolean(row["IsActive"]);
        }
    }
}
