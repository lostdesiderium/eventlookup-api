using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.Models
{
    public class UserEvent
    {
        public bool Interested { get; set; }
        public bool Going { get; set; }
        public bool Created { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
