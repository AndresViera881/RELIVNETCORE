using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelivNET.Entities.infos
{
    public class ProductoInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; } = default!;
        public Estado Estado { get; set; } = default!;
        public string Fecha { get; set; } = default!;
        public string Hora { get; set; } = default!;
    }
}
