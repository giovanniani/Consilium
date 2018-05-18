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
        private ConsiliumEntities db = new ConsiliumEntities();
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
        /*
        [HttpPost]
        public ActionResult Index(UsuariosModelo usuario)
        {
            var usuariosSeleccionados = usuario.Usuarios.Where(x => x.isSelected == true).ToList<Usuario>();
            return Content(String.Join("-", usuariosSeleccionados.Select(x => x.nombre)));
        }*/

        [HttpPost]
        public ActionResult Index(UsuariosModelo usuario)
        {
            MiembroXSesion miembroTemp = new MiembroXSesion();
            List<MiembroXSesion> miembro = new List<MiembroXSesion>();                     

                for (int i = 0; i < usuario.Usuarios.Count; i++)
                {
                //var m = db.Logueo.Where(a => a.idUsuario == login.idUsuario).FirstOrDefault();

                /*var m = db.MiembroXSesion.Where(a => a.idUsuario == usuario.Usuarios[i].idUsuario &&
                a.idSesion == 1).FirstOrDefault();**/               
                var m = db.getMiembrosXSesion(usuario.Usuarios[i].idUsuario, 1);
                                    
                    if(m.Count() == 0)
                    {
                        miembroTemp.idUsuario = usuario.Usuarios[i].idUsuario;
                        miembroTemp.idSesion = 1;
                        miembroTemp.presente = usuario.Usuarios[i].isSelected;
                        db.MiembroXSesion.Add(miembroTemp);
                        db.SaveChanges();
                        System.Diagnostics.Debug.WriteLine("miembro " + usuario.Usuarios[i].idUsuario + "agregado");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("miembro " + usuario.Usuarios[i].idUsuario + "ya existia");
                        db.updateMiembroXSesion(usuario.Usuarios[i].idUsuario, 1, usuario.Usuarios[i].isSelected);
                        m = null;
                    }
                

                //miembro.Add(new MiembroXSesion(usuario.Usuarios[i].idUsuario, '1', usuario.Usuarios[i].isSelected));
            }
            

            //ViewBag.idUsuario = new SelectList(db.Logueo, "idUsuario", "nombreUsuario", usuario.idUsuario);
            //ViewBag.tipo = new SelectList(db.TipoUsuario, "idTipo", "nombre", usuario.tipo);
            return View(usuario);
        }
    }
}