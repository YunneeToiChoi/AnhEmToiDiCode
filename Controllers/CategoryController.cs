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
        private AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category_Index(string name)
        {
            var item = db.Category.Where(s => s.Name_Cate.Contains(name)).ToList();
            if (name == null)
            {
                return PartialView("Category_Index", db.Category.ToList());
            }
            else
            {
                return PartialView("Category_Index", db.Category.Where(s => s.Name_Cate.Contains(name)).ToList());
            }
        }
    }
}