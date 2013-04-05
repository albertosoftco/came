using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.Excepciones;
using Came.Modelo.Interface;
using Came.Modelo;
namespace Came.Negocios.AdministracionGrupos
{
    class AdministracionGrupos
    {
        public IModelo modelo{get;set;}

        public AdministracionGrupos(IModelo modelo)
        {
            this.modelo = modelo;
        }


        public void AgregaGrupo(Grupo grupo)
        {
            Grupo g = modelo.GetGrupo(grupo.ID);
            if(g == null)
            {
                throw new AdministracionGruposException("El grupo ya existe");
            }
            else
            {
                modelo.GetModelo().Grupo.Add(grupo);
                modelo.SalvaCambios();
            }

        }

        public void ActualizarGrupo(Grupo grupo)
        {
            Grupo g = modelo.GetGrupo(grupo.ID);
            if (g == null)
            {
                throw new AdministracionGruposException("El grupo no existe");
            }
            else
            {
                g = grupo;
                modelo.SalvaCambios();
            }
        }


        public void EliminaGrupo(int idGrupo)
        {
            Grupo g = modelo.GetGrupo(idGrupo);
            if(g == null)
            {
                throw new AdministracionGruposException("El grupo no existe");
            }
            else
            {
                modelo.GetModelo().Grupo.Remove(g);
                modelo.SalvaCambios();
            }
        }

        public IEnumerable<Alumno> GetAlumnosEnGrupo(int id)
        {
            return modelo.GetAlumnosGrupo(id);
        }

        public Grupo GetGrupo(int id)
        {
            return modelo.GetGrupo(id);
        }
    }
}
