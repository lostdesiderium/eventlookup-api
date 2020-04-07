using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.Models
{
    public class AuthenticationUser
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public Tuple<int, string> Message { get; set; }
    }
}
