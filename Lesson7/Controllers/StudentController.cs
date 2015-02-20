using Lesson7.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.Data.Entity;
using System.Web.UI;
using Lesson7.Models;
using AutoMapper;
using Lesson7.Service;

namespace Lesson7.Controllers
{
    public class StudentController : Controller
    {
        IStudentService StudentService;

        public StudentController(IStudentService StudentService)
        {
            this.StudentService = StudentService;
        }

        [OutputCache(Duration = 1200)]
        public ActionResult Index()
        {
            return View(StudentService.GetAll().Select(s => Mapper.Map<StudentModel>(s)).ToList());
        }

        [HandleError]
        // GET: Student
        public ActionResult NewIndex()
        {
            //Student student = new Student("Cimi");
            //student.AddGradeRange(8, 5, 9, 10, 8, 7);
            //student.TipiStudentit = StudentType.FullTime;

            //XmlSerializer serializer = new XmlSerializer(typeof(Student));
            //string path = System.Web.HttpRuntime.AppDomainAppPath;
            ////TextWriter writerStream = new StreamWriter(path + "nota.xml");
            ////serializer.Serialize(writerStream, student);


            //XmlSerializer deSerializer = new XmlSerializer(typeof(StudentCollection));
            //FileStream fileReader = new FileStream(path + "nota.xml", FileMode.Open);
            //StudentCollection students = deSerializer.Deserialize(fileReader) as StudentCollection;


            //return RedirectPermanent("/student/search"); // HTTP 301
            //return Redirect("/student/search"); // HTTP 302
            //return RedirectToAction("Search", new { name = "Endri"});

            // Detajet tregohen kur kerkesa ekzekutohet nga i njejti host
            throw new Exception("Dicka e papritur ndodhi");
            // Shkojme ne error view per shkak te handleErrorAttribute
            //return File(path + "nota.xml", "text/xml");
        }


        [HttpGet]
        [OutputCache(CacheProfile = "Aggresive")]
        public ActionResult Search(string name = "cimi")
        {

            StudentModel student = Mapper.Map<StudentModel>(StudentService.Search(s => s.Emri.ToLower() == name.ToLower()));
            if (student != null)
            {
                return Json(student, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content(String.Format("Studenti {0} nuk gjendet ne liste", name));
            }
        }

        public bool trueOrFalse(Student student, string name)
        {
            return true;
        }

        [HttpPost]
        public ActionResult Search()
        {
            return Content("Search!");
        }


        public ActionResult Details(int? Id)
        {
            if (Id.HasValue)
            {
                return View(Mapper.Map<StudentModel>(StudentService.GetById(Id.Value)));
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Edit(int? Id)
        {
            if (Id.HasValue)
            {
                return View(Mapper.Map<StudentModel>(StudentService.GetById(Id.Value, false)));
            }
            else
            {
                return View("Index");
            }
        }

        // Ketu mund te perdorim edhe nje FormCollection nese duam
        // Model
        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                Student st = Mapper.Map<Student>(student);
                StudentService.Update(st);
                return RedirectToAction("Details", new { id = student.Id });

            }
            return View(student);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public ActionResult BestStudent()
        {

            var bestStudent = Mapper.Map<StudentModel>(StudentService.GetBestStudent());

            return PartialView("_Student", bestStudent);

        }
    }
}