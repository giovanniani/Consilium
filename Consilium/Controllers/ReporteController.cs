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
        private ConsiliumEntities context = new ConsiliumEntities();
        // GET: Customer  
        public ActionResult Index()
        {
            var userList = context.TipoUsuario.ToList();
            return View(userList);
        }


        public ActionResult ExportCustomers()
        {
            List<TipoUsuario> allCustomer = new List<TipoUsuario>();


            List<Usuario> allUsers = new List<Usuario>();


            

            ReportDocument rd = new ReportDocument();

            //Consilium.ReportSource = rd;
            var rs = db.getSesionReporte(1).ToList();

            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "SesionReporte.rpt"));

            rd.SetDataSource(rs);
            rd.SetParameterValue("idSesion", 1);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
        

            //System.IO.FileStream stream = new FileStream("CustomerList.docx", System.IO.FileMode.Open);
            //return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CustomerList.PDF");
            return File(stream, "application/pdf", "PorfavorDiosEnLoAltoAyuda.pdf");
            /*
            DataTable dtbl = new DataTable();
            Consilium.CrystalReports.SesionReporte sesionReporte = new CrystalReports.SesionReporte();
            var reporte = db.getReporteSesion(1).ToList();            
            dtbl.Columns.Add("idSesion");
            dtbl.Columns.Add("fecha");

            for (int i = 0; i < reporte.Count(); i++)
            {                
                dtbl.Rows.Add(reporte[i]);
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "Reporte2.rpt"));

            rd.SetParameterValue("idSesion", 1);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            //System.IO.FileStream stream = new FileStream("CustomerList.docx", System.IO.FileMode.Open);
            //return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CustomerList.docx");
            sesionReporte.Database.Tables["Sesion"].SetDataSource(reporte);
            return File(stream, "application/pdf", "CustomerList.pdf");
            
            */

            return null;
        }
        public ActionResult ExportCustomers2()
        {

            /*MySqlConnection cnn;
            string connectionString = null;
            string sql = null;

            connectionString = "Server = DESKTOP-ER09I80/GIOVANNI; Database = Consilium;";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();

            sql = "SELECT * from TipoUsuario ";
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, cnn);
            DataSet1 ds = new DataSet1();
            dscmd.Fill(ds, "Imagetest");
            cnn.Close();
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load("C:/Subreport.rpt");
            cryRpt.SetDataSource(ds.Tables[1]);

            crystalReportViewer1.ReportSource = "C:/MainReport.rpt";
            crystalReportViewer1.Refresh();


            // List<TipoUsuario> allCustomer = new List<TipoUsuario>();
            //allCustomer = context.TipoUsuario.ToList();
            //         List<Usuario> todosUsuarios = new List<Usuario>();
            //       todosUsuarios = context.Usuario.ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "reporte8.rpt"));
       //     rd.SetDataSource(todosUsuarios);
            
       //  rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            //System.IO.FileStream stream = new FileStream("CustomerList.docx", System.IO.FileMode.Open);
/// return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CustomerList.docx");
            return File(stream, "application/pdf", "CustomerList.pdf");*/
            return null;
        }

    }
}