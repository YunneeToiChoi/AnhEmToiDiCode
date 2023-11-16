using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AirBNB_Admin.Controllers
{
    public class OrderHistoryController : Controller
    {
        AirbnbEntities2 db = new AirbnbEntities2();
        public ActionResult Index()
        {
            return View();
        }

        [Obsolete]
        public ActionResult ShowHistory()
        {
            var roomOrderViewModels = (from room in db.Rooms
                                       join order in db.OrderProduct on room.Id_Room equals order.ID_Product
                                       select new OrderHistoryViewModel
                                       {
                                           RoomId = room.Id_Room,
                                           RoomName = room.Room_Name,
                                           OrderId = order.ID_Product,
                                           price = room.Price,
                                           Description = room.Room_Description,
                                           Images_Room = room.Images_Room,
                                          
                                       }).ToList();
            foreach (var viewModel in roomOrderViewModels)
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
                    viewModel.tongtientruocthue = get.tongtientruocthue = -(get.Price * totalDays);
                    get.tongtiensauthue = 1;
                    get.tongtiensauthue = get.tongtientruocthue * 15 / 100;
                    get.tongdem = 1;
                    get.tongdem = totalDays;
                    db.SaveChanges();
                }
            }
            return View(roomOrderViewModels);
        }
    }
}