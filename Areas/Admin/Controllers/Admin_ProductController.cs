using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Areas.Admin.Controllers
{
    public class Admin_ProductController : Controller
    {
        // GET: Admin_Product
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SelectCate() // tao category list cho prodct = ccah lay data tu category
        {
            Category catels = new Category();
            catels.ListCate = db.Category.ToList<Category>();
            return PartialView(catels);

        }
        public ActionResult Product_Create(int id = 0)
        {
            Rooms emp = new Rooms();
            var lastemployee = db.Rooms.OrderByDescending(x => x.Id_Room).FirstOrDefault();
            if (id != 0)
            {
                emp = db.Rooms.Where(x => x.Id_Room == id).FirstOrDefault();
            }
            else if (lastemployee == null)
            {
                emp.Id_Room = 0;
            }
            else
            {
                emp.Id_Room = lastemployee.Id_Room + 1;
            }
            return View(emp);
        }
        [HttpPost]
        public ActionResult Product_Create(Rooms pro)
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename += extent;
                    pro.Images_Room = "~/Content/image/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
                List<Category> catels = db.Category.ToList();
                foreach (var item in catels)
                {
                    pro.Name_Cate = db.Category.Where(x => x.ID_Cate == pro.ID_Cate).Select(x => x.Name_Cate).FirstOrDefault();
                }
                db.Rooms.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Product_Control", pro);
            }
            catch
            {
                return Content("Sai roi bro bo di ma lam ng");
            }
        }
        public ActionResult Product_Delete(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Product_Delete(int id, Rooms room)
        {
            room = db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault();
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Product_Control");
        }
        public ActionResult Product_Detail(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        public ActionResult Product_Edit(int id)
        {
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Product_Edit(int id, Rooms room)
        {
            try
            {
                if (room.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(room.UploadImage.FileName);
                    string extent = Path.GetExtension(room.UploadImage.FileName);
                    filename += extent;
                    room.Images_Room = "~/Content/image/" + filename;
                    room.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
                List<Category> catels = db.Category.ToList();
                foreach (var item in catels)
                {
                    room.Name_Cate = db.Category.Where(x => x.ID_Cate == room.ID_Cate).Select(x=>x.Name_Cate).FirstOrDefault();
                }
                db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Product_Control");
            }
            catch
            {
                return Content("Sai roi bro");
            }
            
        }
        public ActionResult Product_Control()
            {
                return View(db.Rooms.ToList());
            }
    } 
}