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
    public class ResultadoPuntoesController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: ResultadoPuntoes
        public ActionResult Index()
        {
            var resultadoPunto = db.ResultadoPunto.Include(r => r.Punto);
            return View(resultadoPunto.ToList());
        }

        // GET: ResultadoPuntoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoPunto resultadoPunto = db.ResultadoPunto.Find(id);
            if (resultadoPunto == null)
            {
                return HttpNotFound();
            }
            return View(resultadoPunto);
        }

        // GET: ResultadoPuntoes/Create
        public ActionResult Create()
        {
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo");
            return View();
        }

        // POST: ResultadoPuntoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idResultado,fecha,votosFavor,votosContra,votosNulo,votosAbstencion,resultado,idAgenda,idPunto,idQuorum")] ResultadoPunto resultadoPunto)
        {
            if (ModelState.IsValid)
            {
                db.ResultadoPunto.Add(resultadoPunto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", resultadoPunto.idPunto);
            return View(resultadoPunto);
        }

        // GET: ResultadoPuntoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoPunto resultadoPunto = db.ResultadoPunto.Find(id);
            if (resultadoPunto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", resultadoPunto.idPunto);
            return View(resultadoPunto);
        }

        // POST: ResultadoPuntoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idResultado,fecha,votosFavor,votosContra,votosNulo,votosAbstencion,resultado,idAgenda,idPunto,idQuorum")] ResultadoPunto resultadoPunto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultadoPunto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", resultadoPunto.idPunto);
            return View(resultadoPunto);
        }

        // GET: ResultadoPuntoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoPunto resultadoPunto = db.ResultadoPunto.Find(id);
            if (resultadoPunto == null)
            {
                return HttpNotFound();
            }
            return View(resultadoPunto);
        }

        // POST: ResultadoPuntoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultadoPunto resultadoPunto = db.ResultadoPunto.Find(id);
            db.ResultadoPunto.Remove(resultadoPunto);
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
