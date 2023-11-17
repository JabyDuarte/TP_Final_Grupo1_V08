using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class detalleFactura
    {
        private int idDetalleFactura;
        private int idCabeceraFactura;
        private int idProducto;
        private int idUnidadDeMedida;
        private int cantidad;
        private double monto;
        private double montoIva;
        private double montoTotal;

        public int IdDetalleFactura { get => idDetalleFactura; set => idDetalleFactura = value; }
        public int IdCabeceraFactura { get => idCabeceraFactura; set => idCabeceraFactura = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdUnidadDeMedida { get => idUnidadDeMedida; set => idUnidadDeMedida = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Monto { get => monto; set => monto = value; }
        public double MontoIva { get => montoIva; set => montoIva = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
    }
}
