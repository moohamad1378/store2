using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class MyFavuoriteController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly ICatalogItemService _catalogItemService;
        private readonly UserManager<User> _userManager;
        public MyFavuoriteController(IDataBaseContext context, ICatalogItemService catalogItemService
            , UserManager<User> userManager)
        {
            _context = context;
            _catalogItemService = catalogItemService;
            _userManager = userManager;
        }
        public IActionResult Index(int Page = 1, int pagesize = 20)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var data = _catalogItemService.GetMyFavourite(user.Id, Page, pagesize);
            return View(data);
        }
        public IActionResult AddToMyFavourite(int CatalogItemId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _catalogItemService.AddToMyFavuorite(user.Id, CatalogItemId);
            return RedirectToAction(nameof(Index));
        }
    }
}
