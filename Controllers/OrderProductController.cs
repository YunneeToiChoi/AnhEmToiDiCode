using AirBNB_Admin.Models;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class OrderProductController : Controller
    {
        // GET: OrderProduct
        AirbnbEntities2 db = new AirbnbEntities2();

        [System.Obsolete]
        public ActionResult Index_OrderProduct(int id)
        {
            List<int> sum = db.Rooms.Select(propa => propa.Id_Room).ToList();
            foreach (int i in sum)
            {
                var dbContext = new AirbnbEntities2();

                var totalDays = dbContext.Rooms.Where(s => s.Id_Room == i) // thuat toan tinh tong ngay cua san pham 
                    .Select(room => EntityFunctions.DiffDays(room.Check_in, room.Check_out))
                    .Sum();

                var get = db.Rooms.Where(s => s.Id_Room == i).FirstOrDefault();
                get.tongtientruocthue = 1;
                get.tongtientruocthue = (get.Price * totalDays);
                get.tongtiensauthue = 1;
                get.tongtiensauthue = get.tongtientruocthue * 15 / 100;
                get.tongdem = 1;
                get.tongdem = totalDays;
                //x.tongtientrong5ngay = x.Price * 100;
                db.SaveChanges();
            }

            var x = db.Rooms.Where(s => s.Id_Room == id).FirstOrDefault();
            if (x == null)
            {
                Session["event"] = null;
            }
            else
            {
                Session["event"] = x;
            }
            Rooms rooms = new Rooms();
            rooms.Id_Room=id;
            return View(db.Rooms.Where(s=>s.Id_Room==id).ToList());
        }
        //public ActionResult ViewCardOrder()
        //{
        //    var us = db.User.Select(s => s.ID_User).ToList();
        //    var pro = db.Rooms.Select(s => s.Id_Room).ToList();
        //    var viewmodel = new ViewmodelProductUser();
        //    {
        //        User = us,
        //        product=pro
        //    };
        //    return View(viewmodel);
            
        //}
    }
}