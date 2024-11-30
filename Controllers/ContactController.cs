using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
