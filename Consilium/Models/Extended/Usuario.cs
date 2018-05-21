using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models.Extended
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Usuario
    {
    }
    public class UsuarioMetada
    {
        [Display(Name = "Identificación")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Identificación requerida")]
        public string IdUsuario { get; set; }

        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre requerido")]
        public string nombre { get; set; }

        [Display(Name = "Primer apellido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Primer apellido requerido")]
        public string apellidoP { get; set; }

        [Display(Name = "Segundo apellido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Segundo apellido requerido")]
        public string apellidoM { get; set; }

        [Display(Name = "Tipo de usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo de usuario requerido")]
        public int tipo { get; set; }

        public string estado { get; set; }

        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Correo requerido")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
    }
}