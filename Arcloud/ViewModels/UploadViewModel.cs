using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Arcloud.ViewModels
{
    public class UploadViewModel
    {

        [Required(ErrorMessage = "Please enter a title for your upload")]
        [Display(Name = "Upload Title")]
        [StringLength(50)]
        public string UploadTitle { get; set; }
        public string UploadUser { get; set; }

        [Required(ErrorMessage = "Please enter the name of the author for your upload")]
        [Display(Name = "Upload Author")]
        [StringLength(50)]
        public string UploadAuthor { get; set; }

        public IFormFile UploadFile { get; set; }

    }
}
