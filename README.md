AirbnbEntities2
AirBnBDB
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
                                                Wish 
  public class Wish
  {
      List<WishItem> items = new List<WishItem>();
      public string active_heart { set; get; }

      public IEnumerable<WishItem> Items
      {
          get { return items; }
      }
      public void Add_Room_Cart (Room room, int _quanty = 1) // lay san pham bo vao gio hang
      {
          var item = Items.FirstOrDefault(s => s._product.Id_Room == room.Id_Room);
          if(item == null) // neu rong thi them moi gio hang
          {
              items.Add(new WishItem
              {
                  _product = room,
                  _quality = _quanty
              }); 
              
          }
          else
          {
              item._quality += _quanty; // tong so luong trong gio hang dc cong don
          }
      }
      public int Total_quanlity()
      {
          return items.Sum(s => s._quality);
      }
      public void Remove_WishItem(int id)
      {
          items.RemoveAll(s=>s._product.Id_Room==id);
      }

  }
  public class WishItem
  {
      public Room _product { get; set; }
      public int _quality { get; set; }
  }


                                        AdminUser
  [Display(Name = "Mã User")]
  [Required(ErrorMessage = "ID not Empty.....")]
  public int ID { get; set; }
  [Required(ErrorMessage = "Name not Empty.....")]
  [Display(Name = ("Tên User"))]
  public string Name_User { get; set; }

  [Required(ErrorMessage = "Email not Empty....")]
  [Display(Name = ("Email User"))]
  [EmailAddress(ErrorMessage = "Please enter a valid email")]
     
  public string Email_User { get; set; }
  
  [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid password")]
  [StringLength(50, ErrorMessage = "Khong du kich thuoc", MinimumLength = 8)]
  [DataType(DataType.Password)]   
  public string Password_User { get; set; }

  [Compare(otherProperty: "Password_User", ErrorMessage = " Confirm password does not match")]
  
  public string ConfirmPassword {  get; set; }
  [NotMapped]
  public string ErrorLogin {  get; set; }




                                        Category
 
namespace AirBNB_Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Rooms = new HashSet<Room>();
            Image_Cate = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        public List<Category> ListCate { get; internal set; }
        public int ID_Cate { get; set; }
        public string Name_Cate { get; set; }
        public string Image_Cate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}


                                OderProduct
  using System;
  using System.Collections.Generic;
     [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
 public OrderProduct()
 {
     this.Reservations = new HashSet<Reservation>();
 }
    
 public int ID_Product { get; set; }
 public Nullable<int> ID_User { get; set; }
 public string Payment_Card { get; set; }
 public string Zip_Post { get; set; }
    
 public virtual User User { get; set; }
 [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
 public virtual ICollection<Reservation> Reservations { get; set; }

                                Room

namespace AirBNB_Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
            Images_Room = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        public string Name_Cate { get; set; }
        
        public int Id_Room { get; set; }
        public string Room_Name { get; set; }
        public string Place { get; set; }
        public HashSet<Reservation> Reservation { get; }
        public string Images_Room { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Home_types { get; set; }
        public string Room_types { get; set; }
        public Nullable<int> ID_Cate { get; set; }
        public string Room_Description { get; set; }
        public string Check_in { get; set; }
        public string Check_out { get; set; }
        public string active_heart { get; set; }
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}



                        USER

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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
        [Display(Name = "Mã User")]
        [Required(ErrorMessage = "ID not Empty.....")]
        public int ID_User { get; set; }
        [Required(ErrorMessage = "Name not Empty.....")]
        [Display(Name = ("Tên User"))]
        public string User_Name { get; set; }
        [Required(ErrorMessage = "Email not Empty....")]
        [Display(Name = ("Email User"))]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        public string Phone_number { get; set; }
        public string Identity_Card { get; set; }
        public string Address { get; set; }
        public string Emergency_Contact { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid password")]
        [StringLength(50, ErrorMessage = "Khong du kich thuoc", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(otherProperty: "Password_User", ErrorMessage = " Confirm password does not match")]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public string ErrorLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}


  

LinQ
1.	Tổng trước thuế:N  -dl: t6/3/11
2.	Bộ lọc giá x=>y : P   -dl: t7/4/11
3.	Date in :P                  -dl: t7/4/11
4.	Date out:P                -dl: t7/4/11
5.	bộ lọc tăng  P           -dl:cn/5/11
6.	bộ lọc giảm P           -dl:cn/5/11
7.	Lọc theo menu P     -dl:t2/6/11
8.	bộ lọc cho wishlist N -dl:t7/4/11
Ghi chú:sửa db date in date out
Rang buoc email 
sửa user them password => adminuser là user và ngc lại
dl:none

View
1.	Order+ Product : details-box (N)                                    -dl:cn/5/11
2.	Wishlist+ Product : rang buộc tim vs sp (N)                  -dl:t7/4/11
3.	Cate + Product: pro chứa id cate để lọc theo cate(P)  -dl:cn/5/11 
4.	User + Wishlist:…..(N)
5.	User + Order: lịch sử order( N)

l IST  ẢNH : 





