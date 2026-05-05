using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Inventario.Db
{
    public class Conexion
    {
        public Conexion() { }
        public string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=Inventario;Trusted_Connection=True;";

        public SqlConnection Conectar()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Conexión correcta a la base de datos");
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión a la base de datos " + ex.Message);
                return null;
            }
        }
    }
}
