using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using EventLookup.Domain.Services;
using EventLookup.Domain.DTOs;
using EventLookup.Domain.DTOs.Event;

namespace EventLookupBO.Pages
{

    public class EventsModel : PageModel
    {
        private readonly IEventService _eventService;
        private string WebAPIPath = "http://localhost:19422/app-images";

        public EventsModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        public List<EventListItemDTO> eventListItemDTO { get; set; }

        public async Task OnGet()
        {
            var eventsList = await _eventService.ListAsync();
            eventListItemDTO = eventsList.ToList(); 
            for(int i = 0; i < eventListItemDTO.Count; i++)
            {
                string ImagePath = eventListItemDTO[i].CoverImagePath;
                if (ImagePath != null)
                {
                    string[] splittedPathImage = ImagePath.Split('/');
                    string imageName = splittedPathImage[splittedPathImage.Length - 1];

                    eventListItemDTO[i].CoverImagePath = $"{WebAPIPath}/{imageName}";
                }
            }
        }


    }
}