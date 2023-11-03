AirbnbEntities
AirBnBDB
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel.DataAnnotations;
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
        public Category()
        {
            this.Rooms = new HashSet<Rooms>();
            Image_Cate = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
                public List<Category> ListCate { get; internal set; }

Product
        public Rooms()
        {
            this.Reservation = new HashSet<Reservation>();
            Images_Room = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
                public string Name_Cate { get; set; }


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




