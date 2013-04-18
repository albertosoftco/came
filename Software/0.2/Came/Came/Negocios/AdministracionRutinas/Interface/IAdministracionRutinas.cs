using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using Came.Modelo.Interface;

namespace Came.Negocios.AdministracionRutinas.Interface
{
    interface IAdministracionRutinas
    {
        void AsignaRutina(int idAlumno, int idRutina);

        void AsignaProgramasRutina(IEnumerable<Programa> programas, int idPrograma);

        void AsignaActividadesPrograma(IEnumerable<Actividad> actividades, int idActividad);

        void AsignaActividadPrograma(int idActividad, int idPrograma);

        void AsignaEjercicioActividad(int idEjercicio, int idActividad);

        void AsignaProgramaRutina(int idPrograma, int idActividad);

        void AgregaRutina(Rutina rutina);

        void AgregaPrograma(Programa programa);

        void AgregaActividad(Actividad actividad);

        void AgregaEjercicio(Ejercicio ejercicio);

        void ActualizaPrograma(Programa programa);

        void ActualizaActividad(Actividad actividad);

        void ActualizaEjercicio(Ejercicio ejercicio);

        void ActualizaRutina(Rutina rutina);

        void EliminaActividad(int idActividad);

        void EliminaRutina(int idRutina,bool borraTodo);

        Rutina GetRutina(int id);

        IEnumerable<Programa> GetProgramasRutina(int idRutina);

        Actividad GetActividad(int idActividad);

        Actividad GetActividad(string nombre);

        IEnumerable<Actividad> GetActividadesPrograma(int idPrograma);

        Ejercicio GetEjercicio(int idActividad);

        Ejercicio GetEjercicio(string nombre);

        IEnumerable<Ejercicio> GetEjerciciosActividad(int idActividad);

        IEnumerable<Rutina> GetRutinas();

        IEnumerable<Horario> GetHorarios();

        IEnumerable<Maestro> GetMaestros();

        Maestro GetMaestro(int id);

        IModelo GetModelo();

        Programa GetPrograma(string nombre);

        IEnumerable<Programa> GetProgramas();

        IEnumerable<Actividad> GetActividades();

        Rutina GetRutina(string nombre);

        void EliminaPrograma(int idPrograma);

        void EliminaRelacionEjercicioActividad(int idEjercicio, int idActividad);

        void EliminaRelacionActividadPrograma(int idActividad, int idPrograma);
    }
}
