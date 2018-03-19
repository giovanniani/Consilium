using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;

namespace Consilium.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        [HttpGet]
        public ActionResult RegistrationRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationRequest(Request request)
        {

            bool Status = false;
            string message = "";

            //Model validation
            if (ModelState.IsValid)
            {

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    //dc.Request.Add(request);
                    dc.Request.Add(request);
                    dc.SaveChanges();

                    Status = true;

                    message = "Request sent!";

                }


                #endregion

            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(request);
        }
    }
}