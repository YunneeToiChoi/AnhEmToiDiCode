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
    
    public partial class OrderProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderProduct()
        {
            this.Reservation = new HashSet<Reservation>();
        }
    
        public int ID_Product { get; set; }
        public Nullable<int> ID_User { get; set; }
        public string Payment_Card { get; set; }
        public string Zip_Post { get; set; }
        public string idOder { get; set; } // cai nay them tay
        public DateTime DateTime { get; set; } // cai nay them tay
        public virtual User User { get; set; }
        public Nullable<int> Quantity {  get; set; }    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual Rooms Rooms { get; set; }
    }
}
