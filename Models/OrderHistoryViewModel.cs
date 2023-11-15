using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class OrderHistoryViewModel
    {
        public OrderHistoryViewModel()
        {
            Images_Room = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        public int RoomId { get; set; }
        public int ProductId { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public string Images_Room { get; set; }
        public Nullable<decimal> tongtientruocthue { get; set; }
        public int totalday { get;set; }
        public Nullable<decimal> price { get; set; }

    }

}