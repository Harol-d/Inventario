using Inventario.Model;
using Inventario.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Inventario.Controller
{
    public class ProductoController
    {
        public ProductoService service = new ProductoService();
        public Producto producto;

        public Boolean AgregarProducto(string nombre,int cantidad,float precio){
            producto = new Producto(nombre,cantidad,precio);
            Debug.WriteLine("Se agrego correctamente el producto");
            return service.GuardarProducto(producto);
        }

        public Boolean ActualizarProducto(int id,string nombre, int cantidad, float precio) {
            producto = new Producto(nombre, cantidad, precio);
            producto.id = id;
            return service.ActualizarProducto(producto);
            }

        public List<Producto> GetProductos() {
            return service.getProductos();
        }

        public Producto GetProducto(int id) {
            return service.GetProducto(id);
        }
    }
}
