using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextHotel.Data.Repositories
{
    public interface IRatingRepository
    {
        void AddRating(Rating rate);
        List<int?> GetRatingByHotel(int HotelID);
    }
}
