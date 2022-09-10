using Arcloud.Models;
using Arcloud.ViewModels;
using Microsoft.AspNetCore.Http;
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
            return View(uploadRepository.AllUploads);
        }

        [HttpPost]
        public IActionResult Index(UploadViewModel uploadVm)
        {
            var uploads = uploadRepository.AllUploads;
            if (ModelState.IsValid)
            {
                // Add upload to DB
                return RedirectToAction("UploadComplete");
            }

            return View(uploadVm);
        }
    }
}
