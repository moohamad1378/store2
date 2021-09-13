using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Interface.Context;
using Store_2.Application.Userss;
using Store_3.EndPoint.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly IUserAddressService _userAddressService;
        public AddressController(IDataBaseContext context, IUserAddressService userAddressService)
        {
            _context = context;
            _userAddressService = userAddressService;
        }
        public IActionResult Index(string userid)
        {
            var address = _userAddressService.GetAddress(ClaimUtility.GetUserId(User));
            return View(address);
        }
        public IActionResult AddNewAddress()
        {
            return View(new AddUserAddressDto());
        }
        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDto address)
        {
            string userid = ClaimUtility.GetUserId(User);
            address.UserId = userid;
            _userAddressService.AddNewAddress(address);
            return RedirectToAction(nameof(Index));
        }
    }
}
