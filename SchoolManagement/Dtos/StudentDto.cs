namespace SchoolManagement.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
        public List<EnrollmentDto> Enrollments { get; set; }
    }
}
