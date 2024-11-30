using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class BlogSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
