using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        
    }
}
