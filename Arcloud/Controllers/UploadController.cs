using Arcloud.Models;
using Arcloud.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Arcloud.Controllers
{
    public class UploadController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IUploadRepository uploadRepository;

        public UploadController(AppDbContext appDbContext, IUploadRepository uploadRepository)
        {
            this.appDbContext = appDbContext;
            this.uploadRepository = uploadRepository;
        }

        public IActionResult Index()
        {
            return View();
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
