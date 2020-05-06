using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.Models;
using EventLookup.Domain.DTOs.Event;
using EventLookup.Domain.DTOs.Image;
using EventLookup.Domain.DTOs.User;


namespace EventLookup.Domain.Profiles
{
    public class EventLookupProfile : AutoMapper.Profile
    {
        
        public EventLookupProfile()
        {
            CreateMap<Event, EventListItemDTO>().PreserveReferences();

            CreateMap<Event, EventDetailedDTO>().ReverseMap().PreserveReferences();

            CreateMap<EventDetailedDTO, Address>().PreserveReferences().ForMember(dest => dest.Street1, opt => opt.MapFrom(src => src.Street));

            CreateMap<EventDetailedDTO, Image>().PreserveReferences();

            CreateMap<ImageUpdateDTO, Image>().PreserveReferences();

            CreateMap<EventDetailedDTO, Ticket>().PreserveReferences();

            CreateMap<User, UserDTO>().ReverseMap().PreserveReferences();
        }

    }
}
