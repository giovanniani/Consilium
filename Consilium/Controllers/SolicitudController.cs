using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using Consilium.Models.Extended;

namespace Consilium.Controllers
{
    public class SolicitudController : Controller
    {
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

            bool Status = false;
            string message = "";
            Punto punto = new Punto();
            punto.idUsuario = solicitudNueva.idMiembro;
            EstadoPunto estado = new EstadoPunto();
            estado.idEstado = 1;
            estado.nombre = "Pendiente";
            punto.EstadoPunto = estado.idEstado;
            
            punto.titulo = solicitudNueva.Nombre;
            punto.fecha = solicitudNueva.Fecha;
            Solicitud solicitud = new Solicitud();


            //Model validation
            if (ModelState.IsValid)
            {

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
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

            return View(solicitud);
        }
    }
}