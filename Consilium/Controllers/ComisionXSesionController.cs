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
    public class ComisionXSesionController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: ComisionXSesion
        public ActionResult Index()
        {
            var comisionXSesion = db.ComisionXSesion.Include(c => c.Comision).Include(c => c.Sesion);
            return View(comisionXSesion.ToList());
        }

        // GET: ComisionXSesion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionXSesion comisionXSesion = db.ComisionXSesion.Find(id);
            if (comisionXSesion == null)
            {
                return HttpNotFound();
            }
            return View(comisionXSesion);
        }

        // GET: ComisionXSesion/Create
        public ActionResult Create()
        {
            ViewBag.idComision = new SelectList(db.Comision, "idComision", "nombre");
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "documento");
            return View();
        }

        // POST: ComisionXSesion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idComisionXSesion,idComision,idSesion")] ComisionXSesion comisionXSesion)
        {
            if (ModelState.IsValid)
            {
                db.ComisionXSesion.Add(comisionXSesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idComision = new SelectList(db.Comision, "idComision", "nombre", comisionXSesion.idComision);
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "documento", comisionXSesion.idSesion);
            return View(comisionXSesion);
        }

        // GET: ComisionXSesion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionXSesion comisionXSesion = db.ComisionXSesion.Find(id);
            if (comisionXSesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idComision = new SelectList(db.Comision, "idComision", "nombre", comisionXSesion.idComision);
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "documento", comisionXSesion.idSesion);
            return View(comisionXSesion);
        }

        // POST: ComisionXSesion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idComisionXSesion,idComision,idSesion")] ComisionXSesion comisionXSesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comisionXSesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idComision = new SelectList(db.Comision, "idComision", "nombre", comisionXSesion.idComision);
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "documento", comisionXSesion.idSesion);
            return View(comisionXSesion);
        }

        // GET: ComisionXSesion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionXSesion comisionXSesion = db.ComisionXSesion.Find(id);
            if (comisionXSesion == null)
            {
                return HttpNotFound();
            }
            return View(comisionXSesion);
        }

        // POST: ComisionXSesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComisionXSesion comisionXSesion = db.ComisionXSesion.Find(id);
            db.ComisionXSesion.Remove(comisionXSesion);
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
