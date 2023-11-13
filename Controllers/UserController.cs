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
        AirbnbEntities2 db = new AirbnbEntities2();
        //public ActionResult Index()
        //{
        //    return PartialView(db.User.ToList());
        //}
        public ActionResult RegisterUser(int id = 0)
        {
            id = 0;
            User emp = new User();
            var lastemployee = db.User.OrderByDescending(x => x.ID_User).FirstOrDefault();
            if (id != 0)
            {
                emp = db.User.Where(x => x.ID_User == id).FirstOrDefault();
            }
            else if (lastemployee == null)
            {
                emp.ID_User = 0;
            }
            else
            {
                emp.ID_User = lastemployee.ID_User + 1;
            }
            return PartialView(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(User user)
        {
            var mail = user.Email;
            if (ModelState.IsValid)
            {
                var check = db.User.SingleOrDefault(s => s.ID_User == user.ID_User && s.Email.Equals(mail));
                if (check == null)// chua co id{
                {
                    //user.Password_User = GetMD5(user.Password_User);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    //Session["ID"] = user.ID;
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("index_loginMobile", "User");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID or Email is exist";
                    return RedirectToAction("RegisterUserMobile", "User");
                }
            }
            return RedirectToAction("RegisterUserMobile", "User");


        }

        public ActionResult RegisterUserMobile(int id = 0)
        {
            id = 0;
            User emp = new User();
            var lastemployee = db.User.OrderByDescending(x => x.ID_User).FirstOrDefault();
            if (id != 0)
            {
                emp = db.User.Where(x => x.ID_User == id).FirstOrDefault();
            }
            else if (lastemployee == null)
            {
                emp.ID_User = 0;
            }
            else
            {
                emp.ID_User = lastemployee.ID_User + 1;
            }
            return PartialView(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUserMobile(User user)
        {
            var mail = user.Email;
            Session["event"] = 2;
            if (ModelState.IsValid)
            {
                var check = db.User.SingleOrDefault(s => s.ID_User == user.ID_User && s.Email.Equals(mail));

                if (check == null)// chua co id{
                {
                    //user.Password_User = GetMD5(user.Password_User);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    //Session["ID"] = user.ID;
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("index_loginMobile", "User");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID or Email is exist";
                    return RedirectToAction("RegisterUserMobile", "User");
                }
            }
            return RedirectToAction("RegisterUserMobile", "User");


        }
        //----------------------------------------------------------------------------------------------
        public ActionResult LoginAccount()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAccount(User user)
        {
            var check = db.User.Where(s => s.Email == user.Email && s.Password == user.Password).FirstOrDefault();
            if (check == null)
            {
                ViewBag.LoginFail = "Dang nhap that bai";
                Session["User"] = null;
                ModelState.AddModelError("myError", "InvalidEmail or Password");
                return RedirectToAction("index_loginMobile", "User");

            }
            else
            {
                Session["User"] = check;
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = user.ID_User;
                Session["PasswordUser"] = user.Password;
                db.SaveChanges();
                return RedirectToAction("Product_Index_Main", "Product");
            }
        }
        public ActionResult index_loginMobile()
        {
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Product_Index_Main", "Product");
        }
    }
}