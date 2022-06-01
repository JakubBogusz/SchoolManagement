namespace SchoolManagement.Dtos
{
    public class FinalScoreDto
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public decimal Average { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
