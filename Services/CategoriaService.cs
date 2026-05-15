using Inventario.Db;
using Inventario.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Inventario.Services
{
    public class CategoriaService
    {
        public Conexion db = new Conexion();
        private Categoria categoria;

        public Boolean GuardarCategoria(Categoria c)
        {
            string query = "INSERT INTO Categoria (Nombre) VALUES (@nombre)";
            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", c.nombre);
            return cmd.ExecuteNonQuery() > 0;
        }

        public Boolean ActualizarCategoria(Categoria c)
        {
            string query = "UPDATE Categoria SET Nombre=@nombre WHERE IdCategoria=@id";
            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", c.id);
            cmd.Parameters.AddWithValue("@nombre", c.nombre);
            return cmd.ExecuteNonQuery() > 0;
        }

        public Boolean EliminarCategoria(int id)
        {
            string query = "DELETE FROM Categoria WHERE IdCategoria=@id";
            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Categoria> GetCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            string query = "SELECT * FROM categorias";
            MySqlConnection conn = db.Conectar();
            try{
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categoria = new Categoria();
                    categoria.id = reader.GetInt32("IdCategoria");
                    categoria.nombre = reader.GetString("Nombre");
                    categorias.Add(categoria);
                }
                reader.Close(); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener categorías: " + ex.Message);
            }

            return categorias;
        }

        public Categoria GetCategoria(int id)
        {
            string query = "SELECT * FROM Categoria WHERE IdCategoria=@id";
            MySqlConnection conn = db.Conectar();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    categoria = new Categoria();
                    categoria.id = reader.GetInt32("IdCategoria");
                    categoria.nombre = reader.GetString("Nombre");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al recuperar la categoría: " + ex.Message);
            }

            return categoria;
        }
    }
}