using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class Task
    {
        public Task()
        {
            AssignTasks = new HashSet<AssignTask>();
        }

        public string TaskId { get; set; }
        public string FeedbackId { get; set; }
        public string Status { get; set; }
        public string DateTime { get; set; }

        public virtual Feedback Feedback { get; set; }
        public virtual ICollection<AssignTask> AssignTasks { get; set; }
    }
}
