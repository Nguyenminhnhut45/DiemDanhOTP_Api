using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class Session
    {
        public Session()
        {
            SessionDetails = new HashSet<SessionDetail>();
        }

        public int Idsession { get; set; }
        public string Classroom { get; set; }
        public byte? Session1 { get; set; }
        public byte? PeriodStart { get; set; }
        public byte? PeriodEnd { get; set; }
        public int? Idgroup { get; set; }
        public string Day { get; set; }
        public DateTime? Date { get; set; }

        public virtual GroupSubject IdgroupNavigation { get; set; }
        public virtual ICollection<SessionDetail> SessionDetails { get; set; }
    }
}
