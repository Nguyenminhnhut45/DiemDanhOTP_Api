using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class SessionDetail
    {
        public int Idlession { get; set; }
        public string Idstuddent { get; set; }
        public string Status { get; set; }
        public DateTime? Time { get; set; }
        public string Note { get; set; }
        public string Otp { get; set; }
        public string ViTri { get; set; }

        public virtual Session IdlessionNavigation { get; set; }
        public virtual Student IdstuddentNavigation { get; set; }
    }
}
