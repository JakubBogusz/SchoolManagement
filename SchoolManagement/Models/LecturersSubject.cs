using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class LecturersSubject
    {
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Lecturer Lecturer { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
