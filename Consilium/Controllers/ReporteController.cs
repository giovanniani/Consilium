using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consilium.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Consilium.Controllers
{
    public class ReporteController : Controller
    {
        private ConsiliumEntities db = new ConsiliumEntities();
        //DbContext  

        // GET: Customer  
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ExportCustomers()
        {
            ReportDocument rd = new ReportDocument();

            var rs = db.getReporteXSesion(1).ToList();

            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "SesionReporte.rpt"));

            rd.SetDataSource(rs);
            rd.SetParameterValue("idSesion", 1);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
        
            return File(stream, "application/pdf", "Acta.pdf");           
        }

        [HttpGet]
        public ActionResult ExportList()
        {
            return View();
        }
        public ActionResult ExportarLista()
        {
            ReportDocument rd = new ReportDocument();

            var rs = db.getAsistencia(1).ToList();

            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportLista.rpt"));

            rd.SetDataSource(rs);
            rd.SetParameterValue("idSesion", 1);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "ListaSesion.pdf");
        }

        [HttpGet]
        public ActionResult ExportPoints()
        {
            return View();
        }
        public ActionResult ExportarPuntos()
        {
            ReportDocument rd = new ReportDocument();

            var rs = db.usuarioYPuntos("11").ToList();

            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportPoints.rpt"));

            rd.SetDataSource(rs);
            rd.SetParameterValue("idUsuario", "11");
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "ListaPuntos.pdf");
        }

    }
}