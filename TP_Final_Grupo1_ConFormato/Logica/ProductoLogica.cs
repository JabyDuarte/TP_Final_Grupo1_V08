using Datos;
using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class ProductoLogica
    {
        private ProductoConsulta productoConsulta;

        public ProductoLogica()
        {
            productoConsulta = new ProductoConsulta();
        }

        public List<Producto> BuscarProductosPorDescripcion(string descripcion)
        {
            return productoConsulta.BuscarPorDescripcion(descripcion);
        }
    }
}
