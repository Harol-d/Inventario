using Inventario.Model;
using Inventario.Services;

using System.Diagnostics;

namespace Inventario.Controller
{
    public class CategoriaController
    {
        public CategoriaService service = new CategoriaService();
        public Categoria categoria;

        public Boolean AgregarCategoria(string nombre)
        {
            categoria = new Categoria(nombre);
            Debug.WriteLine("Se agregó correctamente la categoría");
            return service.GuardarCategoria(categoria);
        }

        public Boolean ActualizarCategoria(int id, string nombre)
        {
            categoria = new Categoria(nombre);
            categoria.id = id;
            return service.ActualizarCategoria(categoria);
        }

        public List<Categoria> GetCategorias()
        {
            return service.GetCategorias();
        }

        public Categoria GetCategoria(int id)
        {
            return service.GetCategoria(id);
            
        }
    }
}