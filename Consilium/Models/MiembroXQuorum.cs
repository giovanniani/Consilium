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
    using System.ComponentModel.DataAnnotations;
    public partial class MiembroXQuorum
    {
        [Display(Name = "ID Miembro por quórum")]
        public int idMiembroXQuorum { get; set; }
        [Display(Name = "ID Usuario")]
        public string idUsuario { get; set; }
        [Display(Name = "ID Quórum")]
        public Nullable<int> idQuorum { get; set; }

        [Display(Name = "Quórum")]
        public virtual Quorum Quorum { get; set; }
        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
    }
}
