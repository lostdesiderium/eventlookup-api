using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.Services;

namespace EventLookup.Domain.Repositories
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> ListAsync();
        public Task<Event> GetEvent(int id);
    }
}
