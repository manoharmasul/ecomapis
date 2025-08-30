using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly IUploadImageAsync upload;
        public UploadImageController(IUploadImageAsync upload)
        {
            this.upload = upload;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile imageFile)
        {
            //if (imageFile == null || imageFile.Length == 0)
              //  return BadRequest(); 

            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream);

            var imageEntity = new UploadImageModel
            {
                ImageName = imageFile.FileName,
               // ContentType = imageFile.ContentType,
                ImagePath = memoryStream.ToArray()
            };

            var result = await upload.UploadImage(imageEntity);
          

            return Ok(result);
        }
        [HttpPost("uploadproductimage")]
        public async Task<IActionResult> UploadProdcutImage([FromForm] IFormFile imageFile, [FromForm] int productId)
        {
            //if (imageFile == null || imageFile.Length == 0)
            //  return BadRequest(); 

            using var memoryStream = new MemoryStream();
            await imageFile.CopyToAsync(memoryStream);

            var imageEntity = new ProductImageModel()
            {
                ImageName = imageFile.FileName,
                ProductId= productId,
                // ContentType = imageFile.ContentType,
                ImagePath = memoryStream.ToArray()
            };

            var result = await upload.UploadProductImage(imageEntity);


            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var result = await upload.GetAllImages();
            return Ok(result);

        }
    }
  
}
