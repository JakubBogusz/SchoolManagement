using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Comment { get; set; } = null!;
        public string Percent { get; set; } = null!;
    }
}
