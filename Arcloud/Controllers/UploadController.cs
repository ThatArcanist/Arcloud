using Arcloud.Models;
using Arcloud.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Arcloud.Controllers
{
    public class UploadController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IUploadRepository uploadRepository;

        //https://stackoverflow.com/questions/20925822/asp-net-mvc-5-identity-how-to-get-current-applicationuser
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
