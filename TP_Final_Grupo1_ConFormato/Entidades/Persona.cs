using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private int idPersona;
        private DateTime fechaAlta;
        private string apellidoNombre;
        private DateTime fechaNacimiento;

        public int IdPersona { get => idPersona; set => idPersona = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string ApellidoNombre { get => apellidoNombre; set => apellidoNombre = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    }
}
