using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextHotel.Data.Repositories
{
    public class RatingRepository:IRatingRepository
    {
        private MyNextHotelDbContext _myNextHotelDbContext = new MyNextHotelDbContext();
        
       
       public List<int?> GetRatingByHotel(int hotelID)
        {
            List<int?> ratings = new List<int?>();
            
            ratings= _myNextHotelDbContext.Ratings.Where(x => x.HotelID == hotelID).Select(x => x.Rate).ToList();
            return ratings;
        }
       
       

        public void AddRating(Rating rate)
        {
            
            _myNextHotelDbContext.Ratings.Add(rate);
            _myNextHotelDbContext.SaveChanges();
        }
    }

}
