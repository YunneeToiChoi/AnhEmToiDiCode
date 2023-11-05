using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult User_Edit(int id, User user)
        {
            try
            {
                // mot them anh  vao nha 
                //if (room.UploadImage != null)
                //{
                //    string filename = Path.GetFileNameWithoutExtension(room.UploadImage.FileName);
                //    string extent = Path.GetExtension(room.UploadImage.FileName);
                //    filename += extent;
                //    room.Images_Room = "~/Content/image/" + filename;
                //    room.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                //}
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Logout","User");
            }
            catch
            {
                return Content("Sai roi bro, xoa di ma lam nguoi");
            }
        }
        public ActionResult User_Control(int id)
        {
            return View(db.User.Where(x=> x.ID_User==id).ToList());
        }

    }
}