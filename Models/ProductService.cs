using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBNB_Admin.Models
{
    public class ProductService
    {
        private readonly List<Rooms> _products; // Thay thế bằng đối tượng truy cập cơ sở dữ liệu thực tế

        public ProductService()
        {
            _products = new List<Rooms>(); // Khởi tạo danh sách sản phẩm (thay thế bằng lấy từ cơ sở dữ liệu)
                                             // Thêm sản phẩm vào danh sách
        }

        public List<Rooms> GetProductsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _products
                .Where(p => p.CheckIn >= startDate && p.CheckOut <= endDate)
                .ToList();
        }
    }
}