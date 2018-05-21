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
    public class JustificacionesController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: Justificaciones
        public ActionResult Index()
        {
            var justificacion = db.Justificacion.Include(j => j.Usuario);
            return View(justificacion.ToList());
        }

        // GET: Justificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacion justificacion = db.Justificacion.Find(id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        // GET: Justificaciones/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Justificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJustificacion,fecha,idUsuario,asunto,texto,estado")] Justificacion justificacion)
        {
            if (ModelState.IsValid)
            {
                db.Justificacion.Add(justificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", justificacion.idUsuario);
            return View(justificacion);
        }

        // GET: Justificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacion justificacion = db.Justificacion.Find(id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", justificacion.idUsuario);
            return View(justificacion);
        }

        // POST: Justificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJustificacion,fecha,idUsuario,asunto,texto,estado")] Justificacion justificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(justificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", justificacion.idUsuario);
            return View(justificacion);
        }

        // GET: Justificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Justificacion justificacion = db.Justificacion.Find(id);
            if (justificacion == null)
            {
                return HttpNotFound();
            }
            return View(justificacion);
        }

        // POST: Justificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Justificacion justificacion = db.Justificacion.Find(id);
            db.Justificacion.Remove(justificacion);
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
