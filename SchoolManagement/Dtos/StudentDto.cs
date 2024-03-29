﻿namespace SchoolManagement.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Address { get; set; } = null!;
    }
}
