using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    [Area("Customer")]

    public class BlogCusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        
    }
}
