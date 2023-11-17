using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class TipoIvaConsulta
    {
        private ConexionMySql conexionMysql;

        public TipoIvaConsulta()
        {
            conexionMysql = new ConexionMySql();
        }

        public List<TipoIva> ObtenerTiposIva()
        {
            List<TipoIva> tiposIva = new List<TipoIva>();

            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "SELECT IdTipoIva, Descripcion, Porcentaje, Habilitado FROM tipoiva";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TipoIva tipoIva = new TipoIva
                        {
                            IdTipoIva = Convert.ToInt32(reader["IdTipoIva"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Porcentaje = Convert.ToDouble(reader["Porcentaje"]),
                            Habilitado = Convert.ToInt32(reader["Habilitado"])
                        };

                        tiposIva.Add(tipoIva);
                    }
                }
            } // La conexión se cierra automáticamente al salir del bloque using

            return tiposIva;
        }

        public void AgregarTipoIva(TipoIva nuevoTipoIva)
        {
            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "INSERT INTO tipoiva (Descripcion, Porcentaje, Habilitado) VALUES (@descripcion, @porcentaje, @habilitado)";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@descripcion", nuevoTipoIva.Descripcion);
                cmd.Parameters.AddWithValue("@porcentaje", nuevoTipoIva.Porcentaje);
                cmd.Parameters.AddWithValue("@habilitado", nuevoTipoIva.Habilitado);

                
                cmd.ExecuteNonQuery();
            }
        }

        public bool EditarTipoIva(TipoIva tipoIva)
        {
            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "UPDATE tipoiva SET Descripcion = @descripcion, Porcentaje = @porcentaje, Habilitado = @habilitado WHERE IdTipoIva = @idTipoIva";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@descripcion", tipoIva.Descripcion);
                cmd.Parameters.AddWithValue("@porcentaje", tipoIva.Porcentaje);
                cmd.Parameters.AddWithValue("@habilitado", tipoIva.Habilitado);
                cmd.Parameters.AddWithValue("@idTipoIva", tipoIva.IdTipoIva);


                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public bool EliminarTipoIva(int idTipoIva)
        {
            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "DELETE FROM tipoiva WHERE IdTipoIva = @idTipoIva";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idTipoIva", idTipoIva);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

    }
}

