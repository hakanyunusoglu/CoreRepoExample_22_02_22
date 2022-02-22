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
        public HomeController(IRequestRepository _rep)
        {
            rep = _rep;
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
