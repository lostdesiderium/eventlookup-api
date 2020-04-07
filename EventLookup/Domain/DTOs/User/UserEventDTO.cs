using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;

namespace EventLookup.Domain.DTOs.User
{
    public class UserEventDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

#nullable enable
        public ICollection<UserEvent>? UserEvents { get; set; }
#nullable disable
    }
}
