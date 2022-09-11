using Arcloud.Migrations;
using Arcloud.Models;
using Arcloud.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace Arcloud.Controllers
{
    public class UploadController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IUploadRepository uploadRepository;

        private string user;

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
            string uploadPath = "C:/Songs/";
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var file = uploadVm.UploadFile;

            string fileName = file.FileName;

            string filePath = Path.Combine(uploadPath, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            Upload upload = new Upload()
            {
                UploadAuthor = uploadVm.UploadAuthor,
                UploadUser = user,
                UploadTitle = uploadVm.UploadTitle,
                UploadPath = fileName
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
