using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionGrupos.Interface;
using Came.Modelo.Interface;
using Came.Modelo;

namespace Came.Negocios.AdministracionGrupos.Fachada
{
    class FachadaAdministracionGrupos : IAdministracionGrupos
    {
        private IModelo modelo;
        private AdministracionGrupos admGrupos;

        public FachadaAdministracionGrupos(IModelo modelo)
        {
            this.modelo = modelo;
            this.admGrupos = new AdministracionGrupos(modelo);
        }



        public void AgregarGrupo(Modelo.Grupo grupo)
        {
            admGrupos.AgregaGrupo(grupo);
        }

        public void ActualizarGrupo(Modelo.Grupo grupo)
        {
            admGrupos.ActualizarGrupo(grupo);
        }

        public void EliminarGrupo(int id)
        {
            admGrupos.EliminaGrupo(id);
        }

        public IEnumerable<Modelo.Alumno> GetAlumnosGrupo(int id)
        {
            return admGrupos.GetAlumnosEnGrupo(id);
        }

        public Grupo GetGrupo(int id)
        {
            return admGrupos.GetGrupo(id);
        }

        public IModelo GetModelo()
        {
            return admGrupos.modelo;
        }

        public IEnumerable<Horario> GetHorarios()
        {
            return admGrupos.GetHorarios();
        }
    }
}
