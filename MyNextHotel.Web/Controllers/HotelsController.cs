using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNextHotel.Domain.Interfaces;
using MyNextHotel.Domain.Managers;

namespace MyNextHotel.Web.Controllers
{
    public class HotelsController : Controller
    {
        private IHotelsManager _hotelsManager;

        public HotelsController()
        {
            _hotelsManager = new HotelsManager();
        }
        // GET: Hotels
        public ActionResult Index()
        {
            return View();
        }

        
        //[HttpGet]
        //public ActionResult GetHotels()
        //{
        //    var result =_hotelsManager.GetHotel(1);
        //    return Content(result.Name);
        //}
    }
}