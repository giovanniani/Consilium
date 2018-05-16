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
        [Display(Name = "ID Punto")]
        public int idPunto { get; set; }
        [Display(Name = "ID Estado")]
        public Nullable<int> idEstado { get; set; }
        [Display(Name = "Fecha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha requerida")]
        public Nullable<System.DateTime> fecha { get; set; }


        [Display(Name = "Título")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Título requerido")]
        public string titulo { get; set; }

        [Display(Name = "ID Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID Usuario requerido")]

        public string idUsuario { get; set; }
        [Display(Name = "Considerandos")]
        public string considerandos { get; set; }
        [Display(Name = "Resultandos")]
        public string resultandos { get; set; }
        [Display(Name = "Acuerdos")]
        public string acuerdos { get; set; }
        [Display(Name = "Adjuntos")]
        public string adjunto { get; set; }

        [Display(Name = "Estado Punto")]
        public virtual EstadoPunto EstadoPunto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Moción")]
        public virtual ICollection<Mocion> Mocion { get; set; }
        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Punto por agenda")]
        public virtual ICollection<PuntoXAgenda> PuntoXAgenda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Resultado Punto")]
        public virtual ICollection<ResultadoPunto> ResultadoPunto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Solicitud")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
