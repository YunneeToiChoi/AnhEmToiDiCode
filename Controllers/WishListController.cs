﻿using AirBNB_Admin.Models;
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
        AirbnbEntities1 db  = new AirbnbEntities1 ();

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult ShowWish()
        {
            if (Session["Wish"] == null)
            {
                return RedirectToAction("ShowList", "ShoppingCart");
                //return View("EmptyWish");


            }
            Wish wish = Session["Wish"] as Wish;
            return View(wish);
        }
        public Wish GetWish()
        {
            Wish wish = Session["Wish"] as Wish;
            if(wish == null || Session["Wish"]==null)
            {
                wish = new Wish();
                Session["Wish"] = wish;
            }
            return wish;
        }
        public ActionResult AddtoWish(int id)
        {
            var _pro = db.Rooms.SingleOrDefault(s => s.Id_Room == id); // lay product theo id
            if(_pro != null)
            {
                GetWish().Add_Room_Cart(_pro);
            }
            return RedirectToAction("ShowWish", "WishList");
        }
        public ActionResult RemoveWish(int id) // chua xoa dc
        {
            Wish wish = Session["Wish"] as Wish;
            wish.Remove_WishItem(id);
            return RedirectToAction("ShowWish", "WishList");
        }
    }
}