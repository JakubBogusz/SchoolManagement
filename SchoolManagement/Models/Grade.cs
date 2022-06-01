using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int EnrollmentId { get; set; }
        public decimal GradeValue { get; set; }
        public string Percent { get; set; } = null!;
        public DateTime? Date { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
