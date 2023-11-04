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
            var x = db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault();
            if (x == null)
            {
                Session["event"] = null;
            }
            else
            {
                Session["event"] = x;
            }
            Rooms rooms = new Rooms();
            rooms.Id_Room=id;
            return View(db.Rooms.Where(s=>s.Id_Room==id).ToList());
        }
    }
}