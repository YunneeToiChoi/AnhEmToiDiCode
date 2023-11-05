using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class UserMobileController : Controller
    {
        // GET: UserMobile
        AirbnbEntities2 db = new   AirbnbEntities2();
        public ActionResult Index(int id=0)
        {
            id = 0;
            return View(db.User.Where(x=> x.ID_User == id ).ToList());
        }

        public ActionResult Info(int id = 0)
        {
            id = 0;
            return View(db.User.Where(x => x.ID_User == id).ToList());
        }

    }
}