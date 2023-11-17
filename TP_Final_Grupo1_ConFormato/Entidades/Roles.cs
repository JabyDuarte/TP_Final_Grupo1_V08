using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Roles
    {
        private int idRol;
        private DateTime fechaAlta;
        private string descripcion;
        private DateTime? fechaBaja;
        private bool flagBajaLogica;

        public int IdRol { get => idRol; set => idRol = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime? FechaBaja { get => fechaBaja; set => fechaBaja = value; }
        public bool FlagBajaLogica { get => flagBajaLogica; set => flagBajaLogica = value; }
    }
}
