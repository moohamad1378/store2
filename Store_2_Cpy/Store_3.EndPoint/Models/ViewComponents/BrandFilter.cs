using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewComponents
{
    public class BrandFilter : ViewComponent
    {
        private readonly ICatalogItemService catalogItemService;

        public BrandFilter(ICatalogItemService catalogItemService)
        {
            this.catalogItemService = catalogItemService;
        }
        public IViewComponentResult Invoke()
        {
            var brands = catalogItemService.GetBrand();
            return View(viewName: "BrandFilter", model: brands);
    }   }
    

}
