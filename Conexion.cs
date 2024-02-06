using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtiquetaMaster
{
    internal class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "192.168.1.251";
            string db = "ordenes";
            string usuario = "root";
            string password = "Winperfil01$";

            string cadenaConexion = "Database=" + db + ";Server=" + servidor +
                ";Uid=" + usuario + ";Pwd=" + password + ";";

            try
            {
                MySqlConnection conexionDB = new MySqlConnection(cadenaConexion);
                return conexionDB;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return null;

            }
        }
    }
}
