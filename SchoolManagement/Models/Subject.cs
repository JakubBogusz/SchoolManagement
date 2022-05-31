using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Field { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
