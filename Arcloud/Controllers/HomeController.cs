using Microsoft.AspNetCore.Mvc;

namespace Arcloud.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
