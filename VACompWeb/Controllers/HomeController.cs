using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VACompWeb.Models;

namespace VACompWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //[HttpGet]
        //public IActionResult CompensationCalc()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CompensationCalc(VeteranProfileModel model)
        //{
        //    if (model.OperationType == OperationType.Addition)
        //        model.Result = model.NumberA + model.NumberB;
        //    return View(model);
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RatingCalc()
        {
            return View();
        }

        public IActionResult UserInfo()
        {
            return View();
        }
        public IActionResult Resources()
        {
            return View();
        }

        public IActionResult ContactUs()
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
