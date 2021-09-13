using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store_2.Application.banners;
using Store_2.Infrastructure.Externalapi.ImagesServer;

namespace Admin.EndPoint.Pages.Banners
{
    public class CreateModel : PageModel
    {
        private readonly IBannerService _banner;
        private readonly IimageUploadService _iimageUploadService;
        public CreateModel(IBannerService banner, IimageUploadService iimageUploadService)
        {
            _banner = banner;
            _iimageUploadService = iimageUploadService;
        }
        [BindProperty]
        public BannerDto Banner { get; set; }
        [BindProperty]
        public IFormFile BannerImage { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var result = _iimageUploadService.upload(new List<IFormFile> { BannerImage });
            if (result.Count > 0)
            {
                Banner.Image = result.FirstOrDefault();
                _banner.AddBaner(Banner);
            }
            return RedirectToPage("Index");
        }
    }
}
