using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consilium.Models.Extended
{
    public class SesionActiva
    {
        public string idSesion;
        public List<PuntoXSesion> Puntos { get; set; }

        public int quorum;
        
        public UsuariosModelo usuario { get; set; }
    }
}