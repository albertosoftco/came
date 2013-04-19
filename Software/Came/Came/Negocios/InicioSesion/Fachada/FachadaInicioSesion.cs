using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.InicioSesion.Interface;
namespace Came.Negocios.InicioSesion.Fachada
{
    class FachadaInicioSesion : ILogin
    {
        private IModelo modelo;
        private Login sesion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelo"></param>
        public FachadaInicioSesion(IModelo modelo)
        {
            this.modelo = modelo;
            this.sesion = new Login(modelo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool IniciarSesion(Usuario usuario)
        {
            return sesion.LoginProcess(usuario);
        }


        /// <summary>
        /// 
        /// </summary>
        public void CierraSesion()
        {
            sesion.Logout();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetUsuarioActual()
        {
            return sesion.GetUsuario();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPermisoActual()
        {
            return sesion.GetPermisoActual();
        }
    }
}
