using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class Course
    {
        public Course()
        {
            GroupSubjects = new HashSet<GroupSubject>();
        }

        public string Idcourse { get; set; }
        public string CoursetName { get; set; }
        public byte? Noc { get; set; }
        public byte? Peroid { get; set; }

        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
    }
}
