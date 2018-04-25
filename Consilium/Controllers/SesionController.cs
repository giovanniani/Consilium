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
    public class SesionController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: Sesion
        public ActionResult Index()
        {
            var sesion = db.Sesion.Include(s => s.TipoSesion);
            return View(sesion.ToList());
        }

        // GET: Sesion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesion sesion = db.Sesion.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            return View(sesion);
        }

        // GET: Sesion/Create
        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.TipoSesion, "idTipo", "nombre");
            return View();
        }

        // POST: Sesion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSesion,idTipo,fecha,idAgenda,documento")] Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                db.Sesion.Add(sesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipo = new SelectList(db.TipoSesion, "idTipo", "nombre", sesion.idTipo);
            return View(sesion);
        }

        // GET: Sesion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesion sesion = db.Sesion.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.TipoSesion, "idTipo", "nombre", sesion.idTipo);
            return View(sesion);
        }

        // POST: Sesion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSesion,idTipo,fecha,idAgenda,documento")] Sesion sesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(db.TipoSesion, "idTipo", "nombre", sesion.idTipo);
            return View(sesion);
        }

        // GET: Sesion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesion sesion = db.Sesion.Find(id);
            if (sesion == null)
            {
                return HttpNotFound();
            }
            return View(sesion);
        }

        // POST: Sesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sesion sesion = db.Sesion.Find(id);
            db.Sesion.Remove(sesion);
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
