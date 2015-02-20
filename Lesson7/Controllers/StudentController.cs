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

namespace Lesson7.Controllers
{
    public class StudentController : Controller
    {
        [OutputCache(Duration=1200)]
        public ActionResult Index()
        {
            using (var db = new Lesson7Entities())
            {
                return View(db.Students.AsEnumerable().Select(s => Mapper.Map<StudentModel>(s)).ToList());
            }
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
        [OutputCache(CacheProfile="Aggresive")]
        public ActionResult Search(string name = "cimi")
        {
            using (var db = new Lesson7Entities())
            {
                StudentModel student = Mapper.Map<StudentModel>(db.Students.FirstOrDefault(s => s.Emri.ToLower() == name.ToLower())) ;
                if (student != null)
                {
                    return Json(student, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Content(String.Format("Studenti {0} nuk gjendet ne liste", name));
                }
            }
        }

        public bool trueOrFalse (Student student, string name)
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
            using (var db = new Lesson7Entities())
            {
                return View(Mapper.Map<StudentModel>(db.Students.Include(s => s.StudentNotas).Include(s => s.Courses).FirstOrDefault(s => s.Id == Id)));
            }
        }

        public ActionResult Edit(int? Id)
        {
            using (var db = new Lesson7Entities())
            {
                return View(Mapper.Map<StudentModel>(db.Students.FirstOrDefault(s => s.Id == Id)));
            }
        }

        // Ketu mund te perdorim edhe nje FormCollection nese duam
        // Model
        [HttpPost]
        public ActionResult Edit (StudentModel student)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Lesson7Entities())
                {
                    Student st = db.Students.FirstOrDefault(s => s.Id == student.Id);
                    if (st != null)
                    {
                        st = Mapper.Map<Student>(student);
                        db.Students.Attach(st);
                        db.SaveChanges();
                        return RedirectToAction("Details", new { name = student.Emri });
                    }
                }
            }
            return View(student);
        }


        [ChildActionOnly]
        [OutputCache(Duration=60)]
        public ActionResult BestStudent()
        {
            using (var db = new Lesson7Entities())
            {
                var bestStudent = Mapper.Map<StudentModel>(db.Students.OrderByDescending(s => s.StudentNotas.Average(n => n.Nota)).First());

                return PartialView("_Student", bestStudent);
            }
        }
    }
}