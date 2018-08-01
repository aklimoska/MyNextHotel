using MyNextHotel.Common.Dtos;
using MyNextHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextHotel.Domain.Interfaces
{
    public interface IHotelsManager
    {
        void AddHotel(HotelDto hotelDto);
        void AddRoom(RoomDto roomDto);
        int NumberOfRoom(int hotelId);
        List<string> GetAllRoomType();
        HotelDto GetHotel(int id);
        List<HotelDto> GetAllHotels();
        List<CityDto> GetAllCitiesByName(string searchTerm);
        List<HotelDto> SearchResults(string keyword, bool isPetFriendly, bool hasRestaurant, string keywordCity, int? RoomTypeId);
    }
}
