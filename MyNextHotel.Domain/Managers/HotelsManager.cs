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
            var hotelsResult = new List<HotelDto>();
            var result = _hotelRepository.GetAllHotels();
            if (result != null)
            {
                foreach (Hotel hotel in result)
                {
                    hotelsResult.Add(new HotelDto()
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
                        PhotoData = hotel.PhotoData,
                        City = new CityDto()
                        {
                            CityID = hotel.CityID,
                            Name = hotel.City.Name
                        }
                    });
                }
            }
            return hotelsResult;
        }
        public List<CityDto> GetAllCitiesByName(string searchTerm)
        {
            var citiesResults = new List<CityDto>();
            var result = _hotelRepository.GetAllCities();
            result = result.Where(x => x.Name.StartsWith(searchTerm));
            if (result != null)
            {
                foreach (City city in result)
                {
                    citiesResults.Add(new CityDto()
                    {
                        CityID = city.CityID,
                        Name = city.Name
                    });
                }
            }
            return citiesResults;
        }

        public List<HotelDto> SearchResults(string keyword, bool isPetFriendly, bool hasRestaurant, string keywordCity, int? roomTypeId)
        {
            var hotelsResult = new List<HotelDto>();
            var results = GetSearchingQuery(keyword, isPetFriendly, hasRestaurant, keywordCity, roomTypeId);
            if (results != null)
            {
                foreach (Hotel hotel in results)
                {
                    hotelsResult.Add(new HotelDto()
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
                        PhotoData = hotel.PhotoData,
                        City = new CityDto()
                        {
                            CityID = hotel.CityID,
                            Name = hotel.City.Name
                        }
                    });
                }
            }
            return hotelsResult;
        }
        private IQueryable<Hotel> GetSearchingQuery(string keyword, bool isPetFriendly, bool hasRestaurant, string keywordCity, int? roomTypeId)
        {
            var result = _hotelRepository.GetAllHotels();

            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(x => x.Name.Contains(keyword));
            }
            if (isPetFriendly)
            {
                result = result.Where(x => x.IsPetFriendly == isPetFriendly);
            }
            if (hasRestaurant)
            {
                result = result.Where(x => x.HasRestourant == hasRestaurant);
            }
            if (!string.IsNullOrEmpty(keywordCity))
            {
                result = result.Where(x => x.City.Name.Contains(keywordCity));
            }
            if (roomTypeId.HasValue)
            {
                result = result.Where(x => x.Rooms.Any(y => y.RoomType.RoomTypesID == roomTypeId));
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
