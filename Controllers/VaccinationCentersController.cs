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
    public class VaccinationCentersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VaccinationCenters
        public ActionResult Index()
        {
            return View(db.VaccinationCenters.ToList());
        }

        // GET: VaccinationCenters/Details/5
        [Authorize(Roles = "Doctor")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Create
        [Authorize(Roles = "Doctor")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,MaxCapacity")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                db.VaccinationCenters.Add(vaccinationCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Edit/5
        [Authorize(Roles = "Doctor")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,MaxCapacity")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccinationCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        [Authorize(Roles = "Doctor")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            db.VaccinationCenters.Remove(vaccinationCenter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult CreateVaccine()
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
        

        public ActionResult CreateVaccine([Bind(Include = "Id,Manufacturer,Certificate,DateTaken,PatientId,VaccinationCenterId")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Vaccines.Add(vaccine);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Embg", vaccine.PatientId);
            ViewBag.VaccinationCenterId = new SelectList(db.VaccinationCenters, "Id", "Name", vaccine.VaccinationCenterId);
            return View(vaccine);
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
