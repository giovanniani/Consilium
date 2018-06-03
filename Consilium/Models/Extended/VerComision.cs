using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consilium.Models.Extended
{
    public class VerComision
    {

        public Comision comision { get; set; }

        public List<MiembroXComision> miembros { get; set; }
    }
}