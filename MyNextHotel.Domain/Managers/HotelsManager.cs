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

        
        public HotelDto GetHotel(int id)
        {
            var HotelResult = new HotelDto();

            var result = _hotelRepository.GetHotelById(id);
            if(result!=null)
            {
                HotelResult.Name = result.Name;
            }

            return HotelResult;
        }
    }
}
