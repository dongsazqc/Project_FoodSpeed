using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    [Area("Customer")]

    public class BlogSingleCusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
