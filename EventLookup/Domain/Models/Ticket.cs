using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventLookup.Domain.Models
{
    public class Ticket
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
#nullable enable
        public string? Distributor { get; set; }
        public string? DistributorUrl { get; set; }
#nullable disable
        public double Price { get; set; }
        public int Count { get; set; }

        // ------ Relations ------

#nullable enable
        public Image? Image { get; set; }
#nullable disable

        public int? EventId { get; set; }
        public Event Event { get; set; }
    }
}
