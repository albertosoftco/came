using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;

namespace Came.Negocios.InicioSesion.Interface
{
    interface ILogin
    {
        bool IniciarSesion(Usuario usuario);

        void CierraSesion();

        int GetUsuarioActual();

        string GetPermisoActual();
    }
}
