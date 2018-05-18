using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consilium.Models.Extended
{
    public class SesionActiva
    {
        public int idSesion;
        public List<PuntoXAgenda> Puntos { get; set; }

        public int quorum;
    }
}