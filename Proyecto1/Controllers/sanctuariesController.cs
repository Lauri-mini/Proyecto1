using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    public class sanctuariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: sanctuaries
        public ActionResult Index()
        {
            var sanctuaries = db.sanctuaries.Include(s => s.Biodiversidad);
            return View(sanctuaries.ToList());
        }

        // GET: sanctuaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanctuary sanctuary = db.sanctuaries.Find(id);
            if (sanctuary == null)
            {
                return HttpNotFound();
            }
            return View(sanctuary);
        }

        // GET: sanctuaries/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.biodiversities, "Id", "Nombre");
            return View();
        }

        // POST: sanctuaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Ubicacion,Descripcion")] sanctuary sanctuary)
        {
            if (ModelState.IsValid)
            {
                db.sanctuaries.Add(sanctuary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.biodiversities, "Id", "Nombre", sanctuary.Id);
            return View(sanctuary);
        }

        // GET: sanctuaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanctuary sanctuary = db.sanctuaries.Find(id);
            if (sanctuary == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.biodiversities, "Id", "Nombre", sanctuary.Id);
            return View(sanctuary);
        }

        // POST: sanctuaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Ubicacion,Descripcion")] sanctuary sanctuary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanctuary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.biodiversities, "Id", "Nombre", sanctuary.Id);
            return View(sanctuary);
        }

        // GET: sanctuaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanctuary sanctuary = db.sanctuaries.Find(id);
            if (sanctuary == null)
            {
                return HttpNotFound();
            }
            return View(sanctuary);
        }

        // POST: sanctuaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sanctuary sanctuary = db.sanctuaries.Find(id);
            db.sanctuaries.Remove(sanctuary);
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
