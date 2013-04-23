using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.Excepciones;
using Came.Negocios.AdministracionDiagnosticos.Interface;
using Came.Negocios.AdministracionGrupos.Interface;
using Came.Negocios.AdministracionRutinas.Interface;
using Came.Negocios.AdministracionRutinas.Fachada;
using Came.Negocios.AdministracionDiagnosticos.Fachada;
using Came.Negocios.AdministracionGrupos.Fachada;
using System.Data.Entity;

namespace Came.Negocios.AdministracionAlumnos
{
    class AdministracionAlumnos
    {

        /// <summary>
        /// interface del modelo
        /// </summary>
        private IModelo modelo;

        /// <summary>
        /// interface del subsistema administracion de diagnosticos
        /// </summary>
        private IAdministracionDiagnosticos diagnosticos;

        /// <summary>
        /// interface de subsistema administracion de grupos
        /// </summary>
        private IAdministracionGrupos grupos;

        /// <summary>
        /// interface de subsistema administracion de rutinas
        /// </summary>
        public IAdministracionRutinas rutinas;

        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="modelo"></param>
        public AdministracionAlumnos(IModelo modelo)
        {
            //inicializa cada subsistema
            this.modelo = modelo;
            this.diagnosticos = new FachadaAdministracionDiagnosticos(modelo);
            this.rutinas = new FachadaAdministracionRutinas(modelo);
            this.grupos = new FachadaAdministracionGrupos(modelo);
        }

        /// <summary>
        /// agrega un alumno a la bd 
        /// </summary>
        /// <param name="alumno"></param>
        public void AgregaAlumno(Alumno alumno)
        {
            var al = modelo.GetAlumnos().Where(i => i.CURP.Equals(alumno.CURP)).SingleOrDefault();
            if (al == null)
            {
                modelo.GetAlumnos().Add(alumno);
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionAlumnosException("El alumno ya existe");
            }
        }


        /// <summary>
        /// actualiza un alumno en la bd
        /// </summary>
        /// <param name="alumno"></param>
        public void ActualizaAlumno(Alumno alumno)
        {
            var al = modelo.GetAlumnos().Where(i => i.CURP.Equals(alumno.CURP)).SingleOrDefault();
            if (al == null)
                throw new AdministracionAlumnosException("El alumno no existe");
            //actualiza el alumno
            al.Nombre = alumno.Nombre;
            al.Direccion = alumno.Direccion;
            al.IdTutor = alumno.IdTutor;
            al.FechaNacimiento = alumno.FechaNacimiento;
            al.FechaRegistro = alumno.FechaRegistro;
            al.CURP = alumno.CURP;
            al.GradoAcademico = alumno.GradoAcademico;
            al.TallaUniforme = alumno.TallaUniforme;
            al.IdDiagnostico = alumno.IdDiagnostico;
            al.IdGrupo = alumno.IdGrupo;
            al.IdRutina = alumno.IdRutina;

            //actualiza su lista de relaciones con alergias
            var rAlergias = modelo.GetRelacionesAlumnoAlergia().Where(i => i.IdAlumno.Equals(al.ID));
            var rMedicamentos = modelo.GetRelacionesAlumnoMedicamento().Where(i => i.IdAlumno.Equals(al.ID));

            //compara las relaciones existenetes con las nuevas 
            if (rAlergias.Count() > 0)
            {
                foreach (Alumno_Alergia aa in rAlergias)
                {
                    modelo.GetRelacionesAlumnoAlergia().Remove(aa);
                }
            }
            //si el alumno tiene relaciones con alergias 
            if (alumno.Alumno_Alergia.Count > 0)
            {
                foreach (Alumno_Alergia aa in alumno.Alumno_Alergia)
                {
                    if (modelo.GetRelacionesAlumnoAlergia().Where(i => i.IdAlergia.Equals(aa.IdAlergia) && i.IdAlumno.Equals(aa.IdAlumno)).SingleOrDefault() == null)
                    {
                        modelo.GetRelacionesAlumnoAlergia().Add(aa);
                    }
                }
            }
            //si tiene viejas relaciones
            if (rMedicamentos.Count() > 0)
            {
                foreach (Alumno_Medicamento am in rMedicamentos)
                {
                    modelo.GetRelacionesAlumnoMedicamento().Remove(am);
                }
            }
            //si el alumno las tiene
            if (alumno.Alumno_Medicamento.Count > 0)
            {
                foreach (Alumno_Medicamento am in alumno.Alumno_Medicamento)
                {
                    if (modelo.GetRelacionesAlumnoMedicamento().Where(i => i.IdAlumno.Equals(am.IdAlumno) && i.IdMedicamento.Equals(am.IdMedicamento)).SingleOrDefault() == null)
                    {
                        modelo.GetRelacionesAlumnoMedicamento().Add(am);
                    }

                }
            }
            //guarda los cambios
            modelo.SalvaCambios();
        }


