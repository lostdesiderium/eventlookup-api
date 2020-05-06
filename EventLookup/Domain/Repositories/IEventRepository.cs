using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.DTOs.Event;
using EventLookup.Domain.Services;

namespace EventLookup.Domain.Repositories
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> ListAsync();
        public Task<Event> GetEvent(int id);
        public Task<bool> AddEvent(EventDetailedDTO ev);
        public Task<int> Add(Event ev, List<Image> image, Address address, Ticket ticket);
        public Task<bool> Edit(Event ev, List<Image> imagesToAdd, List<Image> imagesToUpdate, Address address, Ticket ticket);
        public Task<bool> Delete(int eventId);

    }
}
