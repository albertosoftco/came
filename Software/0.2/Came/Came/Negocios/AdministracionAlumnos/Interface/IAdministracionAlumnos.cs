using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;

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
         void EliminaAlumno(int idAlumno);

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
         IEnumerable<Alumno> GetAlumnos();
    }
}
