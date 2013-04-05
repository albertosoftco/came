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
            var  g = modelo.GetGrupos().Where(i => i.Nombre.Equals(grupo.Nombre)); ;
            if(g.Count() ==0)
            {
                modelo.GetModelo().Grupo.Add(grupo);
                modelo.SalvaCambios();
                
            }
            else
            {
                throw new AdministracionGruposException("El grupo ya existe");
            }

        }

        public void ActualizarGrupo(Grupo grupo)
        {
            var g = modelo.GetGrupos().First(i=>i.ID.Equals(grupo.ID));
            var m = modelo.GetMaestros().First(i => i.ID.Equals(grupo.Maestro.ID));
            var h = modelo.GetHorarios().First(i => i.ID.Equals(grupo.Horario.ID));
            var a = modelo.GetGrupos().First(i => i.ID.Equals(grupo.ID)).Alumno;
            if (g== null)
            {
                throw new AdministracionGruposException("El grupo no existe");
            }
            else
            {
                modelo.GetModelo().Grupo.Attach(g);
                //g.Alumno = a;
                g.Capacidad = grupo.Capacidad;
                g.Horario = h;
                g.Maestro = m;
                g.Nombre = grupo.Nombre;
                modelo.GetModelo().SaveChanges();
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

        public IEnumerable<Horario>GetHorarios()
        {
            return modelo.GetHorarios();
        }
    }
}
