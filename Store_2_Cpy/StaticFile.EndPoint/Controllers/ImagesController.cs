using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StaticFile.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public ImagesController(IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }
        //یه سرویس بنویسیم که کاربری که لاگین کرده رو برسی کنیم دسترسی داره یا نه
        public IActionResult Post(string apikey)
        {
            if (apikey != "mysecretkey")
            {
                return BadRequest();
            }
            try
            {
                var files = Request.Form.Files;
                var foldername = Path.Combine("Resources", "Images");
                var pathTosave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                if(files != null)
                {
                    return Ok(uploadfile(files));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Interanl server error");
                throw new Exception("Upload Image Error", ex);
            }
            
        }
        private UploadDto uploadfile(IFormFileCollection files)
        {
            string NewNAme = Guid.NewGuid().ToString();
            var data = DateTime.Now;
            string folder = $@"Resources\images\{data.Year}\{data.Year}-{data.Month}\";
            var uploadRootFolder = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(uploadRootFolder))
            {
                Directory.CreateDirectory(uploadRootFolder);
            }
            List<string> address = new List<string>();
            foreach (var file in files)
            {
                if(file !=null && file.Length>0)
                {
                    string filename = NewNAme + file.FileName;
                    var filepathe = Path.Combine(uploadRootFolder, filename);
                    using (var fileStream = new FileStream(filepathe, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    address.Add(folder + filename);
                }
            }
            return new UploadDto()
            {
                FileNameAddress = address,
                Statuse = true
            };
        }
        public class UploadDto
        {
            public bool Statuse { get; set; }
            public List<string> FileNameAddress { get; set; }
        }
    }
}
