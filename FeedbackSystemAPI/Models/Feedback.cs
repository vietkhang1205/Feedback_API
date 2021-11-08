using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            Tasks = new HashSet<Task>();
        }

        public string FeedbackId { get; set; }
        public string DeviceId { get; set; }
        public string UserId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string DateTime { get; set; }

        public virtual Device Device { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
