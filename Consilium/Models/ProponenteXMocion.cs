
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
    
public partial class ProponenteXMocion
{

    public int idProponente { get; set; }

    public int idMocion { get; set; }

    public string idUsuario { get; set; }



    public virtual Mocion Mocion { get; set; }

    public virtual Usuario Usuario { get; set; }

}

}