using System;
using System.Collections.Generic;

#nullable disable

namespace FeedbackSystemAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            Devices = new HashSet<Device>();
        }

        public string LocationId { get; set; }
        public string LocatitonName { get; set; }
        public string Floor { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
