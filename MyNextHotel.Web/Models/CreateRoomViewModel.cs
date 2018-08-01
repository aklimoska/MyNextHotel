using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNextHotel.Web.Models
{
    public class CreateRoomViewModel
    {
        [Range(0, 1000)]
        public int Price { get; set; }

        public int RoomNumber { get; set; }

        [Range(0, 200)]
        public int Capacity { get; set; }

        [DisplayName("Has Air Condition")]
        public bool HasAirCondition { get; set; }

        [DisplayName("Has TV")]
        public bool HasTv { get; set; }

        [DisplayName("Has Balcony")]
        public bool HasBalcony { get; set; }

        [DisplayName("Has Kitchen")]
        public bool HasKitchen { get; set; }

        [DisplayName("Has Private Bathroom")]
        public bool HasPrivateBathroom { get; set; }

        [Range(0, 200)]
        public int Quadrature { get; set; }

        public int Type { get; set; }
    }
}