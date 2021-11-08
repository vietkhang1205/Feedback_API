using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class Device
    {
        public Device()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
