using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Store_2.Application.Catalogs.CatalogItems.GetGatalogItemPDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetCatalogItemPLPService _pLPService;
        private readonly IGetCatalogItemPDPService _getCatalogItemPDPService;
        public ProductController(IGetCatalogItemPLPService pLPService,
            IGetCatalogItemPDPService getCatalogItemPDPService)
        {
            _pLPService = pLPService;
            _getCatalogItemPDPService = getCatalogItemPDPService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] CatalogPLPRequestDto request)
        {
            return Ok(_pLPService.Execute(request));
        }
        [HttpGet]
        [Route("PDP")]
        public IActionResult Get([FromQuery]int id)
        {
            return Ok(_getCatalogItemPDPService.Execute(id));
        }
    }
}
