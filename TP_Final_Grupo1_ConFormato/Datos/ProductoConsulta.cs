using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Entidades;

namespace Datos
{
    public class ProductoConsulta
    {
        private ConexionMySql conexionMysql;

        public ProductoConsulta()
        {
            conexionMysql = new ConexionMySql();
        }

        public List<Producto> BuscarPorDescripcion(string descripcion)
        {
            List<Producto> productos = new List<Producto>();

            MySqlConnection connection = conexionMysql.GetConexion();
            string query = "SELECT IdProducto, Descripcion, IdUnidadDeMedida, ValorUnitario, Habilitado FROM producto WHERE Descripcion LIKE @descripcion";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@descripcion", "%" + descripcion + "%");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            IdUnidadDeMedida = Convert.ToInt32(reader["IdUnidadDeMedida"]),
                            ValorUnitario = Convert.ToDouble(reader["ValorUnitario"]),
                            Habilitado = Convert.ToBoolean(reader["Habilitado"])
                        };

                        productos.Add(producto);
                    }
                }
            } // La conexión se cierra automáticamente al salir del bloque using

            return productos;
        }
    }
}
