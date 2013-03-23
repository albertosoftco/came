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
        private IModelo modelo;

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
                modelo.GetModelo().Grupo.AddObject(grupo);
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
                modelo.GetModelo().DeleteObject(g);
                modelo.SalvaCambios();
            }
        }

        public IEnumerable<Alumno> GetAlumnosEnGrupo(int id)
        {
            IQueryable<Grupo_Alumno> relaciones = modelo.GetModelo().Grupo_Alumno.Where(i => i.Alumno.ID == id);
            IList<Alumno> alumnos = new List<Alumno>();

            foreach (Grupo_Alumno ga in relaciones)
            {
                alumnos.Add(ga.Alumno);
            }

            return alumnos.AsEnumerable();
        }
    }
}
