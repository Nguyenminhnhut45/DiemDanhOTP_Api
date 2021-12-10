using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class GroupSubject
    {
        public GroupSubject()
        {
            Sessions = new HashSet<Session>();
        }

        public int Idgroup { get; set; }
        public string Idcourse { get; set; }
        public int? Idteacher { get; set; }
        public string ClassGroup { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public byte? Semester { get; set; }
        public int? Year { get; set; }
        public string Linkds { get; set; }
        public string Linkaddsr { get; set; }

        public virtual Course IdcourseNavigation { get; set; }
        public virtual Teacher IdteacherNavigation { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
