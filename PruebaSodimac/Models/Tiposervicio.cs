using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class Tiposervicio
    {
        public Tiposervicio()
        {
            Items = new HashSet<Item>();
        }

        public decimal Rowidtiposervicio { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
