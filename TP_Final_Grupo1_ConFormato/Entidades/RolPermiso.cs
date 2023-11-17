using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class RolPermiso
    {
        private int idRolPermiso;
        private int idRol;
        private int idPermiso;

        public int IdRolPermiso { get => idRolPermiso; set => idRolPermiso = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public int IdPermiso { get => idPermiso; set => idPermiso = value; }
    }
}
