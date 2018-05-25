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
    public class PuntoXAgendaController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: PuntoXAgenda
        public ActionResult Index()
        {
            var puntoXAgenda = db.PuntoXAgenda.Where(p => p.Punto.EstadoPunto.idEstado == 1).Include(p => p.Agenda).Include(p => p.Punto);
            return View(puntoXAgenda.ToList());
        }

        // GET: PuntoXAgenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoXAgenda puntoXAgenda = db.PuntoXAgenda.Find(id);
            if (puntoXAgenda == null)
            {
                return HttpNotFound();
            }
            return View(puntoXAgenda);
        }

        // GET: PuntoXAgenda/Create
        public ActionResult Create()
        {
            ViewBag.idAgenda = new SelectList(db.Agenda, "idAgenda", "idAgenda");
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo");
            return View();
        }

        // POST: PuntoXAgenda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPuntoXAgenda,idAgenda,idPunto")] PuntoXAgenda puntoXAgenda)
        {
            if (ModelState.IsValid)
            {
                db.PuntoXAgenda.Add(puntoXAgenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAgenda = new SelectList(db.Agenda, "idAgenda", "idAgenda", puntoXAgenda.idAgenda);
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", puntoXAgenda.idPunto);
            return View(puntoXAgenda);
        }

        // GET: PuntoXAgenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoXAgenda puntoXAgenda = db.PuntoXAgenda.Find(id);
            if (puntoXAgenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAgenda = new SelectList(db.Agenda, "idAgenda", "idAgenda", puntoXAgenda.idAgenda);
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", puntoXAgenda.idPunto);
            return View(puntoXAgenda);
        }

        // POST: PuntoXAgenda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPuntoXAgenda,idAgenda,idPunto")] PuntoXAgenda puntoXAgenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntoXAgenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAgenda = new SelectList(db.Agenda, "idAgenda", "idAgenda", puntoXAgenda.idAgenda);
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", puntoXAgenda.idPunto);
            return View(puntoXAgenda);
        }

        // GET: PuntoXAgenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoXAgenda puntoXAgenda = db.PuntoXAgenda.Find(id);
            if (puntoXAgenda == null)
            {
                return HttpNotFound();
            }
            return View(puntoXAgenda);
        }

        // POST: PuntoXAgenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PuntoXAgenda puntoXAgenda = db.PuntoXAgenda.Find(id);
            db.PuntoXAgenda.Remove(puntoXAgenda);
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
