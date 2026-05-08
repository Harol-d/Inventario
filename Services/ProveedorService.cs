using System;
using System.Collections.Generic;
//using System.Diagnostics;
using Inventario.Model;
using Inventario.Db;
using MySql.Data.MySqlClient;

namespace Inventario.Services
{
    public class ProveedorService
    {
        Conexion db = new Conexion();

        public Boolean GuardarProveedor(Proveedor p)
        {
            string query = "INSERT INTO Proveedores (Nombre) VALUES (@nombre)";
            using (MySqlConnection conn = db.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean ActualizarProveedor(Proveedor p)
        {
            string query = "UPDATE Proveedores SET Nombre=@nombre WHERE IdProveedor=@id";
            using (MySqlConnection conn = db.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Boolean EliminarProveedor(int id, int estado)
        {
            string query = "UPDATE Proveedores SET estado=@estado WHERE IdProveedor=@id";
            using (MySqlConnection conn = db.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Proveedor> GetProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            string query = "SELECT IdProveedor, Nombre FROM Proveedores";

            using (MySqlConnection conn = db.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Proveedor p = new Proveedor();
                    p.id = reader.GetInt32("id_Proveedor");
                    p.nombre = reader.GetString("Nombre");
                    lista.Add(p);
                }
            }
            return lista;
        }

        public Proveedor GetProveedor(int id)
        {
            string query = "SELECT IdProveedor, Nombre FROM Proveedores WHERE IdProveedor=@id";

            using (MySqlConnection conn = db.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Proveedor p = new Proveedor();
                        p.id = reader.GetInt32("id_Proveedor");
                        p.nombre = reader.GetString("Nombre");
                        return p;
                    }
                }
            }
            return null;
        }
    }
}
