using Microsoft.AspNetCore.Mvc;

namespace MyBus.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            
            if (email == "admin.mybus@gmail.com" && password == "adminpassword")
            {
                
                return RedirectToAction("Index", "Home");
            }

            
            ViewBag.ErrorMessage = "Invalid email or password";
            return View();
        }
    }
}
