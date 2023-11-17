using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int idUsuario;
        private DateTime fechaAlta;
        private string nombreUsuario;
        private string pass;
        private int idPersona;
        private DateTime fechaCaducidadPass;
        private DateTime? fechaBaja;
        private bool bloqueado;
        private bool bajaLogica;
        private int qIntentosFallido;
        public List<Roles> Roles { get; set; }
        public List<Permiso> Permisos { get; set; }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Pass { get => pass; set => pass = value; }
        public DateTime FechaCaducidadPass { get => fechaCaducidadPass; set => fechaCaducidadPass = value; }
        public DateTime? FechaBaja { get => fechaBaja; set => fechaBaja = value; }
        public bool Bloqueado { get => bloqueado; set => bloqueado = value; }
        public bool BajaLogica { get => bajaLogica; set => bajaLogica = value; }
        public int QIntentosFallido { get => qIntentosFallido; set => qIntentosFallido = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }

        public Usuario()
        {
            // Inicializa las listas de roles y permisos
            Roles = new List<Roles>();
            Permisos = new List<Permiso>();
        }
    }
}
