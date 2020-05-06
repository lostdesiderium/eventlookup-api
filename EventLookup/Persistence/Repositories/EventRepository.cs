using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.DTOs.Event;
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

        public async Task<bool> AddEvent(EventDetailedDTO ev)
        {
            return false;
        }

        private async Task SaveChanges()
        {
            await _eventLookupContext.SaveChangesAsync();
        }

        public async Task<int> Add(Event ev, List<Image> images, Address address, Ticket ticket)
        {
            try
            {
                using var transaction = _eventLookupContext.Database.BeginTransaction();
                await _eventLookupContext.Events.AddAsync(ev);
                await SaveChanges();

                address.EventId = ev.EventId;
                ticket.EventId = ev.EventId;
                _eventLookupContext.Addresses.Add(address);
                _eventLookupContext.Tickets.Add(ticket);

                for (int i = 0; i < images.Count; i++)
                {
                    images[i].EventId = ev.EventId;
                    _eventLookupContext.Images.Add(images[i]);
                }

                await SaveChanges();

                transaction.Commit();

                return ev.EventId;
            }
            catch(Exception e)
            {
                throw e;
            } 
            
        }

        public async Task<bool> Edit(Event ev, List<Image> imagesToAdd, List<Image> imagesToUpdate, Address address, Ticket ticket)
        {
            try
            {
                using var transaction = _eventLookupContext.Database.BeginTransaction();

                _eventLookupContext.Events.Update(ev);

                var addressFromDB = await _eventLookupContext.Addresses.FirstOrDefaultAsync(ad => ad.EventId == address.EventId);
                if (addressFromDB != null)
                {
                    addressFromDB.City = address.City;
                    addressFromDB.Country = address.Country;
                    addressFromDB.Street1 = address.Street1;
                    addressFromDB.Lat = address.Lat;
                    addressFromDB.Lng = address.Lng;
                    addressFromDB.District = address.District;

                    _eventLookupContext.Addresses.Update(addressFromDB);
                }

                var ticketFromDB = await _eventLookupContext.Tickets.FirstOrDefaultAsync(ti => ti.EventId == ticket.EventId);
                if (ticketFromDB != null)
                {
                    ticketFromDB.Price = ticket.Price;
                    ticketFromDB.Image = ticket.Image;
                    ticketFromDB.Count = ticket.Count;
                    ticketFromDB.Distributor = ticket.Distributor;
                    ticketFromDB.DistributorUrl = ticket.DistributorUrl;

                    _eventLookupContext.Tickets.Update(ticket);
                }
               

                for (int i = 0; i < imagesToUpdate.Count; i++)
                {
                    var imageFromDB = await _eventLookupContext.Images.FirstOrDefaultAsync(img => img.ImageId == imagesToUpdate[i].ImageId);
                    if(imageFromDB != null)
                    {
                        imageFromDB.PathOnServer = imagesToUpdate[i].PathOnServer;
                        imageFromDB.Caption = imagesToUpdate[i].Caption;
                        _eventLookupContext.Images.Update(imageFromDB);
                        
                    }
                }
                await SaveChanges();

                for (int i = 0; i < imagesToAdd.Count; i++)
                {
                    imagesToAdd[i].EventId = ev.EventId;
                    _eventLookupContext.Images.Add(imagesToAdd[i]);
                }
                await SaveChanges();

                transaction.Commit();
                transaction.Dispose();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int eventId)
        {
            var ev = await _eventLookupContext.Events.Include(i => i.Images).Include(t => t.Tickets).Include(a => a.Address).FirstOrDefaultAsync(ev => ev.EventId == eventId);
            _eventLookupContext.Remove(ev);

            await SaveChanges();

            return true;
        }
    }
}
