using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostCode { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
    }
}
