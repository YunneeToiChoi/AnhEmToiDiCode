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
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Category_Control()
        {
            return View(db.Category.ToList());
        }
        public ActionResult Category_Create(int id=0)
        {

            Category emp = new Category();
            var lastemployee = db.Category.OrderByDescending(x => x.ID_Cate).FirstOrDefault();
            if (id != 0)
            {
                emp = db.Category.Where(x => x.ID_Cate == id).FirstOrDefault();
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
                db.Category.Add(pro);
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
            return View(db.Category.Where(s => s.ID_Cate == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Category_Delete(int id, Category cate)
        {
            cate = db.Category.Where(s => s.ID_Cate == id).FirstOrDefault();
            db.Category.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Category_Control");
        }
        public ActionResult Category_Detail(int id)
        {
            return View(db.Category.Where(s => s.ID_Cate == id).FirstOrDefault());
        }
        public ActionResult Category_Edit(int id)
        {
            return View(db.Category.Where(s => s.ID_Cate == id).FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Category_Edit([Bind(Include = "ID_Cate,Name_Cate,Image_Cate")] Category cate, HttpPostedFileBase Upload)
        {
            var pro = db.Category.FirstOrDefault(p => p.ID_Cate == cate.ID_Cate );
            if (pro != null)
            {
                pro.Name_Cate = cate.Name_Cate;
                if (Upload != null)
                {
                    var filename = Path.GetFileName(Upload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/image/"), filename);
                    pro.Image_Cate = "~/Content/image/" + filename;
                    Upload.SaveAs(path);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Category_Control");
        }
    }
}