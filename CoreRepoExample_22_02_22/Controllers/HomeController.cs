using CoreRepoExample_22_02_22.Controllers.Repository;
using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepoExample_22_02_22.Controllers
{
    public class HomeController : Controller
    {

        private IRequestRepository rep;
        private ICourseRepository repCourse;
        public HomeController(IRequestRepository _rep, ICourseRepository _repCourse)
        {
            rep = _rep;
            repCourse = _repCourse;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Request model)
        {
            rep.Insert(model);
            return View("Tesekkur",model);
        }
        public IActionResult Liste()
        {
            return View(rep.GetRequestsAll());
        }

        //Filtrelemeli Liste
        public IActionResult KursListe(string name =null, decimal? price=null, string isActive=null)

        {
            ViewBag.Name = name;
            ViewBag.Price = price;
            ViewBag.isActive = isActive == "on" ? true : false;
            return View(repCourse.GetCoursesByFilter(name,price,isActive));
        }
        public IActionResult KursEkle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult KursEkle(Course model)
        {
            repCourse.Insert(model);
            return RedirectToAction("KursListe");
        }
        public IActionResult Edit(int id)
        {
            return View(repCourse.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Course model)
        {
            Course c = new Course();
            c = repCourse.GetById(model.ID);
            c.Ad = model.Ad;
            c.Aciklama = model.Aciklama;
            c.Fiyat = model.Fiyat;
            c.Aktif = model.Aktif;
            repCourse.Update(c);
            return RedirectToAction("KursListe");
        }
        public IActionResult Delete(Course model)
        {
            repCourse.Delete(model);
            return RedirectToAction("KursListe");
        }
    }
}
