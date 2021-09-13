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
    public class EditModel : PageModel
    {
        private readonly ICatalogTypeService _CatalogTypeService;
        private readonly IMapper _mapper;
        public EditModel(ICatalogTypeService catalogTypeService,IMapper mapper)
        {
            _CatalogTypeService = catalogTypeService;
            _mapper = mapper;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public List<string> Message { get; set; } = new List<string>();
        public void OnGet(int Id)
        {
           var model=_CatalogTypeService.FindById(Id);
            if (model.IsSuccess)
            {
                CatalogType = _mapper.Map<CatalogTypeViewModel>(model.Data);
                Message = model.Message;
            }
        }
        public IActionResult OnPost()
        {
            var model = _mapper.Map<CatalogTypeDto>(CatalogType);
            var result = _CatalogTypeService.Edit(model);
            Message = result.Message;
            CatalogType = _mapper.Map<CatalogTypeViewModel>(result.Data);
            return Page();
        }
    }
}
