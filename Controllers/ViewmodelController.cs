using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class ViewmodelController : Controller
    {
        // GET: Viewmodel
        public class HomeController : Controller
        {
            AirbnbEntities2 db = new AirbnbEntities2(); 

            public HomeController(AirbnbEntities2 context)
            {
                db = context;
            }

            public ActionResult AdminUserCategory()
            {
                var adminUserCategoryData = (from au in db.AdminUser
                                             join c in db.Category on au.ID equals c.ID_Cate
                                             select new AdminUserCategoryViewModel
                                             {
                                                 AdminUserID = au.ID,
                                                 AdminUserName = au.Name_User,
                                                 CategoryID = c.ID_Cate,
                                                 CategoryName = c.Name_Cate
                                             }).ToList();

                return View(adminUserCategoryData);
            }

            public ActionResult OrderProductUser()
            {
                var orderProductUserData = (from op in db.OrderProduct
                                            join u in db.User on op.ID_User equals u.ID_User
                                            select new OrderProductUserViewModel
                                            {
                                                OrderProductID = op.ID_Product,
                                                UserID = u.ID_User,
                                                UserName = u.User_Name,
                                                PaymentCard = op.Payment_Card,
                                                ZipPost = op.Zip_Post
                                            }).ToList();

                return View(orderProductUserData);
            }

            public ActionResult ReservationRooms()
            {
                var reservationRoomsData = (from r in db.Reservation
                                            join rm in db.Rooms on r.ID_Rooms equals rm.Id_Room
                                            select new ReservationRoomsViewModel
                                            {
                                                ReservationID = r.ID_Reservation,
                                                RoomID = rm.Id_Room,
                                                Price = (decimal)r.Price,
                                                Guest = (int)r.Guest,
                                                RoomName = rm.Room_Name,
                                                Place = rm.Place,
                                                ImagesRoom = rm.Images_Room
                                            }).ToList();

                return View(reservationRoomsData);
            }
        }
    }
}