using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consilium.Models.Extended
{
    public class ComisionSesion
    {
        public Comision comision { get; set; }

        public UsuariosModelo usuarios { get; set; }

        public int quorum { get; set; }
    }
}