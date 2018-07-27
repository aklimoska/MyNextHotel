using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNextHotel.Domain.Interfaces;
using MyNextHotel.Domain.Managers;
using MyNextHotel.Web;
using MyNextHotel.Common.Dtos;


namespace MyNextHotel.Web.Controllers
{
    public class HotelsController : Controller
    {
        private IHotelsManager _hotelsManager;
        private IRatingManager _ratingManager;
       

        public HotelsController()
        {
            _hotelsManager = new HotelsManager();
            _ratingManager = new RatingManager();
        }
        // GET: Hotels
        public ActionResult Index()
        {
            return View();
        }

        
        
        public ActionResult AddRating(int id, int star)
        {
            _ratingManager.AddRatingByHotelID(id, star);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult HotelDetails(int id)
        {
            HotelDto hotelmodel = new HotelDto();
            hotelmodel = _hotelsManager.GetHotel(id);
                        
            hotelmodel.Rating = (float)_ratingManager.GetRatingByHotelID(id);
            
            return View(hotelmodel);
        }

    }
}