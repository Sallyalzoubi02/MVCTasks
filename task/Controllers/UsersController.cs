using Microsoft.AspNetCore.Mvc;

namespace task.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult RoomsList()
        {
            return View();
        }
    }
}
