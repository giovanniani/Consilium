using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Consilium.Models
{
    public class UserLogin
    {
        [Display(Name = "Identificación del usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Identificación requerida")]
        public string idUsuario { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña requerida")]
        [DataType(DataType.Password)]
        public string contrasenna { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}