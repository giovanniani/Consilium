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
    
    public partial class Sesion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sesion()
        {
            this.ComisionXSesion = new HashSet<ComisionXSesion>();
        }
    
        public int idSesion { get; set; }
        public Nullable<int> idTipo { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> idAgenda { get; set; }
        public string documento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComisionXSesion> ComisionXSesion { get; set; }
        public virtual TipoSesion TipoSesion { get; set; }
        public virtual Agenda Agenda { get; set; }
    }
}
