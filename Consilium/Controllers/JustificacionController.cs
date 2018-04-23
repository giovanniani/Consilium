using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;


namespace Consilium.Controllers
{
    public class JustificacionController : Controller
    {
        // GET: Justification
        public ActionResult JustificacionRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JustificacionRequest(Justificacion justificacion)
        {

            bool Status = false;
            string message = "";

            //Model validation
            if (ModelState.IsValid)
            {

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    justificacion.estado = "Pendiente";
                    dc.Justificacion.Add(justificacion);
                    dc.SaveChanges();

                    Status = true;

                    message = "Justificación enviada";

                }


                #endregion

            }
            else
            {
                message = "Justificación inválida";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(justificacion);
        }
    }
}