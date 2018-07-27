using MyNextHotel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyNextHotel.Data.Repositories
{
    public class HotelsRepository : IHotelsRepository
    {
        private MyNextHotelDbContext _myNextHotelContext;
        private ILogger _logger;

        public HotelsRepository()
        {
            _logger = new ProjectLogger();
            _myNextHotelContext = new MyNextHotelDbContext();
        }
        public void AddHotel(Hotel hotel, List<Room> rooms)
        {
            //if (hotel == null) throw new ArgumentNullException("hotel");
            var savedHotel = _myNextHotelContext.Hotels.Add(hotel);
            _myNextHotelContext.Rooms.AddRange(rooms);
            _myNextHotelContext.SaveChanges();
        }

        public IQueryable<Hotel> GetAllHotels()
        {           
            return _myNextHotelContext.Hotels;
        }

        public IQueryable<Hotel> SearchingQuery()    //todo: remove
        {
            return _myNextHotelContext.Hotels.AsQueryable();
        }
        public Hotel GetHotelByCityId(int id)
        {
            return _myNextHotelContext.Hotels.Where(x => x.CityID == id).FirstOrDefault();
        }


        public Hotel GetHotelById(int id)
        {
            return _myNextHotelContext.Hotels.Where(x => x.HotelID == id).FirstOrDefault();
            
        }

        public void RemoveHotel(Hotel hotel)
        {
            _myNextHotelContext.Hotels.Remove(hotel);
            _myNextHotelContext.SaveChanges();
        }
    }
}
