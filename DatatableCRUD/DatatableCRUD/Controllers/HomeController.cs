using DatatableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatatableCRUD.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            using (ConsiliumEntities1 dc = new ConsiliumEntities1())
            {
                var employees = dc.Usuario.OrderBy(a => a.nombre).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public ActionResult Save(string id)
        {
            using (ConsiliumEntities1 dc = new ConsiliumEntities1())
            {
                var v = dc.Usuario.Where(a => a.idUsuario == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Usuario emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ConsiliumEntities1 dc = new ConsiliumEntities1())
                {
                    if (emp.idUsuario != "")
                    {
                        //Edit 
                        var v = dc.Usuario.Where(a => a.idUsuario == emp.idUsuario).FirstOrDefault();
                        if (v != null)
                        {
                            v.nombre = emp.nombre;
                            v.apellidoM = emp.apellidoM;
                            v.correo = emp.correo;
                        }
                    }
                    else
                    {
                        //Save
                        dc.Usuario.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status} };
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (ConsiliumEntities1 dc = new ConsiliumEntities1())
            {
                var v = dc.Usuario.Where(a => a.idUsuario == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(string id)
        {
            bool status = false;
            using (ConsiliumEntities1 dc = new ConsiliumEntities1())
            {
                var v = dc.Usuario.Where(a => a.idUsuario == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Usuario.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status} };
        }
    }
}