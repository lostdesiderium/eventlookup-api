using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel;

using EventLookup.Domain.Models;

namespace EventLookup.Domain.DTOs.Event
{
    public class EventListItemDTO
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        //------ Relations ------
        public string AddressCountryCityStreet1 { get; set; }

        public string AddressLat { get; set; }

        public string AddressLng { get; set; }

        public string CoverImagePath { get; set; } // Base64 encoded string images list

    }
}
