using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class Top_ViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]

        public int Id { get; set; }

        public string namePro { get; set; }

        public decimal? price { get; set; }
        public string descriptionPro { get; set; }

        public string imagePro { get; set; }
        public Rooms rooms { get; set; }
        public OrderProduct orderDetail { get; set; }
        public IEnumerable<Rooms> List { get; set; }

        public int? Top_10_Pro { get; set; }
    }
}