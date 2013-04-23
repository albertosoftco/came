using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using System.Data.Entity;
using Came.Modelo.Interface;

namespace Came.Negocios.AdministracionAlumnos.Interface
{
    interface IAdministracionAlumnos
    {
        /// <summary>
        /// agrega un alumno
        /// </summary>
        /// <param name="alumno"></param>
         void AgregaAlumno(Alumno alumno);

        /// <summary>
        /// actualiza un alumno
        /// </summary>
        /// <param name="alumno"></param>
         void ActualizaAlumno(Alumno alumno);

        /// <summary>
        /// elimina un alumno
        /// </summary>
        /// <param name="idAlumno"></param>
         void EliminaAlumno(int idAlumno, bool todo);

        /// <summary>
        /// obtiene un alumno
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
         Alumno GetAlumno(int idAlumno);

        /// <summary>
        /// obtiene un alumno
        /// </summary>
        /// <param name="curp"></param>
        /// <returns></returns>
         Alumno GetAlumno(string curp);

        /// <summary>
        /// obtiene todos los alumno
        /// </summary>
        /// <returns></returns>
         DbSet<Alumno> GetAlumnos();

        /// <summary>
        /// obtiene todos los grupos
        /// </summary>
        /// <returns></returns>
         DbSet<Grupo> GetGrupos();

        /// <summary>
        /// obtiene todos los diagnosticos 
        /// </summary>
        /// <returns></returns>
         DbSet<Diagnostico> GetDiagnosticos();

        /// <summary>
        /// obtiene todas las rutinas 
        /// </summary>
        /// <returns></returns>
         DbSet<Rutina> GetRutinas();

        /// <summary>
        /// agrega un tutor a la bd
        /// </summary>
        /// <param name="tutor"></param>
         void AgregaTutor(Tutor tutor);

        /// <summary>
        /// actualiza un tutor 
        /// </summary>
        /// <param name="tutor"></param>
        void ActualizaTutor(Tutor tutor);

        /// <summary>
        /// elimina un tutor
        /// </summary>
        /// <param name="id"></param>
        void EliminaTutor(int id);


        /// <summary>
        /// obtiene todas las alergias
        /// </summary>
        /// <returns></returns>
        DbSet<Alergia> GetAlergias();

        /// <summary>
        /// obtiene todos los medicamentos
        /// </summary>
        /// <returns></returns>
        DbSet<Medicamento> GetMedicamentos();

        /// <summary>
        /// obtiene todos los tutores
        /// </summary>
        /// <returns></returns>
        DbSet<Tutor> GetTutores();

        /// <summary>
        /// obtiene la interface del modelo
        /// </summary>
        /// <returns></returns>
        IModelo GetModelo();

        /// <summary>
        /// obtiene la lista de relaciones
        /// </summary>
        /// <returns></returns>
        DbSet<Alumno_Medicamento> GetRelacionesAlumnoMedicamento();

        /// <summary>
        /// obtiene la lista de relaciones
        /// </summary>
        /// <returns></returns>
        DbSet<Alumno_Alergia> GetRelacionesAlumnoAlergia();

    }
}
