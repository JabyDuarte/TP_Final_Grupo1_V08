using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Entidades;

namespace Datos
{
    public class ClienteConsulta
    {
        private ConexionMySql conexionMysql;

        public ClienteConsulta()
        {
            conexionMysql = new ConexionMySql();
        }

        public List<Cliente> BuscarPorRazonSocial(string razonSocial)
        {
            List<Cliente> clientes = new List<Cliente>();

            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "SELECT IdCliente, RazonSocial, FechaAlta, FechaBaja, LimiteCredito, idTipoIva FROM cliente WHERE RazonSocial LIKE @razonSocial";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@razonSocial", "%" + razonSocial + "%");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            RazonSocial = reader["RazonSocial"].ToString(),
                            FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                            FechaBaja = reader["FechaBaja"] is DBNull ? null : (DateTime?)Convert.ToDateTime(reader["FechaBaja"]),
                            LimiteCredito = Convert.ToDouble(reader["LimiteCredito"]),
                            TipoIva = Convert.ToInt32(reader["idTipoIva"])
                        };

                        clientes.Add(cliente);
                    }
                }
            } // La conexión se cierra automáticamente al salir del bloque using

            return clientes;
        }

    }
}
