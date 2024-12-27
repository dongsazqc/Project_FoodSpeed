using Microsoft.AspNetCore.Mvc;
using asm.Models;  // Đảm bảo thêm dòng này để sử dụng CartViewModel và CartItem
using Newtonsoft.Json;
using System.Linq;

namespace asm.Controllers
{

    [Area("Customer")]
    public class CartCusController : Controller
    {
        public IActionResult Index()
        {   
            var cart = HttpContext.Session.GetString("Cart");
            List<CartItem> cartItems = string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);

            var cartViewModel = new CartViewModel
            {
                CartItems = cartItems,
                TotalAmount = cartItems.Sum(item => item.Price * item.Quantity)
            };

            return View(cartViewModel);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.GetString("Cart");
            var cartItems = string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);

            var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));
            }

            return RedirectToAction("Index");
        }
    }
}
