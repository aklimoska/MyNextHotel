using MyNextHotel.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNextHotel.Web.Models
{
    public class GetAllHotelsViewModel
    {
        public List<HotelDto> Hotels { get; set; }
        public List<string> RoomTypes { get; set; }
    }
}