
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
    
public partial class ResultadoPunto
{

    public int idResultado { get; set; }

    public System.DateTime fecha { get; set; }

    public int votosFavor { get; set; }

    public int votosContra { get; set; }

    public int votosNulo { get; set; }

    public int votosAbstencion { get; set; }

    public string resultado { get; set; }

    public string idSesion { get; set; }

    public int idPunto { get; set; }

    public int quorum { get; set; }

    public string anotaciones { get; set; }



    public virtual Punto Punto { get; set; }

    public virtual Sesion Sesion { get; set; }

}

}
