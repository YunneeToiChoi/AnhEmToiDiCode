using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class Wish
    {
        List<WishItem> items = new List<WishItem>();
        public string active_heart { set; get; }

        public IEnumerable<WishItem> Items
        {
            get { return items; }
        }
        public void Add_Room_Cart (Rooms room, int _quanty = 1) // lay san pham bo vao gio hang
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
        public Rooms _product { get; set; }
        public int _quality { get; set; }
    }
  
}