using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MedicalConsultationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: MedicalConsultations
        public ActionResult Index()
        {
            var medicalConsultation = db.MedicalConsultation.Include(m => m.Doctor).Include(m => m.Patient).Include(m => m.Prescription);
            return View(medicalConsultation.ToList());
        }

        // GET: MedicalConsultations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalConsultation medicalConsultation = db.MedicalConsultation.Find(id);
            if (medicalConsultation == null)
            {
                return HttpNotFound();
            }
            return View(medicalConsultation);
        }

        // GET: MedicalConsultations/Create
        public ActionResult Create()
        {
            ViewBag.id_med = new SelectList(db.Doctor, "id", "DrName");
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName");
            ViewBag.id_pres = new SelectList(db.Prescription, "id", "note");
            return View();
        }

        // POST: MedicalConsultations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_med,id_pat,RoomNumber,DateOfmedicalconsultation,id_pres")] MedicalConsultation medicalConsultation)
        {
            if (ModelState.IsValid)
            {
                db.MedicalConsultation.Add(medicalConsultation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_med = new SelectList(db.Doctor, "id", "DrName", medicalConsultation.id_med);
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName", medicalConsultation.id_pat);
            ViewBag.id_pres = new SelectList(db.Prescription, "id", "note", medicalConsultation.id_pres);
            return View(medicalConsultation);
        }

        // GET: MedicalConsultations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalConsultation medicalConsultation = db.MedicalConsultation.Find(id);
            if (medicalConsultation == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_med = new SelectList(db.Doctor, "id", "DrName", medicalConsultation.id_med);
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName", medicalConsultation.id_pat);
            ViewBag.id_pres = new SelectList(db.Prescription, "id", "note", medicalConsultation.id_pres);
            return View(medicalConsultation);
        }

        // POST: MedicalConsultations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_med,id_pat,RoomNumber,DateOfmedicalconsultation,id_pres")] MedicalConsultation medicalConsultation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalConsultation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_med = new SelectList(db.Doctor, "id", "DrName", medicalConsultation.id_med);
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName", medicalConsultation.id_pat);
            ViewBag.id_pres = new SelectList(db.Prescription, "id", "note", medicalConsultation.id_pres);
            return View(medicalConsultation);
        }

        // GET: MedicalConsultations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalConsultation medicalConsultation = db.MedicalConsultation.Find(id);
            if (medicalConsultation == null)
            {
                return HttpNotFound();
            }
            return View(medicalConsultation);
        }

        // POST: MedicalConsultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalConsultation medicalConsultation = db.MedicalConsultation.Find(id);
            db.MedicalConsultation.Remove(medicalConsultation);
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
