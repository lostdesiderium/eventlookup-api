using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace EventLookup.Domain.Models
{
    public class Event
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string LongDescription { get; set; }
        public int GoingPeopleCount { get; set; }
        public int InterestedPeopleCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int DaysEventActive { get; set; }

        //------ Relations ------
        //[JsonIgnore]
        public Address Address { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }

        public ICollection<Image> Images { get; set; } // Base64 encoded string images list

        public ICollection<Ticket> Tickets { get; set; }



    }
}
