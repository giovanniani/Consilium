using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;


namespace Consilium.Controllers
{
    public class JustificationController : Controller
    {
        // GET: Justification
        public ActionResult JustificationRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JustificationRequest(Justification justification)
        {

            bool Status = false;
            string message = "";

            //Model validation
            if (ModelState.IsValid)
            {

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    dc.Justification.Add(justification);
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

            return View(justification);
        }
    }
}