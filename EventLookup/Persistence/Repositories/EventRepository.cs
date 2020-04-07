using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.Repositories;
using EventLookup.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EventLookup.Persistence.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(EventLookupContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _eventLookupContext.Events
                .Include(ev => ev.Address)
                .Include(ev => ev.Images)
                .Include(ev => ev.Tickets)
                .ToListAsync();
        }

        public async Task<Event> GetEvent(int id)
        {
            var oneEvent = await _eventLookupContext.Events.Include(ev => ev.Address)
                .Include(ev => ev.Images)
                .Include(ev => ev.Tickets)
                .Include(ue => ue.UserEvents)
                .FirstOrDefaultAsync(x => x.EventId == id); 

            return oneEvent;
        }
    }
}
