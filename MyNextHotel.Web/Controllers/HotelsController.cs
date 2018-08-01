using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNextHotel.Domain.Interfaces;
using MyNextHotel.Domain.Managers;
using MyNextHotel.Web;
using MyNextHotel.Common.Dtos;
using MyNextHotel.Web.Models;
using System.IO;
using System.Drawing;

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
        public ActionResult Menage()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateHotelViewModel newHotel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                HotelDto hotelDto = new HotelDto();
                hotelDto.Name = newHotel.Name;
                hotelDto.Stars = newHotel.Stars;
                hotelDto.HasPool = newHotel.HasPool;
                hotelDto.HasParking = newHotel.HasParking;
                hotelDto.HasRestourant = newHotel.HasRestourant;
                hotelDto.HasGym = newHotel.HasGym;
                hotelDto.HasSpaCenter = newHotel.HasSpaCenter;
                hotelDto.HasWiFi = newHotel.HasWiFi;
                hotelDto.IsPetFriendly = newHotel.IsPetFriendly;
                hotelDto.Description = newHotel.Description;
                hotelDto.Distance = newHotel.Distance;
                hotelDto.Address = newHotel.Address;
                hotelDto.CityName = newHotel.City;
                hotelDto.PhotoData = FileToByteArray(file);
                _hotelsManager.AddHotel(hotelDto);

                return RedirectToAction("Menage");
            }
            else
            {
                return View(newHotel);
            }
        }

        private byte[] FileToByteArray(HttpPostedFileBase file)
        {
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = b.ReadBytes(file.ContentLength);
            return binData;
        }

        public ActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRoom(CreateRoomViewModel newRoom, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                var roomDto = new RoomDto();
                roomDto.Capacity = newRoom.Capacity;
                roomDto.HasAirCondition = newRoom.HasAirCondition;
                roomDto.HasBalcony = newRoom.HasBalcony;
                roomDto.HasKitchen = newRoom.HasKitchen;
                roomDto.HasPrivateBathroom = newRoom.HasPrivateBathroom;
                roomDto.HasTv = newRoom.HasTv;
                roomDto.Price = newRoom.Price;
                roomDto.Quadrature = newRoom.Quadrature;
                roomDto.Type = newRoom.Type;
                roomDto.PhotoData = FileToByteArray(file);
                _hotelsManager.AddRoom(roomDto);

                return RedirectToAction("Menage");
            }
            else
            {
                return View(newRoom);
            }
        }

        
        [HttpGet]
        public ActionResult GetAllHotels()
        {
            List<HotelDto> model = new List<HotelDto>();
            GetAllHotelsViewModel Model = new GetAllHotelsViewModel();
            List<string> roomtypes = new List<string>();
            roomtypes = _hotelsManager.GetAllRoomType();
            model = _hotelsManager.GetAllHotels();
            Model.Hotels = model;
            Model.RoomTypes = roomtypes;



            return View(Model);
        }

        [HttpGet]
        public ActionResult Search(string keyword, bool isPetFriendly, bool hasRestaurant, string keywordCity, int? roomTypeId)
        {
            var model = _hotelsManager.SearchResults(keyword, isPetFriendly, hasRestaurant, keywordCity, roomTypeId);
            ViewBag.SearchList = model;
            List<string> roomtypes = new List<string>();
            roomtypes = _hotelsManager.GetAllRoomType();
            GetAllHotelsViewModel Model = new GetAllHotelsViewModel();
            Model.RoomTypes = roomtypes;
            return View(Model);

            
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