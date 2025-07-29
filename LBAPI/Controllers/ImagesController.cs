using Entities.Domain;
using Entities.DTO_S;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace LBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepo repo;

        public ImagesController(IImageRepo repo)
        {
            this.repo = repo;
        }



        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto requestDto)
        {
            ValidateFileUpload(requestDto);

            if (ModelState.IsValid)
            {
                // convert DTO to Domain mode;
                var imageDomain = new Image
                {
                    File = requestDto.File,
                    FileExtinsion = Path.GetExtension(requestDto.File.FileName),
                    FileSizeInBytes = requestDto.File.Length,
                    FileName = requestDto.FileName,
                    FileDescription = requestDto.FileDescription
                };

                // User repository to upload image
                await repo.Upload(imageDomain);

                return Ok(imageDomain);
            }

            return BadRequest(ModelState);
        }



        private void ValidateFileUpload(ImageUploadRequestDto requestDto)
        {
            var allowedExtinsion =new string[] { ".jpg", ".jpeg", ".png"};

            if (!allowedExtinsion.Contains(Path.GetExtension(requestDto.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extinsion");
            }

            if (requestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "file size more than 10MB, please upload a smaller size file.");
            }
        }
    }
}
