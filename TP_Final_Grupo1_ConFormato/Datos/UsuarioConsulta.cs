using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class UsuarioConsulta
    {
        private ConexionMySql conexionMysql;


        public UsuarioConsulta()
        {
            conexionMysql = new ConexionMySql();
        }

        public Usuario Login(string nombreUsuario, string password)
        {
            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "SELECT * FROM usuario WHERE NombreUsuario = @nombreUsuario AND Password = @password";

            // Uso el using para cuando salga del mismo se cierre la conexión
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {

                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            Pass = reader["Password"].ToString(),
                            IdPersona = Convert.ToInt32(reader["IdPersona"]),
                            FechaCaducidadPass = Convert.ToDateTime(reader["FechaCaducidadPassword"]),
                            FechaBaja = reader["FechaBaja"] is DBNull ? null : (DateTime?)Convert.ToDateTime(reader["FechaBaja"]),
                            Bloqueado = Convert.ToBoolean(reader["flagBloqueado"]),
                            QIntentosFallido = Convert.ToInt32(reader["cantidadIntentosFallidos"]),
                            BajaLogica = Convert.ToBoolean(reader["flagBajaLogica"])
                        };

                        reader.Close();
                        // Obtener los permisos del usuario
                        usuario.Permisos = ObtenerPermisosDeUsuario(usuario.IdUsuario);

                        return usuario;
                    }
                }
            }// Aca se cierra la conexión

            return null; // Devuelve null si no se encontró un usuario válido
        }


        public List<Permiso> ObtenerPermisosDeUsuario(int idUsuario)
        {
            List<Permiso> permisos = new List<Permiso>();

            MySqlConnection connection = conexionMysql.GetConexion();

            // Obtener roles del usuario
            List<int> roles = new List<int>();

            using (MySqlCommand rolesCmd = new MySqlCommand("SELECT idRol FROM UsuarioRol WHERE idUsuario = @idUsuario", connection))
            {
                rolesCmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                using (MySqlDataReader rolesReader = rolesCmd.ExecuteReader())
                {
                    while (rolesReader.Read())
                    {
                        int idRol = Convert.ToInt32(rolesReader["idRol"]);
                        roles.Add(idRol);
                    }
                }
            }

            // Obtener permisos de los roles
            foreach (int idRol in roles)
            {
                using (MySqlCommand permisosCmd = new MySqlCommand("SELECT p.idPermisos, p.descripcion FROM RolPermiso rp INNER JOIN Permisos p ON rp.idPermisos = p.idPermisos WHERE rp.idRol = @idRol", connection))
                {
                    permisosCmd.Parameters.AddWithValue("@idRol", idRol);

                    using (MySqlDataReader permisosReader = permisosCmd.ExecuteReader())
                    {
                        while (permisosReader.Read())
                        {
                            Permiso permiso = new Permiso
                            {
                                IdPermiso = Convert.ToInt32(permisosReader["idPermisos"]),
                                Descripcion = permisosReader["descripcion"].ToString()
                            };
                            permisos.Add(permiso);
                        }
                    }
                }
            }

            return permisos;
        }

        public bool UsuarioEstaBloqueado(Usuario usuario)
        {
            MySqlConnection connection = conexionMysql.GetConexion();

            using (MySqlCommand cmd = new MySqlCommand("SELECT flagBloqueado FROM usuario WHERE IdUsuario = @idUsuario", connection))
            {
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToBoolean(result);
                }
            }

            return false; // Usuario no encontrado o no bloqueado
        }


    }
}
