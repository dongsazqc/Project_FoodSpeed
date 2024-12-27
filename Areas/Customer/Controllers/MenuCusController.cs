using Microsoft.AspNetCore.Mvc;
using asm.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace asm.Controllers
{
    [Area("Customer")]
    public class MenuCusController : Controller
    {
        private readonly FastFoodStoreContext _context;

        public MenuCusController(FastFoodStoreContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sản phẩm
        public IActionResult Index(string searchTerm)
        {
            // Truy vấn danh sách sản phẩm
            var products = _context.Products.AsQueryable();

            // Nếu có từ khóa tìm kiếm, lọc sản phẩm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.ProductName.Contains(searchTerm));
            }

            return View(products.ToList());
        }

        // Thêm sản phẩm vào giỏ hàng


        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }


            // Lấy giỏ hàng hiện tại từ session
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);

            // Kiểm tra nếu sản phẩm đã có trong giỏ hàng
            var existingItem = cartItems.FirstOrDefault(c => c.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++; // Tăng số lượng nếu sản phẩm đã có
            }
            else
            {
                cartItems.Add(new CartItem { ProductId = productId, ProductName = product.ProductName, ImageUrl = product.ImageUrl, Price = product.Price, Quantity = 1 });
            }

            // Lưu lại giỏ hàng vào session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            // Trở lại trang menu hoặc giỏ hàng
            return RedirectToAction("Index");
        }
    }
}
