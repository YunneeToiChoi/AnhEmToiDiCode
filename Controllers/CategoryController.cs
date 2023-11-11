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
        // GET: Category
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

        //public ActionResult ViewmodelProCate(int idcate)
        //{
        //    List<Category> Cate = db.Category.ToList();
        //    List<Rooms> Pro = db.Rooms.ToList();
        //    var query = Cate.GroupJoin(Pro, a => a.ID_Cate, b => b.ID_Cate, (Category, ProList) =>
        //    {
        //        return new ViewModelProCate
        //        {
        //            cate = Category,
        //            pro = (Rooms)ProList,
        //        };
        //    }
        //    );
        //    return View(query.ToList());
        //}
    }
}