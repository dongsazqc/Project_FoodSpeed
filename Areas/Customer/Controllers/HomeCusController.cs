using Microsoft.AspNetCore.Mvc;

namespace asm.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeCusController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
