using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using System.Web.Security;
/*
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
                    ModelState.AddModelError("EmailExists", "Usuario ya existe");
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

                //user.IsEmailVerified = false;

                #region Save to Data
                using (ConsiliumEntities dc = new ConsiliumEntities())
                {
                    dc.User.Add(user);
                    dc.SaveChanges();


                    //Send email to user
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registro completo! correo de verificación enviado! ";

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
            

            //Generate activation code

            //Password hashing 

            //Sava data to database

            //Send Email to user
            return View(user);
        }


        //verify email
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (ConsiliumEntities dc = new ConsiliumEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; // this line is to avoid confirm password doesnt mastch issue on save changes

                var v = dc.User.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if(v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Solicitud inválida";
                }

            }
            ViewBag.Status = Status;
            return View();
        }

        //verify email link

        //login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //login post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl="")
        {
            string message = "";

            using (ConsiliumEntities dc = new ConsiliumEntities())
            {
                var v = dc.User.Where(a => a.EmailID == login.idUsuario).FirstOrDefault();
                if(v != null)
                {
                    if(string.Compare(Crypto.Hash(login.contrasenna),v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; //525600 min = 1 year
                        //var ticket = new FormsAuthenticationTicket(login.idUsuario, login.RememberMe, timeout);
                        var ticket = new FormsAuthenticationTicket(1, login.idUsuario, DateTime.Now, DateTime.Now, login.RememberMe, "Stefi");
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        /*if(Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            if (v.MemberType == "Student")
                            {
                                return RedirectToAction("SolicitudRequest", "Solicitud");
                            }
                            if (v.MemberType == "President")
                            {
                                return RedirectToAction("Index", "President");
                            }
                            if (v.MemberType == "Secretary")
                            {
                                return RedirectToAction("Index", "Secretary");
                            }
                        //}
                    }
                    else
                    {
                        message = "Credenciales inválidas!";
                    }
                }
                else
                {
                    message = "Credenciales inválidas!";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //logout

       [Authorize] 
       [HttpPost]
       public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

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

    
}*/