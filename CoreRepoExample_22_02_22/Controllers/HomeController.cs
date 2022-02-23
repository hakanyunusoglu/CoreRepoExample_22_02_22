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
        private ITeacherRepository repTeacher;
        EntityVM evm = new EntityVM();
        public HomeController(IRequestRepository _rep, ICourseRepository _repCourse, ITeacherRepository _repTeacher)
        {
            rep = _rep;
            repCourse = _repCourse;
            repTeacher = _repTeacher;
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
        public IActionResult Liste(string name = null, string email = null, string tel = null, string mesaj = null)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Tel = tel;
            ViewBag.Mesaj = mesaj;

            return View(rep.GetRequestByFilter(name, email, tel, mesaj));
        }

        //Filtrelemeli Liste
        public IActionResult KursListe(string name =null, decimal? price=null, string isActive=null)

        {
            ViewBag.Name = name;
            ViewBag.Price = price;
            ViewBag.isActive = isActive == "on" ? true : false;
            EntityVM evm = new EntityVM();
            evm.cList = repCourse.GetCoursesByFilter(name, price, isActive).ToList();
            evm.tList = repTeacher.GetTeachers().ToList();
            return View(evm);
        }
        public IActionResult KursEkle()
        {
            evm.tList = repTeacher.GetAvailableTeachers().ToList();
            return View(evm);
        }
        [HttpPost]
        public IActionResult KursEkle(EntityVM model)
        {
            repCourse.Insert(model.Courses);
            return RedirectToAction("KursListe");
        }
        public IActionResult Edit(int id)
        {
            evm.tList = repTeacher.GetAvailableTeachers().ToList();
            evm.Courses = repCourse.GetById(id);
            return View(evm);
        }
        [HttpPost]
        public IActionResult Edit(EntityVM model)
        {
            Course c = new Course();
            c = repCourse.GetById(model.Courses.ID);
            c.Ad = model.Courses.Ad;
            c.Aciklama = model.Courses.Aciklama;
            c.Fiyat = model.Courses.Fiyat;
            c.Aktif = model.Courses.Aktif;
            c.TeacherID = model.Courses.TeacherID;
            repCourse.Update(c);
            return RedirectToAction("KursListe");
        }
        public IActionResult Delete(Course model)
        {
            repCourse.Delete(model);
            return RedirectToAction("KursListe");
        }
        public IActionResult EditTalep(int id)
        {
            return View(rep.GetById(id));
        }
        [HttpPost]
        public IActionResult EditTalep(Request model)
        {
            Request r = new Request();
            r = rep.GetById(model.ID);
            r.Ad = model.Ad;
            r.Email = model.Email;
            r.Telefon = model.Telefon;
            r.Mesaj = model.Mesaj;
            rep.Update(r);
            return RedirectToAction("Liste");
        }
        public IActionResult DeleteTalep(Request model)
        {
            rep.Delete(model);
            return RedirectToAction("Liste");
        }
        public IActionResult DetailTalep(int id)
        {
            return View(rep.GetById(id));
        }
        public IActionResult Detail(int id)
        {
            evm.Courses = repCourse.GetById(id);
            evm.Teachers = repTeacher.GetTeacherAll().FirstOrDefault(x=>x.ID == evm.Courses.TeacherID);
            return View(evm);
        }
    }
}
