using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class BUS_Course
    {
        private DAL_Course dalCourse = new DAL_Course();

        // Lấy tất cả các khóa học đang hoạt động
        public List<DTO_Course> GetAllCourses()
        {
            return dalCourse.GetAllCourses();
        }

        // Lấy khóa học theo ID
        public DTO_Course GetCourseById(int id)
        {
            return dalCourse.GetCourseById(id);
        }

        // Thêm khóa học
        public bool AddCourse(DTO_Course course)
        {
            // Có thể kiểm tra điều kiện đầu vào tại đây nếu muốn
            return dalCourse.AddCourse(course);
        }

        // Cập nhật thông tin khóa học
        public bool UpdateCourse(DTO_Course course)
        {
            return dalCourse.UpdateCourse(course);
        }

        // Xóa mềm khóa học (set IsActive = false)
        public bool DeleteCourse(string id)
        {
            return dalCourse.DeleteCourse(id);
        }
        // Lấy mã khóa học tiếp theo
        public string GetNextCourseID()
        {
            return dalCourse.GetNextCourseID();
        }

        // Hàm lấy tên môn học theo SubjectID
        public string GetSubjectNameByID(string subjectID)
        {
            return dalCourse.GetSubjectNameByID(subjectID);
        }

        public string GetDescriptionByID(string courseID)
        {
            return dalCourse.GetDescriptionByID(courseID);
        }
    }
}
