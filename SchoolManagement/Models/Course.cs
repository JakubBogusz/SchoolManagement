using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public decimal Price { get; set; }
        public string Level { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Code { get; set; } = null!;

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
