using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Descuentosrepuesto
    {
        public Descuentosrepuesto()
        {
            Descuentosmovimientos = new HashSet<Descuentosmovimiento>();
        }

        public decimal Rowiddescuentos { get; set; }
        public string Codrepuesto { get; set; }
        public DateTime? Fechavigencia { get; set; }
        public decimal? Valordescuento { get; set; }
        public decimal? Porcentajedescuentos { get; set; }

        public virtual Item CodrepuestoNavigation { get; set; }
        public virtual ICollection<Descuentosmovimiento> Descuentosmovimientos { get; set; }
    }
}
