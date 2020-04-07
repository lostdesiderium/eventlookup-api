using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;

namespace EventLookup.Domain.DTOs.User
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
#nullable enable
        public string? Biography { get; set; }
        public ICollection<UserEvent>? UserEvents { get; set; }
        public string? ImagePath { get; set; }
#nullable disable

    }
}
