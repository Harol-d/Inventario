using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Model
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
    }
}
