using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class OrderDetail_ProductController : Controller
    {
        // GET: OrderDetail_Product
       AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Top10_Pro()
        {
            List<OrderProduct> order = db.OrderProduct.ToList();
            List<Rooms> pro = db.Rooms.ToList();
            var check = from od in order
                        join p in pro on od.ID_Product equals p.Id_Room into dbt
                        group od by new
                        {
                            IdPro = od.Rooms.Id_Room,
                            NamePro = od.Rooms.Room_Name,
                            ImagePro = od.Rooms.Images_Room,
                            Price = od.Rooms.Price
                        } into x
                        orderby x.Sum(s => s.Quantity) ascending
                        select new Top_ViewModel
                        {
                            Id = (int)x.Key.IdPro,
                            namePro = x.Key.NamePro,
                            imagePro = x.Key.ImagePro,
                            price = x.Key.Price,
                            Top_10_Pro = x.Sum(s => s.Quantity)
                        };
            return View(check.Take(10).ToList());
        }
     }
    }
