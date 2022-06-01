using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public decimal Amount { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
    }
}
