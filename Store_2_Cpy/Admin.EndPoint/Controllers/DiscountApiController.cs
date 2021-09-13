using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountApiController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        [Route("Searchcatalogitem")]
        public async Task<IActionResult> Searchcatalogitem(string term)
        {
            return Ok(_discountService.GetCatalogItems(term));
        }
    }
}
