﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;

namespace Came.Modelo.Fachada
{
    class FachadaModelo : IModelo
    {
        /// <summary>
        /// 
        /// </summary>
        private Entidades modelo;
        /// <summary>
        /// 
        /// </summary>
        public FachadaModelo()
        {
            modelo = new Entidades();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Entidades GetModelo()
        {
            return modelo;
        }
        /// <summary>
        /// 
        /// </summary>
        public void SalvaCambios()
        {
            modelo.SaveChanges();
        }

        public System.Data.Entity.DbSet<Actividad> GetActividades()
        {
            return modelo.Actividad;
        }

        public System.Data.Entity.DbSet<Alergia> GetAlergias()
        {
            return modelo.Alergia;
        }

        public System.Data.Entity.DbSet<Alumno> GetAlumnos()
        {
            return modelo.Alumno;
        }

        public System.Data.Entity.DbSet<Diagnostico> GetDiagnosticos()
        {
            return modelo.Diagnostico;
        }

        public System.Data.Entity.DbSet<Discapacidad> GetDiscapacidades()
        {
            return modelo.Discapacidad;
        }

        public System.Data.Entity.DbSet<Ejercicio> GetEjercicios()
        {
            return modelo.Ejercicio;
        }

        public System.Data.Entity.DbSet<Horario> GetHorarios()
        {
            return modelo.Horario;
        }

        public System.Data.Entity.DbSet<Factor> GetFactores()
        {
            return modelo.Factor;
        }

        public System.Data.Entity.DbSet<Grupo> GetGrupos()
        {
            return modelo.Grupo;
        }

        public System.Data.Entity.DbSet<Maestro> GetMaestros()
        {
            return modelo.Maestro;
        }

        public System.Data.Entity.DbSet<Medicamento> GetMedicamentos()
        {
            return modelo.Medicamento;
        }

        public System.Data.Entity.DbSet<Programa> GetProgramas()
        {
            return modelo.Programa;
        }

        public System.Data.Entity.DbSet<Rutina> GetRutinas()
        {
            return modelo.Rutina;
        }

        public System.Data.Entity.DbSet<Tutor> GetTutores()
        {
            return modelo.Tutor;
        }

        public System.Data.Entity.DbSet<Usuario> GetUsuarios()
        {
            return modelo.Usuario;
        }

        public IEnumerable<Ejercicio> GetEjerciciosActividad(int idActividad)
        {
            IEnumerable<Actividad_Ejercicio> actividades = modelo.Actividad_Ejercicio.Where(i => i.Actividad.ID == idActividad);
            IList<Ejercicio> ej = new List<Ejercicio>();
            foreach (Actividad_Ejercicio ae in actividades)
            {
                ej.Add(ae.Ejercicio);
            }
            return ej.AsEnumerable();
        }

        public IEnumerable<Alumno> GetAlumnosGrupo(int idGrupo)
        {
            IEnumerable<Grupo_Alumno> gr = modelo.Grupo_Alumno.Where(i => i.Grupo.ID == idGrupo);
            IList<Alumno> al = new List<Alumno>();
            foreach (Grupo_Alumno ga in gr)
            {
                al.Add(ga.Alumno);
            }
            return al.AsEnumerable();
        }

        public IEnumerable<Alergia> GetAlergiasAlumno(int idAlumno)
        {
            IEnumerable<Alumno_Alergia> aa = modelo.Alumno_Alergia.Where(i => i.Alumno.ID == idAlumno);
            IList<Alergia> al = new List<Alergia>();
            foreach (Alumno_Alergia x in aa)
            {
                al.Add(x.Alergia);
            }
            return al;
        }

        public IEnumerable<Medicamento> GetMedicamentosAlumno(int idAlumno)
        {
            IEnumerable<Alumno_Medicamento> med = modelo.Alumno_Medicamento.Where(i => i.Alumno.ID == idAlumno);
            IList<Medicamento> m = new List<Medicamento>();
            foreach (Alumno_Medicamento am in med)
            {
                m.Add(am.Medicamento);
            }
            return m.AsEnumerable();
        }

        public IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico)
        {
            IEnumerable<Diagnostico_Discapacidad> ie = modelo.Diagnostico_Discapacidad.Where(i => i.Diagnostico.ID == idDiagnostico);
            IList<Discapacidad> li = new List<Discapacidad>();
            foreach (Diagnostico_Discapacidad dd in ie)
            {
                li.Add(dd.Discapacidad);
            }
            return li.AsEnumerable();
        }

