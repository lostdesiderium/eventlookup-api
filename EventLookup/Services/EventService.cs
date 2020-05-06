using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using EventLookup.Domain.Services;
using EventLookup.Domain.Models;
using EventLookup.Domain.Repositories;
using AutoMapper;
using EventLookup.Domain.DTOs.Event;
using EventLookup.Domain.DTOs.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace EventLookup.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IConfiguration _conf;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private string scheme;
        private string baseUrl;
        private string sharedVirtualPath;

        public EventService(IEventRepository eventRepository, IMapper mapper, IHttpContextAccessor cont, IConfiguration conf, IWebHostEnvironment webHostEnvironment)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _httpContext = cont;
            _conf = conf;
            _hostingEnvironment = webHostEnvironment;

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

        public async Task<int> AddEvent(EventDetailedDTO ev)
        {
            List<Image> images = new List<Image>();
            Event eventToSave = _mapper.Map<Event>(ev);

            Address address = _mapper.Map<Address>(ev);

            Ticket ticket = _mapper.Map<Ticket>(ev);
           

            // creating images from base64
            for(int i = 0; i < ev.EventImages.Count; i++)
            {
                string imagePath = SaveImageToSharedDirectory(ev.EventImages[i].ImageBase64);
                Image image = _mapper.Map<Image>(ev);
                image.PathOnServer = imagePath;
                if(i == 0)
                {
                    image.IsCover = true;
                }
                image.Caption = Path.GetFileName(image.PathOnServer);

                images.Add(image);
            }


            int eventId = await _eventRepository.Add(eventToSave, images, address, ticket);
            
            return eventId;
        }

        private string SaveImageToSharedDirectory(string imageBase64)
        {
            string imageName = Guid.NewGuid().ToString() + ".png";
            string saveImagePath = _hostingEnvironment.ContentRootPath + "/Shared/Files/Images/" + imageName;
            byte[] bytes = Convert.FromBase64String(imageBase64);

            System.Drawing.Image bitmapImage;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                bitmapImage = System.Drawing.Image.FromStream(ms);
                bitmapImage.Save(saveImagePath);

                if (File.Exists(_hostingEnvironment.ContentRootPath + "/Shared/Files/Images/" + imageName))
                    return imageName;
                return "";
            }
        }

        public async Task<bool> Delete(int eventId)
        {
            return await _eventRepository.Delete(eventId);
        }

        public async Task<bool> Edit(EventDetailedDTO ev)
        {
            List<Image> imagesToAdd = new List<Image>();
            List<Image> imagesToUpdate = new List<Image>();
            Event eventToSave = _mapper.Map<Event>(ev);

            Address address = _mapper.Map<Address>(ev);

            Ticket ticket = _mapper.Map<Ticket>(ev);


            // creating images from base64
            for (int i = 0; i < ev.EventImages.Count; i++)
            {
                string imagePath = SaveImageToSharedDirectory(ev.EventImages[i].ImageBase64);
                Image image = _mapper.Map<Image>(ev.EventImages[i]);
                image.PathOnServer = imagePath;

                image.Caption = Path.GetFileName(image.PathOnServer);
                image.IsCover = ev.EventImages[i].IsCover;

                if (ev.EventImages[i].ImageId == 0)
                {
                    imagesToAdd.Add(image);
                }
                else
                {
                    imagesToUpdate.Add(image);
                }
            }  

            bool isSuccess = await _eventRepository.Edit(eventToSave, imagesToAdd, imagesToUpdate, address, ticket);

            return isSuccess;
        }
    }
}
