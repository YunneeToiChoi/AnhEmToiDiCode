using AirBNB_Admin.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        AirbnbEntities1 db = new AirbnbEntities1();
        //public ActionResult Index()
        //{
        //    return PartialView(db.AdminUsers.ToList());
        //}
        public ActionResult RegisterUser()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(AdminUser user)
        {
            var mail = user.Email_User;
                if (ModelState.IsValid)
                {
                    var check = db.AdminUsers.SingleOrDefault(s => s.ID == user.ID && s.Email_User.Equals(mail));
                    
                    if (check == null)// chua co id{
                    {
                        //user.Password_User = GetMD5(user.Password_User);
                        db.Configuration.ValidateOnSaveEnabled = false;
                        //Session["ID"] = user.ID;
                        db.AdminUsers.Add(user);
                        db.SaveChanges();
                      return RedirectToAction("index_login", "User");
                }
                    else
                    {
                        ViewBag.ErrorRegister = "This ID or Email is exist";
                        return RedirectToAction("index_register", "User");
                    }
                }
           return RedirectToAction("index_register", "User");


        }
        public ActionResult index_register(AdminUser user)
        {
            return PartialView();
        }
        public ActionResult LoginAccount()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAccount(AdminUser user)
        { 
                var check = db.AdminUsers.Where(s => s.Email_User == user.Email_User && s.Password_User == user.Password_User).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.LoginFail = "Dang nhap that bai";
                    Session["User"] = null;
                    return RedirectToAction("index_login", "User");
                }
                else
                {
                    Session["User"] = check;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    Session["ID"] = user.ID;
                    Session["PasswordUser"] = user.Password_User;
                    return RedirectToAction("Index", "Home");
                }
        }
        public ActionResult index_login(AdminUser user)
        {
            return PartialView();
        }
        public ActionResult Logout() {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LoginAccount(AdminUser user)
        //{
        //    var check = db.AdminUsers.Where(s => s.ID == user.ID && s.Password_User == user.Password_User).FirstOrDefault();
        //    if (check == null) {
        //        ViewBag.ErrorInfo = "Sai info ";
        //        return PartialView();
        //    }
        //    else
        //    {
        //        db.Configuration.ValidateOnSaveEnabled = false;
        //        Session["ID"] = user.ID;
        //        Session["PasswordUser"] = user.Password_User;
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //public ActionResult LoginAccount(string email, string password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var _password = GetMD5(password);
        //        var data = db.AdminUsers.Where(s => s.Email_User.Equals(email) && s.Password_User.Equals(_password)).ToList();
        //        if (data.Count() > 0)
        //        {
        //            // add session
        //            Session["FullName"] = data.FirstOrDefault().Name_User;
        //            Session["Email"] = data.FirstOrDefault().Email_User;
        //            Session["idUser"] = data.FirstOrDefault().ID;
        //        }
        //        else
        //        {
        //            ViewBag.error = "Login Failed";
        //            return View();
        //        }
        //    }
        //    return View();
        //}
    }
}