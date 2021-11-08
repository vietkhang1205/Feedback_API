using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class User
    {
        public User()
        {
            AssignTasks = new HashSet<AssignTask>();
            Feedbacks = new HashSet<Feedback>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<AssignTask> AssignTasks { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
