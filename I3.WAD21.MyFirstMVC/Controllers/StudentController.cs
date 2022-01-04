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
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _service;

        public StudentController(IRepository<Student> service)
        {
            this._service = service;
        }

        // GET: StudentController
        public ActionResult Index(bool? sorted)
        {
            IEnumerable<StudentListItem> model = this._service.Get().Select(s => s.ToListItem());
            if(!(sorted is null) && sorted == true)
            {
                model = model.OrderBy(s => s.Nom).ThenBy(s=>s.Prenom);
            }
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            StudentDetails model = this._service.Get(id).ToDetails();
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateForm collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (collection.Prenom != "Sam") throw new ArgumentException("Le prénom n'est pas Sam");
                Student result = new Student()
                {
                    First_Name = collection.Prenom,
                    Last_Name = collection.Nom,
                    BirthDate = collection.BirthDate,
                    Section_ID = collection.Section,
                    Course_ID = collection.Course,
                    Year_Result = 0,
                    Login = collection.Prenom[0] + collection.Nom
                };
                this._service.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(collection);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
