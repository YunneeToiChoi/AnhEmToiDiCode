using AirBNB_Admin.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        AirbnbEntities1 db = new AirbnbEntities1();
        public ActionResult FormLogin()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult LoginAccount(AdminUser user)
        {
            var check = db.AdminUsers.Where(s => s.ID == user.ID && s.Password_User == user.Password_User).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("Index");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = user.ID;
                Session["PasswordUser"] = user.Password_User;
                return View();
            }
        }
        public ActionResult RegisterUser()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult RegisterUser(AdminUser user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = db.AdminUsers.Where(s => s.ID == user.ID).FirstOrDefault();
                if(check_ID==null)// chua co id{
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.AdminUsers.Add(user);
                    db.SaveChanges();
                    return View("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View();
                }
            }
            return View();
        }   
    }
}