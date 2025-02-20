using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace task4.Controllers
{
    public class UserController : Controller
    {
        

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Email") == "Admin@gmail.com")
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            string username = HttpContext.Session.GetString("UserName");
            CookieOptions obj = new CookieOptions();
            obj.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("Username", username, obj);
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
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
            string Remember = Request.Form["Remember"];

            string storedEmail = HttpContext.Session.GetString("UserEmail");
            string storedPassword = HttpContext.Session.GetString("UserPassword");

            string storedEmailCookies = HttpContext.Request.Cookies["Email"];
            string storedPasswordCookies = HttpContext.Request.Cookies["Password"];
            if (pass == "123" && email == "Admin@gmail.com")
            {
                HttpContext.Session.SetString("UserEmail", email);
                HttpContext.Session.SetString("UserPassword", pass);
                return RedirectToAction("Index", "Home");
            }

            if ((pass == storedPassword && email == storedEmail) || (pass== storedPasswordCookies && email == storedEmailCookies))
            {
                if (Remember != null)
                {
                    CookieOptions obj = new CookieOptions();
                    obj.Expires = DateTime.Now.AddDays(7);
                    //store
                    
                    Response.Cookies.Append("Email", email, obj);
                    Response.Cookies.Append("Password", pass, obj);

                }
                if(storedEmail == null)
                {
                    HttpContext.Session.SetString("UserName", HttpContext.Request.Cookies["Username"]);
                    HttpContext.Session.SetString("UserEmail", email);
                    HttpContext.Session.SetString("UserPassword", pass);
                }

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

        public IActionResult EditProfile()
        {

            return View();
        }

        public IActionResult saveData()
        {
            
            string address = Request.Form["Address"];
            string phone = Request.Form["Phone"];


            HttpContext.Session.SetString("UserAddress", address);
            HttpContext.Session.SetString("UserPhone", phone);
            return RedirectToAction("Profile");
        }

    }
}
