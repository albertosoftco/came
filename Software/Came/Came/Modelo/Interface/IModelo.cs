using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using System.Data.Objects;
using Came.Modelo;

namespace Came.Modelo.Interface
{
    interface IModelo 
    {

        Entidades GetModelo();

        void SalvaCambios();

        IQueryable<Actividad> GetActividades();

        IQueryable<Alergia> GetAlergias();

        IQueryable<Alumno> GetAlumnos();

        IQueryable<Diagnostico> GetDiagnosticos();

        IQueryable<Discapacidad> GetDiscapacidades();

        IQueryable<Ejercicio> GetEjercicios();

        IQueryable<Factor> GetFactores();

        IQueryable<Grupo> GetGrupos();

        IQueryable<Maestro> GetMaestros();

        IQueryable<Medicamento> GetMedicamentos();

        IQueryable<Programa> GetProgramas();

        IQueryable<Rutina> GetRutinas();

        IQueryable<Tutor> GetTutores();

        IQueryable<Usuario> GetUsuarios();


        // metodos para obtener todas las relaciones 
        IEnumerable<Ejercicio> GetEjerciciosActividad(int idActividad);

        IEnumerable<Alumno> GetAlumnosGrupo(int idGrupo);

        IEnumerable<Alergia> GetAlergiasAlumno(int idAlumno);

        IEnumerable<Medicamento> GetMedicamentosAlumno(int idAlumno);

        IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico);

        IEnumerable<Factor> GetfactoresDiscapacidad(int idDiscapacidad);

        IEnumerable<Grupo> GetGruposMaestro(int idMaestro);

        IEnumerable<Actividad> GetActividadesPrograma(int idPrograma);

        IEnumerable<Programa> GetProgramasRutina(int idRutina);

        Actividad GetActividad(int id);

        Alergia GetAlergia(int id);

        Alumno GetAlumno(int id);

        Diagnostico GetDiagnostico(int id);

        Discapacidad GetDiscapacidad(int id);

        Ejercicio GetEjercicio(int id);

        Factor GetFactor(int id);

        Grupo GetGrupo(int id);

        Maestro GetMaestro(int id);

        Medicamento GetMedicamento(int id);

        Programa GetPrograma(int id);

        Rutina GetRutina(int id);

        Tutor GetTutor(int id);

        Usuario GetUsuario(int id);

        Horario GetHorario(int id);    

    }
}
