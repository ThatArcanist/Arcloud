using Arcloud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arcloud.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext appDbContext;
        private readonly IUploadRepository uploadRepository;

        public HomeController (AppDbContext appDbContext, IUploadRepository uploadRepository)
        {
            this.appDbContext = appDbContext;
            this.uploadRepository = uploadRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
