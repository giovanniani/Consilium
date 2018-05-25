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


    public virtual DbSet<Agenda> Agenda { get; set; }

    public virtual DbSet<Comision> Comision { get; set; }

    public virtual DbSet<ComisionXSesion> ComisionXSesion { get; set; }

    public virtual DbSet<EstadoPunto> EstadoPunto { get; set; }

    public virtual DbSet<Justificacion> Justificacion { get; set; }

    public virtual DbSet<Logueo> Logueo { get; set; }

    public virtual DbSet<MiembroXComision> MiembroXComision { get; set; }

    public virtual DbSet<MiembroXSesion> MiembroXSesion { get; set; }

    public virtual DbSet<Mocion> Mocion { get; set; }

    public virtual DbSet<ProponenteXMocion> ProponenteXMocion { get; set; }

    public virtual DbSet<Punto> Punto { get; set; }

    public virtual DbSet<PuntoXAgenda> PuntoXAgenda { get; set; }

    public virtual DbSet<ResultadoPunto> ResultadoPunto { get; set; }

    public virtual DbSet<Sesion> Sesion { get; set; }

    public virtual DbSet<Solicitud> Solicitud { get; set; }

    public virtual DbSet<TipoSesion> TipoSesion { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Motion> Motion { get; set; }


    public virtual ObjectResult<Nullable<int>> getMiembrosXSesion(string idMiembro, Nullable<int> idSesion)
    {

        var idMiembroParameter = idMiembro != null ?
            new ObjectParameter("idMiembro", idMiembro) :
            new ObjectParameter("idMiembro", typeof(string));


        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getMiembrosXSesion", idMiembroParameter, idSesionParameter);
    }


    public virtual int updateMiembroXSesion(string idMiembro, Nullable<int> idSesion, Nullable<bool> isSelected)
    {

        var idMiembroParameter = idMiembro != null ?
            new ObjectParameter("idMiembro", idMiembro) :
            new ObjectParameter("idMiembro", typeof(string));


        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        var isSelectedParameter = isSelected.HasValue ?
            new ObjectParameter("isSelected", isSelected) :
            new ObjectParameter("isSelected", typeof(bool));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateMiembroXSesion", idMiembroParameter, idSesionParameter, isSelectedParameter);
    }


    public virtual ObjectResult<getPuntosSesion_Result> getPuntosSesion(Nullable<int> idSesion)
    {

        var idSesionParameter = idSesion.HasValue ?
            new ObjectParameter("idSesion", idSesion) :
            new ObjectParameter("idSesion", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPuntosSesion_Result>("getPuntosSesion", idSesionParameter);
    }


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

}

}

