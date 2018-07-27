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
        HotelDto GetHotel(int id);
        List<HotelDto> GetAllHotels();
       // IQueryable<Hotel> GetSearchingQuery(string searching, bool isPetFriendly, bool hasRestaurant, int? CityId, int? RoomTypeId);
        List<HotelDto> SearchResults(string searching, bool isPetFriendly, bool hasRestaurant, int? CityId, int? RoomTypeId);
    }
}
