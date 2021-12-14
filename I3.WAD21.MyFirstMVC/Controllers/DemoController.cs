using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.WAD21.MyFirstMVC.Handlers;
using I3.WAD21.MyFirstMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Controllers
{
    public class DemoController : Controller
    {
        private readonly IRepository<Student> service;

        public List<Movie> Movies = new List<Movie>(new Movie[] {
        new Movie() { Id = 1 , Title = "Jurassic Park", Subtitle = null,  Minutes = 90, RealeaseDate = new DateTime(1993,6,21)},
            new Movie() { Id = 2, Title = "Matrix", Subtitle = null, Minutes = 90, RealeaseDate = new DateTime(1999, 6, 21) }, new Movie() { Id = 3, Title = "Matrix", Subtitle = "Reloaded", Minutes = 90, RealeaseDate = new DateTime(1993, 6, 21) }
        });

        public DemoController(IRepository<Student> service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(this.Movies);
        }

        public IActionResult Student(int id)
        {
            StudentListItem stud = service.Get(id).ToListItem();
            return View(stud);
        }

        /// <summary>
        /// Action affichant le formulaire, n'ayant pas de HttpVerb Attribute, la méthode par défaut est GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Action récupérant le formulaire dans un IFormCollection, permet de travailler les donnée d'un formulaire.
        /// ATTENTION : Signature doit être différente de l'affichage du formulaire, et être d'un HttpVerb différent, si l'affichage est en GET, la récupération est en POST (vérifier que la balise form contienne une méthode POST) : [HttpPost]
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(IFormCollection formCollection)
        {
            return View();
        }
    }
}
