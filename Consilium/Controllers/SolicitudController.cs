using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using Consilium.Models.Extended;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Consilium.Controllers
{
    public class SolicitudController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();
        // GET: Request
        [HttpGet]
        public ActionResult SolicitudRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SolicitudRequest(SolicitudNueva solicitudNueva)
        {
            string[] data = System.Web.HttpContext.Current.User.Identity.Name.Split('&');
            solicitudNueva.idMiembro = data[1];
            bool Status = false;
            string message = "";
            Punto punto = new Punto
            {
                idUsuario = solicitudNueva.idMiembro,
                titulo = solicitudNueva.Nombre,
                fecha = solicitudNueva.Fecha,
                considerandos = solicitudNueva.Considerandos,
                resultandos = solicitudNueva.Resultandos,
                acuerdos = solicitudNueva.Acuerdos,
                adjunto = " "
            };
            Solicitud solicitud = new Solicitud();


            //Model validation
            if (ModelState.IsValid)
            {

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    var e = dc.EstadoPunto.Where(a => a.idEstado == 1).FirstOrDefault();
                    punto.EstadoPunto = e;
                    dc.Punto.Add(punto);                    
                    dc.SaveChanges();

                }
                
                
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    var p = dc.Punto.Where(a => a.titulo == solicitudNueva.Nombre && a.fecha == solicitudNueva.Fecha).FirstOrDefault();
                    solicitud.idPunto = p.idPunto;
                    solicitud.considerandos = solicitudNueva.Considerandos;
                    solicitud.acuerdos = solicitudNueva.Acuerdos;
                    solicitud.resultandos = solicitudNueva.Resultandos;

                    dc.Solicitud.Add(solicitud);
                    dc.SaveChanges();

                    Status = true;

                    message = "Solicitud enviada!";

                }


                #endregion

            }
            else
            {
                message = "Solicitud inválida";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(solicitudNueva);
        }

        public ActionResult CreatePuntoMiembro()
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
        public ActionResult CreatePuntoMiembro([Bind(Include = "idPunto,fecha,titulo,idUsuario,considerandos,resultandos,acuerdos,adjunto")] Punto punto, string myFile)
        {
            punto.idEstado = 1;
            if (myFile != "")
            {
                punto.adjunto = myFile;
            }
            else
            {
                punto.adjunto = " ";
            }
            var usuario = System.Web.HttpContext.Current.User.Identity.Name.Split('&');
            punto.idUsuario = usuario[1];
            if (ModelState.IsValid)
            {
                punto.idEstado = 1;
                db.Punto.Add(punto);
                db.SaveChanges();
                ViewBag.Status = true;
                return RedirectToAction("CreatePuntoMiembro");
            }

            ViewBag.idEstado = new SelectList(db.EstadoPunto, "idEstado", "nombre", punto.idEstado);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", punto.idUsuario);
            return View(punto);
        }
    }
}