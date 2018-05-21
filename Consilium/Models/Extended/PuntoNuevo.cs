using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models
{
    public partial class PuntoNuevo
    {
        public int idPunto;

        [Display(Name = "Fecha de la sesión")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita la fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Nombre de la solicitud")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita el nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Identificación del solicitante")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita la identificación del miembro")]
        public string idMiembro { get; set; }

        [Display(Name = "Considerandos")]
        public string Considerandos { get; set; }

        [Display(Name = "Resultandos")]
        public string Resultandos { get; set; }

        [Display(Name = "Acuerdos")]
        public string Acuerdos { get; set; }
    }
}
