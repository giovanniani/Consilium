using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models.Extended
{
    public class Justificacion
    {
        [Display(Name = "Fecha de la ausencia")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita la fecha")]
        public string Date { get; set; }
        
        public string idMember { get; set; }

        [Display(Name = "Asunto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita el asunto")]
        public string About { get; set; }

        [Display(Name = "Justificacion")]
        public string Body { get; set; }
    }
}