using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class UsuarioRol
    {
        private int idUsuarioRol;
        private int idUsuario;
        private int idRol;

        public int IdUsuarioRol { get => idUsuarioRol; set => idUsuarioRol = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdRol { get => idRol; set => idRol = value; }
    }
}
