using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Controllers
{
    public class EmptyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
