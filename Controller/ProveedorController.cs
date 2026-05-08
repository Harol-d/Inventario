using Inventario.Model;
using Inventario.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Inventario.Controller
{
    public class ProveedorController
    {
        public ProveedorService service = new ProveedorService();
        public Proveedor proveedor;

        public Boolean AgregarProveedor(string nombre)
        {
            proveedor = new Proveedor(nombre);
            Debug.WriteLine("Intentando agregar proveedor: " + nombre);
            return service.GuardarProveedor(proveedor);
        }

        public Boolean ActualizarProveedor(int id, string nombre)
        {
            proveedor = new Proveedor(nombre);
            proveedor.id = id;
            return service.ActualizarProveedor(proveedor);
        }

        public Boolean EliminarProveedor(int id, int estado)
        {
            return service.EliminarProveedor(id, estado);
        }

        public List<Proveedor> GetProveedores()
        {
            return service.GetProveedores();
        }

        public Proveedor GetProveedor(int id)
        {
            return service.GetProveedor(id);
        }
        
    }
}