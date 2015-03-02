using DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson7.Controllers
{
    public class HomeController : Controller
    {
        private Lesson7Entities context = new Lesson7Entities();
        public ActionResult Index()
        {
            int numer = context.Students.Count();
            ViewBag.NumriStudenteve = numer;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}