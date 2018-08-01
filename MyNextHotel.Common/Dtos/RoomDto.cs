using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextHotel.Common.Dtos
{
    public class RoomDto
    {
        public int Price { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool HasAirCondition { get; set; }
        public bool HasTv { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasPrivateBathroom { get; set; }
        public int Quadrature { get; set; }
        public int Type { get; set; }
        public byte[] PhotoData { get; set; }
    }
}
