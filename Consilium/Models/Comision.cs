//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
namespace Consilium.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comision
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comision()
        {
            this.ComisionXSesion = new HashSet<ComisionXSesion>();
        }

        [Display(Name = "ID Comisión")]
        public int idComision { get; set; }

        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre requerido")]
        public string nombre { get; set; }

        [Display(Name = "Objetivo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Objetivo requerido")]
        public string objetivo { get; set; }


        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha requerido")]
        public Nullable<System.DateTime> fechaFin { get; set; }

        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha requerido")]

        public Nullable<System.DateTime> fechaIni { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComisionXSesion> ComisionXSesion { get; set; }
    }
}
