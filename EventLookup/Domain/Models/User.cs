using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
#nullable enable
        public string? Biography { get; set; }
        public ICollection<UserEvent>? UserEvents { get; set; }
#nullable disable
        public string ImagePath { get; set; }

        public string Token { get; set; }

    }
}
