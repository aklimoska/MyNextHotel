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
    }
}
