using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.DTOs.User
{
    public class ChangePasswordDTO
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
