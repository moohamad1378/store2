using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.ViewModels.Catalogs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store_2.Application.Catalogs.CatalogTypes;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogTypeService _CatalogTypeService;
        private readonly IMapper _mapper;
        public CreateModel(ICatalogTypeService catalogTypeService,IMapper mapper)
        {
            _mapper = mapper;
            _CatalogTypeService = catalogTypeService;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public List<string> Message { get; set; } = new List<string>();
        
        public void OnGet(int? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var model = _mapper.Map<CatalogTypeDto>(CatalogType);
            var result = _CatalogTypeService.Add(model);
            if (result.IsSuccess)
            {
                return RedirectToPage("Index", new { parentid = CatalogType.ParentCatalogTypeId });
            }
            Message = result.Message;
            return Page();
        }
    }
}
