using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManagementSystem.Data;
using CourseManagementSystem.Models.Models;

namespace CourseManagementSystem.Web.Areas.Admin.Controllers
{
    public class TeachingsController : Controller
    {
        private CourseManagementSystemDbContext db = new CourseManagementSystemDbContext();

        // GET: Admin/Teachings
        public ActionResult Index()
        {
            var teachings = db.Teachings.Include(t => t.Course).Include(t => t.Instructor);
            return View(teachings.ToList());
        }

        // GET: Admin/Teachings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teachings.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        // GET: Admin/Teachings/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstName");
            return View();
        }

        // POST: Admin/Teachings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,CourseID")] Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                db.Teachings.Add(teaching);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", teaching.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstName", teaching.InstructorID);
            return View(teaching);
        }

        // GET: Admin/Teachings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teachings.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", teaching.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstName", teaching.InstructorID);
            return View(teaching);
        }

        // POST: Admin/Teachings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,CourseID")] Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teaching).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", teaching.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FirstName", teaching.InstructorID);
            return View(teaching);
        }

        // GET: Admin/Teachings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teaching teaching = db.Teachings.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        // POST: Admin/Teachings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teaching teaching = db.Teachings.Find(id);
            db.Teachings.Remove(teaching);
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
