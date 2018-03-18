using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;

namespace Consilium.Controllers
{
    public class UserController : Controller
    {
        //Registration action

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //registration post action

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {

            bool Status = false;
            string message = "";

            //Model validation
            if(ModelState.IsValid)
            {

                #region //Email already exists
                var exists = EmailExists(user.EmailID);
                if(exists)
                {
                    ModelState.AddModelError("EmailExists", "Email already exists");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion

                user.IsEmailVerified = false;

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    dc.User.Add(user);
                    dc.SaveChanges();


                    //Send email to user
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registration completed! Activation link sent ";

                    Status = true;

                }


                #endregion

            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            

            //Generate activation code

            //Password hashing 

            //Sava data to database

            //Send Email to user
            return View(user);
        }

        //login

        //verify email

        //verify email link

        //login

        //login post

        //logout

        [NonAction]
        public bool EmailExists(string emailID)
        {
            using (ConsiliumEntities dc = new ConsiliumEntities())
            {
                var v = dc.User.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("giovannivh92@gmail.com", "Que chiva esto");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "tomela.3392";
            string subject = "Your account is the most awesome one!";

            string body = "<h1>Just passing by ignore this awesome email!!!</h1>"+
                "<br/><br/>We are very awesome!!!! click the next link to verify account" +
                "<br/><br/><a href='" + link + "'+>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);

        }
    }

    
}