using MyNextHotel.Data;
using MyNextHotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyNextHotel.Data.Repositories;
using MyNextHotel.Common.Dtos;

namespace MyNextHotel.Domain.Managers
{
    public class HotelsManager : IHotelsManager
    {
        private IHotelsRepository _hotelRepository;

        public HotelsManager()
        {
            _hotelRepository = new HotelsRepository();
        }

        public HotelDto GetHotel(int id)
        {
            var hotelResult = new HotelDto();

            var result = _hotelRepository.GetHotelById(id);
            if (result != null)
            {
                hotelResult.Name = result.Name;
                hotelResult.Address = result.Address;
                hotelResult.Distance = result.Distance;
                hotelResult.Description = result.Description;
                hotelResult.HasGym = result.HasGym;
                hotelResult.HasParking = result.HasParking;
                hotelResult.HasPool = result.HasPool;
                hotelResult.HasRestourant = result.HasRestourant;
                hotelResult.HasSpaCenter = result.HasSpaCenter;
                hotelResult.HasWiFi = result.HasWiFi;
                hotelResult.HotelID = result.HotelID;
                hotelResult.IsPetFriendly = result.IsPetFriendly;
                hotelResult.Stars = result.Stars;
                hotelResult.PhotoData = result.PhotoData;
            }
            
            return hotelResult;
        }
    }
}
