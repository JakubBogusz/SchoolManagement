using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Lecturer
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
    }
}
