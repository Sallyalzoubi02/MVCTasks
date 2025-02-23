using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task5.Models;

namespace task5.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View(_context.Departments.ToList());
        }

     

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Departments.Add(department);
                    _context.SaveChangesAsync();                    
                    return RedirectToAction(nameof(Index));
                }

                return View(department);
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
