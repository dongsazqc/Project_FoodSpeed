using Microsoft.AspNetCore.Mvc;

namespace asm.Controllers
{
    public class ContactCusController : Controller
    {
        [Area("Customer")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
