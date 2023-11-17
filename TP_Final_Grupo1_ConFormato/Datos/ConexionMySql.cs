using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class ConexionMySql : Conexion
    {
        private MySqlConnection conn;
        private string cadenaConexion;

        public ConexionMySql()
        {
            cadenaConexion = "Database=" + database +
                             "; DataSource=" + server +
                             "; User Id=" + user +
                             "; Password=" + password;

            conn = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection GetConexion()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("No se pudo establecer la conexion");
            }

            return conn;
        }
    }
}
