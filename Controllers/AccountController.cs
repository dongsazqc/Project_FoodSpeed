using Microsoft.AspNetCore.Mvc;
using asm.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace asm.Controllers
{
    public class AccountController : Controller
    {
        FastFoodStoreContext fastFoodStore;
        public AccountController(FastFoodStoreContext fastfoodstore)
        {
            fastFoodStore = fastfoodstore;
        }
        private string connectionString = @"Data Source=PHAMVANDONG\DONGSAZQC;Initial Catalog=FastFoodStore;Integrated Security=True;Trust Server Certificate=True";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string query = "SELECT UserId, FullName, Role FROM Users WHERE Email = @Email AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    var userId = reader.GetInt32(0);
                    var fullName = reader.GetString(1);
                    var role = reader.GetString(2);

                    // Lưu thông tin người dùng vào Session
                    HttpContext.Session.SetInt32("UserId", userId);
                    HttpContext.Session.SetString("FullName", fullName);
                    HttpContext.Session.SetString("Role", role);

                    // Chuyển hướng dựa trên vai trò
                    if (role == "Admin")
                    {
                        return RedirectToAction("Index", "HomeAd", new { Area = "Admin" });
                    }
                    else if (role == "Customer")
                    {
                        return RedirectToAction("Index", "HomeCus", new { Area = "Customer" });
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Nếu đăng nhập thất bại
                    ViewBag.ErrorMessage = "Email hoặc mật khẩu không đúng.";
                    return View();
                }
            }
        }


        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra email đã tồn tại chưa
                if (fastFoodStore.Users.Any(u => u.Email == model.Email))
                {
                    ViewBag.ErrorMessage = "Email đã được sử dụng.";
                    return View(model);
                }

                // Mặc định role là "Customer"
                model.Role = "Customer";
                model.CreatedDate = DateTime.Now;

                // Thêm người dùng mới vào database
                fastFoodStore.Users.Add(model);
                fastFoodStore.SaveChanges();

                // Điều hướng người dùng tới trang đăng nhập
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }
    }
}