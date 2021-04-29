using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Existenciarepuesto
    {
        public string Codrepuesto { get; set; }
        public decimal? Cantidadexistencia { get; set; }

        public virtual Item CodrepuestoNavigation { get; set; }
    }
}
