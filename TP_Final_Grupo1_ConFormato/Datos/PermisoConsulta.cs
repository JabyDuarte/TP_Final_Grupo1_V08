using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class PermisoConsulta
    {
        private ConexionMySql conexionMysql;

        public PermisoConsulta(ConexionMySql conexion)
        {
            conexionMysql = conexion;
        }

        public List<Permiso> CargarPermisos()
        {
            List<Permiso> permisos = new List<Permiso>();

            using (MySqlConnection connection = conexionMysql.GetConexion())
            {
                string query = "SELECT * FROM permisos";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permiso permiso = new Permiso
                            {
                                IdPermiso = Convert.ToInt32(reader["IdPermisos"]),
                                FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                FechaBaja = reader["FechaBaja"] is DBNull ? null : (DateTime?)Convert.ToDateTime(reader["FechaBaja"]),
                                FlagBajaLogica = Convert.ToBoolean(reader["FlagBajaLogica"])
                            };

                            permisos.Add(permiso);
                        }
                    }
                }
            }

            return permisos;
        }
    }
}

