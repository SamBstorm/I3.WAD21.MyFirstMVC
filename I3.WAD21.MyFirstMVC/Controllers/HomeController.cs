using I3.WAD21.MyFirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public static string name { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(int? id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HiddenMe()
        {
            string message = "Samuel Legrain est passé par là!";
            return Json(message);
        }
        [Route("SaveName/{id?}")]
        [Route("SaveMe/{id?}")]
        [Route("Save/{id?}")]
        public IActionResult SaveName(string id)
        {
            HomeController.name = id;
            return Ok();
        }
        public IActionResult ShowName()
        {
            return Json(HomeController.name);
        }
    }
}
