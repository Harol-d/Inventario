using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Inventario.Db
{
    public class Conexion
    {
        private string connection = "server=localhost;user=root;database=inventario;password=;port=3306;";

        public MySqlConnection Conectar()
        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine("Error de conexión a la base de datos: " + ex.Message);
                return null;
            }
        }
    }
}
