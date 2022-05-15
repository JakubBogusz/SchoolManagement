namespace SchoolManagement.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public decimal Amount { get; set; }
    }
}
