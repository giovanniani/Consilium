using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using Consilium.Models.Extended;
namespace Consilium.Controllers
{
    public class ComisionesController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: Comisiones
        public ActionResult Index()
        {
            var comision = db.Comision.Include(c => c.Punto).Include(c => c.Sesion);
            return View(comision.ToList());
        }

        // GET: Comisiones/Details/5
        public ActionResult Details(int id)
        {
            VerComision comisionVista = new VerComision();
            var usuarios = db.MiembroXComision.Where(a => a.idComision == id).ToList();
            var comision = db.Comision.Find(id);
            comisionVista.comision = comision;
            comisionVista.miembros = usuarios;


            return View(comisionVista);
        }

        // GET: Comisiones/Create
        public ActionResult Create()
        {
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo");
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "idSesion");
            return View();
        }

        // POST: Comisiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idComision,nombre,objetivo,fechaFin,fechaIni,idSesion,idPunto")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Comision.Add(comision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", comision.idPunto);
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "idSesion", comision.idSesion);
            return View(comision);
        }

        // GET: Comisiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comision comision = db.Comision.Find(id);
            if (comision == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", comision.idPunto);
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "idSesion", comision.idSesion);
            return View(comision);
        }

        // POST: Comisiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idComision,nombre,objetivo,fechaFin,fechaIni,idSesion,idPunto")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo", comision.idPunto);
            ViewBag.idSesion = new SelectList(db.Sesion, "idSesion", "idSesion", comision.idSesion);
            return View(comision);
        }

        // GET: Comisiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comision comision = db.Comision.Find(id);
            if (comision == null)
            {
                return HttpNotFound();
            }
            return View(comision);
        }

        // POST: Comisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comision comision = db.Comision.Find(id);
            db.Comision.Remove(comision);
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
