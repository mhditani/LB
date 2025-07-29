using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

        public string FileName { get; set; } = "";

        public string? FileDescription { get; set; }

        // for the image type .png or jpg etc..
        public string FileExtinsion { get; set; } = "";

         public long FileSizeInBytes { get; set; }

        public string FilePath { get; set; } = "";
    }
}
