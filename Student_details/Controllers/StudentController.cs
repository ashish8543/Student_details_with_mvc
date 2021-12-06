using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_details.Models;

namespace Student_details.Controllers
{
    public class StudentController : Controller
    {
        private stu_detailsEntities db = new stu_detailsEntities();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.stu_info.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stu_info stu_info = db.stu_info.Find(id);
            if (stu_info == null)
            {
                return HttpNotFound();
            }
            return View(stu_info);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stu_Id,Student_Name,Email,Mobile,Student_Course,Section,Student_Address")] stu_info stu_info)
        {
            if (ModelState.IsValid)
            {
                db.stu_info.Add(stu_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stu_info);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stu_info stu_info = db.stu_info.Find(id);
            if (stu_info == null)
            {
                return HttpNotFound();
            }
            return View(stu_info);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stu_Id,Student_Name,Email,Mobile,Student_Course,Section,Student_Address")] stu_info stu_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu_info);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stu_info stu_info = db.stu_info.Find(id);
            if (stu_info == null)
            {
                return HttpNotFound();
            }
            return View(stu_info);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stu_info stu_info = db.stu_info.Find(id);
            db.stu_info.Remove(stu_info);
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
