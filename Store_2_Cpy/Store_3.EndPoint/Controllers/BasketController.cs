using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.basketsService;
using Store_2.Application.Discounts;
using Store_2.Application.Interface.Context;
using Store_2.Application.Orders;
using Store_2.Application.Payments;
using Store_2.Application.Userss;
using Store_2.Domain.Orders;
using Store_2.Domain.Users;
using Store_3.EndPoint.Models.ViewModels.Baskets;
using Store_3.EndPoint.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly IBasketservice _basketservice;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserAddressService _userAddressService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IDiscountService _discountService;
        private readonly UserManager<User> _userManager;

        private string userId = null;
        public BasketController(IDataBaseContext context, IBasketservice basketservice
            , SignInManager<User> signInManager, IUserAddressService userAddressService,
            IOrderService orderService, IPaymentService paymentService, IDiscountService discountService
            , UserManager<User> userManager)
        {
            _context = context;
            _basketservice = basketservice;
            _signInManager = signInManager;
            _userAddressService = userAddressService;
            _orderService = orderService;
            _paymentService = paymentService;
            _discountService = discountService;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = GetOrSetbasket();
            return View(data);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(int catalogitemid, int quantiny = 1)
        {
            var Basket = GetOrSetbasket();
            _basketservice.AddItemToBasket(Basket.Id, catalogitemid, quantiny);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RemoveItemFromBasket(int ItemId)
        {
            _basketservice.RemoveItemFromBasket(ItemId);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SetQouantity(int basketitemid, int qouantity)
        {
            return Json(_basketservice.SetQouantities(basketitemid, qouantity));
        }
        public IActionResult ShippingPayment()
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            string userid = ClaimUtility.GetUserId(User);
            model.basket = _basketservice.GetBasketForUser(userid);
            model.userAddresses = _userAddressService.GetAddress(userid);
            return View(model);
        }
        [HttpPost]
        public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod)
        {
            string userid = ClaimUtility.GetUserId(User);
            var basket = _basketservice.GetBasketForUser(userid);
            int orderid = _orderService.CreateOrder(basket.Id, Address, PaymentMethod);
            if (PaymentMethod == PaymentMethod.onlinePament)
            {
                var peyment = _paymentService.PayForOrder(orderid);
                return RedirectToAction("Index", "Pay", new { Paymentid = peyment.PaymentId });


            }
            else
            {
                return RedirectToAction("Index", "Orders", new { area = "customer" });
            }

        }
        public IActionResult checkout()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ApplyDiscount(string CoponCode, int BasketId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var valisdiscount = _discountService.IsDiscountValid(CoponCode, user);

            if (valisdiscount.IsSuccess)
            {
                _discountService.ApplyDiscountInBasket(CoponCode, BasketId);
            }
            else
            {
                TempData["InvalidMessage"] = String.Join(Environment.NewLine, valisdiscount.Message.Select(a => String.Join(", ", a)));

            }

            //_discountService.ApplyDiscountInBasket(CoponCode, BasketId);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public IActionResult RemoveDiscount(int Id)
        {
            _discountService.RemoveDiscountFromBasket(Id);
            return RedirectToAction(nameof(Index));
        }
        private BasketDto GetOrSetbasket()
        {
            if (_signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User);
                return _basketservice.GetOrCreateasketForUser(userId);
            }
            else
            {
                SetCookieForBasket();
                return _basketservice.GetOrCreateasketForUser(userId);
            }
        }
        private void SetCookieForBasket()
        {
            string basketcookiename = "BasketId";
            if (Request.Cookies.ContainsKey(basketcookiename))
            {
                userId = Request.Cookies[basketcookiename];
            }
            if (userId != null) return;
            userId = Guid.NewGuid().ToString();
            var cookieoptions = new CookieOptions { IsEssential = true };
            cookieoptions.Expires = DateTime.Today.AddYears(20);
            Response.Cookies.Append(basketcookiename, userId, cookieoptions);
        }
    }
}

