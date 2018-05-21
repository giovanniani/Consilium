using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;

/*
namespace Consilium.Controllers
{
    public class MotionController : Controller
    {
        // GET: Justification
        public ActionResult MotionRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MotionRequest(Motion motion)
        {

            bool Status = false;
            string message = "";

            //Model validation
            if (ModelState.IsValid)
            {

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    dc.Motion.Add(motion);
                    dc.SaveChanges();

                    Status = true;

                    message = "moción enviada!";

                }


                #endregion

            }
            else
            {
                message = "Solicitud inválida";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(motion);
        }
    }
}*/