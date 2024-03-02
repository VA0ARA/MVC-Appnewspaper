using Microsoft.AspNetCore.Mvc;

namespace News.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminProfile()
        {
            return View();
        }
    }
}
