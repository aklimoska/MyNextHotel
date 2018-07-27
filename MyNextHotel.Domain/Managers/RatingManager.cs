
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNextHotel.Common.Dtos;
using MyNextHotel.Data;
using MyNextHotel.Data.Repositories;
using MyNextHotel.Domain.Interfaces;


namespace MyNextHotel.Domain.Managers
{
    public class RatingManager: IRatingManager
    {

        private IRatingRepository _ratingRepository;

        public RatingManager()
        {
            

            _ratingRepository = new RatingRepository();
        }



        public double GetRatingByHotelID(int hotelID)
        {
            List<int?> ratings = new List<int?>();
            ratings = _ratingRepository.GetRatingByHotel(hotelID);
            if (ratings.Any())
            {
                float _average = (float)ratings.Sum() / ratings.Count();
                
                return Math.Round(_average, 2);
            }
            else return 0;
        }

        public void AddRatingByHotelID(int hotelID, int rating)
        {
            Rating rate = new Rating
            {
                HotelID = hotelID,
                Rate = rating
            };

            _ratingRepository.AddRating(rate);
        }




    }
}
