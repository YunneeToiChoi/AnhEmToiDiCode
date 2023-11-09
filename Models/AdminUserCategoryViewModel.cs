using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class AdminUserCategoryViewModel
    {
        public int AdminUserID { get; set; }
        public string AdminUserName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}