using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Came.Modelo.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModelo
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Entidades GetModelo();
        /// <summary>
        /// 
        /// </summary>
        void SalvaCambios();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Actividad> GetActividades();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Alergia> GetAlergias();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Alumno> GetAlumnos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Diagnostico> GetDiagnosticos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Discapacidad> GetDiscapacidades();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Ejercicio> GetEjercicios();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Horario> GetHorarios();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Factor> GetFactores();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Grupo> GetGrupos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Maestro> GetMaestros();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Medicamento> GetMedicamentos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Programa> GetProgramas();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Rutina> GetRutinas();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Tutor> GetTutores();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DbSet<Usuario> GetUsuarios();


        // metodos para obtener todas las relaciones 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActividad"></param>
        /// <returns></returns>
        IEnumerable<Ejercicio> GetEjerciciosActividad(int idActividad);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        IEnumerable<Alumno> GetAlumnosGrupo(int idGrupo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        IEnumerable<Alergia> GetAlergiasAlumno(int idAlumno);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        IEnumerable<Medicamento> GetMedicamentosAlumno(int idAlumno);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiagnostico"></param>
        /// <returns></returns>
        IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <returns></returns>
        IEnumerable<Factor> GetfactoresDiscapacidad(int idDiscapacidad);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMaestro"></param>
        /// <returns></returns>
        IEnumerable<Grupo> GetGruposMaestro(int idMaestro);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <returns></returns>
        IEnumerable<Actividad> GetActividadesPrograma(int idPrograma);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRutina"></param>
        /// <returns></returns>
        IEnumerable<Programa> GetProgramasRutina(int idRutina);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Actividad GetActividad(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Alergia GetAlergia(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Alumno GetAlumno(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Diagnostico GetDiagnostico(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Discapacidad GetDiscapacidad(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Ejercicio GetEjercicio(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Factor GetFactor(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Grupo GetGrupo(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Maestro GetMaestro(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Medicamento GetMedicamento(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Programa GetPrograma(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Rutina GetRutina(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tutor GetTutor(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetUsuario(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Horario GetHorario(int id);    


    }
}
