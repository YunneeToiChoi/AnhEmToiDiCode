AirbnbEntities
AirBnBDB
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
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
