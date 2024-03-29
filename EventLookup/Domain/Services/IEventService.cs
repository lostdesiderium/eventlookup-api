﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventLookup.Domain.DTOs.Event;
using EventLookup.Domain.Models;

namespace EventLookup.Domain.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventListItemDTO>> ListAsync();
        Task<Event> GetEvent(int id);
        Task<int> AddEvent(EventDetailedDTO ev);
        Task<bool> Edit(EventDetailedDTO ev);
        Task<bool> Delete(int eventId);
    }
}
