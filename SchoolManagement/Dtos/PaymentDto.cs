namespace SchoolManagement.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public decimal Amount { get; set; }
        public string Rate { get; set; }
    }
}
