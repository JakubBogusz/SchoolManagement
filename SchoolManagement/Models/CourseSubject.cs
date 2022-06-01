using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class CourseSubject
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
