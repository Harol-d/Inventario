using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.Model;
using Inventario.Db;
using System.Data.SqlClient;

namespace Inventario.Services
{
    public class ProductoService
    {
        Conexion db = new Conexion();

        public Boolean GuardarProducto(Producto p)
        {
            string query = "INSERT INTO Productos (Nombre, Cantidad, IdCategoria, Precio) " + "VALUES (@nombre, @cantidad, @categoria, @precio)";

            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@cantidad", p.Cantidad);
                cmd.Parameters.AddWithValue("@categoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@precio", p.Precio);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean ActualizarProducto(Producto p)
        {
            string query = "UPDATE Productos SET Nombre=@nombre, Cantidad=@cantidad, " +
                           "IdCategoria=@categoria, Precio=@precio WHERE IdProducto=@id";

            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", p.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@cantidad", p.Cantidad);
                cmd.Parameters.AddWithValue("@categoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@precio", p.Precio);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean EliminarProducto(int id)
        {
            string query = "DELETE FROM Productos WHERE IdProducto=@id";

            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
