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
    public class PrescriptionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Prescriptions
        public ActionResult Index()
        {
            var prescription = db.Prescription.Include(p => p.Doctor).Include(p => p.Patient);
            return View(prescription.ToList());
        }

        // GET: Prescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescription.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: Prescriptions/Create
        public ActionResult Create()
        {
            ViewBag.id_doc = new SelectList(db.Doctor, "id", "DrName");
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName");
            return View();
        }

        // POST: Prescriptions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_doc,id_pat,note,medicine")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescription.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_doc = new SelectList(db.Doctor, "id", "DrName", prescription.id_doc);
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName", prescription.id_pat);
            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescription.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_doc = new SelectList(db.Doctor, "id", "DrName", prescription.id_doc);
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName", prescription.id_pat);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_doc,id_pat,note,medicine")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_doc = new SelectList(db.Doctor, "id", "DrName", prescription.id_doc);
            ViewBag.id_pat = new SelectList(db.Patient, "id", "FullName", prescription.id_pat);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescription.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescription.Find(id);
            db.Prescription.Remove(prescription);
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
