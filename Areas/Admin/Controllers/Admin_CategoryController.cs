using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Areas.Admin.Controllers
{
    public class Admin_CategoryController : Controller
    {
        // GET: Admin/Admin_Category
        AirbnbEntities1 db = new AirbnbEntities1();
        public ActionResult Category_Control()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Category_Create(int id=0)
        {

            Category emp = new Category();
            var lastemployee = db.Categories.OrderByDescending(x => x.ID_Cate).FirstOrDefault();
            if (id != 0)
            {
                emp = db.Categories.Where(x => x.ID_Cate == id).FirstOrDefault();
            }
            else if (lastemployee == null)
            {
                emp.ID_Cate = 0;
            }
            else
            {
                emp.ID_Cate = lastemployee.ID_Cate + 1;
            }
            return View(emp);
        }
        [HttpPost]
        public ActionResult Category_Create(Category pro)
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename += extent;
                    pro.Image_Cate = "~/Content/image/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
                db.Categories.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Category_Control", pro);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Category_Delete(int id)
        {
            return View(db.Categories.Where(s => s.ID_Cate == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Category_Delete(int id, Category cate)
        {
            cate = db.Categories.Where(s => s.ID_Cate == id).FirstOrDefault();
            db.Categories.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Category_Control");
        }



        public ActionResult Category_Detail(int id)
        {
            return View(db.Categories.Where(s => s.ID_Cate == id).FirstOrDefault());
        }


        public ActionResult Category_Edit(int id)
        {
            return View(db.Categories.Where(s => s.ID_Cate == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Category_Edit(Category cate)
        {
            try
            {
                if (cate.UploadImage != null )
                {
                    string filename = Path.GetFileNameWithoutExtension(cate.UploadImage.FileName);
                    string extent = Path.GetExtension(cate.UploadImage.FileName);
                    filename += extent;
                    cate.Image_Cate = "~/Content/image/" + filename;
                    cate.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/image/"), filename));
                }
                db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Category_Control");
            }
            catch
            {
                return Content("Sai roi bro, xoa di ma lam nguoi");
            }
        }
    }
}