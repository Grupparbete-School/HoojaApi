using Microsoft.AspNetCore.Mvc;

namespace HoojaApi.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
