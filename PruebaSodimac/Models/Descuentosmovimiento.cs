using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Descuentosmovimiento
    {
        public decimal Rowiddescmovtos { get; set; }
        public decimal? Rowidmovtosfact { get; set; }
        public decimal? Rowiddescuento { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? Valor { get; set; }

        public virtual Descuentosrepuesto RowiddescuentoNavigation { get; set; }
        public virtual Movimientofactura RowidmovtosfactNavigation { get; set; }
    }
}
