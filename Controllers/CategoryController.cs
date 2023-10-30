using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class CategoryController : Controller
    {
        private AirbnbEntities1 db = new AirbnbEntities1();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category_Index(string name)
        {
            var item = db.Categories.Where(s => s.Name_Cate.Contains(name)).ToList();
            if (name == null)
            {
                return PartialView("Category_Index", db.Categories.ToList());
            }
            else
            {
                return PartialView("Category_Index", db.Categories.Where(s => s.Name_Cate.Contains(name)).ToList());
            }
        }
    }
}