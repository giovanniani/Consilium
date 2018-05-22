

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Consilium.Controllers
{
    public class ReporteController2 : Controller
    {
        //DbContext  
        private ConsiliumEntities context = new ConsiliumEntities();
        // GET: Customer  C:\Users\Giova\Documents\GitHub\Consilium\Consilium\Controllers\ReporteController2.cs
        public ActionResult Index()
        {
            var userList = context.TipoUsuario.ToList();
            return View(userList);
        }


        public ActionResult ExportCustomers2()
        {
            List<TipoUsuario> allCustomer = new List<TipoUsuario>();
            allCustomer = context.TipoUsuario.ToList();
            List<Usuario> todosUsuarios = new List<Usuario>();
            todosUsuarios = context.Usuario.ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Reporte2.rpt"));
            rd.SetDataSource(todosUsuarios);
            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            //System.IO.FileStream stream = new FileStream("CustomerList.docx", System.IO.FileMode.Open);
            return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CustomerList.docx");
            //return File(stream, "application/pdf", "CustomerList.pdf");
        }

    }
}