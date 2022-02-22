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
    }
}
