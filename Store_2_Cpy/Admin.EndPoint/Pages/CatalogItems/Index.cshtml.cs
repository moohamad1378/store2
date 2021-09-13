using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using Store_2.Application.Dtos;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemService _catalogItemService;
        public IndexModel(ICatalogItemService catalogItemService)
        {
            _catalogItemService = catalogItemService;
        }
        public PageInatedItemDto<CatalogItemListDto> catalogitem { get; set; }
        public void OnGet(int page=1,int pagesize=100)
        {
            catalogitem = _catalogItemService.GetCatalogList(page, pagesize);
        }
    }
}
