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
            AirbnbEntities2 db = new AirbnbEntities2(); // AirbnbContext là context của cơ sở dữ liệu của bạn

            public HomeController(AirbnbEntities2 context)
            {
                db = context;
            }

            public ActionResult AdminUser()
            {
                var adminUsers = db.AdminUser.Select(u => new AdminUserViewModel
                {
                    ID = u.ID,
                    Name_User = u.Name_User,
                    Email_User = u.Email_User
                }).ToList();

                return View(adminUsers);
            }

            public ActionResult Category()
            {
                var categories = db.Category.Select(c => new CategoryViewModel
                {
                    ID_Cate = c.ID_Cate,
                    Name_Cate = c.Name_Cate,
                    Image_Cate = c.Image_Cate
                }).ToList();

                return View(categories);
            }

            public ActionResult Rooms()
            {
                var rooms = db.Rooms.Select(r => new RoomsViewModel
                {
                    Id_Room = r.Id_Room,
                    Room_Name = r.Room_Name,
                    Place = r.Place,
                    Images_Room = r.Images_Room,
                    Price = (decimal)r.Price,
                    Home_types = r.Home_types,
                    Room_types = r.Room_types,
                    ID_Cate = (int)r.ID_Cate,
                    Room_Description = r.Room_Description,
                    Check_in = (DateTime)r.Check_in,
                    Check_out = (DateTime)r.Check_out,
                    Name_Cate = r.Name_Cate
                }).ToList();

                return View(rooms);
            }
        }
    }
}