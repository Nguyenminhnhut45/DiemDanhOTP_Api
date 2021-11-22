using System;
using System.Collections.Generic;

#nullable disable

namespace DiemDanhOTP.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Users = new HashSet<User>();
        }

        public byte Idadmin { get; set; }
        public string Name { get; set; }
        public string Usename { get; set; }
        public string Password { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
