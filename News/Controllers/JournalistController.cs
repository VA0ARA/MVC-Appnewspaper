using Microsoft.AspNetCore.Mvc;

namespace News.Controllers
{
    public class JournalistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JournalistProfile ()
        {
            //index >>incident>>Id
            return View();
        }
    }
}
