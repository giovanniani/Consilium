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
    public class UsuariosController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Logueo).Include(u => u.TipoUsuario);
            return View(usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Logueo, "idUsuario", "nombreUsuario");
            ViewBag.tipo = new SelectList(db.TipoUsuario, "idTipo", "nombre");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,nombre,apellidoP,apellidoM,tipo,estado,correo,telefono,fechaInicio,fechaFin")] Usuario usuario, string contrasenna)
        {
            usuario.estado = "1";
            if (ModelState.IsValid)
            {
                var exists = existeId(usuario.idUsuario);
                if (exists)
                {
                    ModelState.AddModelError("UserExists", "Usuario ya existe");
                    return View(usuario);
                }
                db.Usuario.Add(usuario);
                db.SaveChanges();
                Logueo logueo = new Logueo();
                logueo.contrasenna = contrasenna;
                logueo.idUsuario = usuario.idUsuario;
                logueo.nombreUsuario = usuario.nombre;
                logueo.contrasenna = Crypto.Hash(logueo.contrasenna);
                db.Logueo.Add(logueo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Logueo, "idUsuario", "nombreUsuario", usuario.idUsuario);
            ViewBag.tipo = new SelectList(db.TipoUsuario, "idTipo", "nombre", usuario.tipo);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Logueo, "idUsuario", "nombreUsuario", usuario.idUsuario);
            ViewBag.tipo = new SelectList(db.TipoUsuario, "idTipo", "nombre", usuario.tipo);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,nombre,apellidoP,apellidoM,tipo,estado,correo,telefono,fechaInicio,fechaFin")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Logueo, "idUsuario", "nombreUsuario", usuario.idUsuario);
            ViewBag.tipo = new SelectList(db.TipoUsuario, "idTipo", "nombre", usuario.tipo);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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

        // GET: Usuario
        public ActionResult Registro()
        {
            return View();
        }

        //registration post action

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Exclude = "ExisteId")] Usuario usuario, string contrasenna)
        {

            bool Status = false;
            string message = "";
            Logueo logueo = new Logueo();

            //Model validation
            if (ModelState.IsValid)
            {

                #region //Email already exists
                var exists = existeId(usuario.idUsuario);
                if (exists)
                {
                    ModelState.AddModelError("UserExists", "Usuario ya existe");
                    return View(usuario);
                }
                #endregion

                #region Save to Data  
                logueo.contrasenna = contrasenna;
                logueo.idUsuario = usuario.idUsuario;
                logueo.nombreUsuario = usuario.nombre;


                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    dc.Usuario.Add(usuario);
                    dc.SaveChanges();


                    Status = true;

                }
                #region Password hashing
                logueo.contrasenna = Crypto.Hash(logueo.contrasenna);
                #endregion
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    dc.Logueo.Add(logueo);
                    dc.SaveChanges();


                    Status = true;

                }


                #endregion

            }
            else
            {
                message = "Solicitud inválida";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;


            return View(usuario);
        }

        public bool existeId(string usuarioId)
        {
            using (ConsiliumEntities dc = new ConsiliumEntities())
            {
                var v = dc.Usuario.Where(a => a.idUsuario == usuarioId).FirstOrDefault();
                return v != null;
            }
        }
    }
}
