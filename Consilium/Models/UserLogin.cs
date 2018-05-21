using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models
{
    public class UserLogin
    {
        [Display(Name = "ID Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Identificación requerida")]
        public string idUsuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña requerida")]
        [DataType(DataType.Password)]
        public string contrasenna { get; set; }

        [Display(Name = "Recordar usuario")]
        public bool RememberMe { get; set; }
    }
}