using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Payment
    {
        public string PaymentID { get; set; }
        public string StudentID { get; set; }
        public string CourseID { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentDate { get; set; }  // Use DateTime? for nullable DateTime
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }

        public DTO_Payment(DataRow row)
        {
            PaymentID = row["PaymentID"].ToString();
            StudentID = row["StudentID"].ToString();
            CourseID = row["CourseID"].ToString();
            TotalAmount = decimal.Parse(row["TotalAmount"].ToString());
            PaymentDate = row["PaymentDate"].ToString();
            PaymentStatus = row["PaymentStatus"].ToString();
            PaymentMethod = row["PaymentMethod"].ToString();
        }
    }

}
