using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lesson7.Model;
using Lesson7.Models;
using AutoMapper;

namespace Lesson7.Controllers
{
    public class CourseController : Controller
    {
        private Lesson7Entities db = new Lesson7Entities();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.Courses.AsEnumerable().Select(c => Mapper.Map<CourseModel>(c)).ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModel courseModel = Mapper.Map<CourseModel>(db.Courses.Find(id));
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numer,Emer")] CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(Mapper.Map<Course>(courseModel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseModel);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModel courseModel = Mapper.Map<CourseModel>(db.Courses.Find(id));
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numer,Emer")] CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                Course course = Mapper.Map<Course>(courseModel);
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseModel);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModel courseModel = Mapper.Map<CourseModel>(db.Courses.Find(id));
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
