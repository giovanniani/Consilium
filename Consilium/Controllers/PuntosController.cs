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
    public class PuntosController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: Puntos
        public ActionResult Index()
        {
            var punto = db.Punto.Include(p => p.EstadoPunto).Include(p => p.Usuario);
            return View(punto.ToList());
        }

        // GET: Puntos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punto punto = db.Punto.Find(id);
            if (punto == null)
            {
                return HttpNotFound();
            }
            return View(punto);
        }

        // GET: Puntos/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.EstadoPunto, "idEstado", "nombre");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Puntos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPunto,idEstado,fecha,titulo,idUsuario,considerandos,resultandos,acuerdos,adjunto")] Punto punto, string myFile)
        {
            if(myFile != "")
            {
                punto.adjunto = myFile;
            }
            else
            {
                punto.adjunto = " ";
            }
            punto.idEstado = 1;
            if (ModelState.IsValid)
            {
                db.Punto.Add(punto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.EstadoPunto, "idEstado", "nombre", punto.idEstado);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", punto.idUsuario);
            return View(punto);
        }

        // GET: Puntos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punto punto = db.Punto.Find(id);
            if (punto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.EstadoPunto, "idEstado", "nombre", punto.idEstado);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", punto.idUsuario);
            return View(punto);
        }

        // POST: Puntos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPunto,idEstado,fecha,titulo,idUsuario,considerandos,resultandos,acuerdos,adjunto")] Punto punto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.EstadoPunto, "idEstado", "nombre", punto.idEstado);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", punto.idUsuario);
            return View(punto);
        }

        // GET: Puntos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punto punto = db.Punto.Find(id);
            if (punto == null)
            {
                return HttpNotFound();
            }
            return View(punto);
        }

        // POST: Puntos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Punto punto = db.Punto.Find(id);
            db.Punto.Remove(punto);
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
