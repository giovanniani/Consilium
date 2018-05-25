using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models.Extended
{
    public partial class SolicitudNueva
    {
        public int idSolicitud { get; set; }

        [Display(Name = "Fecha de la sesión")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita la fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Nombre de la solicitud")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita el nombre")]
        public string Nombre { get; set; }

        public string idMiembro { get; set; }

        [Display(Name = "Considerandos")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesitan los considerandos")]
        public string Considerandos { get; set; }

        [Display(Name = "Resultandos")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesitan los resultandos")]
        public string Resultandos { get; set; }

        [Display(Name = "Acuerdos")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesitan los acuerdos")]
        public string Acuerdos { get; set; }
    }
}