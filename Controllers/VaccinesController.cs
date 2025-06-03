using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaccinationApp.Models;

namespace VaccinationApp.Controllers
{
    public class VaccinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vaccines
        public ActionResult Index()
        {
            var vaccines = db.Vaccines.Include(v => v.Patient).Include(v => v.VaccinationCenter);
            return View(vaccines.ToList());
        }

        // GET: Vaccines/Details/5
        [Authorize(Roles = "Doctor")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // GET: Vaccines/Create
        [Authorize(Roles = "Doctor")]

        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Embg");
            ViewBag.VaccinationCenterId = new SelectList(db.VaccinationCenters, "Id", "Name");
            return View();
        }

        // POST: Vaccines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]

        public ActionResult Create([Bind(Include = "Id,Manufacturer,Certificate,DateTaken,PatientId,VaccinationCenterId")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Vaccines.Add(vaccine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Embg", vaccine.PatientId);
            ViewBag.VaccinationCenterId = new SelectList(db.VaccinationCenters, "Id", "Name", vaccine.VaccinationCenterId);
            return View(vaccine);
        }

        // GET: Vaccines/Edit/5
        [Authorize(Roles = "Doctor")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Embg", vaccine.PatientId);
            ViewBag.VaccinationCenterId = new SelectList(db.VaccinationCenters, "Id", "Name", vaccine.VaccinationCenterId);
            return View(vaccine);
        }

        // POST: Vaccines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Manufacturer,Certificate,DateTaken,PatientId,VaccinationCenterId")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Embg", vaccine.PatientId);
            ViewBag.VaccinationCenterId = new SelectList(db.VaccinationCenters, "Id", "Name", vaccine.VaccinationCenterId);
            return View(vaccine);
        }

        // GET: Vaccines/Delete/5
        [Authorize(Roles = "Doctor")]

        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: Vaccines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccine vaccine = db.Vaccines.Find(id);
            db.Vaccines.Remove(vaccine);
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
