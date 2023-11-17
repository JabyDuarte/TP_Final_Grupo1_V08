using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class UnidadDeMedida
    {
        private int idUnidadDeMedida;
        private string descripcion;
        private int habilitado;

        public int IdUnidadDeMedida { get => idUnidadDeMedida; set => idUnidadDeMedida = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Habilitado { get => habilitado; set => habilitado = value; }

    }
}
