using Microsoft.AspNetCore.Mvc;
using asm.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace asm.Controllers
{
    public class Account : Controller
    {
        FastFoodStoreContext fastFoodStore;
        public Account(FastFoodStoreContext fastfoodstore)
        {
            fastFoodStore = fastfoodstore;
        }
        private string connectionString = @"Data Source=PHAMVANDONG;Initial Catalog=FastFoodStore;Integrated Security=True;Trust Server Certificate=True";

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
    }
}