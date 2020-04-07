using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.DTOs.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }

        public string Caption { get; set; }
        public bool IsCover { get; set; }

        public string PathOnServer { get; set; }

        // ------ Relations ------
        public int? EventId { get; set; }
    }
}
