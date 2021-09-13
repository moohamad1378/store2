using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store_2.Application.Catalogs.CatalogTypes;
using Store_2.Application.Dtos;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeService _CatalogTypeService;
        public IndexModel(ICatalogTypeService catalogTypeService)
        {
            _CatalogTypeService = catalogTypeService;
        }
        public PageInatedItemDto<CatalogTypeListDto> catalogtype { get; set; }
        public void OnGet(int? parentid,int pageIndex=1,int pagesize=2)
        {
            catalogtype = _CatalogTypeService.GetList(parentid, pageIndex, pagesize);
        }
    }
}
