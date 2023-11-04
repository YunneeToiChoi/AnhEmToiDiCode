using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class OrderProductController : Controller
    {
        // GET: OrderProduct
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Index_OrderProduct(int id)
        {
            Rooms rooms = new Rooms();
            rooms.Id_Room=id;
            return View(db.Rooms.Where(x=>x.Id_Room==id).ToList());
        }
    }
}