        public IEnumerable<Factor> GetfactoresDiscapacidad(int idDiscapacidad)
        {
            IEnumerable<Discapacidad_Factor> df = modelo.Discapacidad_Factor.Where(i => i.Discapacidad.ID == idDiscapacidad);
            IList<Factor> li = new List<Factor>();
            foreach (Discapacidad_Factor d in df)
            {
                li.Add(d.Factor);
            }
            return li.AsEnumerable();
        }

        public IEnumerable<Grupo> GetGruposMaestro(int idMaestro)
        {
            IEnumerable<Maestro_Grupo> ie = modelo.Maestro_Grupo.Where(i => i.Maestro.ID == idMaestro);
            IList<Grupo> grupos = new List<Grupo>();
            foreach (Maestro_Grupo mg in ie)
            {
                grupos.Add(mg.Grupo);
            }
            return grupos.AsEnumerable();
        }

        public IEnumerable<Actividad> GetActividadesPrograma(int idPrograma)
        {
            IEnumerable<Programa_Actividad> ie = modelo.Programa_Actividad.Where(i => i.Programa.ID == idPrograma);
            IList<Actividad> actividades = new List<Actividad>();
            foreach (Programa_Actividad pa in ie)
            {
                actividades.Add(pa.Actividad);
            }
            return actividades.AsEnumerable();
        }

        public IEnumerable<Programa> GetProgramasRutina(int idRutina)
        {
            IEnumerable<Rutina_Programa> ie = modelo.Rutina_Programa.Where(i => i.Rutina.ID == idRutina);
            IList<Programa> programas = new List<Programa>();
            foreach (Rutina_Programa rp in ie)
            {
                programas.Add(rp.Programa);
            }
            return programas.AsEnumerable();
        }

        public Actividad GetActividad(int id)
        {
            return modelo.Actividad.Single(i => i.ID == id);

        }

        public Alergia GetAlergia(int id)
        {
            return modelo.Alergia.Single(i => i.ID == id);
        }

        public Alumno GetAlumno(int id)
        {
            return modelo.Alumno.Single(i => i.ID == id);
        }

        public Diagnostico GetDiagnostico(int id)
        {
            return modelo.Diagnostico.Single(i => i.ID == id);
        }

        public Discapacidad GetDiscapacidad(int id)
        {
            return modelo.Discapacidad.Single(i => i.ID == id);
        }

        public Ejercicio GetEjercicio(int id)
        {
            return modelo.Ejercicio.Single(i => i.ID == id);
        }

        public Factor GetFactor(int id)
        {
            return modelo.Factor.Single(i => i.ID == id);
        }

        public Grupo GetGrupo(int id)
        {
            return modelo.Grupo.Single(i => i.ID == id);
        }

        public Maestro GetMaestro(int id)
        {
            return modelo.Maestro.Single(i => i.ID == id);
        }

        public Medicamento GetMedicamento(int id)
        {
            return modelo.Medicamento.Single(i => i.ID == id);
        }

        public Programa GetPrograma(int id)
        {
            return modelo.Programa.Single(i => i.ID == id);
        }

        public Rutina GetRutina(int id)
        {
            return modelo.Rutina.Single(i => i.ID == id);
        }

        public Tutor GetTutor(int id)
        {
            return modelo.Tutor.Single(i => i.ID == id);
        }

        public Usuario GetUsuario(int id)
        {
            return modelo.Usuario.Single(i => i.ID == id);
        }

        public Horario GetHorario(int id)
        {
            return modelo.Horario.Single(i => i.ID == id);
        }

        public static IModelo GetInstance()
        {
            IModelo modelo = new FachadaModelo();
            return modelo;
        }

    }
}
