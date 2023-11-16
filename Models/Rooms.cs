

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirBNB_Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rooms()
        {
            this.Reservation = new HashSet<Reservation>();
            Images_Room = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        public int Id_Room { get; set; }
        public string Name_Cate { get; set; }
        public string Room_Name { get; set; }
        public string Place { get; set; }
        public string Images_Room { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int Quantity {  get; set; }
        public string Home_types { get; set; }
        public string Room_types { get; set; }
        public Nullable<int> ID_Cate { get; set; }
        public string Room_Description { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Datein only")]
        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Check_in { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Dateout only")]
        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Check_out { get; set; }
        public string active_heart { get; set; }
        public Nullable<decimal> tongtientruocthue { get; set; }
        public Nullable<decimal> tongtiensauthue { get; set; }
        public Nullable<decimal> tongdem { get; set; }
        public int Guest { get; set; }
        public string Status { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
