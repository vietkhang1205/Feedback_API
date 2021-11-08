using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
