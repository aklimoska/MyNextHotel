using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextHotel.Common.Dtos
{
        public class HotelDto
    {
        public int HotelID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Stars { get; set; }
        public bool? HasPool { get; set; }
        public bool? HasParking { get; set; }
        public bool? HasGym { get; set; }
        public bool? HasSpaCenter { get; set; }
        public bool? IsPetFriendly { get; set; }
        public bool? HasWiFi { get; set; }
        public bool? HasRestourant { get; set; }
        public decimal? Distance { get; set; }
        public string Description { get; set; }
        public byte[] PhotoData { get; set; }

        public float Rating { get; set; } 

        
    }
}
