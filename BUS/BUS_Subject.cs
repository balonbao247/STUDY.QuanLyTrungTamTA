using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_Subject
    {
        private static BUS_Subject instance;

        public static BUS_Subject Instance
        {
            get
            {
                if (instance == null)
                    instance = new BUS_Subject();
                return instance;
            }
            private set { instance = value; }
        }

        // Constructor mặc định
        private BUS_Subject() { }

        // Lấy tất cả môn học
        public List<DTO_Subject> GetAllSubjects()
        {
            return DAL_Subject.Instance.GetAllSubjects();
        }

        // Lấy môn học theo ID
        public DTO_Subject GetSubjectByID(string subjectID)
        {
            return DAL_Subject.Instance.GetSubjectByID(subjectID);
        }

        // Thêm môn học mới
        public bool InsertSubject(DTO_Subject subject)
        {
            return DAL_Subject.Instance.InsertSubject(subject);
        }

        // Cập nhật môn học
        public bool UpdateSubject(DTO_Subject subject)
        {
            return DAL_Subject.Instance.UpdateSubject(subject);
        }

        // Xóa môn học
        public bool DeleteSubject(string subjectID)
        {
            return DAL_Subject.Instance.DeleteSubject(subjectID);
        }
    }
}
