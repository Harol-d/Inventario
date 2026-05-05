using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Inventario.Model;
using System.Data.SqlClient;
using Inventario.Db;

namespace Inventario.Services
{
    public class CategoriaService
    {
        Conexion db = new Conexion();

        public Boolean GuardarCategoria(Categoria c)
        {
            string query = "INSERT INTO Categoria (Nombre) VALUES (@nombre)";
            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean ActualizarCategoria(Categoria c)
        {
            string query = "UPDATE Categoria SET Nombre=@nombre WHERE IdCategoria=@id";
            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", c.Id);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean EliminarCategoria(int id)
        {
            string query = "DELETE FROM Categoria WHERE IdCategoria=@id";
            using (SqlConnection conn = db.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
