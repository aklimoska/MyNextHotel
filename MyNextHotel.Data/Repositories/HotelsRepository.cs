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
        public void AddHotel(Hotel hotel)
        {
            var savedHotel = _myNextHotelContext.Hotels.Add(hotel);
            _myNextHotelContext.SaveChanges();
        }
        public void AddHotel(Hotel hotel, List<Room> rooms)
        {
            var savedHotel = _myNextHotelContext.Hotels.Add(hotel);
            _myNextHotelContext.Rooms.AddRange(rooms);
            _myNextHotelContext.SaveChanges();
        }

        public IQueryable<Hotel> GetAllHotels()
        {           
            return _myNextHotelContext.Hotels.Where(x => x.Rooms.Any());
        }
        public IQueryable<City> GetAllCities()
        {
            return _myNextHotelContext.Cities;
        }
        public int GetCityIdByName(string name)
        {
            return _myNextHotelContext.Cities.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault().CityID;
        }
        public void AddRoom(Room room)
        {
            var savedHotel = _myNextHotelContext.Rooms.Add(room);
            _myNextHotelContext.SaveChanges();
        }

        public int NumberOfRoom(int hotelId)
        {
            return GetHotelById(hotelId).Rooms.Count;
        }
        public Hotel GetHotelByCityId(int id)
        {
            return _myNextHotelContext.Hotels.Where(x => x.CityID == id).FirstOrDefault();
        }


        public Hotel GetHotelById(int id)
        {
            return _myNextHotelContext.Hotels.Where(x => x.HotelID == id).FirstOrDefault();
            
        }
        public List<RoomType> GetAllRoomTypes()
        {
            return _myNextHotelContext.RoomTypes.ToList();
        }
        public void RemoveHotel(Hotel hotel)
        {
            _myNextHotelContext.Hotels.Remove(hotel);
            _myNextHotelContext.SaveChanges();
        }
    }
}
