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
        public List<HotelDto> GetAllHotels()
        {
            var HotelsResult = new List<HotelDto>();
            var result = _hotelRepository.GetAllHotels();
            if (result != null)
            {
                foreach (Hotel hotel in result)
                {
                    HotelsResult.Add(new HotelDto()
                    { HotelID = hotel.HotelID,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        Stars = hotel.Stars,
                        HasPool = hotel.HasPool,
                        HasParking = hotel.HasParking,
                        HasGym = hotel.HasGym,
                        HasSpaCenter = hotel.HasSpaCenter,
                        IsPetFriendly = hotel.IsPetFriendly,
                        HasWiFi = hotel.HasWiFi,
                        HasRestourant = hotel.HasRestourant,
                        Distance = hotel.Distance,
                        Description = hotel.Description,
                        PhotoData = hotel.PhotoData
                    });
                }
            }
            return HotelsResult;
        }
      
        public List<HotelDto> SearchResults(string searching, bool isPetFriendly, bool hasRestaurant, int? CityId, int? RoomTypeId)
        {
            var HotelsResult = new List<HotelDto>();
            var results = GetSearchingQuery(searching, isPetFriendly, hasRestaurant, CityId, RoomTypeId);
            if (results != null)
            {
                foreach (Hotel hotel in results)
                {
                    HotelsResult.Add(new HotelDto()
                    {
                        HotelID=hotel.HotelID,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        Stars = hotel.Stars,
                        HasPool = hotel.HasPool,
                        HasParking = hotel.HasParking,
                        HasGym = hotel.HasGym,
                        HasSpaCenter = hotel.HasSpaCenter,
                        IsPetFriendly = hotel.IsPetFriendly,
                        HasWiFi = hotel.HasWiFi,
                        HasRestourant = hotel.HasRestourant,
                        Distance = hotel.Distance,
                        Description = hotel.Description,
                        PhotoData = hotel.PhotoData
                    });
                }
            }
            return HotelsResult;
        }
        //todo: naming conventions
        private IQueryable<Hotel> GetSearchingQuery(string searching, bool isPetFriendly, bool hasRestaurant, int? CityId, int? RoomTypeId)
        {
            var result = _hotelRepository.GetAllHotels();

            if (!string.IsNullOrEmpty(searching))
            {
                result = result.Where(x => x.Name.Contains(searching));
            }
            if (isPetFriendly)
            {
                result = result.Where(x => x.IsPetFriendly == isPetFriendly);
            }
            if (hasRestaurant)
            {
                result = result.Where(x => x.HasRestourant == hasRestaurant);
            }
            if (CityId.HasValue)
            {
                result = result.Where(x => x.CityID == CityId);
            }
            if (RoomTypeId.HasValue)
            {
                result = result.Where(x => x.Rooms.Any(y => y.RoomType.RoomTypesID == RoomTypeId));
            }
            return result;
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
