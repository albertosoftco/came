using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionAlumnos.Interface;
using Came.Modelo.Interface;

namespace Came.Negocios.AdministracionAlumnos.Fachada
{
    class FachadaAdministracionAlumnos : IAdministracionAlumnos
    {
        /// <summary>
        /// 
        /// </summary>
        private AdministracionAlumnos alumnos;

        /// <summary>
        /// constructor de la clase 
        /// </summary>
        /// <param name="modelo"></param>
        public FachadaAdministracionAlumnos(IModelo modelo)
        {
            alumnos = new AdministracionAlumnos(modelo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        public void AgregaAlumno(Modelo.Alumno alumno)
        {
            alumnos.AgregaAlumno(alumno);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        public void ActualizaAlumno(Modelo.Alumno alumno)
        {
            alumnos.ActualizaAlumno(alumno);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <param name="todo"></param>
        public void EliminaAlumno(int idAlumno,bool todo)
        {
            alumnos.EliminaAlumno(idAlumno,todo);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public Modelo.Alumno GetAlumno(int idAlumno)
        {
            return alumnos.GetAlumno(idAlumno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curp"></param>
        /// <returns></returns>
        public Modelo.Alumno GetAlumno(string curp)
        {
            return alumnos.GetAlumno(curp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Modelo.Alumno> GetAlumnos()
        {
            return alumnos.GetAlumnos();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Modelo.Grupo> GetGrupos()
        {
            return alumnos.GetGrupos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Modelo.Diagnostico> GetDiagnosticos()
        {
            return alumnos.GetDiagnosticos();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Modelo.Rutina> GetRutinas()
        {
            return alumnos.GetRutinas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tutor"></param>
        public void AgregaTutor(Modelo.Tutor tutor)
        {
            alumnos.AgregaTutor(tutor);
        }

        public void ActualizaTutor(Modelo.Tutor tutor)
        {
            throw new NotImplementedException();
        }

        public void EliminaTutor(int id)
        {
            throw new NotImplementedException();
        }


        System.Data.Entity.DbSet<Modelo.Alumno> IAdministracionAlumnos.GetAlumnos()
        {
            return alumnos.GetAlumnos();
        }

        System.Data.Entity.DbSet<Modelo.Grupo> IAdministracionAlumnos.GetGrupos()
        {
            return alumnos.GetGrupos();
        }

        System.Data.Entity.DbSet<Modelo.Diagnostico> IAdministracionAlumnos.GetDiagnosticos()
        {
            return alumnos.GetDiagnosticos();
        }

        System.Data.Entity.DbSet<Modelo.Rutina> IAdministracionAlumnos.GetRutinas()
        {
            return alumnos.GetRutinas();
        }

        public System.Data.Entity.DbSet<Modelo.Alergia> GetAlergias()
        {
            return alumnos.GetAlergias();
        }

        public System.Data.Entity.DbSet<Modelo.Medicamento> GetMedicamentos()
        {
            return alumnos.GetMedicamentos();
        }

        public System.Data.Entity.DbSet<Modelo.Tutor> GetTutores()
        {
            return alumnos.GetTutores();
        }

        public IModelo GetModelo()
        {
            return alumnos.GetModelo();

        }


        public System.Data.Entity.DbSet<Modelo.Alumno_Medicamento> GetRelacionesAlumnoMedicamento()
        {
            return alumnos.GetRelacionesAlumnoMedicamento();
        }

        public System.Data.Entity.DbSet<Modelo.Alumno_Alergia> GetRelacionesAlumnoAlergia()
        {
            return alumnos.GetRelacionesAlumnoAlergia();
        }
    }
}
