namespace Inventario.Model
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Categoria() { }
        public Categoria(int id) {this.id = id;}
        public Categoria(string nombre) {
            this.nombre = nombre;
        }
    }
}
