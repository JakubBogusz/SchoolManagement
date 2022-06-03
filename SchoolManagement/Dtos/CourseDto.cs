namespace SchoolManagement.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Level { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
