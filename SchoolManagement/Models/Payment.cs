using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public DateTime DateOfPayment { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
