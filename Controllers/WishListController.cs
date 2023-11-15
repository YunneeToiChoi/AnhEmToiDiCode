using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBNB_Admin.Controllers
{
    public class WishListController : Controller
    {
        // GET: WishList
        AirbnbEntities2 db  = new AirbnbEntities2 ();

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult EmptyLayout()
        {
            return View();
        }
        public ActionResult ShowWish()
        {
            try
            {
                if (Session["Wish"] == null)
                {
                    //return RedirectToAction("ShowList", "ShoppingCart");
                    return RedirectToAction("EmptyLayout", "WishList");
                    //return View("EmptyWish");
                }
                Wish wish = Session["Wish"] as Wish;
                return View(wish);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
         
        }
        public Wish GetWish()
        {
            Rooms room = new Rooms();
                Wish wish = Session["Wish"] as Wish;
                if (wish == null || Session["Wish"] == null)
                {
                    wish = new Wish();
                    Session["Wish"] = wish;
                    wish.active_heart = "#ff385c";
                    room.active_heart = "#ff385c";
                    Session["CheckWish"] = wish.active_heart;
                }
            return wish;
            
          
        }
        public ActionResult AddtoWish(int id)
        {

            var _pro = db.Rooms.SingleOrDefault(s => s.Id_Room == id); // lay product theo id
            Session["HideMenu"] = _pro;

            if (_pro != null && Session["User"]!=null)
            {
                GetWish().Add_Room_Cart(_pro);
                Session["HideMenu"] = _pro;
                return RedirectToAction("ShowWish", "WishList");
            
            }

            return RedirectToAction("LoginAccount", "User");
        }
        public ActionResult RemoveWish(int id) // chua xoa dc
        {
            Wish wish = Session["Wish"] as Wish;
            wish.Remove_WishItem(id);
            return RedirectToAction("ShowWish", "WishList");
        }
    }
}