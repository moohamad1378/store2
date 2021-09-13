using Microsoft.AspNetCore.Mvc;
using Store_2.Application.basketsService;
using Store_3.EndPoint.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewComponents
{
    public class BasketComponent: ViewComponent
    {
        private readonly IBasketservice _basketservice;
        private ClaimsPrincipal userclaimsPrincipal => ViewContext?.HttpContext?.User;
        public BasketComponent(IBasketservice basketservice)
        {
            _basketservice = basketservice;
        }
        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket = _basketservice.GetBasketForUser(ClaimUtility.GetUserId(userclaimsPrincipal));
            }
            else
            {
                string basketcookiename = "BasketId";
                if (Request.Cookies.ContainsKey(basketcookiename))
                {
                    var BuyerId = Request.Cookies[basketcookiename];
                    basket = _basketservice.GetBasketForUser(BuyerId);
                }
            }
            return View(viewName: "BasketComponent", model: basket);
        }
    }
}
