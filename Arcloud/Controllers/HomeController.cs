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

        [HttpPost]
        public IActionResult Index(Upload upload)
        {
            var uploads = uploadRepository.AllUploads;

            if (ModelState.IsValid)
            {
                // Add upload to DB
                return RedirectToAction("UploadComplete");
            }

            return View(upload);
        }
    }
}
