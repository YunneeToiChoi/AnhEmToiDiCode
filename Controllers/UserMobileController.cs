using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class UserMobileController : Controller
    {
        AirbnbEntities2 db = new   AirbnbEntities2();
        public ActionResult Index(int id=0)
        {
            id = 0;
            return View(db.User.Where(x=> x.ID_User == id ).ToList());
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
            return RedirectToAction("Logout", "User");
        }
        public ActionResult User_Edit(int id)
        {
            return View(db.User.Where(s => s.ID_User == id).FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult User_Edit([Bind(Include = "ID_User,Email,Phone_number,User_Name,Address,Password")] User account) // bin ke thua lai cac contruc
        {
            var pro = db.User.FirstOrDefault(s => s.ID_User == account.ID_User);
            if (pro != null)
            {
                pro.ID_User = account.ID_User;
                pro.User_Name = account.User_Name;
                pro.Email = account.Email;
                pro.Phone_number = account.Phone_number;
                pro.Address = account.Address;
                pro.Password = account.Password;
                pro.ConfirmPassword = account.Password;
            }
            try // test bug
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex); // bat loi
            }
            return RedirectToAction("Logout", "User"); // fix xong thi log out 
        }

        public ActionResult User_Control(int id)
        {
            return View(db.User.Where(x=> x.ID_User==id).ToList());
        }
    }
}