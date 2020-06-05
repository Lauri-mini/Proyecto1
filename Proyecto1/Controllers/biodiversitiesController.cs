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
    public class biodiversitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: biodiversities
        public ActionResult Index()
        {
            return View(db.biodiversities.ToList());
        }

        // GET: biodiversities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            biodiversity biodiversity = db.biodiversities.Find(id);
            if (biodiversity == null)
            {
                return HttpNotFound();
            }
            return View(biodiversity);
        }

        // GET: biodiversities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: biodiversities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Tipo,Descripcion,Especie,Santuario,ImgUrl")] biodiversity biodiversity)
        {
            if (ModelState.IsValid)
            {
                db.biodiversities.Add(biodiversity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biodiversity);
        }

        // GET: biodiversities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            biodiversity biodiversity = db.biodiversities.Find(id);
            if (biodiversity == null)
            {
                return HttpNotFound();
            }
            return View(biodiversity);
        }

        // POST: biodiversities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Tipo,Descripcion,Especie,Santuario,ImgUrl")] biodiversity biodiversity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biodiversity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biodiversity);
        }

        // GET: biodiversities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            biodiversity biodiversity = db.biodiversities.Find(id);
            if (biodiversity == null)
            {
                return HttpNotFound();
            }
            return View(biodiversity);
        }

        // POST: biodiversities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            biodiversity biodiversity = db.biodiversities.Find(id);
            db.biodiversities.Remove(biodiversity);
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
