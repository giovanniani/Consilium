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
    public class MiembroXComisionController : Controller
    {/*
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: MiembroXComision
        public ActionResult Index()
        {
            var miembroXComision = db.MiembroXComision.Include(m => m.ComisionXSesion).Include(m => m.Usuario);
            return View(miembroXComision.ToList());
        }

        // GET: MiembroXComision/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroXComision miembroXComision = db.MiembroXComision.Find(id);
            if (miembroXComision == null)
            {
                return HttpNotFound();
            }
            return View(miembroXComision);
        }

        // GET: MiembroXComision/Create
        public ActionResult Create()
        {
            ViewBag.idComisionXSesion = new SelectList(db.ComisionXSesion, "idComisionXSesion", "idComisionXSesion");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: MiembroXComision/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMiembroXComision,idUsuario,idComisionXSesion,tipoMiembro")] MiembroXComision miembroXComision)
        {
            if (ModelState.IsValid)
            {
                db.MiembroXComision.Add(miembroXComision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idComisionXSesion = new SelectList(db.ComisionXSesion, "idComisionXSesion", "idComisionXSesion", miembroXComision.idComisionXSesion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", miembroXComision.idUsuario);
            return View(miembroXComision);
        }

        // GET: MiembroXComision/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroXComision miembroXComision = db.MiembroXComision.Find(id);
            if (miembroXComision == null)
            {
                return HttpNotFound();
            }
            ViewBag.idComisionXSesion = new SelectList(db.ComisionXSesion, "idComisionXSesion", "idComisionXSesion", miembroXComision.idComisionXSesion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", miembroXComision.idUsuario);
            return View(miembroXComision);
        }

        // POST: MiembroXComision/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMiembroXComision,idUsuario,idComisionXSesion,tipoMiembro")] MiembroXComision miembroXComision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembroXComision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idComisionXSesion = new SelectList(db.ComisionXSesion, "idComisionXSesion", "idComisionXSesion", miembroXComision.idComisionXSesion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", miembroXComision.idUsuario);
            return View(miembroXComision);
        }

        // GET: MiembroXComision/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiembroXComision miembroXComision = db.MiembroXComision.Find(id);
            if (miembroXComision == null)
            {
                return HttpNotFound();
            }
            return View(miembroXComision);
        }

        // POST: MiembroXComision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiembroXComision miembroXComision = db.MiembroXComision.Find(id);
            db.MiembroXComision.Remove(miembroXComision);
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
        }*/
    }
}
