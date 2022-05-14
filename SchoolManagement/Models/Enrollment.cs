﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}