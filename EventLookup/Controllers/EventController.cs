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
    }
}