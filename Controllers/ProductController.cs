using AirBNB_Admin.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AirBNB_Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        AirbnbEntities2 db = new AirbnbEntities2();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Product_Index_Main()
        {




            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2(); 

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i) // thuat toan tinh tong ngay cua san pham 
                    .Select(room => EntityFunctions.DiffDays(room.Check_out, room.Check_in))
                    .Sum();

                var get = db.Rooms.Where(s => s.Id_Room == i).FirstOrDefault();
                get.tongtientruocthue = 1;
                get.tongtientruocthue = -(get.Price * totalDays);
                get.tongtiensauthue = 1;
              get.tongtiensauthue = get.tongtientruocthue * 15 / 100;
                get.tongdem = 1;
                get.tongdem = totalDays;
                db.SaveChanges();
            }
            return PartialView(db.Rooms.ToList());
        }
        //public ActionResult Product_Index_Main__Agothims(int id =0)
        //{
        //    List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
        //        foreach(int i in sum)
        //    {
        //        var x = db.Rooms.Where(s => s.Id_Room == i).FirstOrDefault();
        //        x.tongtientrong5ngay = 1;
        //        x.tongtientrong5ngay = x.Price * 100;
        //        db.SaveChanges();
        //    }
        //    return View(db.Rooms.ToList());
        //}
        public ActionResult Product_Index(int cateid)
        {
            if (cateid == -1)
            {
                var productList = db.Rooms.OrderByDescending(x => x.ID_Cate);
                return View(productList);
            }
            else
            {
                var productlist = db.Rooms.OrderByDescending(x => x.ID_Cate).Where(x => x.ID_Cate == cateid);
                return View(productlist);
            }




        }
        public ActionResult Product_Detail_user(int id)
        {
            var x = db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault();
            if (x == null)
            {
                Session["event"] = null;
            }
            else
            {
                Session["event"] = x;
            }
            return View(db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault());
        }
    }
}