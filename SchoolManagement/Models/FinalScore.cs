﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class FinalScore
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public decimal Average { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
    }
}
