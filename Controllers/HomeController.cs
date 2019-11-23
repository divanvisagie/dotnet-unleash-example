using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dockernet.Models;
using Unleash;

namespace dockernet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DefaultUnleash _unleash;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            var settings = new UnleashSettings()
            {
                AppName = "dockernet",
                InstanceTag = "instance 1",
                UnleashApi = new Uri("http://localhost:5002")
            };

            _unleash = new DefaultUnleash(settings);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var pvm = new PrivacyViewModel();
            pvm.Heading = "Privacy Policy";
;
            if (_unleash.IsEnabled("PrivacyAlt")) {
                pvm.Heading = "New Privacy Policy unleashed";
            }

            
            return View(pvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
