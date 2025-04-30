using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentAttendanceDTO
    {
        public string AttendanceID { get; set; }   // Mã điểm danh
        public string CourseID { get; set; }        // Mã khóa học
        public string StudentID { get; set; }       // Mã học viên
        public DateTime AttendanceDate { get; set; } // Ngày điểm danh
        public string Status { get; set; }          // Trạng thái điểm danh: 'Present', 'Absent', 'Late'
    }

}
