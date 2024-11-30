using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class PagesController : Controller
    {
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
