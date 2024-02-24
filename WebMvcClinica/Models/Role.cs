using System;
using System.Collections.Generic;

namespace WebMvcClinica.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RolId { get; set; }
        public string RolDetails { get; set; } = null!;
        public string RolStatus { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
