using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Movimientofactura
    {
        public Movimientofactura()
        {
            Descuentosmovimientos = new HashSet<Descuentosmovimiento>();
        }

        public decimal Rowidmovimientofactura { get; set; }
        public decimal? Rowidfactura { get; set; }
        public string Coditem { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Totaldescuento { get; set; }
        public decimal? Totalimpuesto { get; set; }
        public decimal? Valorbruto { get; set; }
        public string Valortotal { get; set; }

        public virtual Item CoditemNavigation { get; set; }
        public virtual Factura RowidfacturaNavigation { get; set; }
        public virtual ICollection<Descuentosmovimiento> Descuentosmovimientos { get; set; }
    }
}
