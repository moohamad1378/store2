using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store_2.Application.HomePageService;
using Store_3.EndPoint.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageService _homePageService;
        private static readonly NLog.Logger nlog = NLog.LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger, IHomePageService homePageService)
        {
            _logger = logger;
            _homePageService = homePageService;
        }

        public IActionResult Index()
        {
            nlog.Info("+ 1 visitor");
            var data = _homePageService.GetData();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
