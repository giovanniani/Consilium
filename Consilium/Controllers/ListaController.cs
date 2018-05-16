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
                usuario.Usuarios = db.Usuario.Where(e => e.estado == "1" && (e.tipo == 2 || e.tipo == 3)).ToList();
            }

            return View(usuario);
        }
        [HttpPost]
        public ActionResult Index(UsuariosModelo usuario)
        {
            var usuariosSeleccionados = usuario.Usuarios.Where(x => x.isSelected == true).ToList<Usuario>();
            return Content(String.Join("-", usuariosSeleccionados.Select(x => x.nombre)));
        }
    }
}