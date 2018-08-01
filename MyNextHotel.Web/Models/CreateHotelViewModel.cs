using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNextHotel.Web.Models
{
    public class CreateHotelViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }

        public int Stars { get; set; }

        [DisplayName("Has Pool")]
        public bool HasPool { get; set; }

        [DisplayName("Has Parking")]
        public bool HasParking { get; set; }

        [DisplayName("Has Gym")]
        public bool HasGym { get; set; }

        [DisplayName("Has Spa Center")]
        public bool HasSpaCenter { get; set; }

        [DisplayName("Is Pet Friendly")]
        public bool IsPetFriendly { get; set; }

        [DisplayName("Has WiFi")]
        public bool HasWiFi { get; set; }

        [DisplayName("Has Restourant")]
        public bool HasRestourant { get; set; }

        [Required(ErrorMessage = "Pleasee enter you number")]
        [Range(0, 100, ErrorMessage = "Enter number between 0 to 100")]
        [DisplayName("Distance (km)")]
        public decimal Distance { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Description { get; set; }

    }
}