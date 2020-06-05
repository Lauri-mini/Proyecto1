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
    public class visit_shrinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: visit_shrines
        public ActionResult Index()
        {
            return View(db.visit_shrine.ToList());
        }

        // GET: visit_shrines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            if (visit_shrine == null)
            {
                return HttpNotFound();
            }
            return View(visit_shrine);
        }

        // GET: visit_shrines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: visit_shrines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] visit_shrine visit_shrine)
        {
            if (ModelState.IsValid)
            {
                db.visit_shrine.Add(visit_shrine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visit_shrine);
        }

        // GET: visit_shrines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            if (visit_shrine == null)
            {
                return HttpNotFound();
            }
            return View(visit_shrine);
        }

        // POST: visit_shrines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] visit_shrine visit_shrine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit_shrine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visit_shrine);
        }

        // GET: visit_shrines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            if (visit_shrine == null)
            {
                return HttpNotFound();
            }
            return View(visit_shrine);
        }

        // POST: visit_shrines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            db.visit_shrine.Remove(visit_shrine);
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
