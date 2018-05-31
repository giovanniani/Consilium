using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consilium.Models.Extended
{
    public class SesionPuntos
    {
        public string idSesion;
        public List<Punto> Puntos { get; set; }

        public List<PuntoXSesion> PuntosActuales { get; set; }
    }
}