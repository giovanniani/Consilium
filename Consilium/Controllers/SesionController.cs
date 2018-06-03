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
        public ActionResult Edit(string id)
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
        public ActionResult Delete(string id)
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
        public ActionResult DeleteConfirmed(string id)
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

        public ActionResult Active(string id)
        {
            int quorum = 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosModelo usuario = new UsuariosModelo();
            Sesion sesion = db.Sesion.Find(id);

            if (sesion == null)
            {
                return HttpNotFound();
            }
            SesionActiva sesionActiva = new SesionActiva();
            sesionActiva.idSesion = sesion.idSesion;

            var u = db.PuntoXSesion.Where(a => a.idSesion == sesion.idSesion);
            sesionActiva.Puntos = u.ToList();
            sesionActiva.quorum = 1;
            using (ConsiliumEntities db = new ConsiliumEntities())
            {
                usuario.Usuarios = db.Usuario.Where(e => e.estado == "1" && (e.tipo == 2 || e.tipo == 3)).ToList();
                usuario.sesion = id;
            }
            var v = db.MiembroXSesion.Where(a => a.idSesion == id).ToList();
            quorum = 0;
            for (int i = 0; i < v.Count; i++)
            {
                for (int j = 0; j < usuario.Usuarios.Count; j++)
                {
                    if (v[i].idUsuario == usuario.Usuarios[j].idUsuario)
                    {
                        usuario.Usuarios[j].isSelected = v[i].presente;                        
                        if(usuario.Usuarios[j].isSelected)
                        {
                            quorum += 1;
                        }
                    }
                }
            }
            sesionActiva.quorum = quorum;
            sesionActiva.usuario = usuario;
            ViewBag.idSesion = id;

            return View(sesionActiva);
        }


        [HttpPost]
        public ActionResult Active(UsuariosModelo usuario)
        {
            MiembroXSesion miembroTemp = new MiembroXSesion();
            List<MiembroXSesion> miembro = new List<MiembroXSesion>();

            for (int i = 0; i < usuario.Usuarios.Count; i++)
            {
                var m = db.getMiembrosXSesion(usuario.Usuarios[i].idUsuario, usuario.sesion).First();

                if (m == "false")
                {
                    miembroTemp.idUsuario = usuario.Usuarios[i].idUsuario;
                    miembroTemp.idSesion = usuario.sesion;
                    miembroTemp.presente = usuario.Usuarios[i].isSelected;
                    db.MiembroXSesion.Add(miembroTemp);
                    db.SaveChanges();
                    miembroTemp = new MiembroXSesion();
                    System.Diagnostics.Debug.WriteLine("miembro " + usuario.Usuarios[i].idUsuario + "agregado");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("miembro " + usuario.Usuarios[i].idUsuario + "ya existia");
                    db.updateMiembroXSesion(usuario.Usuarios[i].idUsuario, usuario.sesion, usuario.Usuarios[i].isSelected);
                    m = null;
                }


            }


            return RedirectToAction("Active", "Sesion", new { id = usuario.sesion });
        }

        public ActionResult Vote(int id, int quorum)
        {
            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo");
            Votacion votacion = new Votacion();
            var p = db.PuntoXSesion.Where(a => a.idPunto == id).FirstOrDefault();
            var q = db.Sesion.Where(c => c.idSesion == p.idSesion).FirstOrDefault();         
            var rs = db.ResultadoPunto.Where(d => d.idPunto == id).FirstOrDefault();
            Punto pt = db.Punto.Find(id);
            votacion.punto = pt;
            if (rs == null)
            {
                ResultadoPunto resul = new ResultadoPunto();
                resul.quorum = quorum;
                resul.idSesion = q.idSesion;
                resul.idPunto = pt.idPunto;
                votacion.resultado = resul;
                return View(votacion);
            }
            else
            {
                rs.quorum = quorum;
                rs.idSesion = q.idSesion;
                votacion.resultado = rs;
                return View(votacion);
            }
            
        }

        // POST: ResultadoPuntoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Vote(Votacion votacion)
        {
            if (ModelState.IsValid)
            {
                var m = db.Punto.Find(votacion.punto.idPunto);
                votacion.resultado.quorum = votacion.resultado.votosContra + votacion.resultado.votosFavor + votacion.resultado.votosNulo + votacion.resultado.votosAbstencion;
                if (m.idEstado == 2)
                {
                    db.updateResultadoPunto(votacion.resultado.idPunto, votacion.resultado.votosFavor,
                        votacion.resultado.votosContra, votacion.resultado.votosAbstencion, votacion.resultado.votosNulo,
                        votacion.resultado.quorum, votacion.resultado.resultado);                
                }
                else
                {
                    db.ResultadoPunto.Add(votacion.resultado);
                    db.SaveChanges();
                    db.votePunto(votacion.resultado.idPunto, 2);
                }
                if(votacion.punto.considerandos == null)
                {
                    votacion.punto.considerandos = "";
                }
                if (votacion.punto.resultandos == null)
                {
                    votacion.punto.resultandos = "";
                }
                if (votacion.punto.acuerdos == null)
                {
                    votacion.punto.acuerdos = "";
                }
                db.updatePunto(votacion.punto.idPunto, votacion.punto.considerandos, votacion.punto.resultandos,
                    votacion.punto.acuerdos);
                return RedirectToAction("Active", new { id = votacion.resultado.idSesion });
            }

            ViewBag.idPunto = new SelectList(db.Punto, "idPunto", "titulo",votacion.resultado.idPunto);
            return View(votacion);
        }


        /*public ActionResult Lista(string id)
        {
            UsuariosModelo usuario = new UsuariosModelo();
            using (ConsiliumEntities db = new ConsiliumEntities())
            {
                usuario.Usuarios = db.Usuario.Where(e => e.estado == "1" && (e.tipo == 2 || e.tipo == 3)).ToList();
                usuario.sesion = id;
            }
            var u = db.MiembroXSesion.Where(a => a.idSesion == id).ToList();
            for(int i = 0; i < u.Count; i++)
            {
                for(int j = 0; j < usuario.Usuarios.Count; j++)
                {
                    if(u[i].idUsuario == usuario.Usuarios[j].idUsuario)
                    {
                        usuario.Usuarios[j].isSelected = u[i].presente;
                    }
                }
            }
            ViewBag.idSesion = id;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Lista(UsuariosModelo usuario)
        {
            MiembroXSesion miembroTemp = new MiembroXSesion();
            List<MiembroXSesion> miembro = new List<MiembroXSesion>();

            for (int i = 0; i < usuario.Usuarios.Count; i++)
            {
                var m = db.getMiembrosXSesion(usuario.Usuarios[i].idUsuario, usuario.sesion);

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
                    db.updateMiembroXSesion(usuario.Usuarios[i].idUsuario, usuario.sesion, usuario.Usuarios[i].isSelected);
                    m = null;
                }


            }


            return View(usuario);
        }
        */
        [HttpGet]
        public ActionResult Puntos(string id)
        {

            SesionPuntos sesionPuntos = new SesionPuntos();
            var puntos = db.Punto.Where(a => a.idEstado == 1).ToList();
            var puntosActuales = db.PuntoXSesion.Where(a => a.idSesion == id);
            sesionPuntos.Puntos = puntos;
            sesionPuntos.idSesion = id;
            sesionPuntos.PuntosActuales = puntosActuales.ToList();
            return View(sesionPuntos);
        }

        public ActionResult agregarPunto(int? idPunto, string idSesion)
        {
            if(idPunto != null)
            {
                Punto punto = db.Punto.Find(idPunto);
                if(punto != null)
                {
                    PuntoXSesion puntoxSesion = db.PuntoXSesion.Where(a => a.idPunto == idPunto).FirstOrDefault();
                    if(puntoxSesion == null)
                    {
                        PuntoXSesion puntoNuevo = new PuntoXSesion();
                        puntoNuevo.idPunto = idPunto.GetValueOrDefault();
                        puntoNuevo.idSesion = idSesion;
                        db.PuntoXSesion.Add(puntoNuevo);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.updatePuntoXSesion(puntoxSesion.idPuntoXSesion, idPunto, idSesion);
                    }
                }

            }
            SesionPuntos sesionPuntos = new SesionPuntos();
            var puntos = db.Punto.Where(a => a.idEstado == 1).ToList();
            var puntosActuales = db.PuntoXSesion.Where(a => a.idSesion == idSesion);
            sesionPuntos.Puntos = puntos;
            sesionPuntos.idSesion = idSesion;
            sesionPuntos.PuntosActuales = puntosActuales.ToList();
            return RedirectToAction("Puntos","Sesion", new { id = idSesion});
        }


        public ActionResult createComision(string id, int punto, int quorum)
        {
            ComisionSesion comisionActiva = new ComisionSesion();
            UsuariosModelo usuario = new UsuariosModelo();
            Comision comision = new Comision();
            using (ConsiliumEntities db = new ConsiliumEntities())
            {
                usuario.Usuarios = db.Usuario.Where(e => e.estado == "1" && (e.tipo == 2 || e.tipo == 3)).ToList();
                usuario.sesion = id;
            }
            comision.idSesion = id;
            comision.idPunto = punto;
            comision.objetivo = "nada";
            comisionActiva.comision = comision;
            comisionActiva.usuarios = usuario;

            return View(comisionActiva);
        }

        [HttpPost]
        public ActionResult createComision(ComisionSesion comisionSesion)
        {
            ComisionSesion comisionActiva = new ComisionSesion();
            UsuariosModelo usuario = new UsuariosModelo();
            MiembroXComision miembroTemp = new MiembroXComision();
            Comision comision = new Comision();
            comision = comisionSesion.comision;
            db.Comision.Add(comision);
            db.SaveChanges();
            var nuevaComision = db.Comision.Where(a => a.idPunto == comision.idPunto && a.idSesion == comision.idSesion).FirstOrDefault();
            miembroTemp.idComision = nuevaComision.idComision;
            for (int i = 0; i < comisionSesion.usuarios.Usuarios.Count; i++)
            {
                if(comisionSesion.usuarios.Usuarios[i].isSelected)
                {
                    miembroTemp.idUsuario = comisionSesion.usuarios.Usuarios[i].idUsuario;
                    db.MiembroXComision.Add(miembroTemp);
                    db.SaveChanges();
                }
                
            }
            return RedirectToAction("Vote", "Sesion", new { id = comision.idPunto, quorum = comisionSesion.quorum });
        }
    }   
}