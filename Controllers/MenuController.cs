using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
