using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int idProducto;
        private string descripcion;
        private int idUnidadDeMedida;
        private double valorUnitario;
        private bool habilitado;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdUnidadDeMedida { get => idUnidadDeMedida; set => idUnidadDeMedida = value; }
        public double ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
    }
}
