
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Consilium.Models
{

using System;
    using System.Collections.Generic;
    
public partial class ComisionXSesion
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ComisionXSesion()
    {

        this.MiembroXComision = new HashSet<MiembroXComision>();

    }


    public int idComisionXSesion { get; set; }

    public Nullable<int> idComision { get; set; }

    public Nullable<int> idSesion { get; set; }



    public virtual Comision Comision { get; set; }

    public virtual Sesion Sesion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<MiembroXComision> MiembroXComision { get; set; }

}

}
