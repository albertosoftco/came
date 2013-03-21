using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Came.Modelo.Interface;
using Came.Modelo;
namespace Came.Negocios.AdministracionGrupos
{
    class AdministracionGrupos
    {
        private IModelo modelo;

        public AdministracionGrupos(IModelo modelo)
        {
            this.modelo = modelo;
        }


        public void AgregarAlumnoGrupo(int idAlumno, int idGrupo)
        {
            //checa si el alumno ya esta inscrito en el grupo
            
            
        }

        private bool ExisteAlumnoEnGrupo(int idAlumno, int idGrupo)
        {
            Grupo grupo = new Grupo();
            
        }


    }
}
