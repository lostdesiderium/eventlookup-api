using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.Models
{
    public class Image
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        [Required]
        public string Caption { get; set; }
        public bool IsCover { get; set; }

        [Required]
        public string PathOnServer { get; set; }

        // ------ Relations ------
        public int? EventId { get; set; }
        public Event Event { get; set; }

        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
