using Entities.Data;
using Entities.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class ImageRepo : IImageRepo
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly LbDbContext db;

        public ImageRepo(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, LbDbContext db)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.db = db;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath =  Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtinsion}");

            // Upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var urlfilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtinsion}";

            image.FilePath = urlfilePath;

            // Add Image to the Images table
            await db.Images.AddAsync(image);
            await db.SaveChangesAsync();    

            return image;
        }
    }
}
