using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextHotel.Domain.Interfaces
{
    public interface IRatingManager
    {
        double GetRatingByHotelID(int hotelID);

        void AddRatingByHotelID(int hotelID, int rating);
    }
}
