using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoIva
    {
        private int idTipoIva;
        private string descripcion;
        private double porcentaje;
        private int habilitado;

        public int IdTipoIva { get => idTipoIva; set => idTipoIva = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Porcentaje { get => porcentaje; set => porcentaje = value; }
        public int Habilitado { get => habilitado; set => habilitado = value; }
    }
}
