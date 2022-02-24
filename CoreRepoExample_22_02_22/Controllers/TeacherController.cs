using CoreRepoExample_22_02_22.Controllers.Repository;
using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherRepository rep;
        private ICourseRepository repCourse;
        EntityVM evm = new EntityVM();
        public TeacherController(ITeacherRepository _rep, ICourseRepository _repCourse)
        {
            rep = _rep;
            repCourse = _repCourse;
        }
        public IActionResult Index(string name = null, string surname = null)
        {
            ViewBag.Name = name;
            ViewBag.Surname = surname;
            return View(rep.GetTeachersByFilter(name, surname).ToList());
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            evm.Teachers = rep.GetById(id);
            return View(evm);
        }
        [HttpPost]
        public IActionResult Edit(EntityVM model)
        {
            Teacher t = new Teacher();
            t.Name = model.Teachers.Name;
            t.Surname = model.Teachers.Surname;
            t.Address = model.Teachers.Address;
            rep.Update(t);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Insert(EntityVM model)
        {
            rep.Insert(model.Teachers);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            evm.Teachers = rep.GetById(id);
            return View(evm);
        }
        public IActionResult Delete(Teacher model)
        {
            rep.Delete(model);
            return RedirectToAction("Index");
        }

    }
}
