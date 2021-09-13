﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store_2.Application.Orders.CustomerOrderService;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class OrdersController : Controller
    {
        private readonly ICustomerOrderService customerOrderService;
        private readonly UserManager<User> userManager;

        public OrdersController(ICustomerOrderService customerOrderService
            ,UserManager<User> userManager)
        {
            this.customerOrderService = customerOrderService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;
            var orders = customerOrderService.GetMyOrder(user.Id);
            return View(orders);
        }
    }
}
