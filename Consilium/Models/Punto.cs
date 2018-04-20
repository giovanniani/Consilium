
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
    using System.Collections.Generic;
    
public partial class Punto
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Punto()
    {

        this.Mocion = new HashSet<Mocion>();

        this.PuntoXAgenda = new HashSet<PuntoXAgenda>();

        this.ResultadoPunto = new HashSet<ResultadoPunto>();

        this.Solicitud = new HashSet<Solicitud>();

    }


    public int idPunto { get; set; }

    public Nullable<int> idEstado { get; set; }

    public Nullable<System.DateTime> fecha { get; set; }

    public string titulo { get; set; }

    public string idUsuario { get; set; }

    public Nullable<int> idTipo { get; set; }



    public virtual EstadoPunto EstadoPunto { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Mocion> Mocion { get; set; }

    public virtual Usuario Usuario { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PuntoXAgenda> PuntoXAgenda { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ResultadoPunto> ResultadoPunto { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Solicitud> Solicitud { get; set; }

}

}