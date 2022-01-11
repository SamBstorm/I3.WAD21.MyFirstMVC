using DBSlideDataContext.DTO;
using DBSlideDataContext.Services;
using I3.WAD21.MyFirstMVC.Handlers;
using I3.WAD21.MyFirstMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Controllers
{
    public class DemoController : Controller
    {
        private readonly IRepository<Student> service;
        private readonly SessionManager session;

        public List<Movie> Movies = new List<Movie>(new Movie[] {
        new Movie() { Id = 1 , Title = "Jurassic Park", Subtitle = null,  Minutes = 90, RealeaseDate = new DateTime(1993,6,21)},
            new Movie() { Id = 2, Title = "Matrix", Subtitle = null, Minutes = 90, RealeaseDate = new DateTime(1999, 6, 21) }, new Movie() { Id = 3, Title = "Matrix", Subtitle = "Reloaded", Minutes = 90, RealeaseDate = new DateTime(1993, 6, 21) }
        });

        public DemoController(IRepository<Student> service, SessionManager session)
        {
            this.service = service;
            this.session = session;
        }

        public IActionResult Index()
        {
            return View(service.Get().Select(s=> s.ToListItem()));
        }

        //[Route("Student/details/{id}")]
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
            if (session.IsConnected) return RedirectToAction("Index","Home");
            return View();
        }
        ///// <summary>
        ///// Action récupérant le formulaire dans un IFormCollection, permet de travailler les donnée d'un formulaire.
        ///// ATTENTION : Signature doit être différente de l'affichage du formulaire, et être d'un HttpVerb différent, si l'affichage est en GET, la récupération est en POST (vérifier que la balise form contienne une méthode POST) : [HttpPost]
        ///// </summary>
        ///// <param name="formCollection"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Login(IFormCollection formCollection)
        //{
        //    return View();
        //}
        ///// <summary>
        ///// Action récupérant le formulaire dans des paramètre typés, permet de travailler les donnée d'un formulaire. Attention chaque paramètre doit avoir le nom du name de l'input.
        ///// ATTENTION : Signature doit être différente de l'affichage du formulaire, et être d'un HttpVerb différent, si l'affichage est en GET, la récupération est en POST (vérifier que la balise form contienne une méthode POST) : [HttpPost]
        ///// </summary>
        ///// <param name="formCollection"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Login(string email, string passwd)
        //{
        //    return View();
        //}

        /// <summary>
        /// Action récupérant le formulaire dans un model LoginForm, que j'ai créé moi-même, permet de travailler les donnée d'un formulaire.
        /// ATTENTION : Signature doit être différente de l'affichage du formulaire, et être d'un HttpVerb différent, si l'affichage est en GET, la récupération est en POST (vérifier que la balise form contienne une méthode POST) : [HttpPost]
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            //ValidateLoginForm(form, ModelState);
            if(!ModelState.IsValid) return View();
            session.SetUser(form);
            return RedirectToAction("Index", "Home");
        }

        //private static void ValidateLoginForm(LoginForm form, ModelStateDictionary modelState)
        //{
        //    if (string.IsNullOrWhiteSpace(form.Email))
        //        modelState.AddModelError(nameof(form.Email), "L'Email est obligatoire");
        //    if (string.IsNullOrWhiteSpace(form.Passwd))
        //        modelState.AddModelError(nameof(form.Passwd), "Le mot de passe est obligatoire");
        //    if (form.Passwd is not null &&
        //        !Regex.IsMatch(form.Passwd,
        //        @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$"))
        //        modelState.AddModelError(nameof(form.Passwd), "Le mot de passe n'est pas correct.");
        //}

        public IActionResult DropDownList()
        {
            DropDownModel ddm = new DropDownModel();
            ddm.options = new int[] { 1, 2, 3, 4, 5 };
            return View(ddm);
        }

        [HttpPost]
        public IActionResult DropDownList(DropDownModel form)
        {
            if (!ModelState.IsValid) return View();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Session()
        {
            this.session.MonTableauDeByte = new byte[0];
            this.session.ValeurText = "toto";
            this.session.ValeurInt = 42;
            return View();
        }

        public IActionResult SessionMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionMovies(Movie collection)
        {
            if(collection is null) return View();
            session.AddMovie(collection);
            return View();
        }
    }
}
