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


    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
   
        public int ID_User { get; set; }
        public string User_Name { get; set; }
        public string Email { get; set; }
     
        public string Phone_number { get; set; }
        public string Identity_Card { get; set; }
        public string Address { get; set; }
        public string Emergency_Contact { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
