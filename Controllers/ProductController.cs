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
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Map()
        {

            return View();
        }
        [Obsolete]
        public ActionResult Product_Index_Main()
        {
            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2();

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i)
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
        [Obsolete]
        public ActionResult Product_Index_Main__Agothims(int id = 0)
        {
            int cateid = 0;
            var roomsgiamdan = db.Rooms.OrderByDescending(x => x.ID_Cate).Where(x => x.ID_Cate == cateid);
            var roomsGuest = from room in db.Rooms
                             where room.Guest <= 2
                             select room;

            var roomsPlace = from room in db.Rooms
                             where room.Place == "Hà Nội"
                             select room;
            var roomsPrice = from room in db.Rooms
                             where room.Price < 1000000
                             select room;
            var roomsLaySLtheogia = db.Rooms
            .OrderBy(room => room.Price)
            .Take(5);
            var countStatus = db.Rooms.Where(room => room.Status == "Sẵn sàng").Count();
            var roomsRatings = from room in db.Rooms
                               join review in db.Reviews on room.Id_Room equals review.Id_Room
                               where review.Rating >= 4
                               select room;
            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2();

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i)
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
            List<Category> catels = db.Category.ToList();
            Rooms pro = new Rooms();
            foreach (var item in catels)
            {
                pro.Name_Cate = db.Category.Where(x => x.ID_Cate == item.ID_Cate).Select(x => x.Name_Cate).FirstOrDefault();
            }
            return View(db.Rooms.ToList());
        }
        public ActionResult ShowProductHBOR()
        {
            var products = from product in db.Rooms
                           join orderDetail in db.OrderProduct on product.Id_Room equals orderDetail.ID_Product
                           join od in db.OrderProduct on orderDetail.idOder equals od.idOder
                           where od.DateTime > DateTime.Now.AddMonths(-1)
                           select product;
            return View(products);
        }
        public ActionResult FindByName(string name)
        {
            var check = db.Rooms.Where(s => s.Room_Name == name).FirstOrDefault();
            return View(check);
        }
        public ActionResult Roomgiamdan(int cateid) {
            var roomsgiamdan = db.Rooms.OrderByDescending(x => x.ID_Cate).Where(x => x.ID_Cate == cateid);
            return View(roomsgiamdan);
        }
        public ActionResult RoomLayNguoidung(int sl)
        {
            var roomsGuest = from room in db.Rooms
                             where room.Guest <= sl
                             select room;
            return View(roomsGuest);
        }
        public ActionResult RoomsPlace(string place)
        {
            var roomsPlace = from room in db.Rooms
                             where room.Place == place
                             select room;
            return View(roomsPlace);
        }

        public ActionResult RoomsPrice(decimal gia)
        {
            var roomsPrice = from room in db.Rooms
                             where room.Price < gia
                             select room;
            return View(roomsPrice);
        }
        public ActionResult RoomsSLPrice(int sl)
        {
            var roomsLaySLtheogia = db.Rooms
          .OrderBy(room => room.Price)
          .Take(sl);
            return View(roomsLaySLtheogia);
        }
        public ActionResult RoomsStatus()
        {
            var countStatus = db.Rooms.Where(room => room.Status == "Sẵn sàng").Count();
            return View(countStatus);
        }
        public ActionResult RoomsRatings(int sl)
        {
            var roomsRatings = from room in db.Rooms
                               join review in db.Reviews on room.Id_Room equals review.Id_Room
                               where review.Rating >= 4
                               select room;
            return View(roomsRatings);
        }
        public ActionResult SearchOptions(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) 
        {
            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2();

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i)
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
            var list = db.Rooms.Where(p => (decimal)p.Price >= min && (decimal)p.Price <= max).ToList();
            TempData["SearchResults"] = list;
            return RedirectToAction("AnswerShowSearch",list);
        }

        [Obsolete]
        public ActionResult AnswerShowGiaGiamDanSearch()
        {
            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2();

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i)
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
            var list = from b in db.Rooms
                       orderby b.Price descending
                       select b;
            TempData["GiaGiamDan"] = list;
            return View(list);
        }
        public ActionResult AnswerShowGiaTangDanSearch()
        {
            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2();

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i)
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
            var list = from b in db.Rooms
                       orderby b.Price ascending
                       select b;
            TempData["GiaTangDan"] = list;
            return View(list);
        }
        public ActionResult AnswerShowSearch()
        {
            var list = TempData["SearchResults"] as List<Rooms>;
            if (list != null)
            {
                return View(list);
            }
            return View("SearchOptions");
        }
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