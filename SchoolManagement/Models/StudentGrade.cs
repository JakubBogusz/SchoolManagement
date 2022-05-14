using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class StudentGrade
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public DateTime? DateOfReceive { get; set; }
        public bool IsFinalGrade { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
