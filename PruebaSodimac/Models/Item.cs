using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Item
    {
        public Item()
        {
            Descuentosrepuestos = new HashSet<Descuentosrepuesto>();
            Movimientofacturas = new HashSet<Movimientofactura>();
            Preciosrepuestos = new HashSet<Preciosrepuesto>();
        }

        public string IdRepuesto { get; set; }
        public string Descripcion { get; set; }
        public string Tipoitem { get; set; }
        public decimal? Tiposervicio { get; set; }

        public virtual Tiposervicio TiposervicioNavigation { get; set; }
        public virtual ICollection<Descuentosrepuesto> Descuentosrepuestos { get; set; }
        public virtual ICollection<Movimientofactura> Movimientofacturas { get; set; }
        public virtual ICollection<Preciosrepuesto> Preciosrepuestos { get; set; }
    }
}
