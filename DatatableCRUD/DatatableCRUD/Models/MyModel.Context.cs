﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatatableCRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConsiliumEntities1 : DbContext
    {
        public ConsiliumEntities1()
            : base("name=ConsiliumEntities1")
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
        public virtual DbSet<MiembroXQuorum> MiembroXQuorum { get; set; }
        public virtual DbSet<Mocion> Mocion { get; set; }
        public virtual DbSet<ProponenteXMocion> ProponenteXMocion { get; set; }
        public virtual DbSet<Punto> Punto { get; set; }
        public virtual DbSet<PuntoXAgenda> PuntoXAgenda { get; set; }
        public virtual DbSet<Quorum> Quorum { get; set; }
        public virtual DbSet<ResultadoPunto> ResultadoPunto { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<TipoSesion> TipoSesion { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
