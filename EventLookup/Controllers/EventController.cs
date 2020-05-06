using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EventLookup.Domain.Models;
using EventLookup.Domain.Services;
using EventLookup.Domain.DTOs.Event;
using AutoMapper;

using System.IO;

namespace EventLookup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            var events = await _eventService.ListAsync();
           
            if (events == null)
                return NotFound();

            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEvent(int id)
        {
            var eventById = await _eventService.GetEvent(id);
            if (eventById == null)
                return NotFound();

            return Ok(eventById);
        }

        [HttpPost]
        [Route("add-event")]
        public async Task<ActionResult> PostEvent(EventDetailedDTO ev){

            var eventId = await _eventService.AddEvent(ev);
            if (eventId > 0)
                return Ok(eventId);

            return BadRequest();  
        }

        [HttpPost]
        [Route("remove-event/{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            bool isSuccess = await _eventService.Delete(id);
            if (isSuccess)
                return Ok(isSuccess);

            return BadRequest();
        }
        
        [HttpPost]
        [Route("update-event")]
        public async Task<ActionResult> EditEvent(EventDetailedDTO ev)
        {
            bool isSuccess = await _eventService.Edit(ev);
            if (isSuccess)
                return Ok(isSuccess);

            return BadRequest();
        }
    }
}