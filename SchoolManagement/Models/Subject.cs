﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public string Field { get; set; }
    }
}
