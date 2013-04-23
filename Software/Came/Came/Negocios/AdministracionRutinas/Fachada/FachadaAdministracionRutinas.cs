using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionRutinas.Interface;
using Came.Modelo.Fachada;
using Came.Modelo.Interface;
using Came.Modelo;

namespace Came.Negocios.AdministracionRutinas.Fachada
{
    class FachadaAdministracionRutinas : IAdministracionRutinas
    {
        private AdministracionRutinas admRutinas;

        /// <summary>
        /// 
        /// </summary>
        public FachadaAdministracionRutinas(IModelo modelo)
        {
            admRutinas = new AdministracionRutinas(modelo);    
        }


        public IModelo GetModelo()
        {
            return admRutinas.GetModelo();
        }
        public void AsignaRutina(int idAlumno, int idRutina)
        {
            throw new NotImplementedException();
        }

        public void AgregaRutina(Modelo.Rutina rutina)
        {
            admRutinas.AgregaRutina(rutina);
        }

        public void ActualizaRutina(Modelo.Rutina rutina)
        {
            
            throw new NotImplementedException();
        }

        public void EliminaRutina(int idRutina,bool borraTodo)
        {
            admRutinas.EliminaRutina(idRutina, borraTodo);
        }

        public Modelo.Rutina GetRutina(int id)
        {
            return admRutinas.GetRutina(id);
        }

        public IEnumerable<Modelo.Programa> GetProgramasRutina(int idRutina)
        {
            return admRutinas.GetProgramasRutina(idRutina);
        }

        public Modelo.Actividad GetActividad(int idActividad)
        {
            return admRutinas.GetActividad(idActividad);
        }

        public IEnumerable<Modelo.Actividad> GetActividadesPrograma(int idPrograma)
        {
            return admRutinas.GetActividadesPrograma(idPrograma);
        }

        public Modelo.Ejercicio GetEjercicio(int idActividad)
        {
            return admRutinas.GetEjercicio(idActividad);
        }

        public IEnumerable<Modelo.Ejercicio> GetEjerciciosActividad(int idActividad)
        {
            return admRutinas.GetEjerciciosActividad(idActividad);
        }

        public IEnumerable<Modelo.Rutina> GetRutinas()
        {
            return admRutinas.GetRutinas();
        }

        public IEnumerable<Modelo.Horario>GetHorarios()
        {
            return admRutinas.GetHorarios();
        }

        public IEnumerable<Modelo.Maestro>GetMaestros()
        {
            return admRutinas.GetMaestros();
        }

        public Modelo.Maestro GetMaestro(int id)
        {
            return admRutinas.GetMaestro(id);
        }


        public void AgregaPrograma(Modelo.Programa programa)
        {
            admRutinas.AgregaPrograma(programa);

        }

        public void AgregaActividad(Modelo.Actividad actividad)
        {
            admRutinas.AgregaActividad(actividad);
        }

        public void AgregaEjercicio(Modelo.Ejercicio ejercicio)
        {
            admRutinas.AgregaEjercicio(ejercicio);
        }

        public void ActualizaPrograma(Modelo.Programa programa)
        {
            throw new NotImplementedException();
        }

        public void ActualizaActividad(Modelo.Actividad actividad)
        {
            throw new NotImplementedException();
        }

        public void ActualizaEjercicio(Modelo.Ejercicio ejercicio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo.Programa>GetProgramas()
        {
            return admRutinas.GetProgramas();
        }

        public Modelo.Actividad GetActividad(string nombre)
        {
            return admRutinas.GetActividad(nombre);
        }

        public Modelo.Programa GetPrograma(string nombre)
        {
            return admRutinas.GetPrograma(nombre);
        }


        public Rutina GetRutina(string nombre)
        {
            return admRutinas.GetRutina(nombre);
        }
        public IEnumerable<Modelo.Actividad>GetActividades()
        {
            return admRutinas.GetActividades();
        }
        public void AsignaProgramasRutina(IEnumerable<Programa>programas,int idRutina)
        {
            admRutinas.AsignaProgramasRutina(programas, idRutina);
        }

        public void AsignaActividadesPrograma(IEnumerable<Actividad>actividades,int idPrograma)
        {
            admRutinas.AsignaActividadesPrograma(actividades, idPrograma);
        }

        public void AsignaProgramaRutina(int idPrograma,int idRutina)
        {
            admRutinas.AsignaProgramaRutina(idPrograma, idRutina);
        }

        public void AsignaActividadPrograma(int idActividad,int idPrograma)
        {
            admRutinas.AsignaActividadPrograma(idActividad, idPrograma);
        }


        public void EliminaPrograma(int idPrograma)
        {
            admRutinas.EliminaPrograma(idPrograma);

        }

        public void AsignaEjercicioActividad(int idEjercicio, int idActividad)
        {
            admRutinas.AsignaEjercicioActividad(idEjercicio, idActividad);
        }

        public Ejercicio GetEjercicio(string nombre)
        {
            return admRutinas.GetEjercicio(nombre);
        }


        

        public void EliminaActividad(int idActividad)
        {
            admRutinas.EliminaActividad(idActividad);
        }

        public void EliminaRelacionEjercicioActividad(int idEjercicio, int idActividad)
        {
            admRutinas.EliminaRelacionEjercicioActividad(idEjercicio, idActividad);
        }


        public void EliminaRelacionActividadPrograma(int idActividad, int idPrograma)
        {
            admRutinas.EliminaRelacionEjercicioActividad(idActividad, idPrograma);
        }
    }
}
