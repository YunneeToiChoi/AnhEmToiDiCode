using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult LoginAdmin()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(AdminUser user)
        {
            var check = db.AdminUser.Where(s => s.Email_User == user.Email_User && s.Password_User == user.Password_User).FirstOrDefault();
            if (check == null)
            {
                ViewBag.LoginFail = "Dang nhap that bai";
                ModelState.AddModelError("myError", "InvalidEmail or Password");
                return RedirectToAction("LoginAdmin", "LoginAdmin");

            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = user.ID;
                Session["PasswordUser"] = user.Password_User;
                db.SaveChanges();
                return View("localhost:44371/Admin/HomeAdmin/Index");
            }
        }
    }
}