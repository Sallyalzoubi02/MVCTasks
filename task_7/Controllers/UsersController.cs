using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task_7.Models;

namespace task_7.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        // GET: Users/Details/5
        public IActionResult Details(string? email , string? password)
        {
            if (email == null)
            {
                return NotFound();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            

            if (user == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("UserName", user.Name);

            return RedirectToAction("Index","Home");
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Create(User user)
        {
            if (UserExists(user.Email) == false)
            {
                _context.Add(user);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(user);
        }

        private bool UserExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
        
     
       
    }
}
