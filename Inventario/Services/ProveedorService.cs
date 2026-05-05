using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Inventario.Model;
using Inventario.Db;
using System.Data.SqlClient;

namespace Inventario.Services
{
    internal class ProveedorService
    {
        Conexion db = new Conexion();

        public Boolean GuardarProveedor(Proveedor p)
        {
            string query = "INSERT INTO Proveedores (Nombre) VALUES (@nombre)";
            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean ActualizarProveedor(Proveedor p)
        {
            string query = "UPDATE Proveedores SET Nombre=@nombre WHERE IdProveedor=@id";
            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean EliminarProveedor(int id)
        {
            string query = "DELETE FROM Proveedores WHERE IdProveedor=@id";
            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}

