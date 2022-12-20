using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoToThumbsAngularJS.Models;

namespace VideoToThumbsAngularJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> Index(IFormFile imgfile)
        {
            var saveimg = Path.Combine(_webHost.WebRootPath, "SaveHere", imgfile.FileName);
            string imgext = Path.GetExtension(imgfile.FileName);





            if (imgext == ".jpg" || imgext == ".png")
            {
                using (var uploading = new FileStream(saveimg, FileMode.Create))
                {

                    string s = "";
                    await imgfile.CopyToAsync(uploading);



                    using (var ms = new MemoryStream())
                    {
                        imgfile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        s = Convert.ToBase64String(fileBytes);
                    }



                    ViewData["Message"] = "The Selected File" + " " + imgfile.FileName + " " + "Is Saved Successfully...!";
                    ViewData["None"] = s;

                }


            }
            else
            {
                ViewData["Message"] = "Only The image file";
            }

            return View();
        }
    }
}