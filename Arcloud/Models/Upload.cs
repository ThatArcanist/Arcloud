using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Arcloud.Models
{
    public class Upload
    {

        public int UploadId { get; set; }
        public string UploadTitle { get; set; }
        public string UploadUser { get; set; }
        public string UploadAuthor { get; set; }
        public byte[] UploadContent { get; set; }

    }
}
