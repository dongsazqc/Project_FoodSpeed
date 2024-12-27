using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    [Area("Customer")]

    public class AboutCusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
