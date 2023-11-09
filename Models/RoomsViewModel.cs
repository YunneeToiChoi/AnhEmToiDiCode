using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class RoomsViewModel
    {
        public int Id_Room { get; set; }
        public string Room_Name { get; set; }
        public string Place { get; set; }
        public string Images_Room { get; set; }
        public decimal Price { get; set; }
        public string Home_types { get; set; }
        public string Room_types { get; set; }
        public int ID_Cate { get; set; }
        public string Room_Description { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        public string Name_Cate { get; set; }
    }
}