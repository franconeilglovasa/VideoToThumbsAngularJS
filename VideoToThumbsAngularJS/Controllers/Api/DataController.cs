using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoToThumbsAngularJS.ViewModels;

namespace VideoToThumbsAngularJS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public DataController()
        {

        }

        [HttpPut("UploadImage")]
        public async Task<ActionResult<string>> UploadImage(ImageVM image)
        {
            return "Success";

        }
    }
}
