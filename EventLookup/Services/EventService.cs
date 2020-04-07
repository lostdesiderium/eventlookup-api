using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using EventLookup.Domain.Services;
using EventLookup.Domain.Models;
using EventLookup.Domain.Repositories;
using AutoMapper;
using EventLookup.Domain.DTOs.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EventLookup.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IConfiguration _conf;

        private string scheme;
        private string baseUrl;
        private string sharedVirtualPath;

        public EventService(IEventRepository eventRepository, IMapper mapper, IHttpContextAccessor cont, IConfiguration conf)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _httpContext = cont;
            _conf = conf;

            scheme = _httpContext.HttpContext.Request.Scheme.ToString(); // http : https
            baseUrl = _httpContext.HttpContext.Request.Host.Value; // localhost:<port>
            sharedVirtualPath = _conf.GetValue<string>("SharedImagesPath"); // app-images
        }

        public async Task<IEnumerable<EventListItemDTO>> ListAsync()
        {
            var events = await _eventRepository.ListAsync();

            if (events == null)
                return null;

            List<EventListItemDTO> mappedEvents = _mapper.Map<List<EventListItemDTO>>(events)
                .ToList();


            int i = 0;
            foreach (var oneEvent in events)
            {
                Image image = oneEvent.Images.FirstOrDefault(im => im.EventId == oneEvent.EventId && im.IsCover == true);
                if (image != null)
                {
                    var imageInfo = Path.GetFileName(image.PathOnServer); // eventImage.jpg

                    mappedEvents[i].CoverImagePath = $"{scheme}://{baseUrl}/{sharedVirtualPath}/{imageInfo}";
                }
                mappedEvents[i].StartDate.ToString("yyyy-MM-dd HH:mm");
                i++;
            }

            return mappedEvents;
        }

        public async Task<Event> GetEvent(int id)
        {
            var eventDetailed = await _eventRepository.GetEvent(id);

            if (eventDetailed == null)
                return null;

            foreach(var eventImage in eventDetailed.Images)
            {
                var imageInfo = Path.GetFileName(eventImage.PathOnServer); // eventImage.jpg
                eventImage.PathOnServer = $"{scheme}://{baseUrl}/{sharedVirtualPath}/{imageInfo}";
            }

            return eventDetailed;
        }
    }
}
