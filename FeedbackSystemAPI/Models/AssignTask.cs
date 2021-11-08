using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class AssignTask
    {
        public string AssignId { get; set; }
        public string TaskId { get; set; }
        public string EmployeeId { get; set; }

        public virtual User Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
