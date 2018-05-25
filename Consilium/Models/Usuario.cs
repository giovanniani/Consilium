
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

    public partial class Usuario
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {

            this.Justificacion = new HashSet<Justificacion>();

            this.MiembroXComision = new HashSet<MiembroXComision>();

            this.MiembroXSesion = new HashSet<MiembroXSesion>();

            this.ProponenteXMocion = new HashSet<ProponenteXMocion>();

            this.Punto = new HashSet<Punto>();

        }


        public string idUsuario { get; set; }

        public string nombre { get; set; }

        public string apellidoP { get; set; }

        public string apellidoM { get; set; }

        public int tipo { get; set; }

        public string estado { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public System.DateTime fechaInicio { get; set; }

        public System.DateTime fechaFin { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Justificacion> Justificacion { get; set; }

        public virtual Logueo Logueo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<MiembroXComision> MiembroXComision { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<MiembroXSesion> MiembroXSesion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<ProponenteXMocion> ProponenteXMocion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Punto> Punto { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        public bool isSelected { get; set; }

    }
    public class UsuariosModelo
    {
        public List<Usuario> Usuarios { get; set; }

        public int sesion { get; set; }
    }

}