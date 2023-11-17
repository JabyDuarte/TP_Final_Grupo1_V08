using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Logica
{
    public class LogInLogica
    {
        private UsuarioConsulta _usuarioConsulta;

        public LogInLogica(UsuarioConsulta usuarioConsulta)
        {
            this._usuarioConsulta = usuarioConsulta;
        }

        public Usuario Login(string usuario, string password)
        {
            Usuario objUsuario = _usuarioConsulta.Login(usuario, password);

            if (objUsuario != null)
            {
                // Verificar la contraseña
                if (objUsuario.Pass == password && !objUsuario.Bloqueado && !objUsuario.BajaLogica)
                {
                    // La contraseña es correcta y el usuario no está bloqueado ni dado de baja
                    objUsuario.QIntentosFallido = 0; // Reiniciar intentos fallidos
                                                     // HACERLO EN LA BASE DE DATOS!!!!!!!!
                    return objUsuario; // Usuario autenticado
                }
                else
                {
                    // Contraseña incorrecta o usuario bloqueado/dado de baja
                    objUsuario.QIntentosFallido++; // Incrementar intentos fallidos
                                                   // HACERLO EN LA BASE DE DATOS!!!!!!!

                    if (objUsuario.QIntentosFallido >= 3)
                    {
                        objUsuario.Bloqueado = true;
                    }
                }
            }
            //la autenticación falló
            return null;
        }

        public bool VerificarPermiso(Usuario usuario, string permisoDeseado)
        {
            // Primero, obtenemos todos los permisos del usuario
            List<Permiso> permisosUsuario = usuario.Permisos;

            // Luego, verificamos si el permiso deseado está presente en la lista de permisos del usuario
            bool tienePermiso = permisosUsuario.Any(permiso => permiso.Descripcion == permisoDeseado);

            return tienePermiso;
        }



    }
}
