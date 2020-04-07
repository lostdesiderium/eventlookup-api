using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventLookup.Domain.Models
{
    public class Address
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street1 { get; set; }
#nullable enable
        public string? District { get; set; }
        public string? Street2 { get; set; }
        public string? Lat { get; set; }
        public string? Lng { get; set; }

        //--- Relations ---

        public int? EventId { get; set; }
#nullable disable
        public Event Event { get; set; }

        public string GetCountryCityStreet1()
        {
            return $"{City} {Street1}, {Country}";
        }


    }
}
