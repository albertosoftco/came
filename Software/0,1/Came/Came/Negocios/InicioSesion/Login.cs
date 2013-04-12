using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using Came.Negocios.Excepciones;
using Came.Modelo.Interface;
using Came.Modelo.Fachada;
namespace Came.Negocios.InicioSesion
{
    class Login
    {

        private Usuario usuarioActual;
        public string permisoActual;
        private IModelo modelo;

        /// <summary>
        /// constructor de la clase controladora del login
        /// </summary>
        /// <param name="modelo"></param>
        public Login(IModelo modelo)
        {
            usuarioActual = null;
            permisoActual = null;
            this.modelo = modelo;
        }

        /// <summary>
        /// regresa el Usuario que ha iniciado sesion en el sistema
        /// </summary>
        /// <returns></returns>
        public int GetUsuario()
        {
            return this.usuarioActual.ID;
        }

        /// <summary>
        /// borra todo registro del inicio de sesion
        /// </summary>
        public void Logout()
        {
            usuarioActual = null;
            permisoActual = null;
        }

        /// <summary>
        /// proceso de login 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool LoginProcess(Usuario usuario)
        {
            if (usuario == null) throw new LoginException("Nombre de Usuario y/o contraseña incorrectos");



            //checa si el Usuario existe en la base de datos 
            var usuarios = modelo.GetUsuarios();

            foreach (Usuario u in usuarios)
            {
                if (u.UserName.Equals(usuario.UserName, StringComparison.InvariantCultureIgnoreCase) && u.Contrasenha.Equals(usuario.Contrasenha))
                {
                    usuarioActual = u;
                    //checa el nivel de administracion del Usuario
                    if (usuario.Permisos == 0)
                        permisoActual = "SuperAdmin";
                    if (usuario.Permisos == 1)
                        permisoActual = "Admin";
                    if (usuario.Permisos == 2)
                        permisoActual = "SuperUser";
                    if (usuario.Permisos == 3)
                        permisoActual = "User";
                    return true;
                }
            }
            throw new LoginException("Nombre de Usuario y/o contraseña incorrectos");

        }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public string GetPermisoActual()
            {
                return permisoActual;
            }
    }
}
