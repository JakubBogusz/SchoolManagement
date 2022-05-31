using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            FinalScores = new HashSet<FinalScore>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int PaymentId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<FinalScore> FinalScores { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
