using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventLookup.Domain.DTOs.Image;

namespace EventLookup.Domain.DTOs.Event
{
    public class EventDetailedDTO
    {

        // EVENT
        public int EventId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int GoingPeopleCount { get; set; }
        public int InterestedPeopleCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int DaysEventActive { get; set; }


        // ADDRESS
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }


        // IMAGE
        public List<ImageUpdateDTO> EventImages { get; set; }


        // TICKET
        public string DistributorUrl { get; set; }

    }
}
