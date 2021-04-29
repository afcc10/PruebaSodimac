using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Preciosrepuesto
    {
        public decimal Rowidprecios { get; set; }
        public string Codrepuesto { get; set; }
        public DateTime? Fechavigencia { get; set; }
        public decimal? Valor { get; set; }

        public virtual Item CodrepuestoNavigation { get; set; }
    }
}
