using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class Study
    {
        public int Idgroup { get; set; }
        public string Idstudent { get; set; }
        public byte? Stt { get; set; }
        public int Id { get; set; }

        public virtual GroupSubject IdgroupNavigation { get; set; }
        public virtual Student IdstudentNavigation { get; set; }
    }
}
