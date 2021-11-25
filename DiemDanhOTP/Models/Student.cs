using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class Student
    {
        public Student()
        {
            SessionDetails = new HashSet<SessionDetail>();
        }

        public string Idstudent { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Class { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public int? Id { get; set; }

        public virtual User IdNavigation { get; set; }
        public virtual ICollection<SessionDetail> SessionDetails { get; set; }
    }
}
