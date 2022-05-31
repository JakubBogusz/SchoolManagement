namespace SchoolManagement.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int PaymentId { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
