using Inventario.Db;
using Inventario.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Inventario.Services
{
    public class ProductoService
    {
        public Conexion db = new Conexion();
        public Producto producto;

        public Boolean GuardarProducto(Producto p)
        {
            string query = "INSERT INTO Productos (Nombre, Cantidad, IdCategoria, Precio) VALUES (@nombre, @cantidad, @categoria, @precio)";

            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@nombre", p.nombre);
            cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
            cmd.Parameters.AddWithValue("@precio", p.precio);

            return cmd.ExecuteNonQuery() > 0;
        }

        public Boolean ActualizarProducto(Producto p) 
        {
            string query = "UPDATE Productos SET Nombre=@nombre, Cantidad=@cantidad, " +
                           "IdCategoria=@categoria, Precio=@precio WHERE IdProducto=@id";

            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@precio", p.precio);

                return cmd.ExecuteNonQuery() > 0;

        }

        public Boolean EliminarProducto(int id,Boolean estado)
        {
            string query = "UPDATE productos SET estado=@estado WHERE IdProducto=@id";

            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@estado", estado);
            return cmd.ExecuteNonQuery() > 0;
        }
        public List <Producto> getProductos() {
            List<Producto> productos = new List<Producto>();
            string query = "SELECT * FROM productos";

            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query,conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()){
                producto = new Producto();
                producto.id= reader.GetInt32("idProducto");
                producto.nombre = reader.GetString("nombre");
                producto.precio = reader.GetDouble("precio");
                productos.Add(producto);
            }
            reader.Close();
            return productos;
        }
        public Producto GetProducto(int id){
            string query = "SELECT * FROM productos WHERE idProducto=@id";
            MySqlConnection conn = db.Conectar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    producto = new Producto();
                    producto.id = reader.GetInt32("idProducto");
                    producto.nombre = reader.GetString("nombre");
                    producto.precio = reader.GetDouble("precio");
                }
                reader.Close();
                return producto;
            }
            catch (NullReferenceException ex) {
                Debug.WriteLine("Error al recuperar el producto " + ex.Message);
                return null;
            }
        }
    }
}
