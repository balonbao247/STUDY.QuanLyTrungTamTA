using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Subject
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        // Constructor không tham số
        public DTO_Subject() { }

        // Constructor có tham số
        public DTO_Subject(string subjectID, string subjectName, string description)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Description = description;
        }
    }
}
