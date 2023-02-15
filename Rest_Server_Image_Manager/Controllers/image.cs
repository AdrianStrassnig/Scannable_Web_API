using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace Rest_Server_Image_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class image : ControllerBase
    {
       
        
        [HttpGet("gettingimage")]
        public async Task<string> GettingzutImage2()
        {

            return "test";
        }
        [HttpGet("getting_status")]
        public async Task<string> getting_status()
        {
            Task.Delay(10);
            return "server is running";
        }
        [HttpGet("power_off_server")]
        public async Task<string> shutting_off()
        {
            Task.Delay(10);
            Environment.Exit(1);
            return "server is shutting down";
        }
        [HttpPost("imagepost")]
        public async Task<IActionResult> gettingimage()
        {
            IFormFile file = Request.Form.Files.FirstOrDefault();
            var orignialFileName = Path.GetFileName(file.Name);
            var uniqueFileName = Path.GetRandomFileName()+".png";
            var uniqueFilePath = Path.Combine(@"C:\Users\Adnan Rizvanovik\Desktop\images", uniqueFileName);
            using (var stream = System.IO.File.Create(uniqueFilePath))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("File has been uploaded to server");
        }
    }
}
 