        /// <summary>
        /// elimina un alumno de la bd
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <param name="todo"></param>
        public void EliminaAlumno(int idAlumno, bool todo)
        {


            //no borra todos los datos, solo el alumno
            //verifica que el alumno exista
            if (modelo.GetAlumnos().Where(i => i.ID.Equals(idAlumno)).SingleOrDefault() != null)
            {
                //procede a eliminarlo...
                //empieza con las relaciones 
                var alumno = modelo.GetAlumno(idAlumno);
                if (alumno.Alumno_Alergia.Count > 0)
                {
                    foreach (Alumno_Alergia aa in alumno.Alumno_Alergia)
                    {
                        //elimina la relacion
                        modelo.GetRelacionesAlumnoAlergia().Remove(aa);
                    }
                }
                //procede con los medicamentos
                if (alumno.Alumno_Medicamento.Count > 0)
                {
                    foreach (Alumno_Medicamento am in alumno.Alumno_Medicamento)
                    {
                        modelo.GetRelacionesAlumnoMedicamento().Remove(am);
                    }
                }
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionAlumnosException("El alumno no existe");
            }



        }

        /// <summary>
        /// obtiene un alumno por medio de su curp
        /// </summary>
        /// <param name="curp"></param>
        /// <returns></returns>
        public Alumno GetAlumno(string curp)
        {
            return modelo.GetAlumnos().Where(i => i.CURP.Equals(curp)).SingleOrDefault();
        }


        /// <summary>
        /// obtiene un alumno por medio de su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Alumno GetAlumno(int id)
        {
            return modelo.GetAlumnos().Where(i => i.ID.Equals(id)).SingleOrDefault();
        }


        /// <summary>
        /// obtiene un IEnumerable<T>Alumno</T>"/>
        /// </summary>
        /// <returns></returns>
        public DbSet<Alumno> GetAlumnos()
        {
            return modelo.GetAlumnos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Grupo> GetGrupos()
        {
            return modelo.GetGrupos();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Diagnostico>GetDiagnosticos()
        {
            return modelo.GetDiagnosticos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Rutina> GetRutinas()
        {
            return modelo.GetRutinas();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tutor"></param>
        public void AgregaTutor(Tutor tutor)
        {
            var t = modelo.GetTutores().Where(i=>i.Nombre.Equals(tutor.Nombre)).SingleOrDefault();
            if(t != null)
                throw new AdministracionAlumnosException("El alumno ya existe");
            modelo.GetTutores().Add(tutor);
            modelo.SalvaCambios();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Tutor>GetTutores()
        {
            return modelo.GetTutores();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Medicamento> GetMedicamentos()
        {
            return modelo.GetMedicamentos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Alergia> GetAlergias()
        {
            return modelo.GetAlergias();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IModelo GetModelo()
        {
            return modelo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Alumno_Medicamento>GetRelacionesAlumnoMedicamento()
        {
            return modelo.GetRelacionesAlumnoMedicamento();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Alumno_Alergia>GetRelacionesAlumnoAlergia()
        {
            return modelo.GetRelacionesAlumnoAlergia();
        }
    }
}
