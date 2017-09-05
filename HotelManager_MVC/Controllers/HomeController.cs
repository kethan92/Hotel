using HotelManager_MVC.Models;
using HotelManager_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            RoomsClient roomsclient = new RoomsClient();
            var model = roomsclient.GetAll();
            ViewBag.roomsList = model;
            return View();
        }
        [HttpPost]
        public ActionResult Index(room_Type_DescriptionViewModel listroom)
        {
            Room_TypeClient roomsType = new Room_TypeClient();
            var model = roomsType.searchRoom_Type(listroom);
            ViewBag.roomsList = model;
            return View();
        }
        public ActionResult Create()
        {
            RoomStatusClient roomStatusclient = new RoomStatusClient();
            ViewBag.getRommStatus = new SelectList(roomStatusclient.getRoomStatus(), "id_RoomStatus", "status");
            Room_TypeClient roomTypeclient = new Room_TypeClient();
            ViewBag.getRoomType = new SelectList(roomTypeclient.getRoom_Type(), "room_Type_Code", "room_Type_Description");
            return View();
        }
        public ActionResult CreateRoom(RoomsViewModel model)
        {
            if(ModelState.IsValid)
            {
                var rooms = new RoomsClient().InsertRoom(model.rooms);
                if(rooms==true)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            return View("Index");
        }
    }
}