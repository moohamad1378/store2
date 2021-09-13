using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_2.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using Store_2.Application.Dtos;
using Store_2.Infrastructure.Externalapi.ImagesServer;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class CreateModel : PageModel
    {
        private readonly IAddNewCatalogItemService _addNewCatalogItemService;
        private readonly ICatalogItemService _catalogItemService;
        private readonly IimageUploadService _imageUploadService;
        public CreateModel(IAddNewCatalogItemService addNewCatalogItemService, ICatalogItemService catalogItemService
            ,IimageUploadService imageUploadService)
        {
            _addNewCatalogItemService = addNewCatalogItemService;
            _catalogItemService = catalogItemService;
            _imageUploadService = imageUploadService;

        }
        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }
        [BindProperty]
        public AddNewCatalogItemDto Data { get; set; }
        [BindProperty]
        public List<IFormFile> files { get; set; }
        public void OnGet()
        {
            Categories = new SelectList(_catalogItemService.GetCatalogType(), "Id", "Type");
            Brands = new SelectList(_catalogItemService.GetBrand(), "Id", "Brand");
        }
        public JsonResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var allerrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(false, allerrors.Select(p => p.ErrorMessage).ToList(),0));
            }
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                files.Add(file);
            }
            List<AddNewCatalogItemImage_Dto> images = new List<AddNewCatalogItemImage_Dto>();
            if (files.Count > 0)
            {
                var result = _imageUploadService.upload(files);
                foreach (var item in result)
                {
                    images.Add(new AddNewCatalogItemImage_Dto { Src = item });
                }
            }
            Data.image = images;
            var resultservice = _addNewCatalogItemService.Execute(Data);
            return new JsonResult(resultservice);
        }
    }
}
