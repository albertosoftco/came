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

        public FachadaInicioSesion(IModelo modelo)
        {
            this.modelo = modelo;
            this.sesion = new Login(modelo);
        }

        public bool IniciarSesion(Usuario usuario)
        {
            return sesion.LoginProcess(usuario);
        }

        public void CierraSesion()
        {
            sesion.Logout();
        }

        public int GetUsuarioActual()
        {
            return sesion.GetUsuario();
        }

        public string GetPermisoActual()
        {
            return sesion.GetPermisoActual();
        }
    }
}
