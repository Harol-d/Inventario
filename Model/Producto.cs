

namespace Inventario.Model
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public Producto(){}
        public Producto(int id) {
            this.id = id;
        }
        public Producto(string nombre, int cantidad, double precio) {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
        }
        public override string ToString()
        {
            return "Total de productos: "+id;
        }
    }
}
