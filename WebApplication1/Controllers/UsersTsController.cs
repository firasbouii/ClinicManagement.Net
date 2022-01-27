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
    public class UsersTsController : Controller
    {
        private Model1 db = new Model1();

        // GET: UsersTs
        public ActionResult Index()
        {
            return View(db.UsersT.ToList());
        }

        // GET: UsersTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersT usersT = db.UsersT.Find(id);
            if (usersT == null)
            {
                return HttpNotFound();
            }
            return View(usersT);
        }

        // GET: UsersTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersTs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userName,FirsName,password")] UsersT usersT)
        {
            if (ModelState.IsValid)
            {
                db.UsersT.Add(usersT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersT);
        }

        // GET: UsersTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersT usersT = db.UsersT.Find(id);
            if (usersT == null)
            {
                return HttpNotFound();
            }
            return View(usersT);
        }

        // POST: UsersTs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userName,FirsName,password")] UsersT usersT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersT);
        }

        // GET: UsersTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersT usersT = db.UsersT.Find(id);
            if (usersT == null)
            {
                return HttpNotFound();
            }
            return View(usersT);
        }

        // POST: UsersTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersT usersT = db.UsersT.Find(id);
            db.UsersT.Remove(usersT);
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
