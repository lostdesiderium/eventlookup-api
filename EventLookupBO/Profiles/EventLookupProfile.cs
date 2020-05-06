using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.DTOs.Event;
using EventLookup.Domain.DTOs.User;


namespace EventLookupBO.Profiles
{
    public class EventLookupProfile : AutoMapper.Profile
    {
        
        public EventLookupProfile()
        {
            CreateMap<Event, EventListItemDTO>().ReverseMap();
            CreateMap<Event, EventDetailedDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap().PreserveReferences();
        }

    }
}
