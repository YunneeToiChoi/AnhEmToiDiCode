﻿using AirBNB_Admin.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Product_Index()
        {
            Rooms r = new Rooms();
            r.active_heart = "blue";
            return PartialView(db.Rooms.ToList());
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