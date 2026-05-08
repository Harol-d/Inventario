namespace Inventario.Model
{
    public class Proveedor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Proveedor() { }
        public Proveedor(int id)
        {
            this.id = id;
        }
        public Proveedor(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
