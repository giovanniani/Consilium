using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;

namespace Consilium.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista
        public ActionResult Index()
        {
            UsuariosModelo usuario = new UsuariosModelo();
            using (ConsiliumEntities db = new ConsiliumEntities())
            {
                usuario.Usuarios = db.Usuario.ToList<Usuario>();
            }

            return View(usuario);
        }
    }
}