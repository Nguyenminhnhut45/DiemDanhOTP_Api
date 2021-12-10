using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            GroupSubjects = new HashSet<GroupSubject>();
        }

        public int Idteacher { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Id { get; set; }
        public string SourceTeacher { get; set; }
        public string Gmail { get; set; }
        public string Adress { get; set; }

        public virtual User IdNavigation { get; set; }
        public virtual ICollection<GroupSubject> GroupSubjects { get; set; }
    }
}
