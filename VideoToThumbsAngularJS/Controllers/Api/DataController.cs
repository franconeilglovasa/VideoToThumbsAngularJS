using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoToThumbsAngularJS.ViewModels;

namespace VideoToThumbsAngularJS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [Obsolete]
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public DataController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPut("UploadImage")]
        [Obsolete]
        [AllowAnonymous]
        public async Task<ActionResult<string>> UploadImage([FromBody] string imageData)
        {
            var imageFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "image.png");
            using (var stream = new FileStream(imageFilePath, FileMode.Create))
            {
                var imageBytes = Convert.FromBase64String(imageData);
                await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
            }

            return Ok();

        }
    }
}
