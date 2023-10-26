using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        AirbnbEntities1 db = new AirbnbEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product_Index()
        {
            return PartialView(db.Rooms.ToList());
        }
    }
}