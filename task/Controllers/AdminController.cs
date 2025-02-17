using Microsoft.AspNetCore.Mvc;

namespace task.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult UsersList()
        {
            return View();
        }
    }
}
