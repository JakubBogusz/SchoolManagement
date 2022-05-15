namespace SchoolManagement.Dtos
{
    public class StudentRequestDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public int AddressId { get; set; }
        public AddressDto Address { get; set; }
    }
}
