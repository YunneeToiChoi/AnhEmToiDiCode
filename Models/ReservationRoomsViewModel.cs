using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class ReservationRoomsViewModel
    {
        public int ReservationID { get; set; }
        public int RoomID { get; set; }
        public decimal Price { get; set; }
        public int Guest { get; set; }
        public string RoomName { get; set; }
        public string Place { get; set; }
        public string ImagesRoom { get; set; }
    }
}