using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Arcloud.Models
{
    public class Upload
    {

        [BindNever]
        public int UploadId { get; set; }

        [Required(ErrorMessage = "Please enter a title for your upload")]
        [Display(Name = "Upload Title")]
        [StringLength(50)]
        public string UploadTitle { get; set; }
        public string UploadUser { get; set; }

        [Required(ErrorMessage = "Please enter the name of the author for your upload")]
        [Display(Name = "Upload Author")]
        [StringLength(50)]
        public string UploadAuthor { get; set; }

        [Required(ErrorMessage = "Please choose a file to upload")]
        [Display(Name = "Upload")]
        public FormFile UploadFile { get; set; }

    }
}
