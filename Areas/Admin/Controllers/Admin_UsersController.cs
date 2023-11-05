using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Areas.Admin.Controllers
{
    public class Admin_UsersController : Controller
    {
        // GET: Admin/Admin_Users
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult User_Control()
        {
            return View(db.User.ToList());
        }
        public ActionResult User_Delete(int id)
        {
            return View(db.User.Where(s => s.ID_User == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult User_Delete(int id, User user)
        {
            user = db.User.Where(s => s.ID_User == id).FirstOrDefault();
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("User_Control");
        }
        public ActionResult User_Detail(int id)
        {
            return View(db.User.Where(s => s.ID_User == id).FirstOrDefault());
        }
    }
}