using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Student
    {
        public Student()
        {
            Addresses = new HashSet<Address>();
            Enrollments = new HashSet<Enrollment>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime? EnrollmentDate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
