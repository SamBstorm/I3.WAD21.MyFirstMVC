using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Controllers
{
    public class ExoController : Controller
    {
        private readonly IRepository<Student> service;

        public ExoController(IRepository<Student> service)
        {
            this.service = service;
        }
        public static string name { get; set; }
        public IActionResult Index()
        {
            return Json(service.Get());
        }
        [Route("{id}/MultiplierPar2")]
        [Route("{id}/MultiplyPer2")]
        public IActionResult MultiplierParDeux(int id)
        {
            return Json(id*2);
        }

        public IActionResult SaveName(string id)
        {
            name = id;
            return RedirectToAction("ShowName",new { id = 10});
        }

        public IActionResult ShowName(int id)
        {
            if (name is null) return BadRequest("Veuillez d'abord sauvegarder le nom...");
            List<string> result = new List<string>();
            for (int i = 0; i < id; i++)
            {
                result.Add(name);
            }
            return Json(result);
        }
    }
}
