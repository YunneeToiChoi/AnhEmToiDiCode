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
        AirbnbEntities2 db = new AirbnbEntities2();
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
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("LoginAccount", "User");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID or Email is exist";
                    return RedirectToAction("RegisterUser", "User");
                }
            }
            return View(user);
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

                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
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
        public ActionResult LoginAccount()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAccount(User user)
        {
            var check = db.User.Where(s => s.Email == user.Email && s.Password == user.Password).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (check == null)
                {
                    ViewBag.LoginFail = "Đăng nhập thất bại. Email hoặc mật khẩu không chính xác.";
                    Session["User"] = null;
                    ModelState.AddModelError("myError", "InvalidEmail or Password");
                    return View(user);
                }
                else
                {
                    Session["User"] = check;
                    Session["ID"] = user.ID_User;
                    Session["PasswordUser"] = user.Password;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    return RedirectToAction("Product_Index_Main", "Product");
                }
            }
            else
            {
              if(check!=null)
                {
                    Session["User"] = check;
                    Session["ID"] = user.ID_User;
                    Session["PasswordUser"] = user.Password;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    return RedirectToAction("Product_Index_Main", "Product");
                }
                ViewBag.LoginFail = "Đăng nhập thất bại. Email hoặc mật khẩu không chính xác.";
                return View(user);
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