using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventLookup.Domain.DTOs.Image
{
    public class ImageUpdateDTO
    {
        public int ImageId { get; set; }
        public string ImageBase64 { get; set; }
        public bool IsCover { get; set; }
    }
}
