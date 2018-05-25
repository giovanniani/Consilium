using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;

namespace Consilium.Controllers
{
    public class MocionController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: Mocion
        public ActionResult Index()
        {
            var mocion = db.Mocion.Include(m => m.Punto1);
            return View(mocion.ToList());
        }

        // GET: Mocion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mocion mocion = db.Mocion.Find(id);
            if (mocion == null)
            {
                return HttpNotFound();
            }
            return View(mocion);
        }

        // GET: Mocion/Create
        public ActionResult Create()
        {
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo");
            return View();
        }

        // POST: Mocion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMocion,idPunto,punto,propuesta")] Mocion mocion)
        {
            if (ModelState.IsValid)
            {
                db.Mocion.Add(mocion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", mocion.idPunto);
            return View(mocion);
        }

        // GET: Mocion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mocion mocion = db.Mocion.Find(id);
            if (mocion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", mocion.idPunto);
            return View(mocion);
        }

        // POST: Mocion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMocion,idPunto,punto,propuesta")] Mocion mocion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mocion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", mocion.idPunto);
            return View(mocion);
        }

        // GET: Mocion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mocion mocion = db.Mocion.Find(id);
            if (mocion == null)
            {
                return HttpNotFound();
            }
            return View(mocion);
        }

        // POST: Mocion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mocion mocion = db.Mocion.Find(id);
            db.Mocion.Remove(mocion);
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
