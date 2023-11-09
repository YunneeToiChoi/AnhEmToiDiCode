using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class OrderProductUserViewModel
    {
        public int OrderProductID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PaymentCard { get; set; }
        public string ZipPost { get; set; }
    }
}