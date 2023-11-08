using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class ViewmodelUserProduct
    {
        public int Id_Room { get; set; }
        public string Room_Name { get; set; }
        public string Images_Room { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> tongtientruocthue { get; set; }
        public Nullable<decimal> tongtiensauthue { get; set; }
        public Nullable<decimal> tongdem { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Datein only")]
        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Check_in { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Dateout only")]
        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Check_out { get; set; }
        public int ID_User { get; set; }
        public string User_Name { get; set; }
        public string Phone_number { get; set; }
    }
}