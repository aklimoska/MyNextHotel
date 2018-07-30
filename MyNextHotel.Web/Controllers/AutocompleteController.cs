using MyNextHotel.Common.Dtos;
using MyNextHotel.Domain.Interfaces;
using MyNextHotel.Domain.Managers;
using MyNextHotel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNextHotel.Web.Controllers
{
    public class AutocompleteController : Controller
    {
        private IHotelsManager _hotelsManager;
        // GET: Autocomplete

        public AutocompleteController()
        {
            _hotelsManager = new HotelsManager();
        }
        public JsonResult GetSearchValue(string search)
        {
            var cityModel = new List<CityModel>();
            var results = _hotelsManager.GetAllCitiesByName(search);
            if (results != null)
            {
                foreach (CityDto city in results)
                {
                    cityModel.Add(new CityModel()
                    {
                        CityID = city.CityID,
                        Name = city.Name
                    });
                }
            }

            return new JsonResult { Data = cityModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}