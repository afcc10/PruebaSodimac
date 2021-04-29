using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Tercero
    {
        public Tercero()
        {
            FacturaDocumentoclienteNavigations = new HashSet<Factura>();
            FacturaDocumentomecanicoNavigations = new HashSet<Factura>();
        }

        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public string Primerapellido { get; set; }
        public string Segundoapellido { get; set; }
        public string Tipodocumento { get; set; }
        public string Documento { get; set; }
        public decimal? Celular { get; set; }
        public string Direccion { get; set; }
        public string Correoelectronico { get; set; }
        public decimal? Estado { get; set; }

        public virtual ICollection<Factura> FacturaDocumentoclienteNavigations { get; set; }
        public virtual ICollection<Factura> FacturaDocumentomecanicoNavigations { get; set; }
    }
}
