using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using Came.Modelo.Interface;


namespace Came.Negocios.AdministracionGrupos.Interface
{
    interface IAdministracionGrupos
    {
        void AgregarGrupo(Grupo grupo);

        void ActualizarGrupo(Grupo grupo);

        void EliminarGrupo(int id);

        IEnumerable<Alumno> GetAlumnosGrupo(int id);

        Grupo GetGrupo(int id);

        IModelo GetModelo();
    }
}
