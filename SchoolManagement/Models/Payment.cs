using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public decimal Amount { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
