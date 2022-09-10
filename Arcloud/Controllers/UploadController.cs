using Arcloud.Models;
using Arcloud.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;

namespace Arcloud.Controllers
{
    public class UploadController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IUploadRepository uploadRepository;

        private string user;

        //https://stackoverflow.com/questions/20925822/asp-net-mvc-5-identity-how-to-get-current-applicationuser
        public UploadController(AppDbContext appDbContext, IUploadRepository uploadRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appDbContext;
            this.uploadRepository = uploadRepository;

            this.user = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UploadViewModel uploadVm)
        {
            byte[] fileBytes = null;

            using (var ms = new MemoryStream())
            {
                uploadVm.UploadFile.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            Upload upload = new Upload()
            {
                UploadAuthor = uploadVm.UploadAuthor,
                UploadUser = user,
                UploadTitle = uploadVm.UploadTitle,
                UploadContent = fileBytes
            };

            if (ModelState.IsValid)
            {
                uploadRepository.AddUpload(upload);
                return RedirectToAction("UploadComplete");
            }

            return View(uploadVm);
        }

        public IActionResult UploadComplete()
        {
            return View();
        }
    }
}
