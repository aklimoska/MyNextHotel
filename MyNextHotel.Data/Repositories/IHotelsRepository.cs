using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNextHotel.Data;

namespace MyNextHotel.Data.Repositories
{
    public interface IHotelsRepository
    {
        IQueryable<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        Hotel GetHotelByCityId(int id);
        void AddHotel(Hotel hotel, List<Room> rooms);
        void RemoveHotel(Hotel hotel);
        IQueryable<Hotel> SearchingQuery();
    }
}
