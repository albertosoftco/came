using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Came.Modelo.Interface
{
    interface IModelo
    {
        Entidades GetModelo();

        void SalvaCambios();

        DbSet<Actividad> GetActividades();

        DbSet<Alergia> GetAlergias();

        DbSet<Alumno> GetAlumnos();

        DbSet<Diagnostico> GetDiagnosticos();

        DbSet<Discapacidad> GetDiscapacidades();

        DbSet<Ejercicio> GetEjercicios();

        DbSet<Horario> GetHorarios();

        DbSet<Factor> GetFactores();

        DbSet<Grupo> GetGrupos();

        DbSet<Maestro> GetMaestros();

        DbSet<Medicamento> GetMedicamentos();

        DbSet<Programa> GetProgramas();

        DbSet<Rutina> GetRutinas();

        DbSet<Tutor> GetTutores();

        DbSet<Usuario> GetUsuarios();


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
