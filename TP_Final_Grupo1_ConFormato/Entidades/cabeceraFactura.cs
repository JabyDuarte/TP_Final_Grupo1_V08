using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class cabeceraFactura //en entidades debería ser FACTURA, pero para mantener la nomenclatura de la base lo dejé así
    {
        private int idCabeceraFactura;
        private string numeroFactura;
        private int idCliente;
        private int idTipoIva;
        private double montoTotalSinIva;
        private double montoTotalConIva;
        private string ivaPorcentaje;
        private string montoIva;

      
        public string NumeroFactura { get => numeroFactura; set => numeroFactura = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdTipoIva { get => idTipoIva; set => idTipoIva = value; }
        public double MontoTotalSinIva { get => montoTotalSinIva; set => montoTotalSinIva = value; }
        public double MontoTotalConIva { get => montoTotalConIva; set => montoTotalConIva = value; }
        public string IvaPorcentaje { get => ivaPorcentaje; set => ivaPorcentaje = value; }
        public string MontoIva { get => montoIva; set => montoIva = value; }
        public int IdCabeceraFactura { get => idCabeceraFactura; set => idCabeceraFactura = value; }
    }
}
