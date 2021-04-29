using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Movimientofacturas = new HashSet<Movimientofactura>();
        }

        public decimal RowidFactura { get; set; }
        public string Tipodocumento { get; set; }
        public decimal? Consecutivo { get; set; }
        public string Documentocliente { get; set; }
        public string Documentomecanico { get; set; }

        public virtual Tercero DocumentoclienteNavigation { get; set; }
        public virtual Tercero DocumentomecanicoNavigation { get; set; }
        public virtual ICollection<Movimientofactura> Movimientofacturas { get; set; }
    }
}
