using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using System.Web.Security;

namespace Consilium.Controllers
{
    public class UsuarioController : Controller
    {
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

        public ActionResult Login()
        {
            return View();
        }
        
        //login post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";

            using (ConsiliumEntities dc = new ConsiliumEntities())
            {
                var v = dc.Logueo.Where(a => a.idUsuario == login.idUsuario).FirstOrDefault();
                var u = dc.Usuario.Where(a => a.idUsuario == login.idUsuario).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.contrasenna), v.contrasenna) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; //525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.idUsuario, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (u.TipoUsuario.idTipo.ToString() == "1")
                        {
                            return RedirectToAction("SolicitudRequest", "Solicitud");
                        }
                        if (u.TipoUsuario.idTipo.ToString() == "2")
                        {
                            return RedirectToAction("Index", "President");
                        }
                        if (u.TipoUsuario.idTipo.ToString() == "3")
                        {
                            return RedirectToAction("Index", "Secretary");
                        }
                        
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