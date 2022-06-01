namespace SchoolManagement.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int EnrollmentId { get; set; }
        public decimal GradeValue { get; set; }
        public string Percent { get; set; } = null!;
        public DateTime? Date { get; set; }
    }
}
