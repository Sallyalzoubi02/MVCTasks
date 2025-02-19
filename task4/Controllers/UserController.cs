using Microsoft.AspNetCore.Mvc;

namespace task4.Controllers
{
    public class UserController : Controller
    {
        

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandelRegister()
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string pass = Request.Form["password"];
            string repeat = Request.Form["repeatPassword"];

            if (pass == repeat)
            {
                HttpContext.Session.SetString("UserName", name);
                HttpContext.Session.SetString("UserEmail", email);
                HttpContext.Session.SetString("UserPassword", pass);
                return RedirectToAction("Login");
                
            }
            else
            {
                TempData["alert"] = "password not match ";
                return RedirectToAction("Register");
            }
        }

        public IActionResult HandelLogin()
        {
            string email = Request.Form["email"];
            string pass = Request.Form["password"];

            string storedEmail = HttpContext.Session.GetString("UserEmail");
            string storedPassword = HttpContext.Session.GetString("UserPassword");

            if (pass == storedPassword && email == storedEmail)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["alert"] = "password not match ";
                return RedirectToAction("Register");
            }
        }
        public IActionResult Register()
        {
            
            return View();
        }

        public IActionResult Profile()
        {
            
            return View();
        }
    }
}
