using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using Came.Modelo.Interface;
namespace Came.Modelo.Fachada
{
    class FachadaModelo : IModelo
    {
        private Entidades modelo;

        public FachadaModelo()
        {
            modelo = new Entidades();  
           
        }


        public Entidades GetModelo()
        {
            return this.modelo;
        }

        public void SalvaCambios()
        {
            this.modelo.SaveChanges();
        }

        public IQueryable<Actividad> GetActividades()
        {
            return modelo.Actividad.AsQueryable<Actividad>();
        }

        public IQueryable<Alergia> GetAlergias()
        {
            return modelo.Alergia.AsQueryable<Alergia>();
        }

        public IQueryable<Alumno> GetAlumnos()
        {
            return modelo.Alumno.AsQueryable<Alumno>();
        }

        public IQueryable<Diagnostico> GetDiagnosticos()
        {
            return modelo.Diagnostico.AsQueryable<Diagnostico>();
        }

        public IQueryable<Discapacidad> GetDiscapacidades()
        {
            return modelo.Discapacidad.AsQueryable<Discapacidad>();
        }

        public IQueryable<Ejercicio> GetEjercicios()
        {
            return modelo.Ejercicio.AsQueryable<Ejercicio>();
        }

        public IQueryable<Factor> GetFactores()
        {
            return modelo.Factor.AsQueryable<Factor>();
        }

        public IQueryable<Grupo> GetGrupos()
        {
            return modelo.Grupo.AsQueryable<Grupo>();
        }

        public IQueryable<Maestro> GetMaestros()
        {
            return modelo.Maestro.AsQueryable<Maestro>();
        }

        public IQueryable<Medicamento> GetMedicamentos()
        {
            return modelo.Medicamento.AsQueryable<Medicamento>();
        }

        public IQueryable<Programa> GetProgramas()
        {
            return modelo.Programa.AsQueryable<Programa>();
        }

        public IQueryable<Rutina> GetRutinas()
        {
            return modelo.Rutina.AsQueryable<Rutina>();
        }

        public IQueryable<Tutor> GetTutores()
        {
            return modelo.Tutor.AsQueryable<Tutor>();
        }

        public IQueryable<Usuario> GetUsuarios()
        {
            return modelo.Usuario.AsQueryable<Usuario>();
        }


        public IEnumerable<Ejercicio> GetEjerciciosActividad(int idActividad)
        {
            IQueryable<Actividad_Ejercicio> relaciones = modelo.Actividad_Ejercicio.Where(i => i.Actividad.ID == idActividad);

            IList<Ejercicio> ejercicios = new List<Ejercicio>();
            foreach(Actividad_Ejercicio ae in relaciones)
            {
                Ejercicio ejercicio = ae.Ejercicio;
                ejercicios.Add(ejercicio);
            }
            return ejercicios.AsEnumerable();


        }

        public IEnumerable<Alergia> GetAlergiasAlumno(int idAlumno)
        {
            IQueryable<Alumno_Alergia> relaciones = modelo.Alumno_Alergia.Where(i => i.Alumno.ID == idAlumno);
            IList<Alergia> alergias = new List<Alergia>();
            foreach(Alumno_Alergia a in relaciones)
            {
                Alergia alergia = a.Alergia;
                alergias.Add(alergia);
            }
            return alergias.AsEnumerable();
        }

        public IEnumerable<Medicamento> GetMedicamentosAlumno(int idAlumno)
        {
            IQueryable<Alumno_Medicamento> relaciones = modelo.Alumno_Medicamento.Where(i => i.Alumno.ID == idAlumno);
            IList<Medicamento> medicamentos = new List<Medicamento>();
            foreach(Alumno_Medicamento am in relaciones)
            {
                medicamentos.Add(am.Medicamento);
            }
            return medicamentos.AsEnumerable();
        }

        public IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico)
        {
            IQueryable<Diagnostico_Discapacidad> relaciones = modelo.Diagnostico_Discapacidad.Where(i => i.Diagnostico.ID == idDiagnostico);
            IList<Discapacidad> discapacidades = new List<Discapacidad>();
            foreach(Diagnostico_Discapacidad dd in relaciones)
            {
                discapacidades.Add(dd.Discapacidad);
            }
            return discapacidades.AsEnumerable();
        }

        public IEnumerable<Factor> GetfactoresDiscapacidad(int idDiscapacidad)
        {
            IQueryable<Discapacidad_Factor> relaciones = modelo.Discapacidad_Factor.Where(i => i.Discapacidad.ID == idDiscapacidad);
            IList<Factor> factores = new List<Factor>();
            foreach(Discapacidad_Factor df in relaciones)
            {
                factores.Add(df.Factor);
            }
            return factores.AsEnumerable();

        }

        public IEnumerable<Grupo> GetGruposMaestro(int idMaestro)
        {
            IQueryable<Maestro_Grupo> relaciones = modelo.Maestro_Grupo.Where(i => i.Maestro.ID == idMaestro);
            IList<Grupo> grupos = new List<Grupo>();
            foreach(Maestro_Grupo mg in relaciones)
            {
                grupos.Add(mg.Grupo);
            }
            return grupos.AsEnumerable();
        }

        public IEnumerable<Actividad> GetActividadesPrograma(int idPrograma)
        {
            IQueryable<Programa_Actividad> relaciones = modelo.Programa_Actividad.Where(i => i.Programa.ID == idPrograma);
            IList<Actividad> actividades = new List<Actividad>();
            foreach(Programa_Actividad pa in relaciones)
            {
                actividades.Add(pa.Actividad);
            }
            return actividades.AsEnumerable();
        }

        public IEnumerable<Programa> GetProgramasRutina(int idRutina)
        {
            IQueryable<Rutina_Programa> relaciones = modelo.Rutina_Programa.Where(i => i.Rutina.ID == idRutina);
            IList<Programa> programas = new List<Programa>();
            foreach(Rutina_Programa rp in relaciones)
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
    }
}
