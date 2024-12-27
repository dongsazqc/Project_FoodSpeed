using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class PagesCusController : Controller
    {
        [Area("Customer")]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reservation()
        {
            return View();
        }
        public IActionResult Stuff()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
    }
}
