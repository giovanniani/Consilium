using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models
{
    [MetadataType(typeof(RequestMetadata))]
    public partial class Request
    {
    }

    public class RequestMetadata
    {
        [Display(Name = "Fecha de la sesión")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita la fecha")]
        public string Date { get; set; }

        [Display(Name = "Nombre de la solicitud")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita el nombre")]
        public string Name { get; set; }

        [Display(Name = "Nombre del solicitante")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita el nombre del meimbro")]
        public string MemberName { get; set; }

        [Display(Name = "Identificación del solicitante")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita la identificación del miembro")]
        public string MemberId { get; set; }

        [Display(Name = "Considerandos")]
        public string Considerations { get; set; }

        [Display(Name = "Resultandos")]
        public string Results { get; set; }

        [Display(Name = "Acuerdos")]
        public string Agreements { get; set; }
    }
}