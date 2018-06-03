﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Consilium.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class ConsiliumEntities : DbContext
{
    public ConsiliumEntities()
        : base("name=ConsiliumEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<EstadoPunto> EstadoPunto { get; set; }

    public virtual DbSet<Justificacion> Justificacion { get; set; }

    public virtual DbSet<Logueo> Logueo { get; set; }

    public virtual DbSet<MiembroXSesion> MiembroXSesion { get; set; }

    public virtual DbSet<Mocion> Mocion { get; set; }

    public virtual DbSet<ProponenteXMocion> ProponenteXMocion { get; set; }

    public virtual DbSet<Punto> Punto { get; set; }

    public virtual DbSet<PuntoXSesion> PuntoXSesion { get; set; }

    public virtual DbSet<ResultadoPunto> ResultadoPunto { get; set; }

    public virtual DbSet<Sesion> Sesion { get; set; }

    public virtual DbSet<Solicitud> Solicitud { get; set; }

    public virtual DbSet<TipoSesion> TipoSesion { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<MiembroXComision> MiembroXComision { get; set; }

    public virtual DbSet<Comision> Comision { get; set; }


    public virtual ObjectResult<getPunto_Result> getPunto(Nullable<int> idPunto)
    {

        var idPuntoParameter = idPunto.HasValue ?
            new ObjectParameter("idPunto", idPunto) :
            new ObjectParameter("idPunto", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPunto_Result>("getPunto", idPuntoParameter);
    }


    public virtual int votePunto(Nullable<int> idPunto, Nullable<int> estadoPunto)
    {

        var idPuntoParameter = idPunto.HasValue ?
            new ObjectParameter("idPunto", idPunto) :
            new ObjectParameter("idPunto", typeof(int));


        var estadoPuntoParameter = estadoPunto.HasValue ?
            new ObjectParameter("estadoPunto", estadoPunto) :
            new ObjectParameter("estadoPunto", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("votePunto", idPuntoParameter, estadoPuntoParameter);
    }


    public virtual int updateResultadoPunto(Nullable<int> idPunto, Nullable<int> votosFavor, Nullable<int> votosContra, Nullable<int> votosAbstencion, Nullable<int> votosNulo, Nullable<int> quorum, string resultado)
    {

        var idPuntoParameter = idPunto.HasValue ?
            new ObjectParameter("idPunto", idPunto) :
            new ObjectParameter("idPunto", typeof(int));


        var votosFavorParameter = votosFavor.HasValue ?
            new ObjectParameter("votosFavor", votosFavor) :
            new ObjectParameter("votosFavor", typeof(int));


        var votosContraParameter = votosContra.HasValue ?
            new ObjectParameter("votosContra", votosContra) :
            new ObjectParameter("votosContra", typeof(int));


        var votosAbstencionParameter = votosAbstencion.HasValue ?
            new ObjectParameter("votosAbstencion", votosAbstencion) :
            new ObjectParameter("votosAbstencion", typeof(int));


        var votosNuloParameter = votosNulo.HasValue ?
            new ObjectParameter("votosNulo", votosNulo) :
            new ObjectParameter("votosNulo", typeof(int));


        var quorumParameter = quorum.HasValue ?
            new ObjectParameter("quorum", quorum) :
            new ObjectParameter("quorum", typeof(int));


        var resultadoParameter = resultado != null ?
            new ObjectParameter("resultado", resultado) :
            new ObjectParameter("resultado", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateResultadoPunto", idPuntoParameter, votosFavorParameter, votosContraParameter, votosAbstencionParameter, votosNuloParameter, quorumParameter, resultadoParameter);
    }


    public virtual ObjectResult<getReporteSesion_Result> getReporteSesion(Nullable<int> idSesion)
    {

        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getReporteSesion_Result>("getReporteSesion", idSesionParameter);
    }


    public virtual ObjectResult<getSesionReporte_Result> getSesionReporte(Nullable<int> idSesion)
    {

        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSesionReporte_Result>("getSesionReporte", idSesionParameter);
    }


    public virtual ObjectResult<getReporteXSesion_Result> getReporteXSesion(Nullable<int> idSesion)
    {

        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getReporteXSesion_Result>("getReporteXSesion", idSesionParameter);
    }


    public virtual ObjectResult<getAsistencia_Result> getAsistencia(Nullable<int> idSesion)
    {

        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAsistencia_Result>("getAsistencia", idSesionParameter);
    }


    public virtual ObjectResult<getPuntosXUsuaio_Result> getPuntosXUsuaio(string idUsuario)
    {

        var idUsuarioParameter = idUsuario != null ?
            new ObjectParameter("idUsuario", idUsuario) :
            new ObjectParameter("idUsuario", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPuntosXUsuaio_Result>("getPuntosXUsuaio", idUsuarioParameter);
    }


    public virtual ObjectResult<getPuntosXUsuario_Result> getPuntosXUsuario(string idUsuario)
    {

        var idUsuarioParameter = idUsuario != null ?
            new ObjectParameter("idUsuario", idUsuario) :
            new ObjectParameter("idUsuario", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPuntosXUsuario_Result>("getPuntosXUsuario", idUsuarioParameter);
    }


    public virtual ObjectResult<getPuntosdeUsuario_Result> getPuntosdeUsuario(string idUsuario)
    {

        var idUsuarioParameter = idUsuario != null ?
            new ObjectParameter("idUsuario", idUsuario) :
            new ObjectParameter("idUsuario", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPuntosdeUsuario_Result>("getPuntosdeUsuario", idUsuarioParameter);
    }


    public virtual ObjectResult<usuarioYPuntos_Result> usuarioYPuntos(string idUsuario)
    {

        var idUsuarioParameter = idUsuario != null ?
            new ObjectParameter("idUsuario", idUsuario) :
            new ObjectParameter("idUsuario", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usuarioYPuntos_Result>("usuarioYPuntos", idUsuarioParameter);
    }


    public virtual ObjectResult<getPuntosSesion_Result1> getPuntosSesion(string idSesion)
    {

        var idSesionParameter = idSesion != null ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPuntosSesion_Result1>("getPuntosSesion", idSesionParameter);
    }


    public virtual int updatePuntoXSesion(Nullable<int> idPuntoXSesion, Nullable<int> idPunto, string idSesion)
    {

        var idPuntoXSesionParameter = idPuntoXSesion.HasValue ?
            new ObjectParameter("idPuntoXSesion", idPuntoXSesion) :
            new ObjectParameter("idPuntoXSesion", typeof(int));


        var idPuntoParameter = idPunto.HasValue ?
            new ObjectParameter("idPunto", idPunto) :
            new ObjectParameter("idPunto", typeof(int));


        var idSesionParameter = idSesion != null ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updatePuntoXSesion", idPuntoXSesionParameter, idPuntoParameter, idSesionParameter);
    }


    public virtual ObjectResult<string> getMiembrosXSesion(string idMiembro, string idSesion)
    {

        var idMiembroParameter = idMiembro != null ?
            new ObjectParameter("idMiembro", idMiembro) :
            new ObjectParameter("idMiembro", typeof(string));


        var idSesionParameter = idSesion != null ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getMiembrosXSesion", idMiembroParameter, idSesionParameter);
    }


    public virtual int updateMiembroXSesion(string idMiembro, string idSesion, Nullable<bool> isSelected)
    {

        var idMiembroParameter = idMiembro != null ?
            new ObjectParameter("idMiembro", idMiembro) :
            new ObjectParameter("idMiembro", typeof(string));


        var idSesionParameter = idSesion != null ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(string));


        var isSelectedParameter = isSelected.HasValue ?
            new ObjectParameter("isSelected", isSelected) :
            new ObjectParameter("isSelected", typeof(bool));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateMiembroXSesion", idMiembroParameter, idSesionParameter, isSelectedParameter);
    }


    public virtual int updatePunto(Nullable<int> idPunto, string considerandos, string resultandos, string acuerdos)
    {

        var idPuntoParameter = idPunto.HasValue ?
            new ObjectParameter("idPunto", idPunto) :
            new ObjectParameter("idPunto", typeof(int));


        var considerandosParameter = considerandos != null ?
            new ObjectParameter("considerandos", considerandos) :
            new ObjectParameter("considerandos", typeof(string));


        var resultandosParameter = resultandos != null ?
            new ObjectParameter("resultandos", resultandos) :
            new ObjectParameter("resultandos", typeof(string));


        var acuerdosParameter = acuerdos != null ?
            new ObjectParameter("acuerdos", acuerdos) :
            new ObjectParameter("acuerdos", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updatePunto", idPuntoParameter, considerandosParameter, resultandosParameter, acuerdosParameter);
    }

}

}

