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
    
    public partial class PuntoXAgenda
    {
        public int idPuntoXAgenda { get; set; }
        public Nullable<int> idAgenda { get; set; }
        public Nullable<int> idPunto { get; set; }
    
        public virtual Agenda Agenda { get; set; }
        public virtual Punto Punto { get; set; }
    }
}