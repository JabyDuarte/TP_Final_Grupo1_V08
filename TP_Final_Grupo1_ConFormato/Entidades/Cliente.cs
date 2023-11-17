using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private int idCliente;
        private string razonSocial;
        private DateTime? fechaAlta;
        private DateTime? fechaBaja;
        private double limiteCredito;
        private int tipoIva;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public DateTime? FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public DateTime? FechaBaja { get => fechaBaja; set => fechaBaja = value; }
        public double LimiteCredito { get => limiteCredito; set => limiteCredito = value; }
        public int TipoIva { get => tipoIva; set => tipoIva = value; }
    }
}
