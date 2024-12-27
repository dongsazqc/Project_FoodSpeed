using Microsoft.AspNetCore.Mvc;
using asm.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Plugins;

namespace asm.Controllers
{
    public class MenuController : Controller
    {
        private readonly FastFoodStoreContext _context;

        public MenuController(FastFoodStoreContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sản phẩm
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Thêm sản phẩm vào giỏ hàng


        [HttpPost]
        protected void SetAlert(string message ,string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
