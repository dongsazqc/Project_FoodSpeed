using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace asm.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class LogOutCusController : Controller
    {
        public async Task<IActionResult> Logout()
        {

            // Sau khi đăng xuất, chuyển hướng về trang đăng nhập
            return View("https://localhost:7079/Account/Login");  // Chuyển hướng đến Login action trong Account controller
        }
    }
}
