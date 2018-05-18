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
    public class SesionController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();
        public int? sesionId;

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

        public ActionResult Active(int? id)
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
            SesionActiva sesionActiva = new SesionActiva();
            sesionActiva.idSesion = sesion.idSesion;

            var u = db.PuntoXAgenda.Where(a => a.idAgenda == sesion.idAgenda);
            sesionActiva.Puntos = u.ToList();
            sesionActiva.quorum = 0;

            return View(sesionActiva);
        }

        public ActionResult Vote(int? id)
        {
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo");
            return View();
        }

        // POST: ResultadoPuntoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Vote([Bind(Include = "idResultado,fecha,votosFavor,votosContra,votosNulo,votosAbstencion,resultado,idAgenda,idPunto,idQuorum")] ResultadoPunto resultadoPunto)
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


        public ActionResult Lista(int? id)
        {
            UsuariosModelo usuario = new UsuariosModelo();
            using (ConsiliumEntities db = new ConsiliumEntities())
            {
                usuario.Usuarios = db.Usuario.Where(e => e.estado == "1" && (e.tipo == 2 || e.tipo == 3)).ToList();
                usuario.sesion = id;
            }
            ViewBag.idSesion = id;
            sesionId = id.HasValue ? id : 1;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Lista(UsuariosModelo usuario)
        {
            MiembroXSesion miembroTemp = new MiembroXSesion();
            List<MiembroXSesion> miembro = new List<MiembroXSesion>();

            for (int i = 0; i < usuario.Usuarios.Count; i++)
            {
                //var m = db.Logueo.Where(a => a.idUsuario == login.idUsuario).FirstOrDefault();

                /*var m = db.MiembroXSesion.Where(a => a.idUsuario == usuario.Usuarios[i].idUsuario &&
                a.idSesion == 1).FirstOrDefault();**/
                var m = db.getMiembrosXSesion(usuario.Usuarios[i].idUsuario, 1);

                if (m.Count() == 0)
                {
                    miembroTemp.idUsuario = usuario.Usuarios[i].idUsuario;
                    miembroTemp.idSesion = usuario.sesion;
                    miembroTemp.presente = usuario.Usuarios[i].isSelected;
                    db.MiembroXSesion.Add(miembroTemp);
                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("miembro " + usuario.Usuarios[i].idUsuario + "agregado");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("miembro " + usuario.Usuarios[i].idUsuario + "ya existia");
                    db.updateMiembroXSesion(usuario.Usuarios[i].idUsuario, 1, usuario.Usuarios[i].isSelected);
                    m = null;
                }


            }


            return View(usuario);
        }
    }   
}
