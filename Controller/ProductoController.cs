using Inventario.Model;
using Inventario.Services;
using System.Diagnostics;
using Inventario.Views;
namespace Inventario.Controller
{
    public class ProductoController
    {
        public ProductoService service = new ProductoService();
        public Producto producto;
        //public ProductosView view = new ProductosView();
        public Boolean AgregarProducto(string nombre,int cantidad,float precio,int categoria){
            producto = new Producto(nombre, cantidad, precio, categoria);
            return service.GuardarProducto(producto);
        }

        public Boolean ActualizarProducto(int id,string nombre, int cantidad, float precio,int categoria) {
            producto = new Producto(nombre, cantidad, precio, categoria);
            producto.id = id;
            return service.ActualizarProducto(producto);
            }

        public List<Producto> GetProductos() {
            //Debug.WriteLine("Objetos"+service.getProductos());
            return service.getProductos();
        }

        public Producto GetProducto(int id) {
            return service.GetProducto(id);
        }
    }
}
